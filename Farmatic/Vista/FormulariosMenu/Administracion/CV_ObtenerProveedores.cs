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

namespace Vista.FormulariosMenu
{
    public partial class CV_ObtenerProveedores : Form
    {
        CL_Proveedores Proveedores = new CL_Proveedores();
        public delegate void ProveedorSeleccionadoHandler(int idProveedor, string Proveedor);
        public event ProveedorSeleccionadoHandler ProveedorSeleccionado;

        public CV_ObtenerProveedores()
        {
            InitializeComponent();
            CV_Idioma.CargarIdioma(this.Controls, this);
        }

        #region Eventos
        private void CV_ObtenerProveedores_Load(object sender, EventArgs e)
        {
            configurarLoad();
            configurarDTGV();
            cargarDTGV();
            CServ_ConfControles.ConfiguraciondeControles(this);
        }
        private void DTGV_SeleccionProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (DTGV_SeleccionProveedores.SelectedRows.Count > 0) seleccionarProveedor();
        }
        private void DTGV_SeleccionProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (DTGV_SeleccionProveedores.SelectedRows.Count > 0)
            {
                if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                {
                    seleccionarProveedor();
                }
            }

        }
        private void Txb_BusquedaRapida_TextChanged(object sender, EventArgs e)
        {
            DTGV_SeleccionProveedores.DataSource= Proveedores.BusquedaRapida(Txb_BusquedaRapida.Text);
        }
        #endregion

        #region Métodos
        private void configurarLoad()
        {
            CServ_Limpiar.LimpiarFormulario(this);            
            DTGV_SeleccionProveedores.KeyDown += DTGV_SeleccionProveedores_KeyDown;
            DTGV_SeleccionProveedores.ClearSelection();

        }
        private void configurarDTGV() 
        {
            DTGV_SeleccionProveedores.AllowUserToResizeColumns = false;
            DTGV_SeleccionProveedores.AllowUserToResizeRows = false;
            DTGV_SeleccionProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_SeleccionProveedores.MultiSelect = false;
            DTGV_SeleccionProveedores.AllowUserToAddRows = false;
            DTGV_SeleccionProveedores.AllowUserToResizeColumns = false;
            DTGV_SeleccionProveedores.AllowUserToResizeRows = false;
            DTGV_SeleccionProveedores.ReadOnly = true;
            DTGV_SeleccionProveedores.RowHeadersVisible = false;
            DTGV_SeleccionProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void cargarDTGV()
        {
            
            DTGV_SeleccionProveedores.DataSource = Proveedores.MostrarProveedores();
           
            DTGV_SeleccionProveedores.Columns[0].HeaderText = "ID Proveedor";
            DTGV_SeleccionProveedores.Columns[1].HeaderText = "Razon social";
            DTGV_SeleccionProveedores.Columns[2].HeaderText = "Matricula";
            DTGV_SeleccionProveedores.Columns[3].HeaderText = "Direccion";
            DTGV_SeleccionProveedores.Columns[4].HeaderText = "Partido";
            DTGV_SeleccionProveedores.Columns[5].HeaderText = "Telefono";
            DTGV_SeleccionProveedores.Columns[6].HeaderText = "CUIT";
            DTGV_SeleccionProveedores.Columns[7].HeaderText = "Mail";
            DTGV_SeleccionProveedores.Columns[8].HeaderText = "IIBB";
            DTGV_SeleccionProveedores.Columns[9].HeaderText = "Condicion IVA";
        }
        private void seleccionarProveedor() 
        {
            if (DTGV_SeleccionProveedores.SelectedRows.Count > 0)
            {
                int Seleccion = DTGV_SeleccionProveedores.CurrentRow.Index;
                
                int ID_Proveedor = Convert.ToInt32(DTGV_SeleccionProveedores.Rows[Seleccion].Cells[0].Value);
                string Proveedor = DTGV_SeleccionProveedores.Rows[Seleccion].Cells[1].Value.ToString();
                ProveedorSeleccionado(ID_Proveedor, Proveedor);

                this.Close();
            }
        }
        #endregion

    }
}
