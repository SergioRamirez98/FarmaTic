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
using System.Xml.Linq;

namespace Vista.FormulariosMenu.GestionPersonas
{
    public partial class CV_SeleccionarPersona : Form
    {
        CL_Personas Personas = new CL_Personas();        

        public delegate void PersonaSeleccionadaHandler(int idPersona, string persona);

        public event PersonaSeleccionadaHandler PersonaSeleccionada;

        #region Properties
        public int ID_Persona { get; set; }
        public string Persona { get; set; }
        public int Documento { get; set; }
        public string Direccion { get; set; }
        public string Mail{ get; set; }
        public DataTable Dt { get; set; }
        #endregion
        public CV_SeleccionarPersona()
        {
            InitializeComponent();
            CV_Idioma.CargarIdioma(this.Controls, this);
        }

        #region Eventos

        private void CV_SeleccionarPersona_Load(object sender, EventArgs e)
        {
            cargarDTVG();
            configurarDTGV();
            CServ_ConfControles.ConfiguraciondeControles(this);
        }
        private void DTGV_SeleccionarPersona_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarPersona();
        }
        private void DTGV_SeleccionarPersona_KeyDown(object sender, KeyEventArgs e)
        {
            if (DTGV_SeleccionarPersona.SelectedRows.Count > 0) seleccionarPersona();
        }
        private void Txb_BusqPersona_TextChanged(object sender, EventArgs e)
        {
            DTGV_SeleccionarPersona.DataSource = Personas.BusquedaRapida(Txb_BusqPersona.Text, Dt);
        }
        #endregion
        #region Métodos
        private void configurarDTGV()
        {
            DTGV_SeleccionarPersona.AllowUserToResizeColumns = false;
            DTGV_SeleccionarPersona.AllowUserToResizeRows = false;
            DTGV_SeleccionarPersona.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_SeleccionarPersona.MultiSelect = false;
            DTGV_SeleccionarPersona.AllowUserToAddRows = false;
            DTGV_SeleccionarPersona.AllowUserToResizeColumns = false;
            DTGV_SeleccionarPersona.AllowUserToResizeRows = false;
            DTGV_SeleccionarPersona.ReadOnly = true;
            DTGV_SeleccionarPersona.RowHeadersVisible = false;
            DTGV_SeleccionarPersona.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // DTGV_SeleccionarCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DTGV_SeleccionarPersona.Columns[0].HeaderText = "ID Persona";
            DTGV_SeleccionarPersona.Columns[1].HeaderText = "Persona";
            DTGV_SeleccionarPersona.Columns[2].HeaderText = "Documento";
            DTGV_SeleccionarPersona.Columns[3].HeaderText = "Direccion";
            DTGV_SeleccionarPersona.Columns[4].HeaderText = "Mail"; 
        }
        private void cargarDTVG()
        {
            Dt = Personas.ObtenerPersonas();
            DTGV_SeleccionarPersona.DataSource = Dt;
        }        
        private void seleccionarPersona() 
        {
            if (DTGV_SeleccionarPersona.SelectedRows.Count > 0)
            {
                int Seleccion = DTGV_SeleccionarPersona.CurrentRow.Index;
                
                ID_Persona = Convert.ToInt32(DTGV_SeleccionarPersona.Rows[Seleccion].Cells[0].Value);
                Persona = DTGV_SeleccionarPersona.Rows[Seleccion].Cells[1].Value.ToString();
                Documento = Convert.ToInt32(DTGV_SeleccionarPersona.Rows[Seleccion].Cells[2].Value);
                Direccion = DTGV_SeleccionarPersona.Rows[Seleccion].Cells[3].Value.ToString();
                Mail = DTGV_SeleccionarPersona.Rows[Seleccion].Cells[4].Value.ToString();
                PersonaSeleccionada(ID_Persona, Persona);

                this.Close();
            }
        }
        #endregion

    }
}
