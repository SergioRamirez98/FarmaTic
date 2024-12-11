using Logica;
using Sesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class CV_StockMinimo : Form
    {
        CL_Productos Productos = new CL_Productos();
        public CV_StockMinimo()
        {
            InitializeComponent();
        }

        private void CV_StockMinimo_Load(object sender, EventArgs e)
        {
            configurarDTGV();
            cargarDTGV();
        }
        private void configurarDTGV()
        {
            DTGV_StockMinimo.AllowUserToResizeColumns = false;
            DTGV_StockMinimo.AllowUserToResizeRows = false;
            DTGV_StockMinimo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_StockMinimo.MultiSelect = false;
            DTGV_StockMinimo.AllowUserToAddRows = false;
            DTGV_StockMinimo.AllowUserToResizeColumns = false;
            DTGV_StockMinimo.AllowUserToResizeRows = false;
            DTGV_StockMinimo.ReadOnly = true;
            DTGV_StockMinimo.RowHeadersVisible = false;
            DTGV_StockMinimo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // DTGV_StockMinimo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;           

        }
        private void cargarDTGV()
        {
            DTGV_StockMinimo.DataSource = CSesion_CacheStockMinimo.ListaStockMinimo;           

            DTGV_StockMinimo.Columns[0].DisplayIndex = 0;
            DTGV_StockMinimo.Columns[1].DisplayIndex = 1;
            DTGV_StockMinimo.Columns[2].DisplayIndex = 2;
            DTGV_StockMinimo.Columns[3].DisplayIndex = 4;
            DTGV_StockMinimo.Columns[4].DisplayIndex = 5;
            DTGV_StockMinimo.Columns[5].DisplayIndex = 6;
            DTGV_StockMinimo.Columns[6].DisplayIndex = 7;
            DTGV_StockMinimo.Columns[7].DisplayIndex = 8;
            DTGV_StockMinimo.Columns[8].DisplayIndex = 3;

            DTGV_StockMinimo.Columns[0].HeaderText = "ID producto";
            DTGV_StockMinimo.Columns[1].HeaderText = "Nombre del producto";
            DTGV_StockMinimo.Columns[2].HeaderText = "Marca";
            DTGV_StockMinimo.Columns[3].HeaderText = "Descripcion del producto";
            DTGV_StockMinimo.Columns[4].HeaderText = "Cantidad";
            DTGV_StockMinimo.Columns[5].HeaderText = "Precio unitario";

            DTGV_StockMinimo.Columns[5].DefaultCellStyle.Format = "#,##0.00";
            DTGV_StockMinimo.Columns[6].HeaderText = "Vencimiento";
            DTGV_StockMinimo.Columns[7].HeaderText = "Numero de lote";
            DTGV_StockMinimo.Columns[8].HeaderText = "Categoría";
        }
    }
}
