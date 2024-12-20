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
        private bool PanelSecundario = false;
        public CV_Menu()
        {
            InitializeComponent();
            InitializeMenuEvents();
            CV_Idioma.CargarIdioma(this.Controls, this);
        }
        private void CV_Menu_Load(object sender, EventArgs e)
        {
            configurarFormulario(this, this);
            configurarLoad();
            accesoAModulos();

        }

        #region Eventos
        private void Btn_GestionAltas_MouseEnter(object sender, EventArgs e)
        {
            if (!Btn_Ventas.Visible && !Btn_Proveedores.Visible)
            {
                Btn_AltaPersonas.Visible = true;
                Btn_Usuarios.Visible = true;
            }
        }
        private void Btn_GestionAltas_MouseLeave(object sender, EventArgs e)
        {
            if (!PanelSecundario)
            {
                Btn_AltaPersonas.Visible = false;
                Btn_Usuarios.Visible = false;
            }
        }
        private void Btn_GestionVentas_MouseEnter(object sender, EventArgs e)
        {
            if (!Btn_Usuarios.Visible && !Btn_Proveedores.Visible)
            {
                Btn_Ventas.Visible = true;
                Btn_ConsultaVentas.Visible = true;
            }
        }
        private void Btn_GestionVentas_MouseLeave(object sender, EventArgs e)
        {
            if (!PanelSecundario)
            {
                Btn_ConsultaVentas.Visible = false;
                Btn_Ventas.Visible = false;
            }

        }
        private void Btb_Administracion_MouseEnter(object sender, EventArgs e)
        {
            if (!Btn_Usuarios.Visible && !Btn_ConsultaVentas.Visible)
            {
                Btn_Informes.Visible = true;
                Btn_Catalogo.Visible = true;
                Btn_OrdendeCompra.Visible = true;
                Btn_PedidodeCompra.Visible = true;
                Btn_Proveedores.Visible = true;
            }
        }   
        private void Btn_ModuloAdministracion_MouseLeave(object sender, EventArgs e)
        {
            if (!PanelSecundario)
            {

                Btn_Informes.Visible = false;
                Btn_Catalogo.Visible = false;
                Btn_OrdendeCompra.Visible = false;
                Btn_PedidodeCompra.Visible = false;
                Btn_Proveedores.Visible = false;
            }
        }
        private void Btn_GestionAltas_Click(object sender, EventArgs e)
        {
            PanelSecundario = true;
            if (PanelSecundario)
            {
                Btn_AltaPersonas.Visible = true;
                Btn_Usuarios.Visible = true;
                Btn_Ventas.Visible = false;
                Btn_ConsultaVentas.Visible = false;
                Btn_Proveedores.Visible = false;
                Btn_Catalogo.Visible = false;
                Btn_PedidodeCompra.Visible = false;
                Btn_OrdendeCompra.Visible = false;
                Btn_Informes.Visible = false;
            }
        }
        private void Btn_GestionVentas_Click(object sender, EventArgs e)
        {
            PanelSecundario = true;
            if (PanelSecundario)
            {
                Btn_ConsultaVentas.Visible = true;
                Btn_Ventas.Visible = true;

                Btn_AltaPersonas.Visible = false;
                Btn_Usuarios.Visible = false;

                Btn_Proveedores.Visible = false;
                Btn_Catalogo.Visible = false;
                Btn_PedidodeCompra.Visible = false;
                Btn_OrdendeCompra.Visible = false;
                Btn_Informes.Visible = false;
            }

        }
        private void Btn_ModuloAdministracion_Click(object sender, EventArgs e)
        {
            PanelSecundario = true;
            if (PanelSecundario)
            {
                Btn_Informes.Visible = true;
                Btn_Catalogo.Visible = true;
                Btn_OrdendeCompra.Visible = true;
                Btn_PedidodeCompra.Visible = true;
                Btn_Proveedores.Visible = true;

                Btn_AltaPersonas.Visible = false;
                Btn_Usuarios.Visible = false;
                Btn_ConsultaVentas.Visible = false;
                Btn_Ventas.Visible = false;
            }
        }
        private void Btn_Ventas_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_Ventas"];
            if (FrmOpen == null)
            {
                CV_Ventas ventas = new CV_Ventas();
                configurarFormulario(this, ventas);
                ventas.MdiParent = this;
                ventas.Show();
                Pnl_Menu.SendToBack();
            }
            else
            {
                configurarFormulario(this, FrmOpen);  
                FrmOpen.BringToFront();
            }
        }
        private void Btn_ConsultaVentas_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_ConsultaVentas"];
            if (FrmOpen == null)
            {
                CV_ConsultaVentas consulta = new CV_ConsultaVentas();
                configurarFormulario(this, consulta);
                consulta.MdiParent = this;
                consulta.Show();
                Pnl_Menu.SendToBack();
            }
            else
            {
                configurarFormulario(this, FrmOpen);
                FrmOpen.BringToFront();
            }

        }
        private void Btn_AltaPersonas_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_GestionUsuariosPersonas"];
            if (FrmOpen == null)
            {
                CV_GestionUsuariosPersonas agregarPersona = new CV_GestionUsuariosPersonas();
                configurarFormulario(this, agregarPersona);
                agregarPersona.MdiParent = this;
                agregarPersona.Show();
                Pnl_Menu.SendToBack();
            }
            else
            {
                configurarFormulario(this, FrmOpen);
                FrmOpen.BringToFront();
            }

        }
        private void Btn_Usuarios_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_AltaUsuario"];
            if (FrmOpen == null)
            {
                CV_AltaUsuario usuario = new CV_AltaUsuario(0);
                configurarFormulario(this, usuario);
                usuario.MdiParent = this;
                usuario.Show();
                Pnl_Menu.SendToBack();
            }
            else
            {
                configurarFormulario(this, FrmOpen);
                FrmOpen.BringToFront();
            }
        } 
        private void Btn_GestionStock_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_Stock"];
            if (FrmOpen == null)
            {
                CV_Stock Stock = new CV_Stock();
                configurarFormulario(this, Stock);
                Stock.MdiParent = this;
                Stock.Show();
                Pnl_Menu.SendToBack();
            }
            else
            {
                configurarFormulario(this, FrmOpen);
                FrmOpen.BringToFront();
            }
        }
        private void Btn_Seguridad_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_ModulodeSeguridad"];
            if (FrmOpen == null)
            {
                CV_ModulodeSeguridad Seguridad = new CV_ModulodeSeguridad();
                configurarFormulario(this, Seguridad);
                Seguridad.MdiParent = this;
                Seguridad.Show();
                Pnl_Menu.SendToBack();
            }
            else
            {
                configurarFormulario(this, FrmOpen);
                FrmOpen.BringToFront();
            }
        }
        private void Btn_ConfSistema_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_ConfiguracionSistema "];
            if (FrmOpen == null)
            {
                CV_ConfiguracionSistema Sistema = new CV_ConfiguracionSistema();
                configurarFormulario(this, Sistema);
                Sistema.MdiParent = this;
                Sistema.Show();
                Pnl_Menu.SendToBack();
            }
            else
            {
                configurarFormulario(this, FrmOpen);
                FrmOpen.BringToFront();
            }

        }
        private void Btn_Proveedores_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_GestionProveedores"];
            if (FrmOpen == null)
            {
                CV_GestionProveedores Proveedores = new CV_GestionProveedores();
                configurarFormulario(this, Proveedores);
                Proveedores.MdiParent = this;
                Proveedores.Show();
                Pnl_Menu.SendToBack();
            }
            else
            {
                configurarFormulario(this, FrmOpen);
                FrmOpen.BringToFront();
            }
        }
        private void Btn_PedidodeCompra_Click(object sender, EventArgs e)
        {

            Form FrmOpen = Application.OpenForms["CV_PedidodeCompra"];
            if (FrmOpen == null)
            {
                CV_PedidodeCompra PC = new CV_PedidodeCompra();
                configurarFormulario(this, PC);
                PC.MdiParent = this;
                PC.Show();
                Pnl_Menu.SendToBack();
            }
            else
            {
                configurarFormulario(this, FrmOpen);
                FrmOpen.BringToFront();
            }
        }
        private void Btn_OrdendeCompra_Click(object sender, EventArgs e)
        {

            Form FrmOpen = Application.OpenForms["CV_GestionOrdenDeCompra"];
            if (FrmOpen == null)
            {
                CV_GestionOrdenDeCompra oc = new CV_GestionOrdenDeCompra();
                configurarFormulario(this, oc);
                oc.MdiParent = this;
                oc.Show();
                Pnl_Menu.SendToBack();
            }
            else
            {
                configurarFormulario(this, FrmOpen);
                FrmOpen.BringToFront();
            }
        }
        private void Btn_Catalogo_Click(object sender, EventArgs e)
        {

            Form FrmOpen = Application.OpenForms["CV_CatalogoProductos"];
            if (FrmOpen == null)
            {
                CV_CatalogoProductos Catalogo = new CV_CatalogoProductos();
                configurarFormulario(this, Catalogo);
                Catalogo.MdiParent = this;
                Catalogo.Show();
                Pnl_Menu.SendToBack();
            }
            else
            {
                configurarFormulario(this, FrmOpen);
                FrmOpen.BringToFront();
            }
        }
        private void Btn_Informes_Click(object sender, EventArgs e)
        {

            Form FrmOpen = Application.OpenForms["CV_Informes"];
            if (FrmOpen == null)
            {
                CV_Informes Informes = new CV_Informes();
                configurarFormulario(this, Informes);
                Informes.MdiParent = this;
                Informes.Show();
                Pnl_Menu.SendToBack();
            }
            else
            {
                configurarFormulario(this, FrmOpen);
                FrmOpen.BringToFront();
            }
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
        #endregion

        #region Métodos
        private void accesoAModulos()
        {
            Btn_GestionAltas.Enabled = false;
            Btn_Usuarios.Enabled = false;
            Btn_AltaPersonas.Enabled = false;

            Btn_Ventas.Enabled = false;
            Btn_ConsultaVentas.Enabled = false;
            Btn_GestionVentas.Enabled = false;

            Btn_GestionStock.Enabled = false;
            Btn_Seguridad.Enabled = false;
            Btn_ConfSistema.Enabled = false;


            Btn_ModuloAdministracion.Enabled = false;
            Btn_Proveedores.Enabled = false;
            Btn_PedidodeCompra.Enabled = false;
            Btn_OrdendeCompra.Enabled = false;
            Btn_Informes.Enabled = false;
            Btn_Catalogo.Enabled = false;


            foreach (var permiso in CSesion_SesionIniciada.Permisos)
            {
                switch (permiso.ID_Rol)
                {
                    case 1:
                        Btn_GestionAltas.Enabled = true;

                        Btn_Ventas.Enabled = true;
                        Btn_ConsultaVentas.Enabled = true;
                        Btn_GestionVentas.Enabled = true;
                        


                        Btn_GestionStock.Enabled = true;
                        Btn_Usuarios.Enabled = true;
                        Btn_ModuloAdministracion.Enabled = true;
                        Btn_Seguridad.Enabled = true;
                        Btn_ConfSistema.Enabled = true;
                        Btn_AltaPersonas.Enabled = true;


                        Btn_Proveedores.Enabled = true;
                        Btn_PedidodeCompra.Enabled = true;
                        Btn_OrdendeCompra.Enabled = true;
                        Btn_Informes.Enabled = true;
                        Btn_Catalogo.Enabled = true;

                        break;

                    case 2:
                        Btn_GestionAltas.Enabled = true;
                        break;
                    case 7:
                        Btn_AltaPersonas.Enabled = true;
                        break;
                    case 12:
                        Btn_Usuarios.Enabled = true;
                        break;
                    case 17:
                           Btn_ConfSistema.Enabled = true;
                        break;
                    case 19:
                        Btn_GestionStock.Enabled = true;
                        break;
                    case 33:
                        Btn_GestionVentas.Enabled = true;
                        Btn_Ventas.Enabled=true;
                        break;
                    case 39:
                        Btn_ConsultaVentas.Enabled = true;
                        break;
                    case 42:
                        Btn_Proveedores.Enabled = true;
                        break;
                    case 46:
                        Btn_Catalogo.Enabled = true;
                        break;
                    case 51:
                        Btn_PedidodeCompra.Enabled = true;
                        break;
                    case 56:
                        Btn_OrdendeCompra.Enabled = true;
                        break;
                    case 61:
                        Btn_ModuloAdministracion.Enabled = true;
                        break;
                    case 62:
                        Btn_ConfSistema.Enabled = true;
                        break;
                    case 67:
                        Btn_Informes.Enabled = true;
                        break;
                }
            }
        }       
        private void InitializeMenuEvents()
        {
            Timer timerVerificarCursor = new Timer();
            timerVerificarCursor.Interval = 100;
            timerVerificarCursor.Tick += TimerVerificarCursor_Tick;
            timerVerificarCursor.Start();
        }
        private void CV_Menu_MouseMove(object sender, MouseEventArgs e)
        {
            int areaMenu = 113;
            if (e.X <= areaMenu) { Pnl_Principal.Visible = true; Btn_CerraSesion.Visible = true; }
            else { Pnl_Principal.Visible = false; Btn_CerraSesion.Visible = false; }
        }
        private void TimerVerificarCursor_Tick(object sender, EventArgs e)
        {
            if (this.IsDisposed) return;
            Point posicionCursor = this.PointToClient(Cursor.Position);
            Rectangle areaMenu = Pnl_Principal.Bounds;
            bool cursorEnMargenIzquierdo = posicionCursor.X <= 20;
            bool cursorEnAreaMenu = areaMenu.Contains(posicionCursor);
            if (cursorEnMargenIzquierdo || PanelSecundario)
            {
                if (cursorEnAreaMenu)
                {
                    Pnl_Principal.Visible = true;
                    Btn_CerraSesion.Visible = true;
                    Pnl_Menu.Visible = false;

                }
            }
            else
            {
                if (!cursorEnAreaMenu)
                {
                    Pnl_Principal.Visible = false;
                    Btn_CerraSesion.Visible = false;

                    Pnl_Menu.Visible = true;

                    if (!PanelSecundario)
                    {
                        Btn_AltaPersonas.Visible = false;
                        Btn_Usuarios.Visible = false;
                        Btn_Ventas.Visible = false;
                        Btn_ConsultaVentas.Visible = false;
                        Btn_Proveedores.Visible = false;
                        Btn_Catalogo.Visible = false;
                        Btn_PedidodeCompra.Visible = false;
                        Btn_OrdendeCompra.Visible = false;
                        Btn_Informes.Visible = false;
                        Pnl_Menu.Visible = true;
                    }
                }
            }
        }
        private void configurarLoad()
        {
            Pnl_Menu.Location = new Point (1, 150);
            this.BackColor = Color.FromArgb(173, 216, 230); 

            foreach (Control control in this.Controls)
            {
                if (control.GetType().Name == "MdiClient")
                {
                    control.BackColor = Color.FromArgb(173, 216, 230); 
                    break; 
                }
            }


            Btn_AltaPersonas.Visible = false;
            Btn_Usuarios.Visible = false;
            Btn_Ventas.Visible = false;
            Btn_ConsultaVentas.Visible = false;
            Btn_Proveedores.Visible = false;
            Btn_Catalogo.Visible = false;
            Btn_PedidodeCompra.Visible = false;
            Btn_OrdendeCompra.Visible = false;
            Btn_Informes.Visible = false;
            Pnl_Menu.Visible = true;
        }
        public void configurarFormulario(Form padre, Form Hijo) 
        {
            padre.Width = Hijo.Width;
            if (padre.Height < Hijo.Height) { padre.Height = Hijo.Height; Pnl_Principal.Height = Hijo.Height; }
            else
            {
                padre.Height = padre.Height;
                Pnl_Principal.Height = padre.Height;
            }
            PanelSecundario = false;
        }
        private void CV_Menu_Click(object sender, EventArgs e)
        {
            PanelSecundario = false;
            Pnl_Principal.Visible = false;

            Btn_AltaPersonas.Visible = false;
            Btn_Usuarios.Visible = false;
            Btn_Ventas.Visible = false;
            Btn_ConsultaVentas.Visible = false;
            Btn_Proveedores.Visible = false;
            Btn_Catalogo.Visible = false;
            Btn_PedidodeCompra.Visible = false;
            Btn_OrdendeCompra.Visible = false;
            Btn_Informes.Visible = false;
        }
        #endregion

        
    }
}
