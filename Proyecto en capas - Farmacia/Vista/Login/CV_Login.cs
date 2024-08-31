﻿using System;
using Logica;
using System.Windows.Forms;
using Servicios;
using Sesion;
using Vista.FormulariosMenu;

namespace Vista
{
    public partial class CV_Login : Form
    {
        CL_Usuarios Usuarios = new CL_Usuarios();
        CL_Sistema Sistema = new CL_Sistema();
        public CV_Login()
        {
            InitializeComponent();
            
        }
        private void CV_Login_Load(object sender, EventArgs e)
        {
            Txb_Contrasena.PasswordChar = '*';
            Sistema.CargarConfiguracion();
        }
        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            // A MODO DE PRUEBA!!!!
                        
            /*CV_Ventas STOQ = new CV_Ventas();
            STOQ.Show();*/
            CV_GestionUsuariosPersonas Gestion = new CV_GestionUsuariosPersonas();
            Gestion.Show();

            /*
            try
            {
                PasarDatos();
                bool validar = Usuarios.Logear();
                if (validar == true)
                {
                    if (CSesion_SesionIniciada.EstadoCuenta != "Bloqueado")
                    {
                        if (CSesion_SesionIniciada.NuevaPass == true || CSesion_SesionIniciada.CambioPass == true)
                        {
                            CV_OlvidoPass FormRecContrasena = new CV_OlvidoPass();
                            FormRecContrasena.Show();
                        }
                        else
                        {
                            CServ_MsjUsuario.Exito("¡Conexión exitosa!");
                            CV_Menu Menu = new CV_Menu();
                            Menu.Show();
                            CSesion_PreguntasUsuarios.LimpiarCache();
                        }
                        CServ_LimpiarControles.LimpiarFormulario(this);
                        this.Hide();
                    }
                    else
                    {
                        CServ_MsjUsuario.MensajesDeError("Usuario bloqueado. Por favor, comuníquese con el administrador.");
                    }

                }
                else
                {
                    Usuarios.BloqueodeUsuarios();
                }

            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }*/
        }      
        private void Cbx_MostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            CServ_InfoSensible.Contrasena(Txb_Contrasena, Cbx_MostrarContrasena);
        }

        private void LnkLbl_OlvideContrasena_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CV_OlvidoPass FormRecContrasena = new CV_OlvidoPass();
            FormRecContrasena.Show();
            this.Hide();
        }
        private void PasarDatos()
        {
            Usuarios.Prop_NombreUsuarioLogin = Txb_Usuario.Text;
            Usuarios.Prop_ContrasenaUsuarioLogin = Txb_Contrasena.Text;
            Usuarios.Prop_EncriptacionLogin = Txb_Usuario.Text + Txb_Contrasena.Text;
        }
    }
}