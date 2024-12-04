namespace Vista
{
    partial class CV_ObtenerClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CV_ObtenerClientes));
            this.DTGV_Clientes = new System.Windows.Forms.DataGridView();
            this.Txb_BuscarCliente = new System.Windows.Forms.TextBox();
            this.Lbl_BuscarCliente = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // DTGV_Clientes
            // 
            this.DTGV_Clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_Clientes.Location = new System.Drawing.Point(36, 100);
            this.DTGV_Clientes.Name = "DTGV_Clientes";
            this.DTGV_Clientes.RowHeadersWidth = 51;
            this.DTGV_Clientes.RowTemplate.Height = 24;
            this.DTGV_Clientes.Size = new System.Drawing.Size(772, 150);
            this.DTGV_Clientes.TabIndex = 0;
            this.DTGV_Clientes.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_Clientes_CellContentDoubleClick);
            this.DTGV_Clientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTGV_Clientes_KeyDown);
            // 
            // Txb_BuscarCliente
            // 
            this.Txb_BuscarCliente.Location = new System.Drawing.Point(336, 44);
            this.Txb_BuscarCliente.Name = "Txb_BuscarCliente";
            this.Txb_BuscarCliente.Size = new System.Drawing.Size(100, 22);
            this.Txb_BuscarCliente.TabIndex = 1;
            this.Txb_BuscarCliente.TextChanged += new System.EventHandler(this.Txb_BuscarCliente_TextChanged);
            // 
            // Lbl_BuscarCliente
            // 
            this.Lbl_BuscarCliente.AutoSize = true;
            this.Lbl_BuscarCliente.Location = new System.Drawing.Point(258, 47);
            this.Lbl_BuscarCliente.Name = "Lbl_BuscarCliente";
            this.Lbl_BuscarCliente.Size = new System.Drawing.Size(49, 16);
            this.Lbl_BuscarCliente.TabIndex = 2;
            this.Lbl_BuscarCliente.Text = "Buscar";
            // 
            // CV_ObtenerClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(865, 315);
            this.Controls.Add(this.Lbl_BuscarCliente);
            this.Controls.Add(this.Txb_BuscarCliente);
            this.Controls.Add(this.DTGV_Clientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CV_ObtenerClientes";
            this.Text = "Seleccion el cliente";
            this.Load += new System.EventHandler(this.CV_ObtenerClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Clientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGV_Clientes;
        private System.Windows.Forms.TextBox Txb_BuscarCliente;
        private System.Windows.Forms.Label Lbl_BuscarCliente;
    }
}