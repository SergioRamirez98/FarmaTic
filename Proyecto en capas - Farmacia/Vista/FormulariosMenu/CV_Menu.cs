using Logica;
using Servicios;
using Sesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.FormulariosMenu;

namespace Vista
{
    public partial class CV_Menu : Form
    {              
        public CV_Menu()
        {
            InitializeComponent();     
        }
        private void CV_Menu_Load(object sender, EventArgs e)
        {
            accesoAModulos();
        }

        private void Btn_GestionUsuarios_Click(object sender, EventArgs e)
        {
            CV_GestionUsuariosPersonas agregarPersona = new CV_GestionUsuariosPersonas();
            agregarPersona.Show();         
        }
        private void Btn_CerraSesion_Click(object sender, EventArgs e)
        {
            CSesion_PersonaSeleccionada.SesionActiva = false;
            CSesion_PersonaSeleccionada.LimpiarCache();
            CSesion_SesionIniciada.SesionActiva = false;
            CSesion_SesionIniciada.LimpiarCache();
            CSesion_PreguntasUsuarios.SesionActiva = false;
            CSesion_PreguntasUsuarios.LimpiarCache();
            this.Close();
            Program.Login.Show();
        }
        private void CV_Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            CSesion_PersonaSeleccionada.SesionActiva = false;
            CSesion_PersonaSeleccionada.LimpiarCache();
            CSesion_SesionIniciada.SesionActiva = false;
            CSesion_SesionIniciada.LimpiarCache();
            CSesion_PreguntasUsuarios.SesionActiva = false;
            CSesion_PreguntasUsuarios.LimpiarCache();            
            Program.Login.Show();
        }
        private void Btn_Config_Click(object sender, EventArgs e)
        {
            CV_ModulodeSeguridad Configuracion = new CV_ModulodeSeguridad();
            Configuracion.Show();
        }
        private void Btn_ModuloInventario_Click(object sender, EventArgs e)
        {
            CV_Stock stock = new CV_Stock();
            stock.Show();
        }
        private void Btn_GestionVentas_Click(object sender, EventArgs e)
        {
            CV_Ventas ventas = new CV_Ventas();
            ventas.Show();
        }
        private void Btn_Proveedores_Click(object sender, EventArgs e)
        {
            CV_GestionProveedores Proveedores = new CV_GestionProveedores();
            Proveedores.Show();
        }
        private void Btn_Administracion_Click(object sender, EventArgs e)
        {
            CV_MenudeAdministracion GC = new CV_MenudeAdministracion();
            GC.Show();
        }
        private void Btn_ConfigSistema_Click(object sender, EventArgs e)
        {
            CV_ConfiguracionSistema ConfiguracionSistema = new CV_ConfiguracionSistema();
            ConfiguracionSistema.Show();
        }
        private void accesoAModulos()
        {
            Btn_GestionUsuarios.Enabled = false;
            Btn_GestionVentas.Enabled = false;
            Btn_ModuloInventario.Enabled = false;
            Btn_Administracion.Enabled = false;
            Btn_ConfigSeguridad.Enabled = false;
            Btn_ConfigSistema.Enabled = false;

            foreach (var permiso in CSesion_SesionIniciada.Permisos)
            {
                switch (permiso.ID_Rol)
                {
                    case 1: 
                        Btn_GestionUsuarios.Enabled = true;
                        Btn_GestionVentas.Enabled = true;
                        Btn_ModuloInventario.Enabled = true;
                        Btn_Administracion.Enabled = true;
                        Btn_ConfigSeguridad.Enabled = true;
                        Btn_ConfigSistema.Enabled = true;
                        break;

                    case 2: 
                        Btn_GestionUsuarios.Enabled = true;
                        break;
                    case 7:
                        Btn_GestionUsuarios.Enabled = true;
                        break;
                    case 17:
                        Btn_ConfigSeguridad.Enabled = true;
                        break;
                    case 19:
                        Btn_ModuloInventario.Enabled = true;
                        break;
                    case 33:
                        Btn_GestionVentas.Enabled = true;
                        break;                    
                    case 61:
                        Btn_Administracion.Enabled = true;
                        break;
                    case 62:
                        Btn_ConfigSistema.Enabled = true;
                        break;
                }
            }
        }

        
    }
}
