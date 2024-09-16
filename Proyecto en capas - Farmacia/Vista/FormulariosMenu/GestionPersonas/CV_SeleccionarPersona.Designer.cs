namespace Vista.FormulariosMenu.GestionPersonas
{
    partial class CV_SeleccionarPersona
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
            this.DTGV_SeleccionarPersona = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_SeleccionarPersona)).BeginInit();
            this.SuspendLayout();
            // 
            // DTGV_SeleccionarPersona
            // 
            this.DTGV_SeleccionarPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_SeleccionarPersona.Location = new System.Drawing.Point(12, 131);
            this.DTGV_SeleccionarPersona.Name = "DTGV_SeleccionarPersona";
            this.DTGV_SeleccionarPersona.RowHeadersWidth = 51;
            this.DTGV_SeleccionarPersona.RowTemplate.Height = 24;
            this.DTGV_SeleccionarPersona.Size = new System.Drawing.Size(776, 150);
            this.DTGV_SeleccionarPersona.TabIndex = 0;
            this.DTGV_SeleccionarPersona.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_SeleccionarPersona_CellContentDoubleClick);
            this.DTGV_SeleccionarPersona.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTGV_SeleccionarPersona_KeyDown);
            // 
            // CV_SeleccionarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DTGV_SeleccionarPersona);
            this.Name = "CV_SeleccionarPersona";
            this.Text = "Seleccione Persona";
            this.Load += new System.EventHandler(this.CV_SeleccionarPersona_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_SeleccionarPersona)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGV_SeleccionarPersona;
    }
}