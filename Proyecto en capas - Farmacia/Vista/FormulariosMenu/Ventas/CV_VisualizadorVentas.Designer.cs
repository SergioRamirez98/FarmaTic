namespace Vista.FormulariosMenu.Ventas
{
    partial class CV_VisualizadorVentas
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
            this.DTGV_VisualizadorVentas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_VisualizadorVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // DTGV_VisualizadorVentas
            // 
            this.DTGV_VisualizadorVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_VisualizadorVentas.Location = new System.Drawing.Point(16, 87);
            this.DTGV_VisualizadorVentas.Name = "DTGV_VisualizadorVentas";
            this.DTGV_VisualizadorVentas.RowHeadersWidth = 51;
            this.DTGV_VisualizadorVentas.RowTemplate.Height = 24;
            this.DTGV_VisualizadorVentas.Size = new System.Drawing.Size(857, 269);
            this.DTGV_VisualizadorVentas.TabIndex = 0;
            // 
            // CV_VisualizadorVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(885, 398);
            this.Controls.Add(this.DTGV_VisualizadorVentas);
            this.Name = "CV_VisualizadorVentas";
            this.Text = "Visualizador de ventas";
            this.Load += new System.EventHandler(this.CV_VisualizadorVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_VisualizadorVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGV_VisualizadorVentas;
    }
}