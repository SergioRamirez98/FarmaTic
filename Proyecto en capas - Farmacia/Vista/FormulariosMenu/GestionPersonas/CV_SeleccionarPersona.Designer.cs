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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CV_SeleccionarPersona));
            this.DTGV_SeleccionarPersona = new System.Windows.Forms.DataGridView();
            this.Txb_BusqPersona = new System.Windows.Forms.TextBox();
            this.Lbl_BuscarPersona = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_SeleccionarPersona)).BeginInit();
            this.SuspendLayout();
            // 
            // DTGV_SeleccionarPersona
            // 
            this.DTGV_SeleccionarPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_SeleccionarPersona.Location = new System.Drawing.Point(12, 88);
            this.DTGV_SeleccionarPersona.Name = "DTGV_SeleccionarPersona";
            this.DTGV_SeleccionarPersona.RowHeadersWidth = 51;
            this.DTGV_SeleccionarPersona.RowTemplate.Height = 24;
            this.DTGV_SeleccionarPersona.Size = new System.Drawing.Size(776, 253);
            this.DTGV_SeleccionarPersona.TabIndex = 0;
            this.DTGV_SeleccionarPersona.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_SeleccionarPersona_CellContentDoubleClick);
            this.DTGV_SeleccionarPersona.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTGV_SeleccionarPersona_KeyDown);
            // 
            // Txb_BusqPersona
            // 
            this.Txb_BusqPersona.Location = new System.Drawing.Point(299, 47);
            this.Txb_BusqPersona.Name = "Txb_BusqPersona";
            this.Txb_BusqPersona.Size = new System.Drawing.Size(100, 22);
            this.Txb_BusqPersona.TabIndex = 1;
            this.Txb_BusqPersona.TextChanged += new System.EventHandler(this.Txb_BusqPersona_TextChanged);
            // 
            // Lbl_BuscarPersona
            // 
            this.Lbl_BuscarPersona.AutoSize = true;
            this.Lbl_BuscarPersona.Location = new System.Drawing.Point(191, 50);
            this.Lbl_BuscarPersona.Name = "Lbl_BuscarPersona";
            this.Lbl_BuscarPersona.Size = new System.Drawing.Size(102, 16);
            this.Lbl_BuscarPersona.TabIndex = 2;
            this.Lbl_BuscarPersona.Text = "Buscar persona";
            // 
            // CV_SeleccionarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(800, 364);
            this.Controls.Add(this.Lbl_BuscarPersona);
            this.Controls.Add(this.Txb_BusqPersona);
            this.Controls.Add(this.DTGV_SeleccionarPersona);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CV_SeleccionarPersona";
            this.Text = "Seleccione Persona";
            this.Load += new System.EventHandler(this.CV_SeleccionarPersona_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_SeleccionarPersona)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGV_SeleccionarPersona;
        private System.Windows.Forms.TextBox Txb_BusqPersona;
        private System.Windows.Forms.Label Lbl_BuscarPersona;
    }
}