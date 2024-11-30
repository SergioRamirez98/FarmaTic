﻿using Logica;
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
        }
        private void CV_Menu_Load(object sender, EventArgs e)
        {
            configurarFormulario(this, this);
            configurarLoad();
            accesoAModulos();
        }


        private void Ms_Personas_Click(object sender, EventArgs e)
        {

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
            Btn_GestionAltas.Enabled = false;
            Btn_Ventas.Enabled = false;
            Btn_GestionStock.Enabled = false;
            Btn_ModuloAdministracion.Enabled = false;
            Btn_Seguridad.Enabled = false;
            Btn_ConfSistema.Enabled = false;
            Btn_Usuarios.Enabled = false;
            Btn_AltaPersonas.Enabled = false;

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
                     //   Ms_ModuloConfiguracionSistema.Enabled = true;
                        break;
                    case 19:
                        Btn_GestionStock.Enabled = true;
                        break;
                    case 33:
                      //  Ms_ModuloVentas.Enabled = true;
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
                        //Ms_ModuloConfiguracionSistema.Enabled = true;
                        break;
                    case 67:
                        Btn_Informes.Enabled = true;
                        break;
                }
            }
        }
        private void CV_Menu_MouseMove(object sender, MouseEventArgs e)
        {
            int areaMenu = 113;
            if (e.X <= areaMenu) { Pnl_Principal.Visible = true; Btn_CerraSesion.Visible = true; }
            else { Pnl_Principal.Visible = false; Btn_CerraSesion.Visible = false; }
        }
        private void Ms_Menu_MouseLeave(object sender, EventArgs e)
        {
            mouseMenu = false;
            Pnl_Principal.Visible = false;
            Btn_CerraSesion.Visible = false;
        }
        private void Ms_Menu_MouseEnter(object sender, EventArgs e)
        {
            mouseMenu = true;
            
            Pnl_Principal.Visible = true;
            Btn_CerraSesion.Visible = true;

        }
        private void Ms_Menu_Item_MouseEnter(object sender, EventArgs e)
        {
            mouseMenu = true;
            Pnl_Principal.Visible = true;
            Btn_CerraSesion.Visible = true;
        }
        private void Ms_Menu_Item_MouseLeave(object sender, EventArgs e)
        {
            mouseMenu = false;
            Pnl_Principal.Visible = false;
            Btn_CerraSesion.Visible = false;
        }
        private void InitializeMenuEvents()
        {

         Timer   timerVerificarCursor = new Timer();
            timerVerificarCursor.Interval = 100;
            timerVerificarCursor.Tick += TimerVerificarCursor_Tick;
            timerVerificarCursor.Start();
        }

        private void Btn_GestionAltas_MouseEnter(object sender, EventArgs e)
        {
            if (!Btn_Ventas.Visible && !Btn_Proveedores.Visible)
            {
                Btn_AltaPersonas.Visible = true;
                Btn_Usuarios.Visible = true;
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

        private void Btn_Ventas_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_Ventas"];
            if (FrmOpen == null)
            {
                CV_Ventas ventas = new CV_Ventas();
                configurarFormulario(this, ventas);
                ventas.MdiParent = this;
                ventas.Show();
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
            }
        }



        private void TimerVerificarCursor_Tick(object sender, EventArgs e)
        {
            if (this.IsDisposed) return;

            
            Point posicionCursor = this.PointToClient(Cursor.Position);

            //Rectangle areaFormulario = this.ClientRectangle;
            Rectangle areaMenu = Pnl_Principal.Bounds;

            //Rectangle areaMenuLimitada = new Rectangle(areaMenu.Left, areaMenu.Top,35, areaMenu.Height);

            //bool cursorEnFormulario = posicionCursor.X >= 0 && posicionCursor.X <= areaFormulario.Width &&
            //                           posicionCursor.Y >= 0 && posicionCursor.Y <= areaFormulario.Height;

            bool cursorEnMargenIzquierdo = posicionCursor.X <= 20;
            bool cursorEnAreaMenu = areaMenu.Contains(posicionCursor);
            if (cursorEnMargenIzquierdo || PanelSecundario)
            {
                if (cursorEnAreaMenu)
                {
                    Pnl_Principal.Visible = true;
                    Btn_CerraSesion.Visible = true;

                }
            }
            else
            {
                if (!cursorEnAreaMenu)
                {
                    Pnl_Principal.Visible = false;
                    Btn_CerraSesion.Visible = false;

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
                    }
                }
            }
        }
        private void configurarLoad()
        {
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
        }
        private void configurarFormulario(Form padre, Form Hijo) 
        {
            padre.Width = Hijo.Width;
            padre.Height = Hijo.Height;
            PanelSecundario = false;
        }

        private void Btn_GestionAltas_Click(object sender, EventArgs e)
        {
            PanelSecundario = true;
            if (PanelSecundario)
            {
                Btn_AltaPersonas.Visible = true;
                Btn_Usuarios.Visible= true;                
                Btn_Ventas.Visible = false;
                Btn_ConsultaVentas.Visible = false;
                Btn_Proveedores.Visible = false;
                Btn_Catalogo.Visible = false;
                Btn_PedidodeCompra.Visible = false;
                Btn_OrdendeCompra.Visible = false;
                Btn_Informes.Visible = false;
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

        private void Btn_GestionVentas_MouseLeave(object sender, EventArgs e)
        {
            if (!PanelSecundario)
            {

                Btn_ConsultaVentas.Visible = false;
                Btn_Ventas.Visible = false;
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

        private void Btn_GestionStock_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_Stock"];
            if (FrmOpen == null)
            {
                CV_Stock Stock = new CV_Stock();
                configurarFormulario(this, Stock);
                Stock.MdiParent = this;
                Stock.Show();
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
            }
        }

        private void Btn_ConfSistema_Click(object sender, EventArgs e)
        {
            Form FrmOpen = Application.OpenForms["CV_ConfiguracionSistema "];
            if (FrmOpen == null)
            {
             CV_ConfiguracionSistema Sistema= new CV_ConfiguracionSistema();
                configurarFormulario(this, Sistema);
                Sistema.MdiParent = this;
                Sistema.Show();
            }

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
    }
}
