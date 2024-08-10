using System;
using Logica;
using System.Windows.Forms;
using Servicios;
using Sesion;

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
        }
        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            // A MODO DE PRUEBA!!!!

            CV_GestionStock STOQ = new CV_GestionStock();
            STOQ.Show();


           /* PasarDatos();
            try
            {
                bool validar = Usuarios.Logear();
                if (validar == true)
                {
                    Sistema.CargarConfiguracion();
                    if (CSesion_SesionIniciada.NuevaPass == true || CSesion_SesionIniciada.CambioPass ==true)
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
