namespace Vista
{
    partial class CV_ConsultaVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CV_ConsultaVentas));
            this.Txb_Cliente = new System.Windows.Forms.TextBox();
            this.Txb_PrecDesde = new System.Windows.Forms.TextBox();
            this.Txb_PrecHasta = new System.Windows.Forms.TextBox();
            this.Dtp_FeDesde = new System.Windows.Forms.DateTimePicker();
            this.Dtp_FeHasta = new System.Windows.Forms.DateTimePicker();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_Ver = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.DTGV_BusqVentas = new System.Windows.Forms.DataGridView();
            this.Lbl_Cliente = new System.Windows.Forms.Label();
            this.Lbl_PrecDesde = new System.Windows.Forms.Label();
            this.Lbl_PrecHasta = new System.Windows.Forms.Label();
            this.Lbl_FeDesde = new System.Windows.Forms.Label();
            this.Lbl_FeHasta = new System.Windows.Forms.Label();
            this.DTGV_VisualizadorVentas = new System.Windows.Forms.DataGridView();
            this.Pnl_VentaDetallada = new System.Windows.Forms.Panel();
            this.Lbl_VisorDetalle = new System.Windows.Forms.Label();
            this.Pnl_VentaGeneral = new System.Windows.Forms.Panel();
            this.Lbl_VentaGral = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_BusqVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_VisualizadorVentas)).BeginInit();
            this.Pnl_VentaDetallada.SuspendLayout();
            this.Pnl_VentaGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // Txb_Cliente
            // 
            this.Txb_Cliente.Location = new System.Drawing.Point(15, 53);
            this.Txb_Cliente.Name = "Txb_Cliente";
            this.Txb_Cliente.Size = new System.Drawing.Size(127, 22);
            this.Txb_Cliente.TabIndex = 0;
            // 
            // Txb_PrecDesde
            // 
            this.Txb_PrecDesde.Location = new System.Drawing.Point(15, 103);
            this.Txb_PrecDesde.Name = "Txb_PrecDesde";
            this.Txb_PrecDesde.Size = new System.Drawing.Size(127, 22);
            this.Txb_PrecDesde.TabIndex = 2;
            // 
            // Txb_PrecHasta
            // 
            this.Txb_PrecHasta.Location = new System.Drawing.Point(223, 103);
            this.Txb_PrecHasta.Name = "Txb_PrecHasta";
            this.Txb_PrecHasta.Size = new System.Drawing.Size(127, 22);
            this.Txb_PrecHasta.TabIndex = 3;
            // 
            // Dtp_FeDesde
            // 
            this.Dtp_FeDesde.CustomFormat = "dd/MM/yyyy";
            this.Dtp_FeDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_FeDesde.Location = new System.Drawing.Point(15, 160);
            this.Dtp_FeDesde.Name = "Dtp_FeDesde";
            this.Dtp_FeDesde.Size = new System.Drawing.Size(127, 22);
            this.Dtp_FeDesde.TabIndex = 4;
            // 
            // Dtp_FeHasta
            // 
            this.Dtp_FeHasta.CustomFormat = "dd/MM/yyyy";
            this.Dtp_FeHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_FeHasta.Location = new System.Drawing.Point(223, 161);
            this.Dtp_FeHasta.Name = "Dtp_FeHasta";
            this.Dtp_FeHasta.Size = new System.Drawing.Size(127, 22);
            this.Dtp_FeHasta.TabIndex = 5;
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(147, 197);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Buscar.TabIndex = 6;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_Ver
            // 
            this.Btn_Ver.Location = new System.Drawing.Point(1017, 134);
            this.Btn_Ver.Name = "Btn_Ver";
            this.Btn_Ver.Size = new System.Drawing.Size(75, 23);
            this.Btn_Ver.TabIndex = 7;
            this.Btn_Ver.Text = "Ver venta";
            this.Btn_Ver.UseVisualStyleBackColor = true;
            this.Btn_Ver.Click += new System.EventHandler(this.Btn_Ver_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Location = new System.Drawing.Point(1017, 174);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Eliminar.TabIndex = 8;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // DTGV_BusqVentas
            // 
            this.DTGV_BusqVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_BusqVentas.Location = new System.Drawing.Point(412, 103);
            this.DTGV_BusqVentas.Name = "DTGV_BusqVentas";
            this.DTGV_BusqVentas.RowHeadersWidth = 51;
            this.DTGV_BusqVentas.RowTemplate.Height = 24;
            this.DTGV_BusqVentas.Size = new System.Drawing.Size(575, 117);
            this.DTGV_BusqVentas.TabIndex = 9;
            // 
            // Lbl_Cliente
            // 
            this.Lbl_Cliente.AutoSize = true;
            this.Lbl_Cliente.Location = new System.Drawing.Point(12, 34);
            this.Lbl_Cliente.Name = "Lbl_Cliente";
            this.Lbl_Cliente.Size = new System.Drawing.Size(48, 16);
            this.Lbl_Cliente.TabIndex = 10;
            this.Lbl_Cliente.Text = "Cliente";
            // 
            // Lbl_PrecDesde
            // 
            this.Lbl_PrecDesde.AutoSize = true;
            this.Lbl_PrecDesde.Location = new System.Drawing.Point(12, 84);
            this.Lbl_PrecDesde.Name = "Lbl_PrecDesde";
            this.Lbl_PrecDesde.Size = new System.Drawing.Size(91, 16);
            this.Lbl_PrecDesde.TabIndex = 11;
            this.Lbl_PrecDesde.Text = "Precio desde:";
            // 
            // Lbl_PrecHasta
            // 
            this.Lbl_PrecHasta.AutoSize = true;
            this.Lbl_PrecHasta.Location = new System.Drawing.Point(220, 84);
            this.Lbl_PrecHasta.Name = "Lbl_PrecHasta";
            this.Lbl_PrecHasta.Size = new System.Drawing.Size(85, 16);
            this.Lbl_PrecHasta.TabIndex = 12;
            this.Lbl_PrecHasta.Text = "Precio hasta:";
            // 
            // Lbl_FeDesde
            // 
            this.Lbl_FeDesde.AutoSize = true;
            this.Lbl_FeDesde.Location = new System.Drawing.Point(12, 141);
            this.Lbl_FeDesde.Name = "Lbl_FeDesde";
            this.Lbl_FeDesde.Size = new System.Drawing.Size(90, 16);
            this.Lbl_FeDesde.TabIndex = 13;
            this.Lbl_FeDesde.Text = "Fecha desde:";
            // 
            // Lbl_FeHasta
            // 
            this.Lbl_FeHasta.AutoSize = true;
            this.Lbl_FeHasta.Location = new System.Drawing.Point(220, 142);
            this.Lbl_FeHasta.Name = "Lbl_FeHasta";
            this.Lbl_FeHasta.Size = new System.Drawing.Size(84, 16);
            this.Lbl_FeHasta.TabIndex = 14;
            this.Lbl_FeHasta.Text = "Fecha hasta:";
            // 
            // DTGV_VisualizadorVentas
            // 
            this.DTGV_VisualizadorVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_VisualizadorVentas.Location = new System.Drawing.Point(69, 281);
            this.DTGV_VisualizadorVentas.Name = "DTGV_VisualizadorVentas";
            this.DTGV_VisualizadorVentas.RowHeadersWidth = 51;
            this.DTGV_VisualizadorVentas.RowTemplate.Height = 24;
            this.DTGV_VisualizadorVentas.Size = new System.Drawing.Size(918, 224);
            this.DTGV_VisualizadorVentas.TabIndex = 15;
            // 
            // Pnl_VentaDetallada
            // 
            this.Pnl_VentaDetallada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Pnl_VentaDetallada.Controls.Add(this.Lbl_VisorDetalle);
            this.Pnl_VentaDetallada.Location = new System.Drawing.Point(69, 243);
            this.Pnl_VentaDetallada.Name = "Pnl_VentaDetallada";
            this.Pnl_VentaDetallada.Size = new System.Drawing.Size(918, 37);
            this.Pnl_VentaDetallada.TabIndex = 35;
            // 
            // Lbl_VisorDetalle
            // 
            this.Lbl_VisorDetalle.AutoSize = true;
            this.Lbl_VisorDetalle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_VisorDetalle.Location = new System.Drawing.Point(350, 8);
            this.Lbl_VisorDetalle.Name = "Lbl_VisorDetalle";
            this.Lbl_VisorDetalle.Size = new System.Drawing.Size(87, 23);
            this.Lbl_VisorDetalle.TabIndex = 31;
            this.Lbl_VisorDetalle.Text = "Detallada";
            // 
            // Pnl_VentaGeneral
            // 
            this.Pnl_VentaGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Pnl_VentaGeneral.Controls.Add(this.Lbl_VentaGral);
            this.Pnl_VentaGeneral.Location = new System.Drawing.Point(412, 65);
            this.Pnl_VentaGeneral.Name = "Pnl_VentaGeneral";
            this.Pnl_VentaGeneral.Size = new System.Drawing.Size(575, 37);
            this.Pnl_VentaGeneral.TabIndex = 36;
            // 
            // Lbl_VentaGral
            // 
            this.Lbl_VentaGral.AutoSize = true;
            this.Lbl_VentaGral.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_VentaGral.Location = new System.Drawing.Point(205, 7);
            this.Lbl_VentaGral.Name = "Lbl_VentaGral";
            this.Lbl_VentaGral.Size = new System.Drawing.Size(71, 23);
            this.Lbl_VentaGral.TabIndex = 31;
            this.Lbl_VentaGral.Text = "General";
            // 
            // CV_ConsultaVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1208, 547);
            this.Controls.Add(this.Pnl_VentaGeneral);
            this.Controls.Add(this.Pnl_VentaDetallada);
            this.Controls.Add(this.DTGV_VisualizadorVentas);
            this.Controls.Add(this.Lbl_FeHasta);
            this.Controls.Add(this.Lbl_FeDesde);
            this.Controls.Add(this.Lbl_PrecHasta);
            this.Controls.Add(this.Lbl_PrecDesde);
            this.Controls.Add(this.Lbl_Cliente);
            this.Controls.Add(this.DTGV_BusqVentas);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Ver);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Dtp_FeHasta);
            this.Controls.Add(this.Dtp_FeDesde);
            this.Controls.Add(this.Txb_PrecHasta);
            this.Controls.Add(this.Txb_PrecDesde);
            this.Controls.Add(this.Txb_Cliente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CV_ConsultaVentas";
            this.Text = "Consulta de ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CV_ConsultaVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_BusqVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_VisualizadorVentas)).EndInit();
            this.Pnl_VentaDetallada.ResumeLayout(false);
            this.Pnl_VentaDetallada.PerformLayout();
            this.Pnl_VentaGeneral.ResumeLayout(false);
            this.Pnl_VentaGeneral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txb_Cliente;
        private System.Windows.Forms.TextBox Txb_PrecDesde;
        private System.Windows.Forms.TextBox Txb_PrecHasta;
        private System.Windows.Forms.DateTimePicker Dtp_FeDesde;
        private System.Windows.Forms.DateTimePicker Dtp_FeHasta;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Button Btn_Ver;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.DataGridView DTGV_BusqVentas;
        private System.Windows.Forms.Label Lbl_Cliente;
        private System.Windows.Forms.Label Lbl_PrecDesde;
        private System.Windows.Forms.Label Lbl_PrecHasta;
        private System.Windows.Forms.Label Lbl_FeDesde;
        private System.Windows.Forms.Label Lbl_FeHasta;
        private System.Windows.Forms.DataGridView DTGV_VisualizadorVentas;
        private System.Windows.Forms.Panel Pnl_VentaDetallada;
        private System.Windows.Forms.Label Lbl_VisorDetalle;
        private System.Windows.Forms.Panel Pnl_VentaGeneral;
        private System.Windows.Forms.Label Lbl_VentaGral;
    }
}