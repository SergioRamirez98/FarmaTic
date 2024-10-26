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

namespace Vista.FormulariosMenu
{
    public partial class CV_ConfiguracionSistema : Form
    {
        CL_Sistema Sistema = new CL_Sistema();
        public CV_ConfiguracionSistema()
        {
            InitializeComponent();
        }

        private void CV_ConfiguracionSistema_Load(object sender, EventArgs e)
        {            
            Nud_CantMinStock.Value = CSistema_ConfiguracionSistema.CantMinimadeStock;
            Nud_VtoProd.Value = CSistema_ConfiguracionSistema.AvisosVtoProductos;
        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                capturarDatos();
                Sistema.GuardarCambiosDeSistema();
                CServ_MsjUsuario.Exito("¡Configuración guardada con éxito!");
            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }
        }
        private void capturarDatos()
        {

            Sistema.AvisosVtoProductos = Convert.ToInt32(Nud_VtoProd.Value);
            Sistema.CantMinimadeStock = Convert.ToInt32(Nud_CantMinStock.Value);
            

        }
    }
}
