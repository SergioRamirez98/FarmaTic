namespace Vista
{
    partial class CV_ProdVencido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CV_ProdVencido));
            this.DTGV_ProductosVencidos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_ProductosVencidos)).BeginInit();
            this.SuspendLayout();
            // 
            // DTGV_ProductosVencidos
            // 
            this.DTGV_ProductosVencidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_ProductosVencidos.Location = new System.Drawing.Point(12, 50);
            this.DTGV_ProductosVencidos.Name = "DTGV_ProductosVencidos";
            this.DTGV_ProductosVencidos.RowHeadersWidth = 51;
            this.DTGV_ProductosVencidos.RowTemplate.Height = 24;
            this.DTGV_ProductosVencidos.Size = new System.Drawing.Size(1340, 350);
            this.DTGV_ProductosVencidos.TabIndex = 20;
            // 
            // CV_ProdVencido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1361, 450);
            this.Controls.Add(this.DTGV_ProductosVencidos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CV_ProdVencido";
            this.Text = "Productos Vencidos";
            this.Load += new System.EventHandler(this.CV_ProdVencido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_ProductosVencidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGV_ProductosVencidos;
    }
}