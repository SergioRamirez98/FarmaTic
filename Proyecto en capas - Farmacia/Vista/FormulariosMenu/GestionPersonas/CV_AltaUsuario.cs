using Logica;
using Servicios;
using Sesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.FormulariosMenu.GestionPersonas
{
    public partial class CV_AltaUsuario : Form
    {
        CL_Usuarios Usuario = new CL_Usuarios();
        CL_Personas GestionPersonas = new CL_Personas();
        int ID_Persona = 0;
        bool Registrar = false;
        bool Modificar = false;
        bool Eliminar = false;        
        bool SeleccionarUsuarios = false;
        public CV_AltaUsuario(int idpersona)
        {
            InitializeComponent();if (idpersona != 0) ID_Persona = idpersona;
        }
        private void CV_AltaUsuario_Load(object sender, EventArgs e)
        {
            cargarComboBox(true);
            cargarLoad(ID_Persona);
            bloquearControles();
            cargarPermisos();
        }
        private void btn_SeleccionarPersona_Click(object sender, EventArgs e)
        {
            CV_SeleccionarPersona SeleccionarPersona = new CV_SeleccionarPersona();
            SeleccionarPersona.PersonaSeleccionada += new CV_SeleccionarPersona.PersonaSeleccionadaHandler(seleccionPersona);
            SeleccionarPersona.ShowDialog();

        }
        private void Btn_RegistrarUsuario_Click(object sender, EventArgs e)
        {
            if (Registrar)
            {
                capturarDatosUsuarios();
                try
                {
                    Usuario.CrearUsuario();
                    CServ_MsjUsuario.Exito("Usuario Generado con éxito");
                    bloquearControles();
                }
                catch (Exception ex)
                {
                    CServ_MsjUsuario.MensajesDeError(ex.Message);
                }
            }
            else CServ_MsjUsuario.MensajesDeError("No posee permisos para realizar esta operación");
        }
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Modificar)
            {
                habilitarControles();
            }
            else CServ_MsjUsuario.MensajesDeError("No posee permisos para realizar esta operación");
            
        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            capturarDatosUsuarios();
            try
            {
                Usuario.ModificarUsuario(); bloquearControles();
                seleccionPersona(ID_Persona, CSesion_PersonaSeleccionada.Nombre + ' ' + CSesion_PersonaSeleccionada.Apellido);
                Btn_Guardar.Enabled = false;
                Btn_Eliminar.Enabled = true;
                CServ_MsjUsuario.Exito("Datos Guardados con éxito");
            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }
        }
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (Eliminar)
            {
                if (ID_Persona != 0)
                {
                    bool Eliminar = CServ_MsjUsuario.Preguntar("¿Esta seguro de querer eliminar al usuario seleccionado?");
                    if (Eliminar)
                    {
                        Usuario.Eliminar(ID_Persona);
                    }
                }
            }
            else CServ_MsjUsuario.MensajesDeError("No posee permisos para realizar esta operación");

        }
        private void Btn_Refrescar_Click(object sender, EventArgs e)
        {
            cargarLoad(ID_Persona=0);
        }

        private void capturarDatosUsuarios()
        {
            bool NuevaPass = true;
            bool CambioPass = false;
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
            Usuario.Prop_Familia = Cmb_Familia.SelectedValue.ToString();
            Usuario.Prop_Estado = Cmb_Estado.SelectedValue.ToString();
            Usuario.Prop_VtoPass = Cmb_VenceCada.SelectedValue.ToString();
            Usuario.Prop_NuevaPass = Convert.ToString(NuevaPass);
            Usuario.Prop_CambioPass = Convert.ToString(CambioPass);
            Usuario.Prop_Comentarios = Txb_Comentario.Text;
        }
        private void bloquearControles()
        {
            Txb_Comentario.Enabled = false;
            Txb_Contrasena.Enabled = false;
            Txb_ConfContrasena.Enabled = false;
            Txb_Pregunta1.Enabled = false;
            Txb_Pregunta2.Enabled = false;
            Txb_Pregunta3.Enabled = false;
            Txb_Respuesta1.Enabled = false;
            Txb_Respuesta2.Enabled = false;
            Txb_Respuesta3.Enabled = false;


            if (ID_Persona !=0 && !CSesion_PersonaSeleccionada.EsCliente && !string.IsNullOrEmpty( CSesion_PersonaSeleccionada.UserName))
            {                
                Txb_UserName.Enabled = false;
                Dtp_FeAlta.Enabled = false;
                Cmb_Familia.Enabled = false;
                Cmb_Estado.Enabled = false;
                Cmb_VenceCada.Enabled = false;
                Btn_RegistrarUsuario.Enabled = false;
            }
            else Txb_UserName.Enabled = true;

        }
        private void cargarComboBox(bool Rbt_Cliente)
        {
            Cmb_Estado.DataSource = Usuario.ObtenerEstadoUsuarios();
            Cmb_Estado.DisplayMember = "Descripcion_Estado";
            Cmb_Estado.ValueMember = "ID_Estado";
            Cmb_Estado.SelectedIndex = -1;
                            
            DataTable dt = Usuario.ObtenerVtosdePass(); 
            Cmb_VenceCada.DataSource = dt;
            Cmb_VenceCada.DisplayMember = "DiasParaVencimiento";
            Cmb_VenceCada.ValueMember = "ID_Vencimiento";
            Cmb_VenceCada.SelectedIndex = -1;


            Cmb_Familia.DataSource = Usuario.ObtenerFamilia();
            Cmb_Familia.DisplayMember = "Descripcion_Familia";
            Cmb_Familia.ValueMember = "ID_Familia";
            Cmb_Familia.SelectedIndex = -1;
        }
        private void cargarLoad(int ID) 
        {
            Txb_Persona.Text= "";
            Btn_Eliminar.Enabled = false;
            Btn_RegistrarUsuario.Enabled=true;
            Btn_Modificar.Enabled = false;
            Btn_Guardar.Enabled = false;

            if (ID!= 0 && CSesion_PersonaSeleccionada.EsCliente ==false && CSesion_PersonaSeleccionada.EsUsuario ==true)
            { 
                Txb_Persona.Text = CSesion_PersonaSeleccionada.Nombre + " " + CSesion_PersonaSeleccionada.Apellido;
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
                Cmb_Familia.SelectedValue = CSesion_PersonaSeleccionada.ID_Familia;

                Cmb_Estado.SelectedValue = CSesion_PersonaSeleccionada.EstadoUsuario;

                Cmb_VenceCada.SelectedValue = CSesion_PersonaSeleccionada.ID_VenceCada;
                List<TextBox> listatextbox = new List<TextBox>();
                listatextbox.Add(Txb_Contrasena);
                listatextbox.Add(Txb_ConfContrasena);
                listatextbox.Add(Txb_Respuesta1);
                listatextbox.Add(Txb_Respuesta2);
                listatextbox.Add(Txb_Respuesta3);
                CServ_InfoSensible.RespuestasUsuario(listatextbox);
                Txb_Persona.Enabled = false;
                Btn_Eliminar.Enabled = true;
                Btn_Modificar.Enabled = true;
                Btn_Guardar.Enabled = false;
                Btn_RegistrarUsuario.Enabled = false;
            }
            else
            {
                Txb_Persona.Text = CSesion_PersonaSeleccionada.Nombre + " " + CSesion_PersonaSeleccionada.Apellido;                
                CServ_Limpiar.LimpiarPanelBox(Pnb_RegistroUsuario);
                habilitarControles();
            }

        }
        private void seleccionPersona(int idPersonaDelegado, string cliente)
        {
            ID_Persona = idPersonaDelegado;
            Txb_Persona.Text = cliente;
            if (ID_Persona != 0)
            {
                CSesion_PersonaSeleccionada.SesionActiva = false;
                CSesion_PersonaSeleccionada.LimpiarCache();
                cargarPersonas();
                Usuario.CargarDatosUsuarios(ID_Persona);
                bloquearControles();
                cargarLoad(ID_Persona);
                Txb_Persona.Enabled = false;
            }
        }
        private void habilitarControles()
        {
            Dtp_FeAlta.Enabled = true;
            Cmb_Familia.Enabled = true;
            Cmb_Estado.Enabled = true;
            Cmb_VenceCada.Enabled = true;
        }
        private void cargarPersonas()
        {
            DataTable dt = new DataTable();
            dt = GestionPersonas.CargarDatos(ID_Persona);
            GestionPersonas.CargarDatosClientes(ID_Persona);
        }
        private void cargarPermisos()
        {
            foreach (var permiso in CSesion_SesionIniciada.Permisos)
            {
                switch (permiso.ID_Rol)
                {
                    case 1:
                        Registrar = true;
                        Modificar = true;
                        Eliminar = true;
                        SeleccionarUsuarios = true;
                        break;

                    case 13:
                        Registrar = true;
                        break;
                    case 14:
                        Modificar = true;
                        break;

                    case 15:
                        Eliminar = true;
                        break;
                    case 16:
                        SeleccionarUsuarios = true;
                        break;
                }
            }
            btn_SeleccionarPersona.Enabled = SeleccionarUsuarios;
        }

    }
}
