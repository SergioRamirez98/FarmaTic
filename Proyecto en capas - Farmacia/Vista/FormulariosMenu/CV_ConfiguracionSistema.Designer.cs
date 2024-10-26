namespace Vista.FormulariosMenu
{
    partial class CV_ConfiguracionSistema
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
            this.Lbl_CantMinStock = new System.Windows.Forms.Label();
            this.Nud_CantMinStock = new System.Windows.Forms.NumericUpDown();
            this.Lbl_DiasVtoProd = new System.Windows.Forms.Label();
            this.Nud_VtoProd = new System.Windows.Forms.NumericUpDown();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CantMinStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_VtoProd)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_CantMinStock
            // 
            this.Lbl_CantMinStock.AutoSize = true;
            this.Lbl_CantMinStock.Location = new System.Drawing.Point(342, 214);
            this.Lbl_CantMinStock.Name = "Lbl_CantMinStock";
            this.Lbl_CantMinStock.Size = new System.Drawing.Size(161, 16);
            this.Lbl_CantMinStock.TabIndex = 12;
            this.Lbl_CantMinStock.Text = "Cantidad minima de stock";
            // 
            // Nud_CantMinStock
            // 
            this.Nud_CantMinStock.Location = new System.Drawing.Point(279, 214);
            this.Nud_CantMinStock.Name = "Nud_CantMinStock";
            this.Nud_CantMinStock.Size = new System.Drawing.Size(54, 22);
            this.Nud_CantMinStock.TabIndex = 13;
            this.Nud_CantMinStock.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Lbl_DiasVtoProd
            // 
            this.Lbl_DiasVtoProd.AutoSize = true;
            this.Lbl_DiasVtoProd.Location = new System.Drawing.Point(342, 184);
            this.Lbl_DiasVtoProd.Name = "Lbl_DiasVtoProd";
            this.Lbl_DiasVtoProd.Size = new System.Drawing.Size(179, 16);
            this.Lbl_DiasVtoProd.TabIndex = 10;
            this.Lbl_DiasVtoProd.Text = "Aviso de dias Vto. Productos";
            // 
            // Nud_VtoProd
            // 
            this.Nud_VtoProd.Location = new System.Drawing.Point(279, 184);
            this.Nud_VtoProd.Name = "Nud_VtoProd";
            this.Nud_VtoProd.Size = new System.Drawing.Size(54, 22);
            this.Nud_VtoProd.TabIndex = 11;
            this.Nud_VtoProd.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(345, 332);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Guardar.TabIndex = 16;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // CV_ConfiguracionSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Lbl_CantMinStock);
            this.Controls.Add(this.Nud_CantMinStock);
            this.Controls.Add(this.Lbl_DiasVtoProd);
            this.Controls.Add(this.Nud_VtoProd);
            this.Name = "CV_ConfiguracionSistema";
            this.Text = "Configuracion Sistema";
            this.Load += new System.EventHandler(this.CV_ConfiguracionSistema_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CantMinStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_VtoProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Lbl_CantMinStock;
        private System.Windows.Forms.NumericUpDown Nud_CantMinStock;
        private System.Windows.Forms.Label Lbl_DiasVtoProd;
        private System.Windows.Forms.NumericUpDown Nud_VtoProd;
        private System.Windows.Forms.Button Btn_Guardar;
    }
}