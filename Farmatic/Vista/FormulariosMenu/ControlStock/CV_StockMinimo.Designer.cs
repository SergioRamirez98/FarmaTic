namespace Vista
{
    partial class CV_StockMinimo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CV_StockMinimo));
            this.DTGV_StockMinimo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_StockMinimo)).BeginInit();
            this.SuspendLayout();
            // 
            // DTGV_StockMinimo
            // 
            this.DTGV_StockMinimo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_StockMinimo.Location = new System.Drawing.Point(12, 12);
            this.DTGV_StockMinimo.Name = "DTGV_StockMinimo";
            this.DTGV_StockMinimo.RowHeadersWidth = 51;
            this.DTGV_StockMinimo.RowTemplate.Height = 24;
            this.DTGV_StockMinimo.Size = new System.Drawing.Size(1138, 426);
            this.DTGV_StockMinimo.TabIndex = 1;
            // 
            // CV_StockMinimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1159, 450);
            this.Controls.Add(this.DTGV_StockMinimo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CV_StockMinimo";
            this.Text = "Bajo stock";
            this.Load += new System.EventHandler(this.CV_StockMinimo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_StockMinimo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGV_StockMinimo;
    }
}