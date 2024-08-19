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
    public partial class CV_ControlVencimientos : Form
    {
        CL_Productos Productos = new CL_Productos();
        public CV_ControlVencimientos()
        {
            InitializeComponent();
        }

        private void CV_ControlVencimientos_Load(object sender, EventArgs e)
        {
            configurarDTGV();
            cargarDTGV();
            
        }
        private void configurarDTGV()
        {
            DTGV_Vencimientos.AllowUserToResizeColumns = false;
            DTGV_Vencimientos.AllowUserToResizeRows = false;
            DTGV_Vencimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_Vencimientos.MultiSelect = false;
            DTGV_Vencimientos.AllowUserToAddRows = false;
            DTGV_Vencimientos.AllowUserToResizeColumns = false;
            DTGV_Vencimientos.AllowUserToResizeRows = false;
            DTGV_Vencimientos.ReadOnly = true;
            DTGV_Vencimientos.RowHeadersVisible = false;
            DTGV_Vencimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // DTGV_Vencimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;           

        }
        private void cargarDTGV() 
        {
            DTGV_Vencimientos.DataSource = Productos.CargarVtoProductos();
            DTGV_Vencimientos.Columns[0].HeaderText = "ID del producto";
            DTGV_Vencimientos.Columns[1].HeaderText = "Nombre del producto";
            DTGV_Vencimientos.Columns[2].HeaderText = "Marca";
            DTGV_Vencimientos.Columns[3].HeaderText = "Descripcion del producto";
            DTGV_Vencimientos.Columns[4].HeaderText = "Cantidad";
            DTGV_Vencimientos.Columns[5].HeaderText = "Precio unitario";
            DTGV_Vencimientos.Columns[6].HeaderText = "Vencimiento";
            DTGV_Vencimientos.Columns[7].HeaderText = "Numero de lote";
        }
    }
}
