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
            this.Chb_RepetirPass = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Nud_CantidadIntentosFallidos = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_VtoProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CantMinStock)).BeginInit();
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
            // Nud_VtoProd
            // 
            this.Nud_VtoProd.Location = new System.Drawing.Point(290, 55);
            this.Nud_VtoProd.Name = "Nud_VtoProd";
            this.Nud_VtoProd.Size = new System.Drawing.Size(54, 22);
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
            this.Lbl_DiasVtoProd.Location = new System.Drawing.Point(353, 55);
            this.Lbl_DiasVtoProd.Name = "Lbl_DiasVtoProd";
            this.Lbl_DiasVtoProd.Size = new System.Drawing.Size(179, 16);
            this.Lbl_DiasVtoProd.TabIndex = 6;
            this.Lbl_DiasVtoProd.Text = "Aviso de dias Vto. Productos";
            // 
            // Nud_CantMinStock
            // 
            this.Nud_CantMinStock.Location = new System.Drawing.Point(290, 85);
            this.Nud_CantMinStock.Name = "Nud_CantMinStock";
            this.Nud_CantMinStock.Size = new System.Drawing.Size(54, 22);
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
            this.Lbl_CantMinStock.Location = new System.Drawing.Point(353, 85);
            this.Lbl_CantMinStock.Name = "Lbl_CantMinStock";
            this.Lbl_CantMinStock.Size = new System.Drawing.Size(161, 16);
            this.Lbl_CantMinStock.TabIndex = 7;
            this.Lbl_CantMinStock.Text = "Cantidad minima de stock";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Cantidad de intentos fallidos";
            // 
            // Nud_CantidadIntentosFallidos
            // 
            this.Nud_CantidadIntentosFallidos.Location = new System.Drawing.Point(290, 115);
            this.Nud_CantidadIntentosFallidos.Name = "Nud_CantidadIntentosFallidos";
            this.Nud_CantidadIntentosFallidos.Size = new System.Drawing.Size(54, 22);
            this.Nud_CantidadIntentosFallidos.TabIndex = 9;
            this.Nud_CantidadIntentosFallidos.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // CV_Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 249);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Nud_CantidadIntentosFallidos);
            this.Controls.Add(this.Chb_RepetirPass);
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
        private System.Windows.Forms.NumericUpDown Nud_VtoProd;
        private System.Windows.Forms.Label Lbl_DiasVtoProd;
        private System.Windows.Forms.NumericUpDown Nud_CantMinStock;
        private System.Windows.Forms.Label Lbl_CantMinStock;
        private System.Windows.Forms.CheckBox Chb_RepetirPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Nud_CantidadIntentosFallidos;
    }
}