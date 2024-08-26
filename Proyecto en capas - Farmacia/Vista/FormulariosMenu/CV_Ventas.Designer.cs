namespace Vista.FormulariosMenu
{
    partial class CV_Ventas
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
            this.DTGV_Ventas = new System.Windows.Forms.DataGridView();
            this.Txb_UserName = new System.Windows.Forms.TextBox();
            this.Txb_BusquedaRapida = new System.Windows.Forms.TextBox();
            this.Nud_Cantidad = new System.Windows.Forms.NumericUpDown();
            this.Btn_AgregarCompra = new System.Windows.Forms.Button();
            this.Btn_EliminardeCompra = new System.Windows.Forms.Button();
            this.Btn_FinalizarCompra = new System.Windows.Forms.Button();
            this.DTGV_Carrito = new System.Windows.Forms.DataGridView();
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Lbl_Cantidad = new System.Windows.Forms.Label();
            this.Lbl_Cliente = new System.Windows.Forms.Label();
            this.Txb_Cliente = new System.Windows.Forms.TextBox();
            this.Lbl_Fecha = new System.Windows.Forms.Label();
            this.Lbl_Total = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Ventas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Cantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Carrito)).BeginInit();
            this.SuspendLayout();
            // 
            // DTGV_Ventas
            // 
            this.DTGV_Ventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_Ventas.Location = new System.Drawing.Point(12, 64);
            this.DTGV_Ventas.Name = "DTGV_Ventas";
            this.DTGV_Ventas.RowHeadersWidth = 51;
            this.DTGV_Ventas.RowTemplate.Height = 24;
            this.DTGV_Ventas.Size = new System.Drawing.Size(1430, 285);
            this.DTGV_Ventas.TabIndex = 20;
            // 
            // Txb_UserName
            // 
            this.Txb_UserName.Location = new System.Drawing.Point(94, 24);
            this.Txb_UserName.Name = "Txb_UserName";
            this.Txb_UserName.Size = new System.Drawing.Size(100, 22);
            this.Txb_UserName.TabIndex = 0;
            // 
            // Txb_BusquedaRapida
            // 
            this.Txb_BusquedaRapida.Location = new System.Drawing.Point(597, 24);
            this.Txb_BusquedaRapida.Name = "Txb_BusquedaRapida";
            this.Txb_BusquedaRapida.Size = new System.Drawing.Size(100, 22);
            this.Txb_BusquedaRapida.TabIndex = 1;
            this.Txb_BusquedaRapida.TextChanged += new System.EventHandler(this.Txb_BusquedaRapida_TextChanged);
            // 
            // Nud_Cantidad
            // 
            this.Nud_Cantidad.Location = new System.Drawing.Point(1508, 200);
            this.Nud_Cantidad.Name = "Nud_Cantidad";
            this.Nud_Cantidad.Size = new System.Drawing.Size(94, 22);
            this.Nud_Cantidad.TabIndex = 3;
            // 
            // Btn_AgregarCompra
            // 
            this.Btn_AgregarCompra.Location = new System.Drawing.Point(1508, 256);
            this.Btn_AgregarCompra.Name = "Btn_AgregarCompra";
            this.Btn_AgregarCompra.Size = new System.Drawing.Size(94, 55);
            this.Btn_AgregarCompra.TabIndex = 4;
            this.Btn_AgregarCompra.Text = "Agregar a la compra";
            this.Btn_AgregarCompra.UseVisualStyleBackColor = true;
            this.Btn_AgregarCompra.Click += new System.EventHandler(this.Btn_AgregarCompra_Click);
            // 
            // Btn_EliminardeCompra
            // 
            this.Btn_EliminardeCompra.Location = new System.Drawing.Point(1508, 351);
            this.Btn_EliminardeCompra.Name = "Btn_EliminardeCompra";
            this.Btn_EliminardeCompra.Size = new System.Drawing.Size(94, 55);
            this.Btn_EliminardeCompra.TabIndex = 5;
            this.Btn_EliminardeCompra.Text = "Eliminar de la compra";
            this.Btn_EliminardeCompra.UseVisualStyleBackColor = true;
            this.Btn_EliminardeCompra.Click += new System.EventHandler(this.Btn_EliminardeCompra_Click);
            // 
            // Btn_FinalizarCompra
            // 
            this.Btn_FinalizarCompra.Location = new System.Drawing.Point(1508, 466);
            this.Btn_FinalizarCompra.Name = "Btn_FinalizarCompra";
            this.Btn_FinalizarCompra.Size = new System.Drawing.Size(94, 55);
            this.Btn_FinalizarCompra.TabIndex = 6;
            this.Btn_FinalizarCompra.Text = "Finalizar Compra";
            this.Btn_FinalizarCompra.UseVisualStyleBackColor = true;
            this.Btn_FinalizarCompra.Click += new System.EventHandler(this.Btn_FinalizarCompra_Click);
            // 
            // DTGV_Carrito
            // 
            this.DTGV_Carrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_Carrito.Location = new System.Drawing.Point(12, 435);
            this.DTGV_Carrito.Name = "DTGV_Carrito";
            this.DTGV_Carrito.RowHeadersWidth = 51;
            this.DTGV_Carrito.RowTemplate.Height = 24;
            this.DTGV_Carrito.Size = new System.Drawing.Size(1430, 236);
            this.DTGV_Carrito.TabIndex = 24;
            // 
            // Lbl_Usuario
            // 
            this.Lbl_Usuario.AutoSize = true;
            this.Lbl_Usuario.Location = new System.Drawing.Point(21, 27);
            this.Lbl_Usuario.Name = "Lbl_Usuario";
            this.Lbl_Usuario.Size = new System.Drawing.Size(54, 16);
            this.Lbl_Usuario.TabIndex = 25;
            this.Lbl_Usuario.Text = "Usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(452, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Busqueda Rapida";
            // 
            // Lbl_Cantidad
            // 
            this.Lbl_Cantidad.AutoSize = true;
            this.Lbl_Cantidad.Location = new System.Drawing.Point(1505, 159);
            this.Lbl_Cantidad.Name = "Lbl_Cantidad";
            this.Lbl_Cantidad.Size = new System.Drawing.Size(61, 16);
            this.Lbl_Cantidad.TabIndex = 27;
            this.Lbl_Cantidad.Text = "Cantidad";
            // 
            // Lbl_Cliente
            // 
            this.Lbl_Cliente.AutoSize = true;
            this.Lbl_Cliente.Location = new System.Drawing.Point(815, 27);
            this.Lbl_Cliente.Name = "Lbl_Cliente";
            this.Lbl_Cliente.Size = new System.Drawing.Size(48, 16);
            this.Lbl_Cliente.TabIndex = 29;
            this.Lbl_Cliente.Text = "Cliente";
            // 
            // Txb_Cliente
            // 
            this.Txb_Cliente.Location = new System.Drawing.Point(960, 24);
            this.Txb_Cliente.Name = "Txb_Cliente";
            this.Txb_Cliente.Size = new System.Drawing.Size(100, 22);
            this.Txb_Cliente.TabIndex = 2;
            // 
            // Lbl_Fecha
            // 
            this.Lbl_Fecha.AutoSize = true;
            this.Lbl_Fecha.Location = new System.Drawing.Point(1260, 26);
            this.Lbl_Fecha.Name = "Lbl_Fecha";
            this.Lbl_Fecha.Size = new System.Drawing.Size(45, 16);
            this.Lbl_Fecha.TabIndex = 30;
            this.Lbl_Fecha.Text = "Fecha";
            // 
            // Lbl_Total
            // 
            this.Lbl_Total.AutoSize = true;
            this.Lbl_Total.Location = new System.Drawing.Point(1476, 546);
            this.Lbl_Total.Name = "Lbl_Total";
            this.Lbl_Total.Size = new System.Drawing.Size(126, 16);
            this.Lbl_Total.TabIndex = 31;
            this.Lbl_Total.Text = "Total de la compra: ";
            // 
            // CV_Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 751);
            this.Controls.Add(this.Lbl_Total);
            this.Controls.Add(this.Lbl_Fecha);
            this.Controls.Add(this.Lbl_Cliente);
            this.Controls.Add(this.Txb_Cliente);
            this.Controls.Add(this.Lbl_Cantidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lbl_Usuario);
            this.Controls.Add(this.DTGV_Carrito);
            this.Controls.Add(this.Btn_FinalizarCompra);
            this.Controls.Add(this.Btn_EliminardeCompra);
            this.Controls.Add(this.Btn_AgregarCompra);
            this.Controls.Add(this.Nud_Cantidad);
            this.Controls.Add(this.Txb_BusquedaRapida);
            this.Controls.Add(this.Txb_UserName);
            this.Controls.Add(this.DTGV_Ventas);
            this.Name = "CV_Ventas";
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.CV_Ventas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Ventas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Cantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Carrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGV_Ventas;
        private System.Windows.Forms.TextBox Txb_UserName;
        private System.Windows.Forms.TextBox Txb_BusquedaRapida;
        private System.Windows.Forms.NumericUpDown Nud_Cantidad;
        private System.Windows.Forms.Button Btn_AgregarCompra;
        private System.Windows.Forms.Button Btn_EliminardeCompra;
        private System.Windows.Forms.Button Btn_FinalizarCompra;
        private System.Windows.Forms.DataGridView DTGV_Carrito;
        private System.Windows.Forms.Label Lbl_Usuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lbl_Cantidad;
        private System.Windows.Forms.Label Lbl_Cliente;
        private System.Windows.Forms.TextBox Txb_Cliente;
        private System.Windows.Forms.Label Lbl_Fecha;
        private System.Windows.Forms.Label Lbl_Total;
    }
}