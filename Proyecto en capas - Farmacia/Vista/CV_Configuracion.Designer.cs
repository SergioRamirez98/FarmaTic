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
            this.SuspendLayout();
            // 
            // Chb_MinCaracteres
            // 
            this.Chb_MinCaracteres.AutoSize = true;
            this.Chb_MinCaracteres.Location = new System.Drawing.Point(85, 66);
            this.Chb_MinCaracteres.Name = "Chb_MinCaracteres";
            this.Chb_MinCaracteres.Size = new System.Drawing.Size(158, 20);
            this.Chb_MinCaracteres.TabIndex = 0;
            this.Chb_MinCaracteres.Text = "Minimo de caracteres";
            this.Chb_MinCaracteres.UseVisualStyleBackColor = true;
            this.Chb_MinCaracteres.CheckedChanged += new System.EventHandler(this.Chb_MinCaracteres_CheckedChanged);
            // 
            // CV_Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Chb_MinCaracteres);
            this.Name = "CV_Configuracion";
            this.Text = "Configuración de contraseñas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Chb_MinCaracteres;
    }
}