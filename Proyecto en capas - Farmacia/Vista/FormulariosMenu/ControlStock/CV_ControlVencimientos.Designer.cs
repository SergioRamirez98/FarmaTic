namespace Vista
{
    partial class CV_ControlVencimientos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CV_ControlVencimientos));
            this.DTGV_Vencimientos = new System.Windows.Forms.DataGridView();
            this.Txb_BusquedaRapida = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Vencimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // DTGV_Vencimientos
            // 
            this.DTGV_Vencimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_Vencimientos.Location = new System.Drawing.Point(12, 45);
            this.DTGV_Vencimientos.Name = "DTGV_Vencimientos";
            this.DTGV_Vencimientos.RowHeadersWidth = 51;
            this.DTGV_Vencimientos.RowTemplate.Height = 24;
            this.DTGV_Vencimientos.Size = new System.Drawing.Size(1069, 426);
            this.DTGV_Vencimientos.TabIndex = 0;
            // 
            // Txb_BusquedaRapida
            // 
            this.Txb_BusquedaRapida.Location = new System.Drawing.Point(457, 12);
            this.Txb_BusquedaRapida.Name = "Txb_BusquedaRapida";
            this.Txb_BusquedaRapida.Size = new System.Drawing.Size(100, 22);
            this.Txb_BusquedaRapida.TabIndex = 1;
            this.Txb_BusquedaRapida.TextChanged += new System.EventHandler(this.Txb_BusquedaRapida_TextChanged);
            // 
            // CV_ControlVencimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1093, 483);
            this.Controls.Add(this.Txb_BusquedaRapida);
            this.Controls.Add(this.DTGV_Vencimientos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CV_ControlVencimientos";
            this.Text = "Control de vencimientos";
            this.Load += new System.EventHandler(this.CV_ControlVencimientos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Vencimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGV_Vencimientos;
        private System.Windows.Forms.TextBox Txb_BusquedaRapida;
    }
}