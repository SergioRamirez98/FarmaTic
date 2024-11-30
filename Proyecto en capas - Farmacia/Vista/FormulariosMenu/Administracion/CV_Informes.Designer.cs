namespace Vista.FormulariosMenu.Compras
{
    partial class CV_Informes
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.Dtp_FechaInicio = new System.Windows.Forms.DateTimePicker();
            this.Dtp_FechaFin = new System.Windows.Forms.DateTimePicker();
            this.Cmb_TipoAnalisis = new System.Windows.Forms.ComboBox();
            this.Lbl_FechaInicio = new System.Windows.Forms.Label();
            this.Lbl_FechaHasta = new System.Windows.Forms.Label();
            this.Lbl_Analisis = new System.Windows.Forms.Label();
            this.Chart_Grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.DTGV_Datos = new System.Windows.Forms.DataGridView();
            this.Btn_GenerarInforme = new System.Windows.Forms.Button();
            this.Btn_Refrescar = new System.Windows.Forms.Button();
            this.Lbl_Resultados = new System.Windows.Forms.Label();
            this.Pnl_Totales = new System.Windows.Forms.Panel();
            this.Pnl_Graficos = new System.Windows.Forms.Panel();
            this.Pnl_Controles = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Grafico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Datos)).BeginInit();
            this.Pnl_Totales.SuspendLayout();
            this.Pnl_Graficos.SuspendLayout();
            this.Pnl_Controles.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dtp_FechaInicio
            // 
            this.Dtp_FechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_FechaInicio.Location = new System.Drawing.Point(118, 57);
            this.Dtp_FechaInicio.Name = "Dtp_FechaInicio";
            this.Dtp_FechaInicio.Size = new System.Drawing.Size(133, 22);
            this.Dtp_FechaInicio.TabIndex = 1;
            // 
            // Dtp_FechaFin
            // 
            this.Dtp_FechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_FechaFin.Location = new System.Drawing.Point(443, 57);
            this.Dtp_FechaFin.Name = "Dtp_FechaFin";
            this.Dtp_FechaFin.Size = new System.Drawing.Size(115, 22);
            this.Dtp_FechaFin.TabIndex = 2;
            // 
            // Cmb_TipoAnalisis
            // 
            this.Cmb_TipoAnalisis.FormattingEnabled = true;
            this.Cmb_TipoAnalisis.Location = new System.Drawing.Point(118, 10);
            this.Cmb_TipoAnalisis.Name = "Cmb_TipoAnalisis";
            this.Cmb_TipoAnalisis.Size = new System.Drawing.Size(133, 24);
            this.Cmb_TipoAnalisis.TabIndex = 0;
            this.Cmb_TipoAnalisis.SelectedIndexChanged += new System.EventHandler(this.Cmb_TipoAnalisis_SelectedIndexChanged);
            // 
            // Lbl_FechaInicio
            // 
            this.Lbl_FechaInicio.AutoSize = true;
            this.Lbl_FechaInicio.Location = new System.Drawing.Point(13, 62);
            this.Lbl_FechaInicio.Name = "Lbl_FechaInicio";
            this.Lbl_FechaInicio.Size = new System.Drawing.Size(79, 16);
            this.Lbl_FechaInicio.TabIndex = 6;
            this.Lbl_FechaInicio.Text = "Fecha Inicio";
            // 
            // Lbl_FechaHasta
            // 
            this.Lbl_FechaHasta.AutoSize = true;
            this.Lbl_FechaHasta.Location = new System.Drawing.Point(338, 63);
            this.Lbl_FechaHasta.Name = "Lbl_FechaHasta";
            this.Lbl_FechaHasta.Size = new System.Drawing.Size(61, 16);
            this.Lbl_FechaHasta.TabIndex = 7;
            this.Lbl_FechaHasta.Text = "Fecha fin";
            // 
            // Lbl_Analisis
            // 
            this.Lbl_Analisis.AutoSize = true;
            this.Lbl_Analisis.Location = new System.Drawing.Point(13, 18);
            this.Lbl_Analisis.Name = "Lbl_Analisis";
            this.Lbl_Analisis.Size = new System.Drawing.Size(84, 16);
            this.Lbl_Analisis.TabIndex = 8;
            this.Lbl_Analisis.Text = "Tipo analisis";
            // 
            // Chart_Grafico
            // 
            chartArea1.Name = "ChartArea1";
            this.Chart_Grafico.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Chart_Grafico.Legends.Add(legend1);
            this.Chart_Grafico.Location = new System.Drawing.Point(16, 17);
            this.Chart_Grafico.Name = "Chart_Grafico";
            this.Chart_Grafico.Size = new System.Drawing.Size(815, 420);
            this.Chart_Grafico.TabIndex = 14;
            // 
            // DTGV_Datos
            // 
            this.DTGV_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_Datos.Location = new System.Drawing.Point(857, 17);
            this.DTGV_Datos.Name = "DTGV_Datos";
            this.DTGV_Datos.RowHeadersWidth = 51;
            this.DTGV_Datos.RowTemplate.Height = 24;
            this.DTGV_Datos.Size = new System.Drawing.Size(437, 337);
            this.DTGV_Datos.TabIndex = 15;
            // 
            // Btn_GenerarInforme
            // 
            this.Btn_GenerarInforme.Location = new System.Drawing.Point(288, 106);
            this.Btn_GenerarInforme.Name = "Btn_GenerarInforme";
            this.Btn_GenerarInforme.Size = new System.Drawing.Size(75, 23);
            this.Btn_GenerarInforme.TabIndex = 16;
            this.Btn_GenerarInforme.Text = "Generar Informe";
            this.Btn_GenerarInforme.UseVisualStyleBackColor = true;
            this.Btn_GenerarInforme.Click += new System.EventHandler(this.Btn_GenerarInforme_Click);
            // 
            // Btn_Refrescar
            // 
            this.Btn_Refrescar.Location = new System.Drawing.Point(363, 10);
            this.Btn_Refrescar.Name = "Btn_Refrescar";
            this.Btn_Refrescar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Refrescar.TabIndex = 17;
            this.Btn_Refrescar.Text = "Refrescar";
            this.Btn_Refrescar.UseVisualStyleBackColor = true;
            this.Btn_Refrescar.Click += new System.EventHandler(this.Btn_Refrescar_Click);
            // 
            // Lbl_Resultados
            // 
            this.Lbl_Resultados.AutoSize = true;
            this.Lbl_Resultados.Location = new System.Drawing.Point(3, 0);
            this.Lbl_Resultados.Name = "Lbl_Resultados";
            this.Lbl_Resultados.Size = new System.Drawing.Size(44, 16);
            this.Lbl_Resultados.TabIndex = 0;
            this.Lbl_Resultados.Text = "label1";
            // 
            // Pnl_Totales
            // 
            this.Pnl_Totales.Controls.Add(this.Lbl_Resultados);
            this.Pnl_Totales.Location = new System.Drawing.Point(857, 360);
            this.Pnl_Totales.Name = "Pnl_Totales";
            this.Pnl_Totales.Size = new System.Drawing.Size(437, 77);
            this.Pnl_Totales.TabIndex = 18;
            // 
            // Pnl_Graficos
            // 
            this.Pnl_Graficos.Controls.Add(this.Chart_Grafico);
            this.Pnl_Graficos.Controls.Add(this.Pnl_Totales);
            this.Pnl_Graficos.Controls.Add(this.DTGV_Datos);
            this.Pnl_Graficos.Location = new System.Drawing.Point(30, 177);
            this.Pnl_Graficos.Name = "Pnl_Graficos";
            this.Pnl_Graficos.Size = new System.Drawing.Size(1314, 472);
            this.Pnl_Graficos.TabIndex = 19;
            // 
            // Pnl_Controles
            // 
            this.Pnl_Controles.Controls.Add(this.Lbl_Analisis);
            this.Pnl_Controles.Controls.Add(this.Dtp_FechaInicio);
            this.Pnl_Controles.Controls.Add(this.Btn_Refrescar);
            this.Pnl_Controles.Controls.Add(this.Dtp_FechaFin);
            this.Pnl_Controles.Controls.Add(this.Btn_GenerarInforme);
            this.Pnl_Controles.Controls.Add(this.Cmb_TipoAnalisis);
            this.Pnl_Controles.Controls.Add(this.Lbl_FechaInicio);
            this.Pnl_Controles.Controls.Add(this.Lbl_FechaHasta);
            this.Pnl_Controles.Location = new System.Drawing.Point(30, 28);
            this.Pnl_Controles.Name = "Pnl_Controles";
            this.Pnl_Controles.Size = new System.Drawing.Size(654, 143);
            this.Pnl_Controles.TabIndex = 20;
            // 
            // CV_Informes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1536, 762);
            this.Controls.Add(this.Pnl_Controles);
            this.Controls.Add(this.Pnl_Graficos);
            this.Name = "CV_Informes";
            this.Text = "CV_Informes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CV_Informes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Grafico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Datos)).EndInit();
            this.Pnl_Totales.ResumeLayout(false);
            this.Pnl_Totales.PerformLayout();
            this.Pnl_Graficos.ResumeLayout(false);
            this.Pnl_Controles.ResumeLayout(false);
            this.Pnl_Controles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker Dtp_FechaInicio;
        private System.Windows.Forms.DateTimePicker Dtp_FechaFin;
        private System.Windows.Forms.ComboBox Cmb_TipoAnalisis;
        private System.Windows.Forms.Label Lbl_FechaInicio;
        private System.Windows.Forms.Label Lbl_FechaHasta;
        private System.Windows.Forms.Label Lbl_Analisis;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Grafico;
        private System.Windows.Forms.DataGridView DTGV_Datos;
        private System.Windows.Forms.Button Btn_GenerarInforme;
        private System.Windows.Forms.Button Btn_Refrescar;
        private System.Windows.Forms.Label Lbl_Resultados;
        private System.Windows.Forms.Panel Pnl_Totales;
        private System.Windows.Forms.Panel Pnl_Graficos;
        private System.Windows.Forms.Panel Pnl_Controles;
    }
}