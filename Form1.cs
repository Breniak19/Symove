using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Symove
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Opcional: Ajustes adicionales de UI al cargar
        }

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
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Symove_Log.txt");

            try
            {
                using (StreamWriter sw = new StreamWriter(logPath, true))
                {
                    sw.WriteLine($"\n[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] --- INICIO DE BATCH ---");

                    foreach (string origen in lstOrigen.Items)
                    {
                        try
                        {
                            if (!File.Exists(origen) && !Directory.Exists(origen))
                            {
                                sw.WriteLine($"[ERROR] No se encontró: {origen}");
                                fallidos++;
                                continue;
                            }

                            bool isDirectory = File.GetAttributes(origen).HasFlag(FileAttributes.Directory);
                            string nombreItem = Path.GetFileName(origen.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
                            string destinoFinal = Path.Combine(destinoBase, nombreItem);

                            if (origen.Equals(destinoFinal, StringComparison.OrdinalIgnoreCase))
                            {
                                sw.WriteLine($"[OMITIDO] Origen y destino son iguales: {origen}");
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
                                sw.WriteLine($"[ERROR] Al mover: {origen} -> {destinoFinal}");
                                fallidos++;
                                continue;
                            }

                            lblStatus.Text = $"Enlazando '{nombreItem}'...";
                            bool linkCreado = CrearEnlaceSimbolico(origen, destinoFinal, isDirectory);

                            if (linkCreado)
                            {
                                sw.WriteLine($"[ÉXITO] Movido y enlazado: {origen} -> {destinoFinal}");
                                exitosos++;
                            }
                            else
                            {
                                sw.WriteLine($"[ERROR] Al crear MKLINK (¿Faltan permisos Admin?): {origen}");
                                fallidos++;
                            }
                        }
                        catch (Exception ex)
                        {
                            sw.WriteLine($"[EXCEPCIÓN] {origen}: {ex.Message}");
                            fallidos++;
                        }
                    }
                    sw.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] --- FIN DE BATCH (Éxito: {exitosos}, Fallos: {fallidos}) ---");
                }

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
            btnCreateLink.Enabled = enabled;
            btnCreateLink.BackColor = enabled ? Color.FromArgb(0, 122, 204) : Color.FromArgb(50, 50, 50);
            btnAddFolder.Enabled = enabled;
            btnAddFiles.Enabled = enabled;
            btnClearList.Enabled = enabled;
            btnBrowseDestino.Enabled = enabled;
            lstOrigen.Enabled = enabled;
            txtDestino.Enabled = enabled;
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
                return p.ExitCode < 8; // 0-7 son códigos de éxito o advertencias menores en Robocopy
            }
        }

        private bool CrearEnlaceSimbolico(string link, string target, bool esCarpeta)
        {
            // Para carpetas usa /D, para archivos no usa switch extra
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
    }
}