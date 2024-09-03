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
    public partial class CV_ObtenerClientes : Form
    {
        CL_Ventas ventas = new CL_Ventas();
        public delegate void ClienteSeleccionadoHandler( string cliente, int idCliente);
        public event ClienteSeleccionadoHandler ClienteSeleccionado;

        public CV_ObtenerClientes()
        {
            InitializeComponent();
        }

        private void CV_ObtenerClientes_Load(object sender, EventArgs e)
        {
            cargarDTGV();
            configurarDTGV();

        }
        private void configurarDTGV() 
        {
            DTGV_Clientes.AllowUserToResizeColumns = false;
            DTGV_Clientes.AllowUserToResizeRows = false;
            DTGV_Clientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_Clientes.MultiSelect = false;
            DTGV_Clientes.AllowUserToAddRows = false;
            DTGV_Clientes.AllowUserToResizeColumns = false;
            DTGV_Clientes.AllowUserToResizeRows = false;
            DTGV_Clientes.ReadOnly = true;
            DTGV_Clientes.RowHeadersVisible = false;
            DTGV_Clientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // DTGV_Clientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            DTGV_Clientes.Columns[0].HeaderText = "ID Cliente";
            DTGV_Clientes.Columns[1].HeaderText = "ID Persona";
            DTGV_Clientes.Columns[2].HeaderText = "Fecha de Alta";
            DTGV_Clientes.Columns[3].HeaderText = "Cliente";
            DTGV_Clientes.Columns[4].HeaderText = "Documento";
            DTGV_Clientes.Columns[5].HeaderText = "Descuento";
            DTGV_Clientes.Columns[6].HeaderText = "Categoria";

            
        }
        private void cargarDTGV() 
        {
            DTGV_Clientes.DataSource = ventas.ObtenerClientes();
            DTGV_Clientes.ClearSelection();
        }

        private void Txb_BuscarCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void DTGV_Clientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DTGV_Clientes.SelectedRows.Count > 0)
            {
                int Seleccion = DTGV_Clientes.CurrentRow.Index;
                int IdCliente = Convert.ToInt32(DTGV_Clientes.Rows[Seleccion].Cells[0].Value);
                string Cliente = DTGV_Clientes.Rows[Seleccion].Cells[3].Value.ToString();
                ClienteSeleccionado(Cliente,IdCliente);
                this.Close();

            }
        }
    }
}
