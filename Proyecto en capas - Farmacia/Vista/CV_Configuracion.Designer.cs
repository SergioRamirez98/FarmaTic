namespace Vista
{
    partial class CV_Configuracion
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
            this.SuspendLayout();
            // 
            // Chb_MinCaracteres
            // 
            this.Chb_MinCaracteres.AutoSize = true;
            this.Chb_MinCaracteres.Location = new System.Drawing.Point(85, 66);
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
            this.Chb_MayMin.Location = new System.Drawing.Point(85, 116);
            this.Chb_MayMin.Name = "Chb_MayMin";
            this.Chb_MayMin.Size = new System.Drawing.Size(242, 20);
            this.Chb_MayMin.TabIndex = 1;
            this.Chb_MayMin.Text = "Combinar mayusculas y minúsculas";
            this.Chb_MayMin.UseVisualStyleBackColor = true;
            // 
            // Chb_CaracEspec
            // 
            this.Chb_CaracEspec.AutoSize = true;
            this.Chb_CaracEspec.Location = new System.Drawing.Point(85, 163);
            this.Chb_CaracEspec.Name = "Chb_CaracEspec";
            this.Chb_CaracEspec.Size = new System.Drawing.Size(165, 20);
            this.Chb_CaracEspec.TabIndex = 2;
            this.Chb_CaracEspec.Text = "Caracteres especiales";
            this.Chb_CaracEspec.UseVisualStyleBackColor = true;
            // 
            // Chb_DatosPersonales
            // 
            this.Chb_DatosPersonales.AutoSize = true;
            this.Chb_DatosPersonales.Location = new System.Drawing.Point(85, 207);
            this.Chb_DatosPersonales.Name = "Chb_DatosPersonales";
            this.Chb_DatosPersonales.Size = new System.Drawing.Size(202, 20);
            this.Chb_DatosPersonales.TabIndex = 3;
            this.Chb_DatosPersonales.Text = "No permitir datos personales";
            this.Chb_DatosPersonales.UseVisualStyleBackColor = true;
            // 
            // Chb_NumYLetras
            // 
            this.Chb_NumYLetras.AutoSize = true;
            this.Chb_NumYLetras.Location = new System.Drawing.Point(85, 251);
            this.Chb_NumYLetras.Name = "Chb_NumYLetras";
            this.Chb_NumYLetras.Size = new System.Drawing.Size(184, 20);
            this.Chb_NumYLetras.TabIndex = 4;
            this.Chb_NumYLetras.Text = "Contener numeros y letras";
            this.Chb_NumYLetras.UseVisualStyleBackColor = true;
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(394, 160);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Guardar.TabIndex = 5;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // CV_Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Chb_NumYLetras);
            this.Controls.Add(this.Chb_DatosPersonales);
            this.Controls.Add(this.Chb_CaracEspec);
            this.Controls.Add(this.Chb_MayMin);
            this.Controls.Add(this.Chb_MinCaracteres);
            this.Name = "CV_Configuracion";
            this.Text = "Configuración de contraseñas";
            this.Load += new System.EventHandler(this.CV_Configuracion_Load);
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
    }
}