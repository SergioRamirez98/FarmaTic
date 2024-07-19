using Logica;
using Servicios;
using Sesion;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Vista
{
    public partial class CV_Registrar : Form
    {
        CL_RegistrodePersonas RegistrodePersonas = new CL_RegistrodePersonas();
        CL_Usuarios Usuario = new CL_Usuarios();

        public CV_Registrar()
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
            Cmb_VenceCada.Items.Add("30");
            Cmb_VenceCada.Items.Add("60");
            Cmb_VenceCada.Items.Add("120");
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
                BloquearControles();
                DataTable dt = new DataTable();
                dt = RegistrodePersonas.CargarDatos(ID_Persona);
                CargarPersonasdeCombobox(dt);
                
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
                DataTable dt = RegistrodePersonas.InsertarPersona();
                if (dt.Rows.Count > 0)
                {
                    DataRow DT = dt.Rows[0];
                    Usuario.Prop_ID_Persona = Convert.ToInt32(DT["ID_Persona"]);
                    //Usuario.Prop_ID_Persona = dt.Rows[0]["ID"];
                    Cmb_SeleccionePersona.SelectedIndex = Usuario.Prop_ID_Persona;
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
            Cmb_Partido.DataSource = RegistrodePersonas.ObtenerLocalidad();
            Cmb_Partido.DisplayMember = "Localidad";
            Cmb_Partido.ValueMember = "ID_Localidad";
            Cmb_Partido.SelectedIndex = -1;

            Cmb_Nacionalidad.DataSource = RegistrodePersonas.ObtenerPais();
            Cmb_Nacionalidad.DisplayMember = "Pais";
            Cmb_Nacionalidad.ValueMember = "ID_Pais";
            Cmb_Nacionalidad.SelectedIndex = -1;

            Cmb_SeleccionePersona.SelectedIndexChanged -= Cmb_SeleccionePersona_SelectedIndexChanged;
            Cmb_SeleccionePersona.DataSource = RegistrodePersonas.ObtenerPersonas();
            Cmb_SeleccionePersona.DisplayMember = "Nombre";
            Cmb_SeleccionePersona.ValueMember = "ID_Persona";
            Cmb_SeleccionePersona.SelectedIndex = -1;
            Cmb_SeleccionePersona.SelectedIndexChanged += Cmb_SeleccionePersona_SelectedIndexChanged;


            Cmb_Familia.DataSource = RegistrodePersonas.ObtenerFamilia();
            Cmb_Familia.DisplayMember = "Familia";
            Cmb_Familia.ValueMember = "ID_Familia";                  
            Cmb_Familia.SelectedIndex =-1;
        }
        private void CapturarDatosPersonas()
        {
            RegistrodePersonas.Prop_NOMBRE = Txb_Nombre.Text;
            RegistrodePersonas.Prop_APELLIDO = Txb_Apellido.Text;
            RegistrodePersonas.Prop_DNI = Txb_Dni.Text;
            RegistrodePersonas.Prop_CORREO = Txb_Correo.Text;
            RegistrodePersonas.Prop_SEXO = Cmb_Sexo.Text;
            RegistrodePersonas.Prop_DOMICILIO = Txb_Domicilio.Text;
            RegistrodePersonas.Prop_LOCALIDAD = Cmb_Partido.Text;
            RegistrodePersonas.Prop_NACIONALIDAD = Cmb_Nacionalidad.Text;
            RegistrodePersonas.Prop_TELEFONO = Txb_Telefono.Text;

            DateTime FechaNacimiento = Dtp_FeNacimiento.Value;
            if (FechaNacimiento > DateTime.Today)
            {
                throw new Exception("Fecha no valida, por favor ingrese nuevamente");
            }
            else
            {
                RegistrodePersonas.Prop_NACIMIENTO = FechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss");
            }
            RegistrodePersonas.Prop_COMENTARIOS = Txb_Comentario.Text;

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
        public void BloquearControles() 
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
        
        }
        public void CargarPersonasdeCombobox(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                Txb_Nombre.Text = CSesion_PersonaSeleccionada.Nombre;
                Txb_Apellido.Text = CSesion_PersonaSeleccionada.Apellido;
                Txb_Dni.Text = CSesion_PersonaSeleccionada.Dni;
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
        }
        #endregion

    }
}
