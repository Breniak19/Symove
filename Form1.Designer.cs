namespace Symove
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // Controles de Pestaña 1
            lstOrigen = new System.Windows.Forms.ListBox();
            txtDestino = new System.Windows.Forms.TextBox();
            btnCreateLink = new System.Windows.Forms.Button();
            btnAddFolder = new System.Windows.Forms.Button();
            btnAddFiles = new System.Windows.Forms.Button();
            btnClearList = new System.Windows.Forms.Button();
            btnBrowseDestino = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();

            // Controles de Pestaña 2
            txtScanPath = new System.Windows.Forms.TextBox();
            btnBrowseScan = new System.Windows.Forms.Button();
            btnScan = new System.Windows.Forms.Button();
            chkSoloRotos = new System.Windows.Forms.CheckBox();
            dgvEnlaces = new System.Windows.Forms.DataGridView();
            btnUndo = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();

            // Controles Generales
            tabControl1 = new System.Windows.Forms.TabControl();
            tabCrear = new System.Windows.Forms.TabPage();
            tabGestionar = new System.Windows.Forms.TabPage();
            lblStatus = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)dgvEnlaces).BeginInit();
            tabControl1.SuspendLayout();
            tabCrear.SuspendLayout();
            tabGestionar.SuspendLayout();
            SuspendLayout();

            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabCrear);
            tabControl1.Controls.Add(tabGestionar);
            tabControl1.Location = new System.Drawing.Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(660, 360);
            tabControl1.TabIndex = 0;
            // 
            // tabCrear
            // 
            tabCrear.BackColor = System.Drawing.Color.FromArgb(28, 28, 28);
            tabCrear.Controls.Add(label1);
            tabCrear.Controls.Add(lstOrigen);
            tabCrear.Controls.Add(btnAddFolder);
            tabCrear.Controls.Add(btnAddFiles);
            tabCrear.Controls.Add(btnClearList);
            tabCrear.Controls.Add(label2);
            tabCrear.Controls.Add(txtDestino);
            tabCrear.Controls.Add(btnBrowseDestino);
            tabCrear.Controls.Add(btnCreateLink);
            tabCrear.Location = new System.Drawing.Point(4, 26);
            tabCrear.Name = "tabCrear";
            tabCrear.Padding = new System.Windows.Forms.Padding(3);
            tabCrear.Size = new System.Drawing.Size(652, 330);
            tabCrear.TabIndex = 0;
            tabCrear.Text = "Crear Enlaces";
            // 
            // tabGestionar
            // 
            tabGestionar.BackColor = System.Drawing.Color.FromArgb(28, 28, 28);
            tabGestionar.Controls.Add(label4);
            tabGestionar.Controls.Add(txtScanPath);
            tabGestionar.Controls.Add(btnBrowseScan);
            tabGestionar.Controls.Add(btnScan);
            tabGestionar.Controls.Add(chkSoloRotos);
            tabGestionar.Controls.Add(dgvEnlaces);
            tabGestionar.Controls.Add(btnUndo);
            tabGestionar.Location = new System.Drawing.Point(4, 26);
            tabGestionar.Name = "tabGestionar";
            tabGestionar.Padding = new System.Windows.Forms.Padding(3);
            tabGestionar.Size = new System.Drawing.Size(652, 330);
            tabGestionar.TabIndex = 1;
            tabGestionar.Text = "Gestionar Enlaces";
            // 
            // lstOrigen
            // 
            lstOrigen.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            lstOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lstOrigen.ForeColor = System.Drawing.Color.White;
            lstOrigen.FormattingEnabled = true;
            lstOrigen.ItemHeight = 17;
            lstOrigen.HorizontalScrollbar = true;
            lstOrigen.Location = new System.Drawing.Point(20, 35);
            lstOrigen.Name = "lstOrigen";
            lstOrigen.Size = new System.Drawing.Size(490, 104);
            lstOrigen.TabIndex = 0;
            // 
            // btnAddFolder
            // 
            btnAddFolder.BackColor = System.Drawing.Color.FromArgb(60, 60, 65);
            btnAddFolder.FlatAppearance.BorderSize = 0;
            btnAddFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddFolder.ForeColor = System.Drawing.Color.White;
            btnAddFolder.Location = new System.Drawing.Point(525, 35);
            btnAddFolder.Name = "btnAddFolder";
            btnAddFolder.Size = new System.Drawing.Size(105, 28);
            btnAddFolder.TabIndex = 3;
            btnAddFolder.Text = "+ Carpeta";
            btnAddFolder.UseVisualStyleBackColor = false;
            btnAddFolder.Click += btnAddFolder_Click;
            // 
            // btnAddFiles
            // 
            btnAddFiles.BackColor = System.Drawing.Color.FromArgb(60, 60, 65);
            btnAddFiles.FlatAppearance.BorderSize = 0;
            btnAddFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddFiles.ForeColor = System.Drawing.Color.White;
            btnAddFiles.Location = new System.Drawing.Point(525, 75);
            btnAddFiles.Name = "btnAddFiles";
            btnAddFiles.Size = new System.Drawing.Size(105, 28);
            btnAddFiles.TabIndex = 4;
            btnAddFiles.Text = "+ Archivos";
            btnAddFiles.UseVisualStyleBackColor = false;
            btnAddFiles.Click += btnAddFiles_Click;
            // 
            // btnClearList
            // 
            btnClearList.BackColor = System.Drawing.Color.FromArgb(180, 60, 60);
            btnClearList.FlatAppearance.BorderSize = 0;
            btnClearList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClearList.ForeColor = System.Drawing.Color.White;
            btnClearList.Location = new System.Drawing.Point(525, 115);
            btnClearList.Name = "btnClearList";
            btnClearList.Size = new System.Drawing.Size(105, 28);
            btnClearList.TabIndex = 5;
            btnClearList.Text = "Limpiar";
            btnClearList.UseVisualStyleBackColor = false;
            btnClearList.Click += btnClearList_Click;
            // 
            // txtDestino
            // 
            txtDestino.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtDestino.ForeColor = System.Drawing.Color.White;
            txtDestino.Location = new System.Drawing.Point(20, 185);
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new System.Drawing.Size(490, 24);
            txtDestino.TabIndex = 1;
            // 
            // btnBrowseDestino
            // 
            btnBrowseDestino.BackColor = System.Drawing.Color.FromArgb(60, 60, 65);
            btnBrowseDestino.FlatAppearance.BorderSize = 0;
            btnBrowseDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBrowseDestino.ForeColor = System.Drawing.Color.White;
            btnBrowseDestino.Location = new System.Drawing.Point(525, 183);
            btnBrowseDestino.Name = "btnBrowseDestino";
            btnBrowseDestino.Size = new System.Drawing.Size(105, 28);
            btnBrowseDestino.TabIndex = 6;
            btnBrowseDestino.Text = "Examinar";
            btnBrowseDestino.UseVisualStyleBackColor = false;
            btnBrowseDestino.Click += btnBrowseDestino_Click;
            // 
            // btnCreateLink
            // 
            btnCreateLink.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnCreateLink.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCreateLink.FlatAppearance.BorderSize = 0;
            btnCreateLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCreateLink.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCreateLink.ForeColor = System.Drawing.Color.White;
            btnCreateLink.Location = new System.Drawing.Point(20, 245);
            btnCreateLink.Name = "btnCreateLink";
            btnCreateLink.Size = new System.Drawing.Size(610, 55);
            btnCreateLink.TabIndex = 2;
            btnCreateLink.Text = "MOVER Y CREAR ENLACE(S)";
            btnCreateLink.UseVisualStyleBackColor = false;
            btnCreateLink.Click += btnCreateLink_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            label1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            label1.Location = new System.Drawing.Point(17, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(160, 15);
            label1.TabIndex = 8;
            label1.Text = "Archivos / Carpetas de Origen";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            label2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            label2.Location = new System.Drawing.Point(17, 165);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(116, 15);
            label2.TabIndex = 9;
            label2.Text = "Carpeta Destino Raíz";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            label4.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            label4.Location = new System.Drawing.Point(17, 15);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(113, 15);
            label4.TabIndex = 10;
            label4.Text = "Carpeta a Escanear:";
            // 
            // txtScanPath
            // 
            txtScanPath.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            txtScanPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtScanPath.ForeColor = System.Drawing.Color.White;
            txtScanPath.Location = new System.Drawing.Point(20, 35);
            txtScanPath.Name = "txtScanPath";
            txtScanPath.Size = new System.Drawing.Size(390, 24);
            txtScanPath.TabIndex = 11;
            // 
            // btnBrowseScan
            // 
            btnBrowseScan.BackColor = System.Drawing.Color.FromArgb(60, 60, 65);
            btnBrowseScan.FlatAppearance.BorderSize = 0;
            btnBrowseScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBrowseScan.ForeColor = System.Drawing.Color.White;
            btnBrowseScan.Location = new System.Drawing.Point(420, 33);
            btnBrowseScan.Name = "btnBrowseScan";
            btnBrowseScan.Size = new System.Drawing.Size(95, 28);
            btnBrowseScan.TabIndex = 12;
            btnBrowseScan.Text = "Examinar";
            btnBrowseScan.UseVisualStyleBackColor = false;
            btnBrowseScan.Click += btnBrowseScan_Click;
            // 
            // btnScan
            // 
            btnScan.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnScan.FlatAppearance.BorderSize = 0;
            btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnScan.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            btnScan.ForeColor = System.Drawing.Color.White;
            btnScan.Location = new System.Drawing.Point(525, 33);
            btnScan.Name = "btnScan";
            btnScan.Size = new System.Drawing.Size(105, 28);
            btnScan.TabIndex = 13;
            btnScan.Text = "Escanear";
            btnScan.UseVisualStyleBackColor = false;
            btnScan.Click += btnScan_Click;
            // 
            // chkSoloRotos
            // 
            chkSoloRotos.AutoSize = true;
            chkSoloRotos.ForeColor = System.Drawing.Color.WhiteSmoke;
            chkSoloRotos.Location = new System.Drawing.Point(20, 70);
            chkSoloRotos.Name = "chkSoloRotos";
            chkSoloRotos.Size = new System.Drawing.Size(262, 21);
            chkSoloRotos.TabIndex = 14;
            chkSoloRotos.Text = "Mostrar solo enlaces rotos (huérfanos)";
            chkSoloRotos.UseVisualStyleBackColor = true;
            // 
            // dgvEnlaces
            // 
            dgvEnlaces.BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
            dgvEnlaces.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvEnlaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEnlaces.Location = new System.Drawing.Point(20, 100);
            dgvEnlaces.Name = "dgvEnlaces";
            dgvEnlaces.RowTemplate.Height = 25;
            dgvEnlaces.Size = new System.Drawing.Size(610, 160);
            dgvEnlaces.TabIndex = 15;
            // 
            // btnUndo
            // 
            btnUndo.BackColor = System.Drawing.Color.FromArgb(180, 60, 60);
            btnUndo.Cursor = System.Windows.Forms.Cursors.Hand;
            btnUndo.FlatAppearance.BorderSize = 0;
            btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnUndo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnUndo.ForeColor = System.Drawing.Color.White;
            btnUndo.Location = new System.Drawing.Point(20, 275);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new System.Drawing.Size(610, 40);
            btnUndo.TabIndex = 16;
            btnUndo.Text = "DESHACER ENLACE(S) SELECCIONADO(S)";
            btnUndo.UseVisualStyleBackColor = false;
            btnUndo.Click += btnUndo_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblStatus.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);
            lblStatus.Location = new System.Drawing.Point(12, 385);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(102, 15);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Estado: Preparado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            label3.ForeColor = System.Drawing.Color.Gainsboro;
            label3.Location = new System.Drawing.Point(610, 385);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(62, 15);
            label3.TabIndex = 10;
            label3.Text = "By Breniak";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(28, 28, 28);
            ClientSize = new System.Drawing.Size(684, 420);
            Controls.Add(tabControl1);
            Controls.Add(label3);
            Controls.Add(lblStatus);
            Font = new System.Drawing.Font("Segoe UI", 9.5F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Symove - Advanced Management";
            Load += Form1_Load;

            ((System.ComponentModel.ISupportInitialize)dgvEnlaces).EndInit();
            tabControl1.ResumeLayout(false);
            tabCrear.ResumeLayout(false);
            tabCrear.PerformLayout();
            tabGestionar.ResumeLayout(false);
            tabGestionar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCrear;
        private System.Windows.Forms.TabPage tabGestionar;
        private System.Windows.Forms.ListBox lstOrigen;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Button btnCreateLink;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnBrowseDestino;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtScanPath;
        private System.Windows.Forms.Button btnBrowseScan;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.CheckBox chkSoloRotos;
        private System.Windows.Forms.DataGridView dgvEnlaces;
        private System.Windows.Forms.Button btnUndo;
    }
}