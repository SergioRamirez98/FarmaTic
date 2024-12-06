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

namespace Vista.FormulariosMenu
{
    public partial class CV_Bitacora : Form
    {
        CL_Sistema Sistema = new CL_Sistema();
        public CV_Bitacora()
        {
            InitializeComponent();
        }

        private void CV_Bitacora_Load(object sender, EventArgs e)
        {
            configurarLoad();
            configurarDTGV();
            cargarDTGV();
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                capturarDatos(); 
                DTGV_Bitacora.DataSource = null;
                DTGV_Bitacora.DataSource = Sistema.BuscarBitacora(); 
                nombrarColumnas();
                DTGV_Bitacora.ClearSelection();
            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }
        }

        private void Btn_VerTodo_Click(object sender, EventArgs e)
        {
            cargarDTGV();
        }
        private void configurarLoad()
        {
            Dtp_Hasta.Value = DateTime.Now.AddYears(2);

            Cmb_Tipo.DataSource = Sistema.ObtenerAccion();
            Cmb_Tipo.DisplayMember = "DescripcionAccion";
            Cmb_Tipo.ValueMember = "ID_Accion";            
            Cmb_Tipo.SelectedIndex = -1;
            //Cmb_Tipo
        }
        private void configurarDTGV()
        {
            DTGV_Bitacora.AllowUserToResizeColumns = false;
            DTGV_Bitacora.AllowUserToResizeRows = false;
            DTGV_Bitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_Bitacora.MultiSelect = false;
            DTGV_Bitacora.AllowUserToAddRows = false;
            DTGV_Bitacora.AllowUserToResizeColumns = false;
            DTGV_Bitacora.AllowUserToResizeRows = false;
            DTGV_Bitacora.ReadOnly = true;
            DTGV_Bitacora.RowHeadersVisible = false;
            DTGV_Bitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void cargarDTGV()
        {
            DTGV_Bitacora.DataSource = null;
            DTGV_Bitacora.DataSource = Sistema.MostrarBitacora();
            nombrarColumnas();
            DTGV_Bitacora.ClearSelection();
        }
        private void nombrarColumnas()
        {
            DTGV_Bitacora.Columns[0].HeaderText = "ID";
            DTGV_Bitacora.Columns[1].HeaderText = "Usuario";
            DTGV_Bitacora.Columns[2].HeaderText = "Fecha";
            DTGV_Bitacora.Columns[3].HeaderText = "Acción";
            DTGV_Bitacora.Columns[4].HeaderText = "Descripción";
        }
        private void capturarDatos() 
        {
            Sistema.UserName= Txb_UserName.Text;
            Sistema.FechaDesde= Dtp_Desde.Value.ToString();
            Sistema.FechaHasta = Dtp_Hasta.Value.ToString();
            if (Cmb_Tipo.SelectedValue == null) Sistema.Accion = 0.ToString();
            else Sistema.Accion = Cmb_Tipo.SelectedValue.ToString();
        }

    }
}
