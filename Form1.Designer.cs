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
            lstOrigen = new ListBox();
            txtDestino = new TextBox();
            btnCreateLink = new Button();
            btnAddFolder = new Button();
            btnAddFiles = new Button();
            btnClearList = new Button();
            btnBrowseDestino = new Button();
            lblStatus = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // lstOrigen
            // 
            lstOrigen.BackColor = Color.FromArgb(45, 45, 48);
            lstOrigen.BorderStyle = BorderStyle.FixedSingle;
            lstOrigen.ForeColor = Color.White;
            lstOrigen.FormattingEnabled = true;
            lstOrigen.ItemHeight = 17;
            lstOrigen.HorizontalScrollbar = true;
            lstOrigen.Location = new Point(25, 45);
            lstOrigen.Name = "lstOrigen";
            lstOrigen.Size = new Size(370, 87);
            lstOrigen.TabIndex = 0;
            // 
            // btnAddFolder
            // 
            btnAddFolder.BackColor = Color.FromArgb(60, 60, 65);
            btnAddFolder.FlatAppearance.BorderSize = 0;
            btnAddFolder.FlatStyle = FlatStyle.Flat;
            btnAddFolder.ForeColor = Color.White;
            btnAddFolder.Location = new Point(405, 45);
            btnAddFolder.Name = "btnAddFolder";
            btnAddFolder.Size = new Size(95, 25);
            btnAddFolder.TabIndex = 3;
            btnAddFolder.Text = "+ Carpeta";
            btnAddFolder.UseVisualStyleBackColor = false;
            btnAddFolder.Click += btnAddFolder_Click;
            // 
            // btnAddFiles
            // 
            btnAddFiles.BackColor = Color.FromArgb(60, 60, 65);
            btnAddFiles.FlatAppearance.BorderSize = 0;
            btnAddFiles.FlatStyle = FlatStyle.Flat;
            btnAddFiles.ForeColor = Color.White;
            btnAddFiles.Location = new Point(405, 76);
            btnAddFiles.Name = "btnAddFiles";
            btnAddFiles.Size = new Size(95, 25);
            btnAddFiles.TabIndex = 4;
            btnAddFiles.Text = "+ Archivos";
            btnAddFiles.UseVisualStyleBackColor = false;
            btnAddFiles.Click += btnAddFiles_Click;
            // 
            // btnClearList
            // 
            btnClearList.BackColor = Color.FromArgb(180, 60, 60);
            btnClearList.FlatAppearance.BorderSize = 0;
            btnClearList.FlatStyle = FlatStyle.Flat;
            btnClearList.ForeColor = Color.White;
            btnClearList.Location = new Point(405, 107);
            btnClearList.Name = "btnClearList";
            btnClearList.Size = new Size(95, 25);
            btnClearList.TabIndex = 5;
            btnClearList.Text = "Limpiar";
            btnClearList.UseVisualStyleBackColor = false;
            btnClearList.Click += btnClearList_Click;
            // 
            // txtDestino
            // 
            txtDestino.BackColor = Color.FromArgb(45, 45, 48);
            txtDestino.BorderStyle = BorderStyle.FixedSingle;
            txtDestino.ForeColor = Color.White;
            txtDestino.Location = new Point(25, 175);
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new Size(370, 24);
            txtDestino.TabIndex = 1;
            // 
            // btnBrowseDestino
            // 
            btnBrowseDestino.BackColor = Color.FromArgb(60, 60, 65);
            btnBrowseDestino.FlatAppearance.BorderSize = 0;
            btnBrowseDestino.FlatStyle = FlatStyle.Flat;
            btnBrowseDestino.ForeColor = Color.White;
            btnBrowseDestino.Location = new Point(405, 174);
            btnBrowseDestino.Name = "btnBrowseDestino";
            btnBrowseDestino.Size = new Size(95, 26);
            btnBrowseDestino.TabIndex = 6;
            btnBrowseDestino.Text = "Examinar";
            btnBrowseDestino.UseVisualStyleBackColor = false;
            btnBrowseDestino.Click += btnBrowseDestino_Click;
            // 
            // btnCreateLink
            // 
            btnCreateLink.BackColor = Color.FromArgb(0, 122, 204);
            btnCreateLink.Cursor = Cursors.Hand;
            btnCreateLink.FlatAppearance.BorderSize = 0;
            btnCreateLink.FlatStyle = FlatStyle.Flat;
            btnCreateLink.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreateLink.ForeColor = Color.White;
            btnCreateLink.Location = new Point(25, 225);
            btnCreateLink.Name = "btnCreateLink";
            btnCreateLink.Size = new Size(475, 45);
            btnCreateLink.TabIndex = 2;
            btnCreateLink.Text = "MOVER Y CREAR ENLACE(S)";
            btnCreateLink.UseVisualStyleBackColor = false;
            btnCreateLink.Click += btnCreateLink_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 8.5F);
            lblStatus.ForeColor = Color.FromArgb(180, 180, 180);
            lblStatus.Location = new Point(25, 285);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(102, 15);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Estado: Preparado";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F);
            label1.ForeColor = Color.FromArgb(220, 220, 220);
            label1.Location = new Point(25, 20);
            label1.Name = "label1";
            label1.Size = new Size(160, 15);
            label1.TabIndex = 8;
            label1.Text = "Archivos / Carpetas de Origen";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F);
            label2.ForeColor = Color.FromArgb(220, 220, 220);
            label2.Location = new Point(25, 150);
            label2.Name = "label2";
            label2.Size = new Size(116, 15);
            label2.TabIndex = 9;
            label2.Text = "Carpeta Destino Raíz";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F);
            label3.ForeColor = Color.Gainsboro;
            label3.Location = new Point(457, 295);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 10;
            label3.Text = "By Breniak";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 28);
            ClientSize = new Size(530, 330);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblStatus);
            Controls.Add(btnBrowseDestino);
            Controls.Add(btnClearList);
            Controls.Add(btnAddFiles);
            Controls.Add(btnAddFolder);
            Controls.Add(btnCreateLink);
            Controls.Add(txtDestino);
            Controls.Add(lstOrigen);
            Font = new Font("Segoe UI", 9.5F);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Symove - Batch Mode";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstOrigen;
        private TextBox txtDestino;
        private Button btnCreateLink;
        private Button btnAddFolder;
        private Button btnAddFiles;
        private Button btnClearList;
        private Button btnBrowseDestino;
        private Label lblStatus;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}