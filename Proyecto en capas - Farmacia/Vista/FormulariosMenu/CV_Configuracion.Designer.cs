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
            this.Nud_VtoProd = new System.Windows.Forms.NumericUpDown();
            this.Lbl_DiasVtoProd = new System.Windows.Forms.Label();
            this.Nud_CantMinStock = new System.Windows.Forms.NumericUpDown();
            this.Lbl_CantMinStock = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_VtoProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CantMinStock)).BeginInit();
            this.SuspendLayout();
            // 
            // Chb_MinCaracteres
            // 
            this.Chb_MinCaracteres.AutoSize = true;
            this.Chb_MinCaracteres.Location = new System.Drawing.Point(12, 26);
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
            this.Chb_MayMin.Location = new System.Drawing.Point(12, 76);
            this.Chb_MayMin.Name = "Chb_MayMin";
            this.Chb_MayMin.Size = new System.Drawing.Size(242, 20);
            this.Chb_MayMin.TabIndex = 1;
            this.Chb_MayMin.Text = "Combinar mayusculas y minúsculas";
            this.Chb_MayMin.UseVisualStyleBackColor = true;
            // 
            // Chb_CaracEspec
            // 
            this.Chb_CaracEspec.AutoSize = true;
            this.Chb_CaracEspec.Location = new System.Drawing.Point(12, 123);
            this.Chb_CaracEspec.Name = "Chb_CaracEspec";
            this.Chb_CaracEspec.Size = new System.Drawing.Size(165, 20);
            this.Chb_CaracEspec.TabIndex = 2;
            this.Chb_CaracEspec.Text = "Caracteres especiales";
            this.Chb_CaracEspec.UseVisualStyleBackColor = true;
            // 
            // Chb_DatosPersonales
            // 
            this.Chb_DatosPersonales.AutoSize = true;
            this.Chb_DatosPersonales.Location = new System.Drawing.Point(12, 170);
            this.Chb_DatosPersonales.Name = "Chb_DatosPersonales";
            this.Chb_DatosPersonales.Size = new System.Drawing.Size(202, 20);
            this.Chb_DatosPersonales.TabIndex = 3;
            this.Chb_DatosPersonales.Text = "No permitir datos personales";
            this.Chb_DatosPersonales.UseVisualStyleBackColor = true;
            // 
            // Chb_NumYLetras
            // 
            this.Chb_NumYLetras.AutoSize = true;
            this.Chb_NumYLetras.Location = new System.Drawing.Point(312, 26);
            this.Chb_NumYLetras.Name = "Chb_NumYLetras";
            this.Chb_NumYLetras.Size = new System.Drawing.Size(184, 20);
            this.Chb_NumYLetras.TabIndex = 4;
            this.Chb_NumYLetras.Text = "Contener numeros y letras";
            this.Chb_NumYLetras.UseVisualStyleBackColor = true;
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(321, 168);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Guardar.TabIndex = 5;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Nud_VtoProd
            // 
            this.Nud_VtoProd.Location = new System.Drawing.Point(312, 78);
            this.Nud_VtoProd.Name = "Nud_VtoProd";
            this.Nud_VtoProd.Size = new System.Drawing.Size(41, 22);
            this.Nud_VtoProd.TabIndex = 6;
            this.Nud_VtoProd.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // Lbl_DiasVtoProd
            // 
            this.Lbl_DiasVtoProd.AutoSize = true;
            this.Lbl_DiasVtoProd.Location = new System.Drawing.Point(365, 80);
            this.Lbl_DiasVtoProd.Name = "Lbl_DiasVtoProd";
            this.Lbl_DiasVtoProd.Size = new System.Drawing.Size(179, 16);
            this.Lbl_DiasVtoProd.TabIndex = 7;
            this.Lbl_DiasVtoProd.Text = "Aviso de dias Vto. Productos";
            // 
            // Nud_CantMinStock
            // 
            this.Nud_CantMinStock.Location = new System.Drawing.Point(312, 121);
            this.Nud_CantMinStock.Name = "Nud_CantMinStock";
            this.Nud_CantMinStock.Size = new System.Drawing.Size(41, 22);
            this.Nud_CantMinStock.TabIndex = 8;
            this.Nud_CantMinStock.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Lbl_CantMinStock
            // 
            this.Lbl_CantMinStock.AutoSize = true;
            this.Lbl_CantMinStock.Location = new System.Drawing.Point(365, 123);
            this.Lbl_CantMinStock.Name = "Lbl_CantMinStock";
            this.Lbl_CantMinStock.Size = new System.Drawing.Size(161, 16);
            this.Lbl_CantMinStock.TabIndex = 9;
            this.Lbl_CantMinStock.Text = "Cantidad minima de stock";
            // 
            // CV_Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 238);
            this.Controls.Add(this.Lbl_CantMinStock);
            this.Controls.Add(this.Nud_CantMinStock);
            this.Controls.Add(this.Lbl_DiasVtoProd);
            this.Controls.Add(this.Nud_VtoProd);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Chb_NumYLetras);
            this.Controls.Add(this.Chb_DatosPersonales);
            this.Controls.Add(this.Chb_CaracEspec);
            this.Controls.Add(this.Chb_MayMin);
            this.Controls.Add(this.Chb_MinCaracteres);
            this.Name = "CV_Configuracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de contraseñas";
            this.Load += new System.EventHandler(this.CV_Configuracion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Nud_VtoProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CantMinStock)).EndInit();
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
        private System.Windows.Forms.NumericUpDown Nud_VtoProd;
        private System.Windows.Forms.Label Lbl_DiasVtoProd;
        private System.Windows.Forms.NumericUpDown Nud_CantMinStock;
        private System.Windows.Forms.Label Lbl_CantMinStock;
    }
}