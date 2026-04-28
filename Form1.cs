using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Symove
{
    public partial class Form1 : Form
    {
        private readonly string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Symove_Log.txt");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
        }

        #region PESTAÑA 1: CREAR ENLACES

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Selecciona una carpeta para mover y enlazar";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    if (!lstOrigen.Items.Contains(fbd.SelectedPath))
                        lstOrigen.Items.Add(fbd.SelectedPath);
                }
            }
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Selecciona uno o más archivos";
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in ofd.FileNames)
                    {
                        if (!lstOrigen.Items.Contains(file))
                            lstOrigen.Items.Add(file);
                    }
                }
            }
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            lstOrigen.Items.Clear();
        }

        private void btnBrowseDestino_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Selecciona la carpeta destino raíz";
                if (fbd.ShowDialog() == DialogResult.OK) txtDestino.Text = fbd.SelectedPath;
            }
        }

        private async void btnCreateLink_Click(object sender, EventArgs e)
        {
            string destinoBase = txtDestino.Text.Trim();

            if (lstOrigen.Items.Count == 0 || string.IsNullOrWhiteSpace(destinoBase))
            {
                MostrarMensaje("Selecciona rutas de origen y destino.", true);
                return;
            }

            if (!Directory.Exists(destinoBase))
            {
                MostrarMensaje("El destino raíz no existe.", true);
                return;
            }

            SetUIState(false, "Procesando elementos...");

            int exitosos = 0;
            int fallidos = 0;

            try
            {
                EscribirLog("--- INICIO DE BATCH (CREACIÓN) ---");

                foreach (string origen in lstOrigen.Items)
                {
                    try
                    {
                        if (!File.Exists(origen) && !Directory.Exists(origen))
                        {
                            EscribirLog($"[ERROR] No se encontró: {origen}");
                            fallidos++;
                            continue;
                        }

                        bool isDirectory = File.GetAttributes(origen).HasFlag(FileAttributes.Directory);
                        string nombreItem = Path.GetFileName(origen.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
                        string destinoFinal = Path.Combine(destinoBase, nombreItem);

                        if (origen.Equals(destinoFinal, StringComparison.OrdinalIgnoreCase))
                        {
                            EscribirLog($"[OMITIDO] Origen y destino son iguales: {origen}");
                            fallidos++;
                            continue;
                        }

                        lblStatus.Text = $"Moviendo '{nombreItem}'...";

                        bool movidoExitoso = false;

                        if (isDirectory)
                        {
                            if (!Directory.Exists(destinoFinal)) Directory.CreateDirectory(destinoFinal);
                            movidoExitoso = await Task.Run(() => EjecutarRobocopy(origen, destinoFinal));

                            // Eliminar la carpeta original tras Robocopy para poder crear el enlace
                            if (Directory.Exists(origen))
                            {
                                try { Directory.Delete(origen, true); } catch { }
                            }
                        }
                        else
                        {
                            string destDir = Path.GetDirectoryName(destinoFinal);
                            if (!Directory.Exists(destDir)) Directory.CreateDirectory(destDir!);

                            movidoExitoso = await Task.Run(() => MoverArchivoSeguro(origen, destinoFinal));
                        }

                        if (!movidoExitoso)
                        {
                            EscribirLog($"[ERROR] Al mover: {origen} -> {destinoFinal}");
                            fallidos++;
                            continue;
                        }

                        lblStatus.Text = $"Enlazando '{nombreItem}'...";
                        bool linkCreado = CrearEnlaceSimbolico(origen, destinoFinal, isDirectory);

                        if (linkCreado)
                        {
                            EscribirLog($"[ÉXITO] Movido y enlazado: {origen} -> {destinoFinal}");
                            exitosos++;
                        }
                        else
                        {
                            EscribirLog($"[ERROR] Al crear MKLINK (¿Faltan permisos Admin?): {origen}");
                            fallidos++;
                        }
                    }
                    catch (Exception ex)
                    {
                        EscribirLog($"[EXCEPCIÓN] {origen}: {ex.Message}");
                        fallidos++;
                    }
                }

                EscribirLog($"--- FIN DE BATCH (Éxito: {exitosos}, Fallos: {fallidos}) ---");

                if (fallidos == 0)
                {
                    lblStatus.ForeColor = Color.LightGreen;
                    lblStatus.Text = $"¡Listo! {exitosos} elementos procesados.";
                    MessageBox.Show($"Operación completada con éxito.\n{exitosos} elementos procesados.\n\nRevisa Symove_Log.txt para más detalles.", "Symove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstOrigen.Items.Clear(); // Limpiamos si todo salió bien
                }
                else
                {
                    MostrarMensaje($"Terminado con errores. Éxitos: {exitosos}, Fallos: {fallidos}. Revisa el Log.", true);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error general: {ex.Message}", true);
            }
            finally
            {
                SetUIState(true, lblStatus.Text);
            }
        }

        #endregion

        #region PESTAÑA 2: GESTIÓN Y ESCANEO DE ENLACES

        private void ConfigurarDataGridView()
        {
            dgvEnlaces.ColumnCount = 4;
            dgvEnlaces.Columns[0].Name = "Origen (Enlace)";
            dgvEnlaces.Columns[1].Name = "Destino Real";
            dgvEnlaces.Columns[2].Name = "Estado";
            dgvEnlaces.Columns[3].Name = "Tipo";

            dgvEnlaces.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEnlaces.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEnlaces.Columns[2].Width = 80;
            dgvEnlaces.Columns[3].Width = 70;

            // Estilos oscuros para el DataGridView
            dgvEnlaces.EnableHeadersVisualStyles = false;
            dgvEnlaces.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvEnlaces.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEnlaces.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgvEnlaces.DefaultCellStyle.ForeColor = Color.White;
            dgvEnlaces.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgvEnlaces.RowHeadersVisible = false;
            dgvEnlaces.AllowUserToAddRows = false;
            dgvEnlaces.ReadOnly = true;
            dgvEnlaces.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnBrowseScan_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Selecciona la carpeta base a escanear";
                if (fbd.ShowDialog() == DialogResult.OK) txtScanPath.Text = fbd.SelectedPath;
            }
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            string rutaBase = txtScanPath.Text.Trim();
            if (!Directory.Exists(rutaBase))
            {
                MostrarMensaje("La ruta a escanear no existe.", true);
                return;
            }

            SetUIState(false, "Escaneando directorios...");
            dgvEnlaces.Rows.Clear();
            bool soloRotos = chkSoloRotos.Checked;

            List<DataGridViewRow> filasEncontradas = new List<DataGridViewRow>();

            await Task.Run(() =>
            {
                BuscarEnlacesRecursivo(rutaBase, filasEncontradas, soloRotos);
            });

            dgvEnlaces.Rows.AddRange(filasEncontradas.ToArray());

            // Colorear estado
            foreach (DataGridViewRow row in dgvEnlaces.Rows)
            {
                if (row.Cells[2].Value.ToString() == "Roto")
                    row.Cells[2].Style.ForeColor = Color.Salmon;
                else
                    row.Cells[2].Style.ForeColor = Color.LightGreen;
            }

            SetUIState(true, $"Escaneo finalizado. {filasEncontradas.Count} enlaces encontrados.");
        }

        private void BuscarEnlacesRecursivo(string ruta, List<DataGridViewRow> filas, bool soloRotos)
        {
            try
            {
                // Buscar en Directorios
                foreach (string dir in Directory.GetDirectories(ruta))
                {
                    try
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        if (di.Attributes.HasFlag(FileAttributes.ReparsePoint))
                        {
                            var target = di.ResolveLinkTarget(true);
                            string targetPath = target?.FullName ?? "Desconocido";
                            bool existeTarget = target != null && Directory.Exists(targetPath);

                            if (!soloRotos || (soloRotos && !existeTarget))
                            {
                                CrearFilaEnlace(filas, dir, targetPath, existeTarget, true);
                            }
                        }
                        else
                        {
                            // Recursividad si no es un enlace (para evitar bucles infinitos)
                            BuscarEnlacesRecursivo(dir, filas, soloRotos);
                        }
                    }
                    catch { /* Ignorar errores de acceso a carpetas específicas */ }
                }

                // Buscar en Archivos
                foreach (string file in Directory.GetFiles(ruta))
                {
                    try
                    {
                        FileInfo fi = new FileInfo(file);
                        if (fi.Attributes.HasFlag(FileAttributes.ReparsePoint))
                        {
                            var target = fi.ResolveLinkTarget(true);
                            string targetPath = target?.FullName ?? "Desconocido";
                            bool existeTarget = target != null && File.Exists(targetPath);

                            if (!soloRotos || (soloRotos && !existeTarget))
                            {
                                CrearFilaEnlace(filas, file, targetPath, existeTarget, false);
                            }
                        }
                    }
                    catch { /* Ignorar errores de acceso */ }
                }
            }
            catch { /* Ignorar error de acceso a la ruta base */ }
        }

        private void CrearFilaEnlace(List<DataGridViewRow> filas, string origen, string destino, bool esValido, bool isDirectorio)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvEnlaces);
            row.Cells[0].Value = origen;
            row.Cells[1].Value = destino;
            row.Cells[2].Value = esValido ? "Válido" : "Roto";
            row.Cells[3].Value = isDirectorio ? "Carpeta" : "Archivo";
            filas.Add(row);
        }

        private async void btnUndo_Click(object sender, EventArgs e)
        {
            if (dgvEnlaces.SelectedRows.Count == 0) return;

            var result = MessageBox.Show(
                $"¿Estás seguro de deshacer {dgvEnlaces.SelectedRows.Count} enlace(s)?\nEsto eliminará el enlace simbólico y moverá el contenido de vuelta a su ubicación original.",
                "Confirmar Reversión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No) return;

            SetUIState(false, "Deshaciendo enlaces...");
            int exitosos = 0;
            int fallidos = 0;

            EscribirLog("--- INICIO DE REVERSIÓN (UNDO) ---");

            foreach (DataGridViewRow row in dgvEnlaces.SelectedRows)
            {
                string origen = row.Cells[0].Value.ToString();
                string destino = row.Cells[1].Value.ToString();
                bool isDir = row.Cells[3].Value.ToString() == "Carpeta";

                lblStatus.Text = $"Restaurando '{Path.GetFileName(origen)}'...";

                try
                {
                    // 1. Validar que el origen sigue siendo un enlace
                    if (!File.Exists(origen) && !Directory.Exists(origen))
                    {
                        EscribirLog($"[ERROR REVERSIÓN] El enlace original ya no existe: {origen}");
                        fallidos++;
                        continue;
                    }

                    // 2. Validar que el destino (los datos reales) exista
                    bool destinoExiste = isDir ? Directory.Exists(destino) : File.Exists(destino);
                    if (!destinoExiste)
                    {
                        EscribirLog($"[ERROR REVERSIÓN] Los datos reales no existen. Imposible restaurar: {destino}");
                        fallidos++;
                        continue;
                    }

                    // 3. Eliminar el enlace simbólico
                    if (isDir) Directory.Delete(origen);
                    else File.Delete(origen);

                    // 4. Mover la data de vuelta al origen
                    bool restaurado = false;
                    if (isDir)
                    {
                        Directory.CreateDirectory(origen);
                        restaurado = await Task.Run(() => EjecutarRobocopy(destino, origen));
                        if (restaurado) Directory.Delete(destino, true);
                    }
                    else
                    {
                        restaurado = await Task.Run(() => MoverArchivoSeguro(destino, origen));
                    }

                    if (restaurado)
                    {
                        EscribirLog($"[ÉXITO REVERSIÓN] Enlace eliminado y restaurado de: {destino} -> {origen}");
                        exitosos++;
                    }
                    else
                    {
                        EscribirLog($"[ERROR REVERSIÓN] Falló al mover los datos de vuelta. Enlace fue borrado. Datos en: {destino}");
                        fallidos++;
                    }
                }
                catch (Exception ex)
                {
                    EscribirLog($"[EXCEPCIÓN REVERSIÓN] {origen}: {ex.Message}");
                    fallidos++;
                }
            }

            EscribirLog($"--- FIN DE REVERSIÓN (Éxito: {exitosos}, Fallos: {fallidos}) ---");
            SetUIState(true, $"Reversión finalizada. Éxitos: {exitosos}, Fallos: {fallidos}.");
            btnScan.PerformClick(); // Refrescar la lista
        }

        #endregion

        #region MÉTODOS AUXILIARES Y LÓGICA CORE

        private void EscribirLog(string mensaje)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(logPath, true))
                {
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    if (mensaje.StartsWith("---"))
                        sw.WriteLine($"\n[{timestamp}] {mensaje}");
                    else
                        sw.WriteLine($"[{timestamp}] {mensaje}");
                }
            }
            catch { /* Ignorar fallos del log */ }
        }

        private bool MoverArchivoSeguro(string origen, string destino)
        {
            try
            {
                if (File.Exists(destino)) File.Delete(destino);
                File.Copy(origen, destino, true);
                File.Delete(origen);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void SetUIState(bool enabled, string status)
        {
            // Pestaña 1
            btnCreateLink.Enabled = enabled;
            btnCreateLink.BackColor = enabled ? Color.FromArgb(0, 122, 204) : Color.FromArgb(50, 50, 50);
            btnAddFolder.Enabled = enabled;
            btnAddFiles.Enabled = enabled;
            btnClearList.Enabled = enabled;
            btnBrowseDestino.Enabled = enabled;
            lstOrigen.Enabled = enabled;
            txtDestino.Enabled = enabled;

            // Pestaña 2
            btnScan.Enabled = enabled;
            btnScan.BackColor = enabled ? Color.FromArgb(0, 122, 204) : Color.FromArgb(50, 50, 50);
            btnBrowseScan.Enabled = enabled;
            btnUndo.Enabled = enabled;
            btnUndo.BackColor = enabled ? Color.FromArgb(180, 60, 60) : Color.FromArgb(50, 50, 50);
            txtScanPath.Enabled = enabled;
            dgvEnlaces.Enabled = enabled;
            chkSoloRotos.Enabled = enabled;

            lblStatus.Text = status;
        }

        private void MostrarMensaje(string texto, bool esError)
        {
            lblStatus.ForeColor = esError ? Color.Salmon : Color.LightGray;
            lblStatus.Text = texto;
            if (esError) MessageBox.Show(texto, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool EjecutarRobocopy(string origen, string destino)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "robocopy.exe",
                Arguments = $"\"{origen}\" \"{destino}\" /E /MOVE /R:1 /W:1",
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            using (Process? p = Process.Start(psi))
            {
                if (p == null) return false;
                p.WaitForExit();
                return p.ExitCode < 8;
            }
        }

        private bool CrearEnlaceSimbolico(string link, string target, bool esCarpeta)
        {
            string args = esCarpeta ? $"/c mklink /D \"{link}\" \"{target}\"" : $"/c mklink \"{link}\" \"{target}\"";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = args,
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            using (Process? p = Process.Start(psi))
            {
                if (p == null) return false;
                p.WaitForExit();
                return p.ExitCode == 0;
            }
        }

        #endregion
    }
}