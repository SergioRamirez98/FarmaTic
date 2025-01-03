﻿namespace Vista.FormulariosMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CV_Ventas));
            this.DTGV_Ventas = new System.Windows.Forms.DataGridView();
            this.Txb_UserName = new System.Windows.Forms.TextBox();
            this.Txb_BusquedaRapida = new System.Windows.Forms.TextBox();
            this.Nud_Cantidad = new System.Windows.Forms.NumericUpDown();
            this.Btn_AgregarCompra = new System.Windows.Forms.Button();
            this.Btn_EliminardeCompra = new System.Windows.Forms.Button();
            this.Btn_FinalizarCompra = new System.Windows.Forms.Button();
            this.DTGV_Carrito = new System.Windows.Forms.DataGridView();
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            this.Lbl_BusquedaRapida = new System.Windows.Forms.Label();
            this.Lbl_Cantidad = new System.Windows.Forms.Label();
            this.Txb_Cliente = new System.Windows.Forms.TextBox();
            this.Lbl_Fecha = new System.Windows.Forms.Label();
            this.Lbl_Total = new System.Windows.Forms.Label();
            this.Btn_BuscarCliente = new System.Windows.Forms.Button();
            this.Btn_Consultar = new System.Windows.Forms.Button();
            this.Btn_CrearCliente = new System.Windows.Forms.Button();
            this.Pnl_Total = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Ventas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Cantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Carrito)).BeginInit();
            this.Pnl_Total.SuspendLayout();
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
            this.Txb_BusquedaRapida.Location = new System.Drawing.Point(507, 23);
            this.Txb_BusquedaRapida.Name = "Txb_BusquedaRapida";
            this.Txb_BusquedaRapida.Size = new System.Drawing.Size(100, 22);
            this.Txb_BusquedaRapida.TabIndex = 1;
            this.Txb_BusquedaRapida.TextChanged += new System.EventHandler(this.Txb_BusquedaRapida_TextChanged);
            // 
            // Nud_Cantidad
            // 
            this.Nud_Cantidad.Location = new System.Drawing.Point(1448, 200);
            this.Nud_Cantidad.Name = "Nud_Cantidad";
            this.Nud_Cantidad.Size = new System.Drawing.Size(94, 22);
            this.Nud_Cantidad.TabIndex = 4;
            // 
            // Btn_AgregarCompra
            // 
            this.Btn_AgregarCompra.Location = new System.Drawing.Point(1448, 256);
            this.Btn_AgregarCompra.Name = "Btn_AgregarCompra";
            this.Btn_AgregarCompra.Size = new System.Drawing.Size(104, 45);
            this.Btn_AgregarCompra.TabIndex = 5;
            this.Btn_AgregarCompra.Text = "Agregar a la compra";
            this.Btn_AgregarCompra.UseVisualStyleBackColor = true;
            this.Btn_AgregarCompra.Click += new System.EventHandler(this.Btn_AgregarCompra_Click);
            // 
            // Btn_EliminardeCompra
            // 
            this.Btn_EliminardeCompra.Location = new System.Drawing.Point(1448, 475);
            this.Btn_EliminardeCompra.Name = "Btn_EliminardeCompra";
            this.Btn_EliminardeCompra.Size = new System.Drawing.Size(104, 45);
            this.Btn_EliminardeCompra.TabIndex = 6;
            this.Btn_EliminardeCompra.Text = "Eliminar de la compra";
            this.Btn_EliminardeCompra.UseVisualStyleBackColor = true;
            this.Btn_EliminardeCompra.Click += new System.EventHandler(this.Btn_EliminardeCompra_Click);
            // 
            // Btn_FinalizarCompra
            // 
            this.Btn_FinalizarCompra.Location = new System.Drawing.Point(1448, 590);
            this.Btn_FinalizarCompra.Name = "Btn_FinalizarCompra";
            this.Btn_FinalizarCompra.Size = new System.Drawing.Size(104, 45);
            this.Btn_FinalizarCompra.TabIndex = 7;
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
            // Lbl_BusquedaRapida
            // 
            this.Lbl_BusquedaRapida.AutoSize = true;
            this.Lbl_BusquedaRapida.Location = new System.Drawing.Point(362, 26);
            this.Lbl_BusquedaRapida.Name = "Lbl_BusquedaRapida";
            this.Lbl_BusquedaRapida.Size = new System.Drawing.Size(117, 16);
            this.Lbl_BusquedaRapida.TabIndex = 26;
            this.Lbl_BusquedaRapida.Text = "Busqueda Rapida";
            // 
            // Lbl_Cantidad
            // 
            this.Lbl_Cantidad.AutoSize = true;
            this.Lbl_Cantidad.Location = new System.Drawing.Point(1445, 159);
            this.Lbl_Cantidad.Name = "Lbl_Cantidad";
            this.Lbl_Cantidad.Size = new System.Drawing.Size(61, 16);
            this.Lbl_Cantidad.TabIndex = 27;
            this.Lbl_Cantidad.Text = "Cantidad";
            // 
            // Txb_Cliente
            // 
            this.Txb_Cliente.Location = new System.Drawing.Point(870, 23);
            this.Txb_Cliente.Name = "Txb_Cliente";
            this.Txb_Cliente.Size = new System.Drawing.Size(177, 22);
            this.Txb_Cliente.TabIndex = 2;
            // 
            // Lbl_Fecha
            // 
            this.Lbl_Fecha.AutoSize = true;
            this.Lbl_Fecha.Location = new System.Drawing.Point(1243, 30);
            this.Lbl_Fecha.Name = "Lbl_Fecha";
            this.Lbl_Fecha.Size = new System.Drawing.Size(45, 16);
            this.Lbl_Fecha.TabIndex = 30;
            this.Lbl_Fecha.Text = "Fecha";
            // 
            // Lbl_Total
            // 
            this.Lbl_Total.AutoSize = true;
            this.Lbl_Total.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Total.Location = new System.Drawing.Point(7, 8);
            this.Lbl_Total.Name = "Lbl_Total";
            this.Lbl_Total.Size = new System.Drawing.Size(169, 23);
            this.Lbl_Total.TabIndex = 31;
            this.Lbl_Total.Text = "Total de la compra: ";
            // 
            // Btn_BuscarCliente
            // 
            this.Btn_BuscarCliente.Location = new System.Drawing.Point(735, 23);
            this.Btn_BuscarCliente.Name = "Btn_BuscarCliente";
            this.Btn_BuscarCliente.Size = new System.Drawing.Size(111, 23);
            this.Btn_BuscarCliente.TabIndex = 2;
            this.Btn_BuscarCliente.Text = "Buscar Cliente";
            this.Btn_BuscarCliente.UseVisualStyleBackColor = true;
            this.Btn_BuscarCliente.Click += new System.EventHandler(this.Btn_BuscarCliente_Click);
            // 
            // Btn_Consultar
            // 
            this.Btn_Consultar.Location = new System.Drawing.Point(1448, 64);
            this.Btn_Consultar.Name = "Btn_Consultar";
            this.Btn_Consultar.Size = new System.Drawing.Size(104, 40);
            this.Btn_Consultar.TabIndex = 3;
            this.Btn_Consultar.Text = "Consultar ventas";
            this.Btn_Consultar.UseVisualStyleBackColor = true;
            this.Btn_Consultar.Click += new System.EventHandler(this.Btn_Consultar_Click);
            // 
            // Btn_CrearCliente
            // 
            this.Btn_CrearCliente.Location = new System.Drawing.Point(1072, 23);
            this.Btn_CrearCliente.Name = "Btn_CrearCliente";
            this.Btn_CrearCliente.Size = new System.Drawing.Size(134, 23);
            this.Btn_CrearCliente.TabIndex = 32;
            this.Btn_CrearCliente.Text = "Dar de alta cliente";
            this.Btn_CrearCliente.UseVisualStyleBackColor = true;
            this.Btn_CrearCliente.Click += new System.EventHandler(this.Btn_CrearCliente_Click);
            // 
            // Pnl_Total
            // 
            this.Pnl_Total.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Pnl_Total.Controls.Add(this.Lbl_Total);
            this.Pnl_Total.Location = new System.Drawing.Point(12, 672);
            this.Pnl_Total.Name = "Pnl_Total";
            this.Pnl_Total.Size = new System.Drawing.Size(1430, 37);
            this.Pnl_Total.TabIndex = 33;
            // 
            // CV_Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1656, 751);
            this.Controls.Add(this.Pnl_Total);
            this.Controls.Add(this.Btn_CrearCliente);
            this.Controls.Add(this.Btn_Consultar);
            this.Controls.Add(this.Btn_BuscarCliente);
            this.Controls.Add(this.Lbl_Fecha);
            this.Controls.Add(this.Txb_Cliente);
            this.Controls.Add(this.Lbl_Cantidad);
            this.Controls.Add(this.Lbl_BusquedaRapida);
            this.Controls.Add(this.Lbl_Usuario);
            this.Controls.Add(this.DTGV_Carrito);
            this.Controls.Add(this.Btn_FinalizarCompra);
            this.Controls.Add(this.Btn_EliminardeCompra);
            this.Controls.Add(this.Btn_AgregarCompra);
            this.Controls.Add(this.Nud_Cantidad);
            this.Controls.Add(this.Txb_BusquedaRapida);
            this.Controls.Add(this.Txb_UserName);
            this.Controls.Add(this.DTGV_Ventas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CV_Ventas";
            this.Text = "Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CV_Ventas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Ventas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Cantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Carrito)).EndInit();
            this.Pnl_Total.ResumeLayout(false);
            this.Pnl_Total.PerformLayout();
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
        private System.Windows.Forms.Label Lbl_BusquedaRapida;
        private System.Windows.Forms.Label Lbl_Cantidad;
        private System.Windows.Forms.TextBox Txb_Cliente;
        private System.Windows.Forms.Label Lbl_Fecha;
        private System.Windows.Forms.Label Lbl_Total;
        private System.Windows.Forms.Button Btn_BuscarCliente;
        private System.Windows.Forms.Button Btn_Consultar;
        private System.Windows.Forms.Button Btn_CrearCliente;
        private System.Windows.Forms.Panel Pnl_Total;
    }
}