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
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CantidadIntentosFallidos)).BeginInit();
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
            this.Chb_NumYLetras.Location = new System.Drawing.Point(20, 145);
            this.Chb_NumYLetras.Name = "Chb_NumYLetras";
            this.Chb_NumYLetras.Size = new System.Drawing.Size(184, 20);
            this.Chb_NumYLetras.TabIndex = 4;
            this.Chb_NumYLetras.Text = "Contener numeros y letras";
            this.Chb_NumYLetras.UseVisualStyleBackColor = true;
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(223, 203);
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
            this.Chb_RepetirPass.Location = new System.Drawing.Point(290, 25);
            this.Chb_RepetirPass.Name = "Chb_RepetirPass";
            this.Chb_RepetirPass.Size = new System.Drawing.Size(165, 20);
            this.Chb_RepetirPass.TabIndex = 5;
            this.Chb_RepetirPass.Text = "No repetir contraseñas";
            this.Chb_RepetirPass.UseVisualStyleBackColor = true;
            // 
            // Lbl_CantIntentosFallidos
            // 
            this.Lbl_CantIntentosFallidos.AutoSize = true;
            this.Lbl_CantIntentosFallidos.Location = new System.Drawing.Point(353, 55);
            this.Lbl_CantIntentosFallidos.Name = "Lbl_CantIntentosFallidos";
            this.Lbl_CantIntentosFallidos.Size = new System.Drawing.Size(175, 16);
            this.Lbl_CantIntentosFallidos.TabIndex = 9;
            this.Lbl_CantIntentosFallidos.Text = "Cantidad de intentos fallidos";
            // 
            // Nud_CantidadIntentosFallidos
            // 
            this.Nud_CantidadIntentosFallidos.Location = new System.Drawing.Point(290, 55);
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
            this.Btn_Bitacora.Location = new System.Drawing.Point(290, 112);
            this.Btn_Bitacora.Name = "Btn_Bitacora";
            this.Btn_Bitacora.Size = new System.Drawing.Size(75, 23);
            this.Btn_Bitacora.TabIndex = 11;
            this.Btn_Bitacora.Text = "Bitácora";
            this.Btn_Bitacora.UseVisualStyleBackColor = true;
            this.Btn_Bitacora.Click += new System.EventHandler(this.Btn_Bitacora_Click);
            // 
            // CV_ModulodeSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(834, 548);
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
    }
}