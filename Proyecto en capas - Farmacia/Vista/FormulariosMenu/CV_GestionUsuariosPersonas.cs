using Logica;
using Servicios;
using Sesion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Vista
{
    public partial class CV_GestionUsuariosPersonas : Form
    {
        CL_RegistrodePersonas GestionPersonasUsuarios = new CL_RegistrodePersonas();
        CL_Usuarios Usuario = new CL_Usuarios();

        public CV_GestionUsuariosPersonas()
        {
            InitializeComponent();
        }

        #region Eventos
        private void CV_AgregarPersona_Load(object sender, EventArgs e)
        {
            Cmb_Sexo.Items.Add("Masculino");
            Cmb_Sexo.Items.Add("Femenino");
            Cmb_Estado.Items.Add("Activo");
            Cmb_Estado.Items.Add("Inactivo");
            Cmb_Estado.Items.Add("Bloqueado");
            Cmb_VenceCada.Items.Add("30 Dias");
            Cmb_VenceCada.Items.Add("60 Dias");
            Cmb_VenceCada.Items.Add("120 Dias");
            Cmb_VenceCada.Items.Add("Nunca");
            Size = new Size(710, 300);
            Rbt_Cliente.Enabled = false;
            Rbt_Usuario.Enabled = false;
            CargarComboBox();
            CServ_LimpiarControles.LimpiarFormulario(this);
        }
        private void Rbt_Usuario_CheckedChanged(object sender, EventArgs e)
        {
            Size = new Size(710, 600);
            Pnb_RegistroUsuario.Visible = true;
        }        
        private void Btn_RegistrarUsuario_Click(object sender, EventArgs e)
        {
            int ID_Persona = Convert.ToInt32(Cmb_SeleccionePersona.SelectedValue);
            CapturarDatosUsuarios(ID_Persona);
            try
            {
                Usuario.CrearUsuario();
                CServ_MsjUsuario.Exito("Usuario Generado con éxito");
            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }

        }       
        private void Cmb_SeleccionePersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_SeleccionePersona.SelectedIndex > -1)
            {
                DataRowView selectedRow = (DataRowView)Cmb_SeleccionePersona.SelectedItem;
                int ID_Persona = Convert.ToInt32(selectedRow["ID_Persona"]);                                               
                DataTable dt = new DataTable();
                dt = GestionPersonasUsuarios.CargarDatos(ID_Persona);
                bool EsUsuario= GestionPersonasUsuarios.CargarDatosUsuarios(ID_Persona);
                if (EsUsuario==true)
                {
                    BloquearControles(EsUsuario);
                    CargarPersonasdeCombobox(dt, EsUsuario);

                }
                else
                {
                    BloquearControles(EsUsuario);
                    CargarPersonasdeCombobox(dt, EsUsuario);
                }
                
            }
            else
            {
                CServ_LimpiarControles.LimpiarFormulario(this);
            }
        }        
        private void Btn_RegistrarPersona_Click(object sender, EventArgs e)
        {
            CapturarDatosPersonas();
            try
            {
                DataTable dt = GestionPersonasUsuarios.InsertarPersona();
                CargarComboBox();
                if (dt.Rows.Count > 0)
                {
                    DataRow DT = dt.Rows[0];                    
                    Usuario.Prop_ID_Persona = Convert.ToInt32(DT["ID_Persona"]);                    
                    Cmb_SeleccionePersona.SelectedValue = Usuario.Prop_ID_Persona;
                    Cmb_SeleccionePersona.Enabled = false;
                }
                CServ_MsjUsuario.Exito("La persona se ha registrado correctamente");
                Rbt_Usuario.Enabled = true;
            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }
        }
        #endregion

        #region Métodos
        private void CargarComboBox()
        {
            Cmb_Partido.DataSource = GestionPersonasUsuarios.ObtenerLocalidad();
            Cmb_Partido.DisplayMember = "Localidad";
            Cmb_Partido.ValueMember = "ID_Localidad";
            Cmb_Partido.SelectedIndex = -1;

            Cmb_Nacionalidad.DataSource = GestionPersonasUsuarios.ObtenerPais();
            Cmb_Nacionalidad.DisplayMember = "Pais";
            Cmb_Nacionalidad.ValueMember = "ID_Pais";
            Cmb_Nacionalidad.SelectedIndex = -1;

            Cmb_SeleccionePersona.SelectedIndexChanged -= Cmb_SeleccionePersona_SelectedIndexChanged;
            Cmb_SeleccionePersona.DataSource = GestionPersonasUsuarios.ObtenerPersonas();            
            Cmb_SeleccionePersona.DisplayMember = "NombreCompleto";
            Cmb_SeleccionePersona.ValueMember = "ID_Persona";
            Cmb_SeleccionePersona.SelectedIndex = -1;
            Cmb_SeleccionePersona.SelectedIndexChanged += Cmb_SeleccionePersona_SelectedIndexChanged;


            Cmb_Familia.DataSource = GestionPersonasUsuarios.ObtenerFamilia();
            Cmb_Familia.DisplayMember = "Familia";
            Cmb_Familia.ValueMember = "ID_Familia";                  
            Cmb_Familia.SelectedIndex =-1;
        }
        private void CapturarDatosPersonas()
        {
            GestionPersonasUsuarios.Prop_NOMBRE = Txb_Nombre.Text;
            GestionPersonasUsuarios.Prop_APELLIDO = Txb_Apellido.Text;
            GestionPersonasUsuarios.Prop_DNI = Txb_Dni.Text;
            GestionPersonasUsuarios.Prop_CORREO = Txb_Correo.Text;
            GestionPersonasUsuarios.Prop_SEXO = Cmb_Sexo.Text;
            GestionPersonasUsuarios.Prop_DOMICILIO = Txb_Domicilio.Text;
            GestionPersonasUsuarios.Prop_LOCALIDAD = Cmb_Partido.Text;
            GestionPersonasUsuarios.Prop_NACIONALIDAD = Cmb_Nacionalidad.Text;
            GestionPersonasUsuarios.Prop_TELEFONO = Txb_Telefono.Text;

            DateTime FechaNacimiento = Dtp_FeNacimiento.Value;
            if (FechaNacimiento > DateTime.Today)
            {
                throw new Exception("Fecha no valida, por favor ingrese nuevamente");
            }
            else
            {
                GestionPersonasUsuarios.Prop_NACIMIENTO = FechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss");
            }
            GestionPersonasUsuarios.Prop_COMENTARIOS = Txb_Comentario.Text;

        }
        private void CapturarDatosUsuarios(int ID_Persona)
        {
            bool NuevaPass = true;
            bool CambioPass=false;
            Usuario.Prop_ID_Persona = ID_Persona;
            Usuario.Prop_UserName = Txb_UserName.Text;
            DateTime FeAlta = Dtp_FeAlta.Value;
            if (FeAlta > DateTime.UtcNow)
            {
                throw new Exception("Fecha no valida, por favor ingrese nuevamente");
            }
            else
            {
                Usuario.Prop_FeAlta = FeAlta.ToString("yyyy-MM-dd 00:00:00");
            }
            Usuario.Prop_Familia = Cmb_Familia.Text;
            Usuario.Prop_Estado = Cmb_Estado.Text;
            Usuario.Prop_VtoPass = Cmb_VenceCada.Text;
            Usuario.Prop_NuevaPass = Convert.ToString(NuevaPass);
            Usuario.Prop_CambioPass = Convert.ToString(CambioPass);
        }
        public void BloquearControles(bool EsUsuario) 
        {
            Txb_Nombre.Enabled = false;
            Txb_Apellido.Enabled = false;
            Txb_Dni.Enabled = false;
            Txb_Correo.Enabled = false;
            Cmb_Sexo.Enabled = false;
            Txb_Domicilio.Enabled = false;
            Cmb_Partido.Enabled = false;
            Cmb_Nacionalidad.Enabled = false;
            Txb_Telefono.Enabled = false;
            Dtp_FeNacimiento.Enabled = false;            
            Txb_Comentario.Enabled = false;
            Btn_RegistrarPersona.Enabled = false;
            Txb_Contrasena.Enabled = false;
            Txb_ConfContrasena.Enabled = false;
            Txb_Pregunta1.Enabled = false;
            Txb_Pregunta2.Enabled = false;
            Txb_Pregunta3.Enabled = false;
            Txb_Respuesta1.Enabled = false;
            Txb_Respuesta2.Enabled = false;
            Txb_Respuesta3.Enabled = false;

            if (EsUsuario==true)
            {

                Txb_UserName.Enabled = false;
                Dtp_FeAlta.Enabled = false;
                Cmb_Familia.Enabled = false;
                Cmb_Estado.Enabled = false;
                Cmb_VenceCada.Enabled = false;
            }
        
        }
        public void CargarPersonasdeCombobox(DataTable dt, bool EsUsuario)
        {
            if (dt.Rows.Count > 0)
            {
                Txb_Nombre.Text = CSesion_PersonaSeleccionada.Nombre;
                Txb_Apellido.Text = CSesion_PersonaSeleccionada.Apellido;
                Txb_Dni.Text = Convert.ToString(CSesion_PersonaSeleccionada.Dni);
                Txb_Correo.Text = CSesion_PersonaSeleccionada.Correo;
                Cmb_Sexo.Text = CSesion_PersonaSeleccionada.Sexo;
                Txb_Domicilio.Text = CSesion_PersonaSeleccionada.Domicilio;
                Cmb_Partido.Text = CSesion_PersonaSeleccionada.Partido;
                Cmb_Nacionalidad.Text = CSesion_PersonaSeleccionada.Nacionalidad;
                Txb_Telefono.Text = Convert.ToString(CSesion_PersonaSeleccionada.Telefono);
                Dtp_FeNacimiento.Value = CSesion_PersonaSeleccionada.FeNacimiento;
                Txb_Comentario.Text = CSesion_PersonaSeleccionada.Comentario;
                Rbt_Usuario.Enabled = true;
            }
            if (EsUsuario == true)
            {
                BloquearControles(EsUsuario);
                Rbt_Usuario.Checked = true;
                Txb_UserName.Text = CSesion_PersonaSeleccionada.UserName;
                Txb_Contrasena.Text = CSesion_PersonaSeleccionada.PassEncriptada;
                Txb_ConfContrasena.Text = CSesion_PersonaSeleccionada.PassEncriptada;
                Txb_Pregunta1.Text = CSesion_PersonaSeleccionada.Pregunta1;
                Txb_Pregunta2.Text = CSesion_PersonaSeleccionada.Pregunta2;
                Txb_Pregunta3.Text = CSesion_PersonaSeleccionada.Pregunta3;

                Txb_Respuesta1.Text = CSesion_PersonaSeleccionada.Respuesta1;
                Txb_Respuesta2.Text = CSesion_PersonaSeleccionada.Respuesta2;
                Txb_Respuesta3.Text = CSesion_PersonaSeleccionada.Respuesta3;
                Dtp_FeAlta.Value = CSesion_PersonaSeleccionada.FeAlta;
                Cmb_Familia.Text = CSesion_PersonaSeleccionada.Familia;
                Cmb_Estado.Text = CSesion_PersonaSeleccionada.EstadoCuenta;
                Cmb_VenceCada.Text = Convert.ToString(CSesion_PersonaSeleccionada.VenceCada);     
                List<TextBox> listatextbox = new List<TextBox>();
                listatextbox.Add(Txb_Contrasena);
                listatextbox.Add(Txb_ConfContrasena);
                listatextbox.Add(Txb_Respuesta1);
                listatextbox.Add(Txb_Respuesta2);
                listatextbox.Add(Txb_Respuesta3);
                CServ_InfoSensible.RespuestasUsuario(listatextbox);
            }

            else
            {
                CServ_LimpiarControles.LimpiarPanelBox(Pnb_RegistroUsuario);
            }
        }
        #endregion

    }
}
