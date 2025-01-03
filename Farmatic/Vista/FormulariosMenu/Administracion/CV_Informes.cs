﻿using iText.Layout.Splitting;
using Logica;
using Modelo;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Vista.FormulariosMenu.Compras
{
    public partial class CV_Informes : Form
    {
        public CV_Informes()
        {
            InitializeComponent();
            CV_Idioma.CargarIdioma(this.Controls, this);
        }
        CL_Informes Informes = new CL_Informes();
        string LblEgresos = "";
        string LblIngresos = "";
        string LblTotal = "";
        List<CM_Informe> ListaInforme { get; set; } = new List<CM_Informe>();
        #region Eventos
        private void CV_Informes_Load(object sender, EventArgs e)
        {
            configurarLoad();            
            configurarDTGV();
            CServ_ConfControles.ConfiguraciondeControles(this);
        }

        private void Cmb_TipoAnalisis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Cmb_TipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       

        private void Btn_SeleccionCliente_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_SeleccionProveedor_Click(object sender, EventArgs e)
        {

        }

        private void Btn_GenerarInforme_Click(object sender, EventArgs e)
        {
            Lbl_Ingresos.Text = LblIngresos;
            Lbl_Egresos.Text = LblEgresos;
            Lbl_Total.Text = LblTotal;
            try
            {
                ListaInforme.Clear();
                pasarDatos();
                ListaInforme= Informes.RealizarConsulta();
                mostrarGrafico();
                DTGV_Datos.DataSource = null;
                DTGV_Datos.DataSource = ListaInforme;
                nombrarColumnas();
                actualizarBalance();
                
            }
            catch (Exception ex)
            {

                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }
        }
        private void Btn_Refrescar_Click(object sender, EventArgs e)
        {
            Lbl_Ingresos.Text=LblIngresos;
            Lbl_Egresos.Text=LblEgresos;
            Lbl_Total.Text=LblTotal;
            DTGV_Datos.DataSource= null;
            configurarLoad();
            Chart_Grafico.Series.Clear();
            actualizarBalance();
            CV_Informes_Load(sender, e);
        }
        
        #endregion

        #region Métodos
        private void configurarLoad()
        {
            if (LblTotal=="") 
            { 
                LblEgresos = Lbl_Egresos.Text;
                LblIngresos = Lbl_Ingresos.Text;
                LblTotal = Lbl_Total.Text;                
            }
            else if (LblTotal!="")
            {
                //Lbl_Ingresos.Text

            }

            DateTime fechaActual = DateTime.Now;
            DateTime primerDiaMes = new DateTime(fechaActual.Year, fechaActual.Month, 1);
            DateTime ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);
            Dtp_FechaInicio.Value = primerDiaMes;
            Dtp_FechaFin.Value = ultimoDiaMes;
            Cmb_TipoAnalisis.Items.Clear();

            Cmb_TipoAnalisis.Items.Add("Balance general");
            Cmb_TipoAnalisis.Items.Add("Ingresos");
            Cmb_TipoAnalisis.Items.Add("Egresos");
            Cmb_TipoAnalisis.SelectedIndex = 0;
            Lbl_Resultado.Visible = true;
            Lbl_Total.Visible = false;
            Lbl_Ingresos.Visible = false;
            Lbl_Egresos.Visible = false;

        }
        private void pasarDatos() 
        {
            Informes.TipoAnalisis = Cmb_TipoAnalisis.Text;
            Informes.FechaInicio = Dtp_FechaInicio.Value.ToString("yyyy-MM-dd 00:00:00");
            Informes.FechaFin = Dtp_FechaFin.Value.ToString("yyyy-MM-dd 00:00:00");
        }
        private void mostrarGrafico() 
        {
            List<CM_Informe> NuevoInforme = Informes.CalcularPorFecha(ListaInforme);

            Chart_Grafico.Series.Clear();
            Chart_Grafico.ChartAreas.Clear();
            var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            Chart_Grafico.ChartAreas.Add(chartArea);
            var Ventas = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Ventas",
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line,
                BorderWidth = 3,
                Color = System.Drawing.Color.Blue,
                MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle,
                MarkerSize = 8,
                MarkerColor = System.Drawing.Color.Blue
            };

            var Compras = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Compras",
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line,
                BorderWidth = 3,
                Color = System.Drawing.Color.Red,
                MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle,
                MarkerSize = 8,
                MarkerColor = System.Drawing.Color.Red
            };

            bool tieneVentas = false;
            bool tieneCompras = false;

            if (NuevoInforme.Count > 0)
            {
                foreach (var item in NuevoInforme)
                {
                    DateTime fecha = item.Fecha;
                    double total = item.Total;
                    string tipo = item.Tipo;

                    if (tipo == "Venta")
                    {
                        Ventas.Points.AddXY(fecha, total);
                        tieneVentas = true;
                    }
                    else if (tipo == "Compra")
                    {
                        Compras.Points.AddXY(fecha, total);
                        tieneCompras = true;
                    }
                }
            }

            Chart_Grafico.Series.Add(Ventas);
            Chart_Grafico.Series.Add(Compras);

            Chart_Grafico.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yy";
            Chart_Grafico.ChartAreas[0].AxisY.Title = "Montos";
            Chart_Grafico.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
            Chart_Grafico.ChartAreas[0].AxisX.Title = "Fecha";
            Chart_Grafico.ChartAreas[0].AxisY.Minimum = 0;

        }
        private void configurarDTGV()
        {
            DTGV_Datos.AllowUserToResizeColumns = false;
            DTGV_Datos.AllowUserToResizeRows = false;
            DTGV_Datos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_Datos.MultiSelect = false;
            DTGV_Datos.AllowUserToAddRows = false;
            DTGV_Datos.AllowUserToResizeColumns = false;
            DTGV_Datos.AllowUserToResizeRows = false;
            DTGV_Datos.ReadOnly = true;
            DTGV_Datos.RowHeadersVisible = false;
            DTGV_Datos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void nombrarColumnas() 
        {
            DTGV_Datos.Columns[0].HeaderText = "ID";
            DTGV_Datos.Columns[1].HeaderText = "Monto";
            DTGV_Datos.Columns[1].DefaultCellStyle.Format = "#,##0.00";
            DTGV_Datos.Columns[2].HeaderText = "Fecha";
            DTGV_Datos.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            DTGV_Datos.Columns[3].HeaderText = "Tipo Operación";
        }
        private void actualizarBalance() 
        {
            double total = 0;
            double Ingresos = 0;
            double Egresos= 0;

            if (DTGV_Datos.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in DTGV_Datos.Rows)
                {
                    if (fila.Cells["Tipo"].Value.ToString() =="Compra")
                    {
                        Egresos+= Convert.ToDouble(fila.Cells["Total"].Value);
                    }
                    else if (fila.Cells["Tipo"].Value.ToString() == "Venta")
                    {
                        Ingresos += Convert.ToDouble(fila.Cells["Total"].Value);
                    }
                }
                Lbl_Resultado.Visible = true;
                switch (Cmb_TipoAnalisis.Text)
                {
                    case "Balance general": total = Ingresos - Egresos;
                        Lbl_Total.Visible = true;
                        Lbl_Ingresos.Visible = true;
                        Lbl_Egresos.Visible = true;
                        Lbl_Ingresos.Location = new Point(2, 59);
                        Lbl_Egresos.Location = new Point(2, 84);
                        Lbl_Total.Text = LblTotal+ total.ToString("#,##0.00");
                        Lbl_Ingresos.Text = LblIngresos+ Ingresos.ToString("#,##0.00");
                        Lbl_Egresos.Text = LblEgresos+ Egresos.ToString("#,##0.00");                        
                        break;
                    case "Ingresos":
                        Lbl_Ingresos.Visible = true;
                        Lbl_Ingresos.Location = new Point(2, 59);
                        Lbl_Ingresos.Text = Lbl_Ingresos.Text + Ingresos.ToString("#,##0.00");
                        Lbl_Total.Visible = false;
                        Lbl_Egresos.Visible=false;
                        break;
                    case "Egresos":
                        Lbl_Egresos.Visible = true;
                        Lbl_Egresos.Location= new Point(2, 59);
                        Lbl_Egresos.Text = Lbl_Egresos.Text + Egresos.ToString("#,##0.00");
                        Lbl_Total.Visible= false;
                        Lbl_Ingresos.Visible = false;
                        break;
                }
            }
            else 
            {
                Lbl_Resultado.Visible = true;
                Lbl_Total.Visible = false;
                Lbl_Ingresos.Visible = false;
                Lbl_Egresos.Visible = false;
            }
        }
        #endregion

    }
}
