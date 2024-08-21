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

namespace Vista
{
    public partial class CV_ProdVencido : Form
    {
        CL_Productos Productos = new CL_Productos();
        public CV_ProdVencido()
        {
            InitializeComponent();
        }

        private void CV_ProdVencido_Load(object sender, EventArgs e)
        {
            configurarDTGV();
            cargarDTGV();
        }
        private void configurarDTGV()
        {
            DTGV_ProductosVencidos.AllowUserToResizeColumns = false;
            DTGV_ProductosVencidos.AllowUserToResizeRows = false;
            DTGV_ProductosVencidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_ProductosVencidos.MultiSelect = false;
            DTGV_ProductosVencidos.AllowUserToAddRows = false;
            DTGV_ProductosVencidos.AllowUserToResizeColumns = false;
            DTGV_ProductosVencidos.AllowUserToResizeRows = false;
            DTGV_ProductosVencidos.ReadOnly = true;
            DTGV_ProductosVencidos.RowHeadersVisible = false;
            DTGV_ProductosVencidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // DTGV_Vencimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;           

        }
        private void cargarDTGV()
        {
            DTGV_ProductosVencidos.DataSource = Productos.CargarProdVencidos();

            DTGV_ProductosVencidos.Columns[0].DisplayIndex = 0;
            DTGV_ProductosVencidos.Columns[1].DisplayIndex = 1;
            DTGV_ProductosVencidos.Columns[2].DisplayIndex = 2;
            DTGV_ProductosVencidos.Columns[3].DisplayIndex = 4;
            DTGV_ProductosVencidos.Columns[4].DisplayIndex = 5;
            DTGV_ProductosVencidos.Columns[5].DisplayIndex = 6;
            DTGV_ProductosVencidos.Columns[6].DisplayIndex = 7;
            DTGV_ProductosVencidos.Columns[7].DisplayIndex = 8;
            DTGV_ProductosVencidos.Columns[8].DisplayIndex = 3;

            DTGV_ProductosVencidos.Columns[0].HeaderText = "ID del producto";
            DTGV_ProductosVencidos.Columns[1].HeaderText = "Nombre del producto";
            DTGV_ProductosVencidos.Columns[2].HeaderText = "Marca";
            DTGV_ProductosVencidos.Columns[3].HeaderText = "Descripcion del producto";
            DTGV_ProductosVencidos.Columns[4].HeaderText = "Cantidad";
            DTGV_ProductosVencidos.Columns[5].HeaderText = "Precio unitario";
            DTGV_ProductosVencidos.Columns[6].HeaderText = "Vencimiento";
            DTGV_ProductosVencidos.Columns[7].HeaderText = "Numero de lote";
            DTGV_ProductosVencidos.Columns[8].HeaderText = "Categoría";
        }
    }
}
