using System;
using Logica;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicios;
using Sesion;

namespace Vista
{
    public partial class CV_Login : Form
    {
        CL_Usuarios UsuarioExistente = new CL_Usuarios();
        public CV_Login()
        {
            InitializeComponent();
        }

        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            pasardatos();
            try
            {
                bool validar = UsuarioExistente.Logear();
                if (validar == true)
                {
                    if (CSesion_SesionIniciada.NuevaPass == true)
                    {
                        CV_OlvidoPass FormRecContrasena = new CV_OlvidoPass();
                        FormRecContrasena.Show();
                    }
                    else
                    {
                        CServ_MsjUsuario.Exito("¡Conexión exitosa!");
                        CV_Menu Menu = new CV_Menu();
                        Menu.Show();
                    }
                    // this.Hide();
                }

            }
            catch (Exception)
            {
                CServ_MsjUsuario.MensajesDeError("Credenciales incorrectas. Por favor, intente nuevamente");
            }
        }

        private void CV_Login_Load(object sender, EventArgs e)
        {
            Txb_Contrasena.PasswordChar = '*';
        }

        private void pasardatos()
        {
            UsuarioExistente.Prop_NombreUsuarioLogin =Txb_Usuario.Text;
            UsuarioExistente.Prop_ContrasenaUsuarioLogin=Txb_Contrasena.Text;
            UsuarioExistente.Prop_EncriptacionLogin = Txb_Usuario.Text + Txb_Contrasena.Text;
        }

        private void Cbx_MostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            Txb_Contrasena.PasswordChar = '\0';
            Cbx_MostrarContrasena.Text = "Ocultar contraseña";
            if (!Cbx_MostrarContrasena.Checked)
            {
                Txb_Contrasena.PasswordChar = '*';
                Cbx_MostrarContrasena.Text = "Mostrar contraseña";
            }
        }

        private void LnkLbl_OlvideContrasena_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CV_OlvidoPass FormRecContrasena = new CV_OlvidoPass();
            FormRecContrasena.Show();
        }
    }
}
