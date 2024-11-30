namespace Vista.FormulariosMenu
{
    partial class CV_ObtenerProveedores
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
            this.DTGV_SeleccionProveedores = new System.Windows.Forms.DataGridView();
            this.Lbl_Busqueda = new System.Windows.Forms.Label();
            this.Txb_BusquedaRapida = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_SeleccionProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // DTGV_SeleccionProveedores
            // 
            this.DTGV_SeleccionProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_SeleccionProveedores.Location = new System.Drawing.Point(12, 124);
            this.DTGV_SeleccionProveedores.Name = "DTGV_SeleccionProveedores";
            this.DTGV_SeleccionProveedores.RowHeadersWidth = 51;
            this.DTGV_SeleccionProveedores.RowTemplate.Height = 24;
            this.DTGV_SeleccionProveedores.Size = new System.Drawing.Size(1281, 314);
            this.DTGV_SeleccionProveedores.TabIndex = 0;
            this.DTGV_SeleccionProveedores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_SeleccionProveedores_CellDoubleClick);
            this.DTGV_SeleccionProveedores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTGV_SeleccionProveedores_KeyDown);
            // 
            // Lbl_Busqueda
            // 
            this.Lbl_Busqueda.AutoSize = true;
            this.Lbl_Busqueda.Location = new System.Drawing.Point(406, 51);
            this.Lbl_Busqueda.Name = "Lbl_Busqueda";
            this.Lbl_Busqueda.Size = new System.Drawing.Size(69, 16);
            this.Lbl_Busqueda.TabIndex = 1;
            this.Lbl_Busqueda.Text = "Busqueda";
            // 
            // Txb_BusquedaRapida
            // 
            this.Txb_BusquedaRapida.Location = new System.Drawing.Point(482, 51);
            this.Txb_BusquedaRapida.Name = "Txb_BusquedaRapida";
            this.Txb_BusquedaRapida.Size = new System.Drawing.Size(100, 22);
            this.Txb_BusquedaRapida.TabIndex = 2;
            this.Txb_BusquedaRapida.TextChanged += new System.EventHandler(this.Txb_BusquedaRapida_TextChanged);
            // 
            // CV_ObtenerProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1305, 450);
            this.Controls.Add(this.Txb_BusquedaRapida);
            this.Controls.Add(this.Lbl_Busqueda);
            this.Controls.Add(this.DTGV_SeleccionProveedores);
            this.Name = "CV_ObtenerProveedores";
            this.Text = "Obtener Proveedores";
            this.Load += new System.EventHandler(this.CV_ObtenerProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_SeleccionProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGV_SeleccionProveedores;
        private System.Windows.Forms.Label Lbl_Busqueda;
        private System.Windows.Forms.TextBox Txb_BusquedaRapida;
    }
}