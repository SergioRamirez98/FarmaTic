namespace Vista.FormulariosMenu
{
    partial class CV_GestionOrdenDeCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CV_GestionOrdenDeCompra));
            this.DTGV_Pedidos = new System.Windows.Forms.DataGridView();
            this.Btn_ConfTotal = new System.Windows.Forms.Button();
            this.Btn_Descartar = new System.Windows.Forms.Button();
            this.Btn_Historial = new System.Windows.Forms.Button();
            this.DTGV_OC = new System.Windows.Forms.DataGridView();
            this.Lbl_Total = new System.Windows.Forms.Label();
            this.Btn_Refrescar = new System.Windows.Forms.Button();
            this.Txb_Buscar = new System.Windows.Forms.TextBox();
            this.Pnl_Total = new System.Windows.Forms.Panel();
            this.Pnl_OCdetallada = new System.Windows.Forms.Panel();
            this.Lbl_Oc_Detallada = new System.Windows.Forms.Label();
            this.Pnl_OC = new System.Windows.Forms.Panel();
            this.Lbl_OC = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Pedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_OC)).BeginInit();
            this.Pnl_Total.SuspendLayout();
            this.Pnl_OCdetallada.SuspendLayout();
            this.Pnl_OC.SuspendLayout();
            this.SuspendLayout();
            // 
            // DTGV_Pedidos
            // 
            this.DTGV_Pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_Pedidos.Location = new System.Drawing.Point(316, 68);
            this.DTGV_Pedidos.Name = "DTGV_Pedidos";
            this.DTGV_Pedidos.RowHeadersWidth = 51;
            this.DTGV_Pedidos.RowTemplate.Height = 24;
            this.DTGV_Pedidos.Size = new System.Drawing.Size(725, 280);
            this.DTGV_Pedidos.TabIndex = 0;
            this.DTGV_Pedidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_Pedidos_CellClick);
            // 
            // Btn_ConfTotal
            // 
            this.Btn_ConfTotal.Location = new System.Drawing.Point(90, 94);
            this.Btn_ConfTotal.Name = "Btn_ConfTotal";
            this.Btn_ConfTotal.Size = new System.Drawing.Size(114, 45);
            this.Btn_ConfTotal.TabIndex = 1;
            this.Btn_ConfTotal.Text = "Confirmar OC";
            this.Btn_ConfTotal.UseVisualStyleBackColor = true;
            this.Btn_ConfTotal.Click += new System.EventHandler(this.Btn_Confirmar_Click);
            // 
            // Btn_Descartar
            // 
            this.Btn_Descartar.Location = new System.Drawing.Point(90, 154);
            this.Btn_Descartar.Name = "Btn_Descartar";
            this.Btn_Descartar.Size = new System.Drawing.Size(114, 45);
            this.Btn_Descartar.TabIndex = 2;
            this.Btn_Descartar.Text = "Descartar OC";
            this.Btn_Descartar.UseVisualStyleBackColor = true;
            this.Btn_Descartar.Click += new System.EventHandler(this.Btn_Descartar_Click);
            // 
            // Btn_Historial
            // 
            this.Btn_Historial.Location = new System.Drawing.Point(90, 209);
            this.Btn_Historial.Name = "Btn_Historial";
            this.Btn_Historial.Size = new System.Drawing.Size(114, 45);
            this.Btn_Historial.TabIndex = 6;
            this.Btn_Historial.Text = "Historial";
            this.Btn_Historial.UseVisualStyleBackColor = true;
            this.Btn_Historial.Click += new System.EventHandler(this.Btn_Historial_Click);
            // 
            // DTGV_OC
            // 
            this.DTGV_OC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_OC.Location = new System.Drawing.Point(34, 418);
            this.DTGV_OC.Name = "DTGV_OC";
            this.DTGV_OC.RowHeadersWidth = 51;
            this.DTGV_OC.RowTemplate.Height = 24;
            this.DTGV_OC.Size = new System.Drawing.Size(1468, 230);
            this.DTGV_OC.TabIndex = 5;
            this.DTGV_OC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_OC_CellContentClick);
            // 
            // Lbl_Total
            // 
            this.Lbl_Total.AutoSize = true;
            this.Lbl_Total.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.Lbl_Total.Location = new System.Drawing.Point(29, 17);
            this.Lbl_Total.Name = "Lbl_Total";
            this.Lbl_Total.Size = new System.Drawing.Size(285, 23);
            this.Lbl_Total.TabIndex = 6;
            this.Lbl_Total.Text = "El total de la órden de compra es: ";
            // 
            // Btn_Refrescar
            // 
            this.Btn_Refrescar.Location = new System.Drawing.Point(90, 274);
            this.Btn_Refrescar.Name = "Btn_Refrescar";
            this.Btn_Refrescar.Size = new System.Drawing.Size(114, 45);
            this.Btn_Refrescar.TabIndex = 4;
            this.Btn_Refrescar.Text = "Refrescar";
            this.Btn_Refrescar.UseVisualStyleBackColor = true;
            this.Btn_Refrescar.Click += new System.EventHandler(this.Btn_Refrescar_Click);
            // 
            // Txb_Buscar
            // 
            this.Txb_Buscar.Location = new System.Drawing.Point(90, 27);
            this.Txb_Buscar.Name = "Txb_Buscar";
            this.Txb_Buscar.Size = new System.Drawing.Size(114, 22);
            this.Txb_Buscar.TabIndex = 7;
            this.Txb_Buscar.Text = "Buscar";
            this.Txb_Buscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txb_Buscar.Click += new System.EventHandler(this.Txb_Buscar_Click);
            this.Txb_Buscar.TextChanged += new System.EventHandler(this.Txb_Buscar_TextChanged);
            // 
            // Pnl_Total
            // 
            this.Pnl_Total.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Pnl_Total.Controls.Add(this.Lbl_Total);
            this.Pnl_Total.Location = new System.Drawing.Point(34, 649);
            this.Pnl_Total.Name = "Pnl_Total";
            this.Pnl_Total.Size = new System.Drawing.Size(1468, 51);
            this.Pnl_Total.TabIndex = 8;
            // 
            // Pnl_OCdetallada
            // 
            this.Pnl_OCdetallada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Pnl_OCdetallada.Controls.Add(this.Lbl_Oc_Detallada);
            this.Pnl_OCdetallada.Location = new System.Drawing.Point(34, 366);
            this.Pnl_OCdetallada.Name = "Pnl_OCdetallada";
            this.Pnl_OCdetallada.Size = new System.Drawing.Size(1468, 51);
            this.Pnl_OCdetallada.TabIndex = 9;
            // 
            // Lbl_Oc_Detallada
            // 
            this.Lbl_Oc_Detallada.AutoSize = true;
            this.Lbl_Oc_Detallada.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.Lbl_Oc_Detallada.Location = new System.Drawing.Point(29, 17);
            this.Lbl_Oc_Detallada.Name = "Lbl_Oc_Detallada";
            this.Lbl_Oc_Detallada.Size = new System.Drawing.Size(254, 23);
            this.Lbl_Oc_Detallada.TabIndex = 6;
            this.Lbl_Oc_Detallada.Text = "Detalle de la orden de compra";
            // 
            // Pnl_OC
            // 
            this.Pnl_OC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Pnl_OC.Controls.Add(this.Lbl_OC);
            this.Pnl_OC.Location = new System.Drawing.Point(316, 16);
            this.Pnl_OC.Name = "Pnl_OC";
            this.Pnl_OC.Size = new System.Drawing.Size(725, 51);
            this.Pnl_OC.TabIndex = 10;
            // 
            // Lbl_OC
            // 
            this.Lbl_OC.AutoSize = true;
            this.Lbl_OC.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.Lbl_OC.Location = new System.Drawing.Point(29, 17);
            this.Lbl_OC.Name = "Lbl_OC";
            this.Lbl_OC.Size = new System.Drawing.Size(167, 23);
            this.Lbl_OC.TabIndex = 6;
            this.Lbl_OC.Text = "Órdenes de compra";
            // 
            // CV_GestionOrdenDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1543, 748);
            this.Controls.Add(this.Pnl_OC);
            this.Controls.Add(this.Pnl_OCdetallada);
            this.Controls.Add(this.Pnl_Total);
            this.Controls.Add(this.Txb_Buscar);
            this.Controls.Add(this.Btn_Refrescar);
            this.Controls.Add(this.DTGV_OC);
            this.Controls.Add(this.Btn_Historial);
            this.Controls.Add(this.Btn_Descartar);
            this.Controls.Add(this.Btn_ConfTotal);
            this.Controls.Add(this.DTGV_Pedidos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CV_GestionOrdenDeCompra";
            this.Text = "Órden de compra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CV_OrdenDeCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Pedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_OC)).EndInit();
            this.Pnl_Total.ResumeLayout(false);
            this.Pnl_Total.PerformLayout();
            this.Pnl_OCdetallada.ResumeLayout(false);
            this.Pnl_OCdetallada.PerformLayout();
            this.Pnl_OC.ResumeLayout(false);
            this.Pnl_OC.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGV_Pedidos;
        private System.Windows.Forms.Button Btn_ConfTotal;
        private System.Windows.Forms.Button Btn_Descartar;
        private System.Windows.Forms.Button Btn_Historial;
        private System.Windows.Forms.DataGridView DTGV_OC;
        private System.Windows.Forms.Label Lbl_Total;
        private System.Windows.Forms.Button Btn_Refrescar;
        private System.Windows.Forms.TextBox Txb_Buscar;
        private System.Windows.Forms.Panel Pnl_Total;
        private System.Windows.Forms.Panel Pnl_OCdetallada;
        private System.Windows.Forms.Label Lbl_Oc_Detallada;
        private System.Windows.Forms.Panel Pnl_OC;
        private System.Windows.Forms.Label Lbl_OC;
    }
}