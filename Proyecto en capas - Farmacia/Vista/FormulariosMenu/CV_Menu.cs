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
using Vista.FormulariosMenu.Compras;
using Vista.FormulariosMenu.GestionPersonas;

namespace Vista
{
    public partial class CV_Menu : Form
    {
        private bool mouseMenu = false;
        public CV_Menu()
        {
            InitializeComponent();
            InitializeMenuEvents();
        }
        private void CV_Menu_Load(object sender, EventArgs e)
        {
            accesoAModulos();
        }


        private void Ms_Personas_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_GestionUsuariosPersonas"];
            if (FrmOpen == null)
            {
                CV_GestionUsuariosPersonas agregarPersona = new CV_GestionUsuariosPersonas();
                agregarPersona.MdiParent = this;
                agregarPersona.Show();
            }

        }
        private void Ms_ModuloConfiguracionSistema_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_ConfiguracionSistema"];
            if (FrmOpen == null)
            {
                CV_ConfiguracionSistema configuracionSistema = new CV_ConfiguracionSistema();
                configuracionSistema.MdiParent = this;
                configuracionSistema.Show();
            }
        }
        private void Ms_ModuloStock_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_Stock"];
            if (FrmOpen == null)
            {
                CV_Stock stock = new CV_Stock();
                stock.MdiParent = this;
                stock.Show();
            }
        }

        private void Ms_ModuloVentas_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_Ventas"];
            if (FrmOpen == null)
            {
                CV_Ventas ventas = new CV_Ventas();
                ventas.MdiParent = this;
                ventas.Show();
            }
        }

        private void Ms_ModuloSeguridad_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_ModulodeSeguridad"];
            if (FrmOpen == null)
            {
                CV_ModulodeSeguridad seguridad = new CV_ModulodeSeguridad();
                seguridad.MdiParent = this;
                seguridad.Show();
            }
        }

        private void Ms_Proveedores_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_GestionProveedores"];
            if (FrmOpen == null)
            {
                CV_GestionProveedores Proveedores = new CV_GestionProveedores();
                Proveedores.MdiParent = this;
                Proveedores.Show();
            }
        }
        private void Ms_Catalogo_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_CatalogoProductos"];
            if (FrmOpen == null)
            {
                CV_CatalogoProductos Catalogo = new CV_CatalogoProductos();
                Catalogo.MdiParent = this;
                Catalogo.Show();
            }
        }

        private void Ms_PediodeCompra_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_PedidodeCompra"];
            if (FrmOpen == null)
            {
                CV_PedidodeCompra PC = new CV_PedidodeCompra();
                PC.MdiParent = this;
                PC.Show();
            }
        }

        private void Ms_OrdendeCompra_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_GestionOrdenDeCompra"];
            if (FrmOpen == null)
            {
                CV_GestionOrdenDeCompra OC = new CV_GestionOrdenDeCompra();
                OC.MdiParent = this;
                OC.Show();
            }
        }

        private void Ms_Informes_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_Informes"];
            if (FrmOpen == null)
            {
                CV_Informes informes = new CV_Informes();
                informes.MdiParent = this;
                informes.Show();
            }
        }

        private void Ms_Usuarios_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_AltaUsuario"];
            if (FrmOpen == null)
            {
                CV_AltaUsuario usuario = new CV_AltaUsuario(0);
                usuario.MdiParent = this;
                usuario.Show();
            }
        }



        private void Btn_GestionUsuarios_Click(object sender, EventArgs e)
        {
            CV_GestionUsuariosPersonas agregarPersona = new CV_GestionUsuariosPersonas();
            agregarPersona.Show();
        }
        private void Btn_Config_Click(object sender, EventArgs e)
        {
        }
        private void Btn_ModuloInventario_Click(object sender, EventArgs e)
        {
            CV_Stock stock = new CV_Stock();
            stock.Show();
        }
        private void Btn_GestionVentas_Click(object sender, EventArgs e)
        {

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
        private void accesoAModulos()
        {
            Ms_ModuloAltas.Enabled = false;
            Ms_ModuloVentas.Enabled = false;
            Ms_ModuloStock.Enabled = false;
            Ms_ModuloAdministracion.Enabled = false;            
            Ms_ModuloSeguridad.Enabled = false;
            Ms_ModuloConfiguracionSistema.Enabled = false;
            Ms_Usuarios.Enabled = false;

            Ms_ModuloAdministracion.Enabled = false;
            Ms_Proveedores.Enabled = false;
            Ms_PediodeCompra.Enabled = false;
            Ms_OrdendeCompra.Enabled = false;
            Ms_Informes.Enabled = false;
            Ms_Catalogo.Enabled = false;


            foreach (var permiso in CSesion_SesionIniciada.Permisos)
            {
                switch (permiso.ID_Rol)
                {
                    case 1:
                        Ms_ModuloAltas.Enabled = true;
                        Ms_ModuloVentas.Enabled = true;
                        Ms_ModuloStock.Enabled = true;
                        Ms_Usuarios.Enabled = true;
                        Ms_ModuloAdministracion.Enabled = true;                        
                        Ms_ModuloSeguridad.Enabled = true;
                        Ms_ModuloConfiguracionSistema.Enabled = true;


                        Ms_Proveedores.Enabled = true;
                        Ms_PediodeCompra.Enabled = true;
                        Ms_OrdendeCompra.Enabled = true;
                        Ms_Informes.Enabled = true;
                        Ms_Catalogo.Enabled = true;

                        break;

                    case 2:
                        Ms_ModuloAltas.Enabled = true;
                        break;
                    case 7:
                        Ms_ModuloAltas.Enabled = true;
                        break;
                    case 12:
                        Ms_Usuarios.Enabled = true;
                        break;
                    case 17:
                        Ms_ModuloConfiguracionSistema.Enabled = true;
                        break;
                    case 19:
                        Ms_ModuloStock.Enabled = true;
                        break;
                    case 33:
                        Ms_ModuloVentas.Enabled = true;
                        break;
                    case 42:
                        Ms_Proveedores.Enabled = true;
                        break;
                    case 46:
                        Ms_Catalogo.Enabled = true;
                        break;
                    case 51:
                        Ms_PediodeCompra.Enabled = true;
                        break;
                    case 56:
                        Ms_OrdendeCompra.Enabled = true;
                        break;
                    case 61:
                        Ms_ModuloAdministracion.Enabled = true;
                        break;
                    case 62:
                        Ms_ModuloConfiguracionSistema.Enabled = true;
                        break;
                    case 67:
                        Ms_Informes.Enabled = true;
                        break;
                }
            }
        }
        private void CV_Menu_MouseMove(object sender, MouseEventArgs e)
        {
            int areaMenu = 113;
            if (e.X <= areaMenu) { Ms_Menu.Visible = true; Btn_CerraSesion.Visible = true; }
            else { Ms_Menu.Visible = false; Btn_CerraSesion.Visible = false; }
        }
        private void Ms_Menu_MouseLeave(object sender, EventArgs e)
        {
            mouseMenu = false;
            Ms_Menu.Visible = false;
            Btn_CerraSesion.Visible = false;
        }
        private void Ms_Menu_MouseEnter(object sender, EventArgs e)
        {
            mouseMenu = true;
            Ms_Menu.Visible = true;
            Btn_CerraSesion.Visible = true;

        }
        private void Ms_Menu_Item_MouseEnter(object sender, EventArgs e)
        {
            mouseMenu = true;
            Ms_Menu.Visible = true;
            Btn_CerraSesion.Visible = true;
        }
        private void Ms_Menu_Item_MouseLeave(object sender, EventArgs e)
        {
            mouseMenu = false;
            Ms_Menu.Visible = false;
            Btn_CerraSesion.Visible = false;
        }
        private void InitializeMenuEvents()
        {
            foreach (ToolStripMenuItem item in Ms_Menu.Items)
            {
                item.MouseEnter += Ms_Menu_Item_MouseEnter;
                item.MouseLeave += Ms_Menu_Item_MouseLeave;

                foreach (ToolStripMenuItem subItem in item.DropDownItems)
                {
                    subItem.MouseEnter += Ms_Menu_Item_MouseEnter;
                    subItem.MouseLeave += Ms_Menu_Item_MouseLeave;
                }
            }
        }
    }
}
