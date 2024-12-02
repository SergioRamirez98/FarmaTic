namespace Vista
{
    partial class CV_ModulodeSeguridad
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
            this.Chb_MinCaracteres = new System.Windows.Forms.CheckBox();
            this.Chb_MayMin = new System.Windows.Forms.CheckBox();
            this.Chb_CaracEspec = new System.Windows.Forms.CheckBox();
            this.Chb_DatosPersonales = new System.Windows.Forms.CheckBox();
            this.Chb_NumYLetras = new System.Windows.Forms.CheckBox();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Chb_RepetirPass = new System.Windows.Forms.CheckBox();
            this.Lbl_CantIntentosFallidos = new System.Windows.Forms.Label();
            this.Nud_CantidadIntentosFallidos = new System.Windows.Forms.NumericUpDown();
            this.Btn_Bitacora = new System.Windows.Forms.Button();
            this.Pnl_Bitacora = new System.Windows.Forms.Panel();
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            this.Txb_UserName = new System.Windows.Forms.TextBox();
            this.Lbl_Tipo = new System.Windows.Forms.Label();
            this.Lbl_Hasta = new System.Windows.Forms.Label();
            this.Lbl_Desde = new System.Windows.Forms.Label();
            this.Btn_VerTodo = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Cmb_Tipo = new System.Windows.Forms.ComboBox();
            this.Dtp_Hasta = new System.Windows.Forms.DateTimePicker();
            this.Dtp_Desde = new System.Windows.Forms.DateTimePicker();
            this.DTGV_Bitacora = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CantidadIntentosFallidos)).BeginInit();
            this.Pnl_Bitacora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Bitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // Chb_MinCaracteres
            // 
            this.Chb_MinCaracteres.AutoSize = true;
            this.Chb_MinCaracteres.Location = new System.Drawing.Point(20, 25);
            this.Chb_MinCaracteres.Name = "Chb_MinCaracteres";
            this.Chb_MinCaracteres.Size = new System.Drawing.Size(168, 20);
            this.Chb_MinCaracteres.TabIndex = 0;
            this.Chb_MinCaracteres.Text = "Minimo de 8 caracteres";
            this.Chb_MinCaracteres.UseVisualStyleBackColor = true;
            this.Chb_MinCaracteres.CheckedChanged += new System.EventHandler(this.Chb_MinCaracteres_CheckedChanged);
            // 
            // Chb_MayMin
            // 
            this.Chb_MayMin.AutoSize = true;
            this.Chb_MayMin.Location = new System.Drawing.Point(20, 55);
            this.Chb_MayMin.Name = "Chb_MayMin";
            this.Chb_MayMin.Size = new System.Drawing.Size(242, 20);
            this.Chb_MayMin.TabIndex = 1;
            this.Chb_MayMin.Text = "Combinar mayusculas y minúsculas";
            this.Chb_MayMin.UseVisualStyleBackColor = true;
            // 
            // Chb_CaracEspec
            // 
            this.Chb_CaracEspec.AutoSize = true;
            this.Chb_CaracEspec.Location = new System.Drawing.Point(20, 85);
            this.Chb_CaracEspec.Name = "Chb_CaracEspec";
            this.Chb_CaracEspec.Size = new System.Drawing.Size(165, 20);
            this.Chb_CaracEspec.TabIndex = 2;
            this.Chb_CaracEspec.Text = "Caracteres especiales";
            this.Chb_CaracEspec.UseVisualStyleBackColor = true;
            // 
            // Chb_DatosPersonales
            // 
            this.Chb_DatosPersonales.AutoSize = true;
            this.Chb_DatosPersonales.Location = new System.Drawing.Point(20, 115);
            this.Chb_DatosPersonales.Name = "Chb_DatosPersonales";
            this.Chb_DatosPersonales.Size = new System.Drawing.Size(202, 20);
            this.Chb_DatosPersonales.TabIndex = 3;
            this.Chb_DatosPersonales.Text = "No permitir datos personales";
            this.Chb_DatosPersonales.UseVisualStyleBackColor = true;
            // 
            // Chb_NumYLetras
            // 
            this.Chb_NumYLetras.AutoSize = true;
            this.Chb_NumYLetras.Location = new System.Drawing.Point(290, 25);
            this.Chb_NumYLetras.Name = "Chb_NumYLetras";
            this.Chb_NumYLetras.Size = new System.Drawing.Size(184, 20);
            this.Chb_NumYLetras.TabIndex = 4;
            this.Chb_NumYLetras.Text = "Contener numeros y letras";
            this.Chb_NumYLetras.UseVisualStyleBackColor = true;
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(560, 115);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Guardar.TabIndex = 10;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Chb_RepetirPass
            // 
            this.Chb_RepetirPass.AutoSize = true;
            this.Chb_RepetirPass.Location = new System.Drawing.Point(290, 55);
            this.Chb_RepetirPass.Name = "Chb_RepetirPass";
            this.Chb_RepetirPass.Size = new System.Drawing.Size(165, 20);
            this.Chb_RepetirPass.TabIndex = 5;
            this.Chb_RepetirPass.Text = "No repetir contraseñas";
            this.Chb_RepetirPass.UseVisualStyleBackColor = true;
            // 
            // Lbl_CantIntentosFallidos
            // 
            this.Lbl_CantIntentosFallidos.AutoSize = true;
            this.Lbl_CantIntentosFallidos.Location = new System.Drawing.Point(353, 85);
            this.Lbl_CantIntentosFallidos.Name = "Lbl_CantIntentosFallidos";
            this.Lbl_CantIntentosFallidos.Size = new System.Drawing.Size(175, 16);
            this.Lbl_CantIntentosFallidos.TabIndex = 9;
            this.Lbl_CantIntentosFallidos.Text = "Cantidad de intentos fallidos";
            // 
            // Nud_CantidadIntentosFallidos
            // 
            this.Nud_CantidadIntentosFallidos.Location = new System.Drawing.Point(290, 85);
            this.Nud_CantidadIntentosFallidos.Name = "Nud_CantidadIntentosFallidos";
            this.Nud_CantidadIntentosFallidos.Size = new System.Drawing.Size(54, 22);
            this.Nud_CantidadIntentosFallidos.TabIndex = 9;
            this.Nud_CantidadIntentosFallidos.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Btn_Bitacora
            // 
            this.Btn_Bitacora.Location = new System.Drawing.Point(290, 115);
            this.Btn_Bitacora.Name = "Btn_Bitacora";
            this.Btn_Bitacora.Size = new System.Drawing.Size(75, 23);
            this.Btn_Bitacora.TabIndex = 11;
            this.Btn_Bitacora.Text = "Bitácora";
            this.Btn_Bitacora.UseVisualStyleBackColor = true;
            this.Btn_Bitacora.Click += new System.EventHandler(this.Btn_Bitacora_Click);
            // 
            // Pnl_Bitacora
            // 
            this.Pnl_Bitacora.Controls.Add(this.Lbl_Usuario);
            this.Pnl_Bitacora.Controls.Add(this.Txb_UserName);
            this.Pnl_Bitacora.Controls.Add(this.Lbl_Tipo);
            this.Pnl_Bitacora.Controls.Add(this.Lbl_Hasta);
            this.Pnl_Bitacora.Controls.Add(this.Lbl_Desde);
            this.Pnl_Bitacora.Controls.Add(this.Btn_VerTodo);
            this.Pnl_Bitacora.Controls.Add(this.Btn_Buscar);
            this.Pnl_Bitacora.Controls.Add(this.Cmb_Tipo);
            this.Pnl_Bitacora.Controls.Add(this.Dtp_Hasta);
            this.Pnl_Bitacora.Controls.Add(this.Dtp_Desde);
            this.Pnl_Bitacora.Controls.Add(this.DTGV_Bitacora);
            this.Pnl_Bitacora.Location = new System.Drawing.Point(22, 161);
            this.Pnl_Bitacora.Name = "Pnl_Bitacora";
            this.Pnl_Bitacora.Size = new System.Drawing.Size(628, 403);
            this.Pnl_Bitacora.TabIndex = 12;
            // 
            // Lbl_Usuario
            // 
            this.Lbl_Usuario.AutoSize = true;
            this.Lbl_Usuario.Location = new System.Drawing.Point(31, 9);
            this.Lbl_Usuario.Name = "Lbl_Usuario";
            this.Lbl_Usuario.Size = new System.Drawing.Size(54, 16);
            this.Lbl_Usuario.TabIndex = 63;
            this.Lbl_Usuario.Text = "Usuario";
            // 
            // Txb_UserName
            // 
            this.Txb_UserName.Location = new System.Drawing.Point(34, 28);
            this.Txb_UserName.Name = "Txb_UserName";
            this.Txb_UserName.Size = new System.Drawing.Size(119, 22);
            this.Txb_UserName.TabIndex = 53;
            // 
            // Lbl_Tipo
            // 
            this.Lbl_Tipo.AutoSize = true;
            this.Lbl_Tipo.Location = new System.Drawing.Point(485, 9);
            this.Lbl_Tipo.Name = "Lbl_Tipo";
            this.Lbl_Tipo.Size = new System.Drawing.Size(118, 16);
            this.Lbl_Tipo.TabIndex = 61;
            this.Lbl_Tipo.Text = "Tipo de operacion";
            // 
            // Lbl_Hasta
            // 
            this.Lbl_Hasta.AutoSize = true;
            this.Lbl_Hasta.Location = new System.Drawing.Point(332, 9);
            this.Lbl_Hasta.Name = "Lbl_Hasta";
            this.Lbl_Hasta.Size = new System.Drawing.Size(43, 16);
            this.Lbl_Hasta.TabIndex = 60;
            this.Lbl_Hasta.Text = "Hasta";
            // 
            // Lbl_Desde
            // 
            this.Lbl_Desde.AutoSize = true;
            this.Lbl_Desde.Location = new System.Drawing.Point(177, 9);
            this.Lbl_Desde.Name = "Lbl_Desde";
            this.Lbl_Desde.Size = new System.Drawing.Size(48, 16);
            this.Lbl_Desde.TabIndex = 59;
            this.Lbl_Desde.Text = "Desde";
            // 
            // Btn_VerTodo
            // 
            this.Btn_VerTodo.Location = new System.Drawing.Point(321, 75);
            this.Btn_VerTodo.Name = "Btn_VerTodo";
            this.Btn_VerTodo.Size = new System.Drawing.Size(115, 23);
            this.Btn_VerTodo.TabIndex = 58;
            this.Btn_VerTodo.Text = "Ver todo";
            this.Btn_VerTodo.UseVisualStyleBackColor = true;
            this.Btn_VerTodo.Click += new System.EventHandler(this.Btn_VerTodo_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(180, 75);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(115, 23);
            this.Btn_Buscar.TabIndex = 56;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Cmb_Tipo
            // 
            this.Cmb_Tipo.FormattingEnabled = true;
            this.Cmb_Tipo.Location = new System.Drawing.Point(488, 26);
            this.Cmb_Tipo.Name = "Cmb_Tipo";
            this.Cmb_Tipo.Size = new System.Drawing.Size(121, 24);
            this.Cmb_Tipo.TabIndex = 57;
            // 
            // Dtp_Hasta
            // 
            this.Dtp_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Hasta.Location = new System.Drawing.Point(335, 28);
            this.Dtp_Hasta.Name = "Dtp_Hasta";
            this.Dtp_Hasta.Size = new System.Drawing.Size(130, 22);
            this.Dtp_Hasta.TabIndex = 55;
            // 
            // Dtp_Desde
            // 
            this.Dtp_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Desde.Location = new System.Drawing.Point(180, 28);
            this.Dtp_Desde.Name = "Dtp_Desde";
            this.Dtp_Desde.Size = new System.Drawing.Size(130, 22);
            this.Dtp_Desde.TabIndex = 54;
            // 
            // DTGV_Bitacora
            // 
            this.DTGV_Bitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_Bitacora.Location = new System.Drawing.Point(13, 104);
            this.DTGV_Bitacora.Name = "DTGV_Bitacora";
            this.DTGV_Bitacora.RowHeadersWidth = 51;
            this.DTGV_Bitacora.RowTemplate.Height = 24;
            this.DTGV_Bitacora.Size = new System.Drawing.Size(603, 262);
            this.DTGV_Bitacora.TabIndex = 62;
            // 
            // CV_ModulodeSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(693, 576);
            this.Controls.Add(this.Pnl_Bitacora);
            this.Controls.Add(this.Btn_Bitacora);
            this.Controls.Add(this.Lbl_CantIntentosFallidos);
            this.Controls.Add(this.Nud_CantidadIntentosFallidos);
            this.Controls.Add(this.Chb_RepetirPass);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Chb_NumYLetras);
            this.Controls.Add(this.Chb_DatosPersonales);
            this.Controls.Add(this.Chb_CaracEspec);
            this.Controls.Add(this.Chb_MayMin);
            this.Controls.Add(this.Chb_MinCaracteres);
            this.Name = "CV_ModulodeSeguridad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de seguridad";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CV_Configuracion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CantidadIntentosFallidos)).EndInit();
            this.Pnl_Bitacora.ResumeLayout(false);
            this.Pnl_Bitacora.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Bitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Chb_MinCaracteres;
        private System.Windows.Forms.CheckBox Chb_MayMin;
        private System.Windows.Forms.CheckBox Chb_CaracEspec;
        private System.Windows.Forms.CheckBox Chb_DatosPersonales;
        private System.Windows.Forms.CheckBox Chb_NumYLetras;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.CheckBox Chb_RepetirPass;
        private System.Windows.Forms.Label Lbl_CantIntentosFallidos;
        private System.Windows.Forms.NumericUpDown Nud_CantidadIntentosFallidos;
        private System.Windows.Forms.Button Btn_Bitacora;
        private System.Windows.Forms.Panel Pnl_Bitacora;
        private System.Windows.Forms.Label Lbl_Usuario;
        private System.Windows.Forms.TextBox Txb_UserName;
        private System.Windows.Forms.Label Lbl_Tipo;
        private System.Windows.Forms.Label Lbl_Hasta;
        private System.Windows.Forms.Label Lbl_Desde;
        private System.Windows.Forms.Button Btn_VerTodo;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.ComboBox Cmb_Tipo;
        private System.Windows.Forms.DateTimePicker Dtp_Hasta;
        private System.Windows.Forms.DateTimePicker Dtp_Desde;
        private System.Windows.Forms.DataGridView DTGV_Bitacora;
    }
}