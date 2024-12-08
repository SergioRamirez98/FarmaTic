using Logica;
using Servicios;
using Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.FormulariosMenu;

namespace Vista
{
    public partial class CV_ModulodeSeguridad : Form
    {
        CL_Sistema Sistema = new CL_Sistema();
        public CV_ModulodeSeguridad()
        {
            Sistema.CargarConfiguracion();
            InitializeComponent();
            CV_Idioma.CargarIdioma(this.Controls, this); 
        }
        private void CV_Configuracion_Load(object sender, EventArgs e)
        {
            configurarLoad();
            configurarDTGV();
            cargarDTGV();
            Pnl_Bitacora.Visible = false;
            Chb_NumYLetras.Checked = CSistema_ConfiguracionSistema.NumerosYLetras;
            Chb_CaracEspec.Checked = CSistema_ConfiguracionSistema.CaractEspecial;
            Chb_DatosPersonales.Checked = CSistema_ConfiguracionSistema.DatosPersonales;
            Chb_MayMin.Checked = CSistema_ConfiguracionSistema.MayusMinus;
            Nud_CantidadIntentosFallidos.Value = CSistema_ConfiguracionSistema.CantIntentosFallidos;

            CServ_ConfControles.ConfiguraciondeControles(this);

        }
        private void Chb_NumYLetras_CheckedChanged(object sender, EventArgs e)
        {
            if (Chb_NumYLetras.Checked)
            {
                CSistema_NumyLetr.NumerosYLetras = true;
            }

        }
        private void Chb_CaracEspec_CheckedChanged(object sender, EventArgs e)
        {
            if (Chb_CaracEspec.Checked)
            {
                CSistema_CaracEspecial.CaractEspecial = true;
            }

        }
        private void Chb_DatosPersonales_CheckedChanged(object sender, EventArgs e)
        {
            if (Chb_DatosPersonales.Checked)
            {
                CSistema_DatosPersonales.DatosPersonales = true;
            }

        }
        private void Chb_MayMin_CheckedChanged(object sender, EventArgs e)
        {
            if (Chb_MayMin.Checked)
            {
                CSistema_MayMin.MayMin = true;
            }

        }
        private void Chb_MinCaracteres_CheckedChanged(object sender, EventArgs e)
        {
            if (Chb_MinCaracteres.Checked)
            {
                CSistema_MinimoCaracteres.Caracteres = true;
            }
        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                capturarDatos(0);
                Sistema.GuardarCambiosDeSeguridad();
                CServ_MsjUsuario.Exito("¡Configuración guardada con éxito!");

            }
            catch (Exception)
            {
                CServ_MsjUsuario.MensajesDeError("No se ha podido guardar los cambios realizados");
            }
        }
        private void capturarDatos(int Numero)
        {
            switch (Numero)
            {
                case 0:
                    Sistema.NumerosYLetras = Chb_NumYLetras.Checked;
                    Sistema.CaractEspecial = Chb_CaracEspec.Checked;
                    Sistema.DatosPersonales = Chb_DatosPersonales.Checked;
                    Sistema.MayusMinus = Chb_MayMin.Checked;
                    Sistema.MinCaracteres = Chb_MinCaracteres.Checked;
                    Sistema.RepetirPass = Chb_RepetirPass.Checked;
                    Sistema.CantIntentosFallidos = Convert.ToInt32(Nud_CantidadIntentosFallidos.Value);

                    break;
            case 1:
                    Sistema.UserName = Txb_UserName.Text;
                    Sistema.FechaDesde = Dtp_Desde.Value.ToString();
                    Sistema.FechaHasta = Dtp_Hasta.Value.ToString();
                    if (Cmb_Tipo.SelectedValue == null) Sistema.Accion = 0.ToString();
                    else Sistema.Accion = Cmb_Tipo.SelectedValue.ToString();
                    break;
            }

        }

        private void Btn_Bitacora_Click(object sender, EventArgs e)
        {
            Pnl_Bitacora.Visible = true;
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                capturarDatos(1);
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
    }
}
