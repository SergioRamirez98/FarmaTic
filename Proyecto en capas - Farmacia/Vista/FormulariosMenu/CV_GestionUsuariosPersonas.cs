using Logica;
using Servicios;
using Sesion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        CL_Personas GestionPersonas = new CL_Personas();
        CL_Usuarios Usuario = new CL_Usuarios();
        CL_Clientes Clientes = new CL_Clientes();
        int ID_Persona;

        public CV_GestionUsuariosPersonas()
        {
            InitializeComponent();
        }

        #region Eventos
        private void CV_AgregarPersona_Load(object sender, EventArgs e)
        {
            configurarLoad();
            cargarComboBox(false);
            CServ_LimpiarControles.LimpiarFormulario(this);
        }
        private void Cmb_SeleccionePersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_SeleccionePersona.SelectedIndex > -1)
            {
                DataRowView selectedRow = (DataRowView)Cmb_SeleccionePersona.SelectedItem;
                int ID_Persona = Convert.ToInt32(selectedRow["ID_Persona"]);
                DataTable dt = new DataTable();
                dt = GestionPersonas.CargarDatos(ID_Persona);
                bool EsUsuario = GestionPersonas.CargarDatosUsuarios(ID_Persona);
                bool EsCliente = GestionPersonas.CargarDatosClientes(ID_Persona);
                if (EsUsuario)
                {
                    bloquearControles(EsUsuario,false);
                    cargarPersonasdeCombobox(dt, EsUsuario,false);
                }
                else
                {
                    bloquearControles(false, EsCliente);
                    cargarPersonasdeCombobox(dt, false,EsCliente);
                }
            }
            else
            {
                CServ_LimpiarControles.LimpiarFormulario(this);
            }
        }
        private void Cmb_Categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Categoria.SelectedIndex > -1)
            {
                DataRowView selectedRow = (DataRowView)Cmb_Categoria.SelectedItem;
                int ID_Categoria = Convert.ToInt32(selectedRow["ID_Categoria"]);
                int Descuento = Convert.ToInt32((selectedRow["Descuento"]));
                Txb_Descuento.Text = Descuento + "%";
            }
            else
            {
                Txb_Descuento.Text = null;
            }
        }
        private void Rbt_Usuario_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Usuario.Checked) 
            {
                Size = new Size(710, 600);
                Pnb_RegistroUsuario.Visible = true;
                Pnb_RegistroUsuario.Enabled = true;
            }
            else
            {
                Size = new Size(710, 300);
                Pnb_RegistroUsuario.Location = new System.Drawing.Point(15, 235);
                Pnb_RegistroUsuario.Enabled = false;
                Pnb_RegistroUsuario.Visible = false;

            }
        }
        private void Rbt_Cliente_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Cliente.Checked)
            {
                cargarComboBox(true);
                Size = new Size(710, 400);
                Txb_Descuento.Enabled = false;
                Pnb_RegistroCliente.Location = new System.Drawing.Point(15, 235);
                Pnb_RegistroCliente.Enabled = true;
                Pnb_RegistroCliente.Visible = true;
            }
            else
            {
                Size = new Size(710, 300);
                Pnb_RegistroCliente.Location = new System.Drawing.Point(15, 235);
                Pnb_RegistroCliente.Enabled = false;
                Pnb_RegistroCliente.Visible = false;

            }
        }
        private void Btn_RegistrarPersona_Click(object sender, EventArgs e)
        {
            try
            {
                capturarDatosPersonas();
                DataTable dt = GestionPersonas.InsertarPersona();
                if (dt.Rows.Count > 0)
                {
                    cargarComboBox(false);
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
        private void Btn_RegistrarUsuario_Click(object sender, EventArgs e)
        {
            ID_Persona = Convert.ToInt32(Cmb_SeleccionePersona.SelectedValue);
            capturarDatosUsuarios();
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
        private void Btn_RegistrarCliente_Click(object sender, EventArgs e)
        {
            ID_Persona = Convert.ToInt32(Cmb_SeleccionePersona.SelectedValue);
            try
            {
                capturarDatosClientes();
                Clientes.AltaCliente();
                CServ_MsjUsuario.Exito("Cliente generado con éxito");
                CServ_LimpiarControles.BloquearControles(Pnb_RegistroCliente);
            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
                CServ_LimpiarControles.LimpiarPanelBox(Pnb_RegistroCliente);
            }
            
        }
       
        #endregion

        #region Métodos
        private void configurarLoad() 
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
            Pnb_RegistroUsuario.Enabled = false;
            Pnb_RegistroUsuario.Visible = false;
            Pnb_RegistroCliente.Enabled = false;
            Pnb_RegistroCliente.Visible = false;
            //Rbt_Cliente.Enabled = false;
            //Rbt_Usuario.Enabled = false;
            cargarComboBox(false);
            CServ_LimpiarControles.LimpiarFormulario(this);
        }
        private void cargarComboBox(bool Rbt_Cliente)
        {

            if (Rbt_Cliente)
            {
                Cmb_Categoria.DataSource = Clientes.ObtenerCategoria();
                Cmb_Categoria.DisplayMember = "Categoria";
                Cmb_Categoria.ValueMember = "ID_Categoria";
                Cmb_Categoria.SelectedIndex = -1;

            }
            else
            { 
            Cmb_Partido.DataSource = GestionPersonas.ObtenerLocalidad();
            Cmb_Partido.DisplayMember = "Localidad";
            Cmb_Partido.ValueMember = "ID_Localidad";
            Cmb_Partido.SelectedIndex = -1;

            Cmb_Nacionalidad.DataSource = GestionPersonas.ObtenerPais();
            Cmb_Nacionalidad.DisplayMember = "Pais";
            Cmb_Nacionalidad.ValueMember = "ID_Pais";
            Cmb_Nacionalidad.SelectedIndex = -1;

            Cmb_SeleccionePersona.SelectedIndexChanged -= Cmb_SeleccionePersona_SelectedIndexChanged;
            Cmb_SeleccionePersona.DataSource = GestionPersonas.ObtenerPersonas();            
            Cmb_SeleccionePersona.DisplayMember = "NombreCompleto";
            Cmb_SeleccionePersona.ValueMember = "ID_Persona";
            Cmb_SeleccionePersona.SelectedIndex = -1;
            Cmb_SeleccionePersona.SelectedIndexChanged += Cmb_SeleccionePersona_SelectedIndexChanged;


            Cmb_Familia.DataSource = GestionPersonas.ObtenerFamilia();
            Cmb_Familia.DisplayMember = "Familia";
            Cmb_Familia.ValueMember = "ID_Familia";                  
            Cmb_Familia.SelectedIndex =-1;
            }
        }
        private void capturarDatosPersonas()
        {
            GestionPersonas.Prop_NOMBRE = Txb_Nombre.Text;
            GestionPersonas.Prop_APELLIDO = Txb_Apellido.Text;
            GestionPersonas.Prop_DNI = Txb_Dni.Text;
            GestionPersonas.Prop_CORREO = Txb_Correo.Text;
            GestionPersonas.Prop_SEXO = Cmb_Sexo.Text;
            GestionPersonas.Prop_DOMICILIO = Txb_Domicilio.Text;
            GestionPersonas.Prop_LOCALIDAD = Cmb_Partido.Text;
            GestionPersonas.Prop_NACIONALIDAD = Cmb_Nacionalidad.Text;
            GestionPersonas.Prop_TELEFONO = Txb_Telefono.Text;

            DateTime FechaNacimiento = Dtp_FeNacimiento.Value;
            if (FechaNacimiento > DateTime.Today)
            {
                throw new Exception("Fecha no valida, por favor ingrese nuevamente");
            }
            else
            {
                GestionPersonas.Prop_NACIMIENTO = FechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss");
            }

        }
        private void capturarDatosUsuarios()
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
            Usuario.Prop_Comentarios = Txb_Comentario.Text;
        }
        private void capturarDatosClientes()
        {
            Clientes.ID_Persona = ID_Persona.ToString();
            try
            {
                Clientes.ID_Categoria = Cmb_Categoria.SelectedValue.ToString();
            }
            catch (Exception)
            {

                throw new Exception("Debe seleccionar una categoria");
            }
            Clientes.Comentarios = Txb_ComentarioCliente.Text;
            DateTime FeAlta = Dtp_FeAltaCliente.Value;
            if (FeAlta > DateTime.UtcNow)
            {
                throw new Exception("Fecha no valida, por favor ingrese nuevamente");
            }
            else
            {
                Clientes.FeAlta = FeAlta.ToString("yyyy-MM-dd 00:00:00");
            }

        }
        private void bloquearControles(bool EsUsuario, bool EsCliente) 
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

            if (EsUsuario)
            {

                Txb_UserName.Enabled = false;
                Dtp_FeAlta.Enabled = false;
                Cmb_Familia.Enabled = false;
                Cmb_Estado.Enabled = false;
                Cmb_VenceCada.Enabled = false;
            }
            else if (EsCliente)
            {
                Cmb_Categoria.Enabled = false;
                Txb_Descuento.Enabled = false;
                Txb_ComentarioCliente.Enabled = false;
                Dtp_FeAltaCliente.Enabled = false;
            }
        
        }
        private void cargarPersonasdeCombobox(DataTable dt,bool EsUsuario, bool EsCliente)
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
                Txb_Comentario.Text = CSesion_PersonaSeleccionada.ComentarioUsuario;
                Rbt_Usuario.Enabled = true;
            }
            if (EsUsuario)
            {
                bloquearControles(EsUsuario,false);
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
            else if (EsCliente)
            {
                Rbt_Cliente.Checked = true; 
                Cmb_Categoria.SelectedIndex = CSesion_PersonaSeleccionada.ID_Categoria;
                Txb_ComentarioCliente.Text = CSesion_PersonaSeleccionada.ComentarioCliente;
                Dtp_FeAltaCliente.Value = CSesion_PersonaSeleccionada.FechaAltaCliente; 

            }

            else
            {
                CServ_LimpiarControles.LimpiarPanelBox(Pnb_RegistroUsuario);
            }
        }


        #endregion

       
    }
}
