using System;
using Logica;
using System.Windows.Forms;
using Servicios;
using Sesion;
using Sistema;
using Vista.FormulariosMenu;
using Modelo;
using Vista.Properties;

namespace Vista
{
    public partial class CV_Login : Form
    {
        CL_Usuarios Usuarios = new CL_Usuarios();
        CL_Sistema Sistema = new CL_Sistema();

        public CV_Login()
        {
            InitializeComponent();
            cargarComboLenguajes();
            CV_Idioma.CargarIdioma(this.Controls, this);

        }
        private void CV_Login_Load(object sender, EventArgs e)
        {
            Txb_Contrasena.PasswordChar = '*';
            Sistema.CargarConfiguracion();          
        }
        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {            
           try
            {
                Txb_Usuario.Text = "SRamirez98";
                Txb_Contrasena.Text = "Sa";
                //Txb_Usuario.Text = "Paca";
                //Txb_Contrasena.Text = "pa";
                PasarDatos();
                bool validar = Usuarios.Logear();
                if (validar == true)
                {
                    if (CSesion_SesionIniciada.EstadoCuenta != 3)
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
                        CServ_Limpiar.LimpiarFormulario(this);
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
            }
        }
        private void Cbx_MostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            //CServ_InfoSensible.Contrasena(Txb_Contrasena, Cbx_MostrarContrasena);
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

        private void btnMostrarContrasenia_Click(object sender, EventArgs e)
        {
        }

        private void btnMostrarContrasenia_MouseDown(object sender, MouseEventArgs e)
        {
            Txb_Contrasena.PasswordChar = '\0';
        }

        private void btnMostrarContrasenia_MouseUp(object sender, MouseEventArgs e)
        {
            Txb_Contrasena.PasswordChar = '*';
        }
        private void cargarComboLenguajes()
        {
            Cmb_Lenguaje.DataSource = CV_Idioma.ObtenerIdiomas();//Cargo el Combo con la lista de la clase Idioma
            Cmb_Lenguaje.DisplayMember = "Nombre"; //Muestro el "campo" nombre de la lista
            Cmb_Lenguaje.ValueMember = "InfoCultura";//Guardo la informacion Cultural en el Combo
            Cmb_Lenguaje.SelectedValue = Settings.Default.Idioma; //Selecciono el idioma guardado por defecto
        }
        private void Cmb_Lenguaje_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Settings.Default.Idioma = Cmb_Lenguaje.SelectedValue.ToString();//Cargo el idioma seleccionado por el combo
            Settings.Default.Save(); //Guardo el idioma seleccionado para que quede grabado
            CV_Idioma.CargarIdioma(this.Controls, this);//Llamo al metodo que cambiara el idioma en los formularios
        }
    }
}
