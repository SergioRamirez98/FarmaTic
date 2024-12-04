using Logica;
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

namespace Vista
{
    public partial class CV_ObtenerClientes : Form
    {
        CL_Ventas ventas = new CL_Ventas();
        public delegate void ClienteSeleccionadoHandler( string cliente, int idCliente, double Descuento, string Categoria);

        public event ClienteSeleccionadoHandler ClienteSeleccionado;

        #region Properties
        public int ID_Cliente {get;set;}
        public int ID_Persona{get;set;}
        public DateTime Fecha_de_Alta{get;set;}           
        public string Cliente{get;set;}
        public int Documento{get;set;}
        public double Descuento{get;set;}
        public string Categoria { get; set; }
        #endregion


        public CV_ObtenerClientes()
        {
            InitializeComponent();
        }

        private void CV_ObtenerClientes_Load(object sender, EventArgs e)
        {
            cargarDTGV();
            configurarDTGV();
            CServ_ConfControles.ConfiguraciondeControles(this);
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
            seleccionarCliente();
        }

        private void DTGV_Clientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                seleccionarCliente();
            }
        }
        private void seleccionarCliente()
        {
            if (DTGV_Clientes.SelectedRows.Count > 0)
            {
                int Seleccion = DTGV_Clientes.CurrentRow.Index;

                ID_Cliente = Convert.ToInt32(DTGV_Clientes.Rows[Seleccion].Cells[0].Value);
                ID_Persona = Convert.ToInt32(DTGV_Clientes.Rows[Seleccion].Cells[1].Value);
                Fecha_de_Alta = Convert.ToDateTime(DTGV_Clientes.Rows[Seleccion].Cells[2].Value);
                Cliente = DTGV_Clientes.Rows[Seleccion].Cells[3].Value.ToString();
                Documento = Convert.ToInt32(DTGV_Clientes.Rows[Seleccion].Cells[4].Value);
                Descuento = Convert.ToDouble(DTGV_Clientes.Rows[Seleccion].Cells[5].Value);
                Categoria = DTGV_Clientes.Rows[Seleccion].Cells[6].Value.ToString();
                ClienteSeleccionado(Cliente, ID_Cliente, Descuento, Categoria);

                this.Close();
            }
        }
    }
}
