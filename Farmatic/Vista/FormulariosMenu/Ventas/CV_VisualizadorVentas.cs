using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.FormulariosMenu.Ventas
{
    public partial class CV_VisualizadorVentas : Form
    {
        int ID_Venta = 0;
        CL_ConsultaVentas Consulta = new CL_ConsultaVentas();
        public CV_VisualizadorVentas(int ID)
        {
            InitializeComponent();
            ID_Venta=ID;
        }

        public void CV_VisualizadorVentas_Load(object sender, EventArgs e)
        {
            configurarDTGV();
            cargarDTGV();           
        }
        private void cargarDTGV() 
        {
            DTGV_VisualizadorVentas.DataSource = Consulta.VerVentaItems(ID_Venta);
            DTGV_VisualizadorVentas.Columns[0].HeaderText = "ID Venta";
            DTGV_VisualizadorVentas.Columns[1].HeaderText = "Usuario vendedor";
            DTGV_VisualizadorVentas.Columns[2].HeaderText = "Cliente";
            DTGV_VisualizadorVentas.Columns[3].HeaderText = "Nombre del Producto";
            DTGV_VisualizadorVentas.Columns[4].HeaderText = "Precio unitario";
            DTGV_VisualizadorVentas.Columns[5].HeaderText = "Cantidad";
            DTGV_VisualizadorVentas.Columns[6].HeaderText = "Descuento aplicado al cliente";
            DTGV_VisualizadorVentas.Columns[7].HeaderText = "Valor con descuento";
            DTGV_VisualizadorVentas.Columns[8].HeaderText = "Fecha de venta";
            DTGV_VisualizadorVentas.Columns[4].DefaultCellStyle.Format = "#,##0.00";
            DTGV_VisualizadorVentas.Columns[7].DefaultCellStyle.Format = "#,##0.00";
            DTGV_VisualizadorVentas.ClearSelection();
        }
        private void configurarDTGV()
        {
            DTGV_VisualizadorVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_VisualizadorVentas.MultiSelect = false;
            DTGV_VisualizadorVentas.AllowUserToAddRows = false;
            DTGV_VisualizadorVentas.AllowUserToResizeColumns = false;
            DTGV_VisualizadorVentas.AllowUserToResizeRows = false;
            DTGV_VisualizadorVentas.ReadOnly = true;
            DTGV_VisualizadorVentas.RowHeadersVisible = false;
            DTGV_VisualizadorVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
