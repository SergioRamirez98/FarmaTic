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

namespace Vista
{
    public partial class CV_Configuracion : Form
    {
        CL_Sistema Sistema = new CL_Sistema();
        public CV_Configuracion()
        {
            Sistema.CargarConfiguracion();
            InitializeComponent();
        }
        private void CV_Configuracion_Load(object sender, EventArgs e)
        {
            Chb_NumYLetras.Checked = CSistema_ConfiguracionSistema.NumerosYLetras;
            Chb_CaracEspec.Checked = CSistema_ConfiguracionSistema.CaractEspecial;
            Chb_DatosPersonales.Checked = CSistema_ConfiguracionSistema.DatosPersonales;
            Chb_MayMin.Checked = CSistema_ConfiguracionSistema.MayusMinus;
            Chb_MinCaracteres.Checked = CSistema_ConfiguracionSistema.MinCaracteres;
            Nud_CantMinStock.Value = CSistema_ConfiguracionSistema.CantMinimadeStock;
            Nud_VtoProd.Value = CSistema_ConfiguracionSistema.AvisosVtoProductos;
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
                CapturarDatos();
                Sistema.GuardarCambios();
                CServ_MsjUsuario.Exito("¡Configuración guardada con éxito!");

            }
            catch (Exception)
            {
                CServ_MsjUsuario.MensajesDeError("No se ha podido guardar los cambios realizados");
            }
        }
        private void CapturarDatos()
        {
            Sistema.NumerosYLetras = Chb_NumYLetras.Checked;
            Sistema.CaractEspecial = Chb_CaracEspec.Checked;
            Sistema.DatosPersonales = Chb_DatosPersonales.Checked;
            Sistema.MayusMinus = Chb_MayMin.Checked;
            Sistema.MinCaracteres = Chb_MinCaracteres.Checked;
            Sistema.RepetirPass = Chb_RepetirPass.Checked;
            Sistema.AvisosVtoProductos = Convert.ToInt32(Nud_VtoProd.Value);
            Sistema.CantMinimadeStock = Convert.ToInt32(Nud_CantMinStock.Value);
            Sistema.CantIntentosFallidos = Convert.ToInt32(Nud_CantidadIntentosFallidos.Value);

        }
    }
}
