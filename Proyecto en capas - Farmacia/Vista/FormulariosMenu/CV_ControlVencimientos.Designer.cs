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
            this.DTGV_Vencimientos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Vencimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // DTGV_Vencimientos
            // 
            this.DTGV_Vencimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_Vencimientos.Location = new System.Drawing.Point(12, 12);
            this.DTGV_Vencimientos.Name = "DTGV_Vencimientos";
            this.DTGV_Vencimientos.RowHeadersWidth = 51;
            this.DTGV_Vencimientos.RowTemplate.Height = 24;
            this.DTGV_Vencimientos.Size = new System.Drawing.Size(1069, 426);
            this.DTGV_Vencimientos.TabIndex = 0;
            // 
            // CV_ControlVencimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 450);
            this.Controls.Add(this.DTGV_Vencimientos);
            this.Name = "CV_ControlVencimientos";
            this.Text = "Control de vencimientos";
            this.Load += new System.EventHandler(this.CV_ControlVencimientos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Vencimientos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGV_Vencimientos;
    }
}