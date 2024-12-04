namespace Vista.FormulariosMenu
{
    partial class CV_Bitacora
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CV_Bitacora));
            this.DTGV_Bitacora = new System.Windows.Forms.DataGridView();
            this.Dtp_Desde = new System.Windows.Forms.DateTimePicker();
            this.Dtp_Hasta = new System.Windows.Forms.DateTimePicker();
            this.Cmb_Tipo = new System.Windows.Forms.ComboBox();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_VerTodo = new System.Windows.Forms.Button();
            this.Lbl_Desde = new System.Windows.Forms.Label();
            this.Lbl_Hasta = new System.Windows.Forms.Label();
            this.Lbl_Tipo = new System.Windows.Forms.Label();
            this.Txb_UserName = new System.Windows.Forms.TextBox();
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Bitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // DTGV_Bitacora
            // 
            this.DTGV_Bitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_Bitacora.Location = new System.Drawing.Point(63, 104);
            this.DTGV_Bitacora.Name = "DTGV_Bitacora";
            this.DTGV_Bitacora.RowHeadersWidth = 51;
            this.DTGV_Bitacora.RowTemplate.Height = 24;
            this.DTGV_Bitacora.Size = new System.Drawing.Size(603, 262);
            this.DTGV_Bitacora.TabIndex = 50;
            // 
            // Dtp_Desde
            // 
            this.Dtp_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Desde.Location = new System.Drawing.Point(230, 28);
            this.Dtp_Desde.Name = "Dtp_Desde";
            this.Dtp_Desde.Size = new System.Drawing.Size(130, 22);
            this.Dtp_Desde.TabIndex = 1;
            // 
            // Dtp_Hasta
            // 
            this.Dtp_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Hasta.Location = new System.Drawing.Point(385, 28);
            this.Dtp_Hasta.Name = "Dtp_Hasta";
            this.Dtp_Hasta.Size = new System.Drawing.Size(130, 22);
            this.Dtp_Hasta.TabIndex = 2;
            // 
            // Cmb_Tipo
            // 
            this.Cmb_Tipo.FormattingEnabled = true;
            this.Cmb_Tipo.Location = new System.Drawing.Point(538, 26);
            this.Cmb_Tipo.Name = "Cmb_Tipo";
            this.Cmb_Tipo.Size = new System.Drawing.Size(121, 24);
            this.Cmb_Tipo.TabIndex = 3;
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(230, 75);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(115, 23);
            this.Btn_Buscar.TabIndex = 3;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_VerTodo
            // 
            this.Btn_VerTodo.Location = new System.Drawing.Point(371, 75);
            this.Btn_VerTodo.Name = "Btn_VerTodo";
            this.Btn_VerTodo.Size = new System.Drawing.Size(115, 23);
            this.Btn_VerTodo.TabIndex = 4;
            this.Btn_VerTodo.Text = "Ver todo";
            this.Btn_VerTodo.UseVisualStyleBackColor = true;
            this.Btn_VerTodo.Click += new System.EventHandler(this.Btn_VerTodo_Click);
            // 
            // Lbl_Desde
            // 
            this.Lbl_Desde.AutoSize = true;
            this.Lbl_Desde.Location = new System.Drawing.Point(227, 9);
            this.Lbl_Desde.Name = "Lbl_Desde";
            this.Lbl_Desde.Size = new System.Drawing.Size(48, 16);
            this.Lbl_Desde.TabIndex = 6;
            this.Lbl_Desde.Text = "Desde";
            // 
            // Lbl_Hasta
            // 
            this.Lbl_Hasta.AutoSize = true;
            this.Lbl_Hasta.Location = new System.Drawing.Point(382, 9);
            this.Lbl_Hasta.Name = "Lbl_Hasta";
            this.Lbl_Hasta.Size = new System.Drawing.Size(43, 16);
            this.Lbl_Hasta.TabIndex = 7;
            this.Lbl_Hasta.Text = "Hasta";
            // 
            // Lbl_Tipo
            // 
            this.Lbl_Tipo.AutoSize = true;
            this.Lbl_Tipo.Location = new System.Drawing.Point(535, 9);
            this.Lbl_Tipo.Name = "Lbl_Tipo";
            this.Lbl_Tipo.Size = new System.Drawing.Size(118, 16);
            this.Lbl_Tipo.TabIndex = 8;
            this.Lbl_Tipo.Text = "Tipo de operacion";
            // 
            // Txb_UserName
            // 
            this.Txb_UserName.Location = new System.Drawing.Point(84, 28);
            this.Txb_UserName.Name = "Txb_UserName";
            this.Txb_UserName.Size = new System.Drawing.Size(119, 22);
            this.Txb_UserName.TabIndex = 0;
            // 
            // Lbl_Usuario
            // 
            this.Lbl_Usuario.AutoSize = true;
            this.Lbl_Usuario.Location = new System.Drawing.Point(81, 9);
            this.Lbl_Usuario.Name = "Lbl_Usuario";
            this.Lbl_Usuario.Size = new System.Drawing.Size(54, 16);
            this.Lbl_Usuario.TabIndex = 52;
            this.Lbl_Usuario.Text = "Usuario";
            // 
            // CV_Bitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(717, 377);
            this.Controls.Add(this.Lbl_Usuario);
            this.Controls.Add(this.Txb_UserName);
            this.Controls.Add(this.Lbl_Tipo);
            this.Controls.Add(this.Lbl_Hasta);
            this.Controls.Add(this.Lbl_Desde);
            this.Controls.Add(this.Btn_VerTodo);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Cmb_Tipo);
            this.Controls.Add(this.Dtp_Hasta);
            this.Controls.Add(this.Dtp_Desde);
            this.Controls.Add(this.DTGV_Bitacora);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CV_Bitacora";
            this.Text = "Bitacora";
            this.Load += new System.EventHandler(this.CV_Bitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Bitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGV_Bitacora;
        private System.Windows.Forms.DateTimePicker Dtp_Desde;
        private System.Windows.Forms.DateTimePicker Dtp_Hasta;
        private System.Windows.Forms.ComboBox Cmb_Tipo;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Button Btn_VerTodo;
        private System.Windows.Forms.Label Lbl_Desde;
        private System.Windows.Forms.Label Lbl_Hasta;
        private System.Windows.Forms.Label Lbl_Tipo;
        private System.Windows.Forms.TextBox Txb_UserName;
        private System.Windows.Forms.Label Lbl_Usuario;
    }
}