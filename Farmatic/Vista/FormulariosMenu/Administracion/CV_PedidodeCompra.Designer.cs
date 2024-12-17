namespace Vista.FormulariosMenu
{
    partial class CV_PedidodeCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CV_PedidodeCompra));
            this.DTGV_Catalogo = new System.Windows.Forms.DataGridView();
            this.Lbl_Cantidad = new System.Windows.Forms.Label();
            this.Btn_FinalizarPedido = new System.Windows.Forms.Button();
            this.Btn_EliminardePedido = new System.Windows.Forms.Button();
            this.Btn_AgregarAlPedido = new System.Windows.Forms.Button();
            this.Nud_Cantidad = new System.Windows.Forms.NumericUpDown();
            this.DTGV_PedidodeCompra = new System.Windows.Forms.DataGridView();
            this.Lbl_BusqCatalogo = new System.Windows.Forms.Label();
            this.Txb_BusqCatalogo = new System.Windows.Forms.TextBox();
            this.Pnl_Catalogo = new System.Windows.Forms.Panel();
            this.Lbl_Catalogo = new System.Windows.Forms.Label();
            this.Pnl_Carrito = new System.Windows.Forms.Panel();
            this.Lbl_CarritoPC = new System.Windows.Forms.Label();
            this.Btn_Refrescar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Catalogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Cantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_PedidodeCompra)).BeginInit();
            this.Pnl_Catalogo.SuspendLayout();
            this.Pnl_Carrito.SuspendLayout();
            this.SuspendLayout();
            // 
            // DTGV_Catalogo
            // 
            this.DTGV_Catalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_Catalogo.Location = new System.Drawing.Point(23, 81);
            this.DTGV_Catalogo.Name = "DTGV_Catalogo";
            this.DTGV_Catalogo.RowHeadersWidth = 51;
            this.DTGV_Catalogo.RowTemplate.Height = 24;
            this.DTGV_Catalogo.Size = new System.Drawing.Size(1286, 369);
            this.DTGV_Catalogo.TabIndex = 54;
            this.DTGV_Catalogo.SelectionChanged += new System.EventHandler(this.DTGV_Catalogo_SelectionChanged);
            // 
            // Lbl_Cantidad
            // 
            this.Lbl_Cantidad.AutoSize = true;
            this.Lbl_Cantidad.Location = new System.Drawing.Point(1330, 156);
            this.Lbl_Cantidad.Name = "Lbl_Cantidad";
            this.Lbl_Cantidad.Size = new System.Drawing.Size(61, 16);
            this.Lbl_Cantidad.TabIndex = 59;
            this.Lbl_Cantidad.Text = "Cantidad";
            // 
            // Btn_FinalizarPedido
            // 
            this.Btn_FinalizarPedido.Location = new System.Drawing.Point(1333, 619);
            this.Btn_FinalizarPedido.Name = "Btn_FinalizarPedido";
            this.Btn_FinalizarPedido.Size = new System.Drawing.Size(94, 55);
            this.Btn_FinalizarPedido.TabIndex = 58;
            this.Btn_FinalizarPedido.Text = "Finalizar Pedido";
            this.Btn_FinalizarPedido.UseVisualStyleBackColor = true;
            this.Btn_FinalizarPedido.Click += new System.EventHandler(this.Btn_FinalizarPedido_Click);
            // 
            // Btn_EliminardePedido
            // 
            this.Btn_EliminardePedido.Location = new System.Drawing.Point(1333, 522);
            this.Btn_EliminardePedido.Name = "Btn_EliminardePedido";
            this.Btn_EliminardePedido.Size = new System.Drawing.Size(94, 55);
            this.Btn_EliminardePedido.TabIndex = 57;
            this.Btn_EliminardePedido.Text = "Eliminar del pedido";
            this.Btn_EliminardePedido.UseVisualStyleBackColor = true;
            this.Btn_EliminardePedido.Click += new System.EventHandler(this.Btn_EliminardePedido_Click);
            // 
            // Btn_AgregarAlPedido
            // 
            this.Btn_AgregarAlPedido.Location = new System.Drawing.Point(1333, 225);
            this.Btn_AgregarAlPedido.Name = "Btn_AgregarAlPedido";
            this.Btn_AgregarAlPedido.Size = new System.Drawing.Size(94, 55);
            this.Btn_AgregarAlPedido.TabIndex = 56;
            this.Btn_AgregarAlPedido.Text = "Agregar al pedido";
            this.Btn_AgregarAlPedido.UseVisualStyleBackColor = true;
            this.Btn_AgregarAlPedido.Click += new System.EventHandler(this.Btn_AgregarAlPedido_Click);
            // 
            // Nud_Cantidad
            // 
            this.Nud_Cantidad.Location = new System.Drawing.Point(1333, 175);
            this.Nud_Cantidad.Name = "Nud_Cantidad";
            this.Nud_Cantidad.Size = new System.Drawing.Size(94, 22);
            this.Nud_Cantidad.TabIndex = 55;
            // 
            // DTGV_PedidodeCompra
            // 
            this.DTGV_PedidodeCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_PedidodeCompra.Location = new System.Drawing.Point(23, 522);
            this.DTGV_PedidodeCompra.Name = "DTGV_PedidodeCompra";
            this.DTGV_PedidodeCompra.RowHeadersWidth = 51;
            this.DTGV_PedidodeCompra.RowTemplate.Height = 24;
            this.DTGV_PedidodeCompra.Size = new System.Drawing.Size(1286, 331);
            this.DTGV_PedidodeCompra.TabIndex = 60;
            // 
            // Lbl_BusqCatalogo
            // 
            this.Lbl_BusqCatalogo.AutoSize = true;
            this.Lbl_BusqCatalogo.Location = new System.Drawing.Point(354, 13);
            this.Lbl_BusqCatalogo.Name = "Lbl_BusqCatalogo";
            this.Lbl_BusqCatalogo.Size = new System.Drawing.Size(125, 16);
            this.Lbl_BusqCatalogo.TabIndex = 61;
            this.Lbl_BusqCatalogo.Text = "Buscar en Catalogo";
            // 
            // Txb_BusqCatalogo
            // 
            this.Txb_BusqCatalogo.Location = new System.Drawing.Point(485, 10);
            this.Txb_BusqCatalogo.Name = "Txb_BusqCatalogo";
            this.Txb_BusqCatalogo.Size = new System.Drawing.Size(100, 22);
            this.Txb_BusqCatalogo.TabIndex = 1;
            this.Txb_BusqCatalogo.TextChanged += new System.EventHandler(this.Txb_BusqCatalogo_TextChanged);
            // 
            // Pnl_Catalogo
            // 
            this.Pnl_Catalogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Pnl_Catalogo.Controls.Add(this.Lbl_Catalogo);
            this.Pnl_Catalogo.Location = new System.Drawing.Point(23, 42);
            this.Pnl_Catalogo.Name = "Pnl_Catalogo";
            this.Pnl_Catalogo.Size = new System.Drawing.Size(1286, 37);
            this.Pnl_Catalogo.TabIndex = 62;
            // 
            // Lbl_Catalogo
            // 
            this.Lbl_Catalogo.AutoSize = true;
            this.Lbl_Catalogo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Catalogo.Location = new System.Drawing.Point(550, 8);
            this.Lbl_Catalogo.Name = "Lbl_Catalogo";
            this.Lbl_Catalogo.Size = new System.Drawing.Size(34, 23);
            this.Lbl_Catalogo.TabIndex = 31;
            this.Lbl_Catalogo.Text = "cat";
            // 
            // Pnl_Carrito
            // 
            this.Pnl_Carrito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Pnl_Carrito.Controls.Add(this.Lbl_CarritoPC);
            this.Pnl_Carrito.Location = new System.Drawing.Point(23, 484);
            this.Pnl_Carrito.Name = "Pnl_Carrito";
            this.Pnl_Carrito.Size = new System.Drawing.Size(1286, 37);
            this.Pnl_Carrito.TabIndex = 63;
            // 
            // Lbl_CarritoPC
            // 
            this.Lbl_CarritoPC.AutoSize = true;
            this.Lbl_CarritoPC.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CarritoPC.Location = new System.Drawing.Point(550, 8);
            this.Lbl_CarritoPC.Name = "Lbl_CarritoPC";
            this.Lbl_CarritoPC.Size = new System.Drawing.Size(71, 23);
            this.Lbl_CarritoPC.TabIndex = 31;
            this.Lbl_CarritoPC.Text = "Carrito ";
            // 
            // Btn_Refrescar
            // 
            this.Btn_Refrescar.Location = new System.Drawing.Point(1333, 65);
            this.Btn_Refrescar.Name = "Btn_Refrescar";
            this.Btn_Refrescar.Size = new System.Drawing.Size(87, 43);
            this.Btn_Refrescar.TabIndex = 64;
            this.Btn_Refrescar.Text = "Refrescar";
            this.Btn_Refrescar.UseVisualStyleBackColor = true;
            this.Btn_Refrescar.Click += new System.EventHandler(this.Btn_Refrescar_Click);
            // 
            // CV_PedidodeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1441, 904);
            this.Controls.Add(this.Btn_Refrescar);
            this.Controls.Add(this.Pnl_Catalogo);
            this.Controls.Add(this.Pnl_Carrito);
            this.Controls.Add(this.Txb_BusqCatalogo);
            this.Controls.Add(this.Lbl_BusqCatalogo);
            this.Controls.Add(this.DTGV_PedidodeCompra);
            this.Controls.Add(this.Lbl_Cantidad);
            this.Controls.Add(this.Btn_FinalizarPedido);
            this.Controls.Add(this.Btn_EliminardePedido);
            this.Controls.Add(this.Btn_AgregarAlPedido);
            this.Controls.Add(this.Nud_Cantidad);
            this.Controls.Add(this.DTGV_Catalogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CV_PedidodeCompra";
            this.Text = "Gestion de Pedidos de compra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CV_OrdendeCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Catalogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Cantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_PedidodeCompra)).EndInit();
            this.Pnl_Catalogo.ResumeLayout(false);
            this.Pnl_Catalogo.PerformLayout();
            this.Pnl_Carrito.ResumeLayout(false);
            this.Pnl_Carrito.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGV_Catalogo;
        private System.Windows.Forms.Label Lbl_Cantidad;
        private System.Windows.Forms.Button Btn_FinalizarPedido;
        private System.Windows.Forms.Button Btn_EliminardePedido;
        private System.Windows.Forms.Button Btn_AgregarAlPedido;
        private System.Windows.Forms.NumericUpDown Nud_Cantidad;
        private System.Windows.Forms.DataGridView DTGV_PedidodeCompra;
        private System.Windows.Forms.Label Lbl_BusqCatalogo;
        private System.Windows.Forms.TextBox Txb_BusqCatalogo;
        private System.Windows.Forms.Panel Pnl_Catalogo;
        private System.Windows.Forms.Label Lbl_Catalogo;
        private System.Windows.Forms.Panel Pnl_Carrito;
        private System.Windows.Forms.Label Lbl_CarritoPC;
        private System.Windows.Forms.Button Btn_Refrescar;
    }
}