using Logica;
using Servicios;
using Sesion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Vista.FormulariosMenu.GestionPersonas;

namespace Vista
{
    public partial class CV_GestionUsuariosPersonas : Form
    {
        CL_Personas GestionPersonas = new CL_Personas();
        CL_Usuarios Usuario = new CL_Usuarios();
        CL_Clientes Clientes = new CL_Clientes();
        int ID_Persona;
        public delegate void PersonaSeleccionadaHandler(int idCliente, string cliente);
        public event PersonaSeleccionadaHandler PersonaSeleccionada;

        public CV_GestionUsuariosPersonas()
        {
            InitializeComponent();
        }

        #region Eventos
        private void CV_AgregarPersona_Load(object sender, EventArgs e)
        {
            configurarLoad();
            cargarComboBox(false);
            CServ_Limpiar.LimpiarFormulario(this);
        }      
        private void Cmb_Categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Categoria.SelectedIndex > -1)
            {
                DataRowView selectedRow = (DataRowView)Cmb_Categoria.SelectedItem;
                int ID_Categoria = Convert.ToInt32(selectedRow["ID_Categoria"]);
                int Descuento = Convert.ToInt32((selectedRow["Descuento"]));
                string DescCategoria = (selectedRow["Descripcion"]).ToString();
                Txb_Descuento.Text = Descuento + "%";
                Txb_DescCategoria.Text = DescCategoria;
            }
            else
            {
                Txb_Descuento.Text = null;
            }
        }
        private void Rbt_Usuario_CheckedChanged(object sender, EventArgs e)
        {
           /* if (Rbt_Usuario.Checked)
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
            }*/
        }
        private void Rbt_Cliente_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Cliente.Checked)
            {
                cargarComboBox(true);
                Size = new Size(710, 400);
                Txb_Descuento.Enabled = false;
                Pnb_RegistroCliente.Location = new System.Drawing.Point(15, 237);
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
        private void Txb_AsociarUsuario_Click(object sender, EventArgs e)
        {
            CV_AltaUsuario altaUsuario = new CV_AltaUsuario(ID_Persona);
            altaUsuario.Show();
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
                    ID_Persona = Convert.ToInt32(DT["ID_Persona"]);                    
                    cargarPersonas();                    
                }
                CServ_MsjUsuario.Exito("La persona se ha registrado correctamente");
                Btn_Modificar.Enabled = true;
                Btn_Eliminar.Enabled = true;
                Rbt_Usuario.Enabled = true;
                Rbt_Cliente.Enabled = true;

            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }
        }
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (ID_Persona!=0 )
            {
                desbloquearControles();
                Btn_RegistrarPersona.Enabled = false;
                Btn_Eliminar.Enabled = false;
                Btn_GuardarCambios.Enabled = true;
            }
            
        }
        private void Btn_GuardarCambios_Click(object sender, EventArgs e)
        {
            capturarDatosPersonas();
            if (Rbt_Cliente.Checked) capturarDatosClientes();
            else if(Rbt_Usuario.Checked) capturarDatosUsuarios();
            try
            {
                GestionPersonas.ModificarPersona(ID_Persona);
                if (Rbt_Cliente.Checked) { Clientes.ModificarCliente(); bloquearControles(false, true); }
                else if (Rbt_Usuario.Checked) { Usuario.ModificarUsuario(); bloquearControles(true, false); }
                seleccionPersona(ID_Persona, CSesion_PersonaSeleccionada.Nombre+' '+ CSesion_PersonaSeleccionada.Apellido);
                Btn_GuardarCambios.Enabled = false;
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
            if (ID_Persona!=0)
            {
                bool Eliminar=CServ_MsjUsuario.Preguntar("¿Esta seguro de querer eliminar a la persona seleccionada? Si la persona es cliente o usuario se dará de baja también.");
                if (Eliminar)
                {
                    GestionPersonas.Eliminar(ID_Persona);
                    CServ_MsjUsuario.Exito("Persona eliminada con éxito");
                }
            }
        }
        private void Btn_RegistrarUsuario_Click(object sender, EventArgs e)
        {
            capturarDatosUsuarios();
            try
            {
                Usuario.CrearUsuario();
                CServ_MsjUsuario.Exito("Usuario Generado con éxito");
                bloquearControles(true,false);
            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }
        }
        private void Btn_RegistrarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                capturarDatosClientes();
                Clientes.AltaCliente();
                CServ_MsjUsuario.Exito("Cliente generado con éxito");
                CServ_Limpiar.BloquearControles(Pnb_RegistroCliente);
            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
                CServ_Limpiar.LimpiarPanelBox(Pnb_RegistroCliente);
            }

        }
        private void Btn_SeleccionarPersona_Click(object sender, EventArgs e)
        {
            CV_SeleccionarPersona SeleccionarPersona = new CV_SeleccionarPersona();
            SeleccionarPersona.PersonaSeleccionada += new CV_SeleccionarPersona.PersonaSeleccionadaHandler(seleccionPersona);
            SeleccionarPersona.ShowDialog();
        }
        private void Btn_Refrescar_Click(object sender, EventArgs e)
        {
            desbloquearControles();
            configurarLoad();
            CServ_Limpiar.LimpiarPanelBox(Pnb_RegistroPersona);
            CServ_Limpiar.LimpiarPanelBox(Pnb_RegistroUsuario);
            CServ_Limpiar.LimpiarPanelBox(Pnb_RegistroCliente);

        }

        #endregion

        #region Métodos
        private void configurarLoad()
        {
            Cmb_Sexo.Items.Add("Masculino");
            Cmb_Sexo.Items.Add("Femenino");
            Cmb_Sexo.SelectedIndex = -1;

            Size = new Size(710, 300);
            Pnb_RegistroUsuario.Enabled = false;
            Pnb_RegistroUsuario.Visible = false;
            Pnb_RegistroCliente.Enabled = false;
            Pnb_RegistroCliente.Visible = false;
            Txb_PersonaSeleccionada.Enabled = false;
            Rbt_Cliente.Enabled = false;
            Rbt_Usuario.Enabled = false;

            Btn_Modificar.Enabled = false;
            Btn_Eliminar.Enabled = false;
            Btn_GuardarCambios.Enabled = false;
        }
        private void cargarComboBox(bool Rbt_Cliente)
        {

            if (Rbt_Cliente)
            {
                Cmb_Categoria.DataSource = Clientes.ObtenerCategoria();
                Cmb_Categoria.DisplayMember = "Categoria";
                Cmb_Categoria.ValueMember = "ID_Categoria";
                Txb_DescCategoria.Enabled = false;
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

                Cmb_Familia.DataSource = Usuario.ObtenerFamilia();
                Cmb_Familia.DisplayMember = "Descripcion_Familia";
                Cmb_Familia.ValueMember = "ID_Familia";
                Cmb_Familia.SelectedIndex = -1;

                Cmb_Estado.DataSource = Usuario.ObtenerEstadoUsuarios();
                Cmb_Estado.DisplayMember = "Descripcion_Estado";
                Cmb_Estado.ValueMember = "ID_Estado";
                Cmb_Estado.SelectedIndex = -1;


                
                DataTable dt= Usuario.ObtenerVtosdePass(); ;
                Cmb_VenceCada.DataSource = dt;
                Cmb_VenceCada.DisplayMember = "DiasParaVencimiento";
                Cmb_VenceCada.ValueMember = "ID_Vencimiento";
                Cmb_VenceCada.SelectedIndex = -1;
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
                Rbt_Usuario.Enabled = false; 
                Rbt_Cliente.Checked = true;
                Rbt_Cliente.Enabled = true;

                Txb_UserName.Enabled = false;
                Dtp_FeAlta.Enabled = false;
                Cmb_Familia.Enabled = false;
                Cmb_Estado.Enabled = false;
                Cmb_VenceCada.Enabled = false;
                Btn_RegistrarUsuario.Enabled = false;
            }
            else if (EsCliente)
            {
                Rbt_Usuario.Checked = true;
                Rbt_Cliente.Enabled = false;
                Cmb_Categoria.Enabled = false;
                Txb_Descuento.Enabled = false;
                Txb_DescCategoria.Enabled = false;
                Txb_ComentarioCliente.Enabled = false;
                Dtp_FeAltaCliente.Enabled = false;
                Btn_RegistrarCliente.Enabled = false;
            }
            else
            {
                Rbt_Usuario.Checked = false;
                Cmb_Categoria.Enabled = true;
                Rbt_Cliente.Checked = false;
                Txb_UserName.Enabled = true;
                Rbt_Cliente.Enabled = true;
                Rbt_Usuario.Enabled = true;
            }

        }
        private void desbloquearControles(bool EsUsuario, bool EsCliente)
        {
            Txb_Nombre.Enabled = true;
            Txb_Apellido.Enabled = true;
            Txb_Dni.Enabled = true;
            Txb_Correo.Enabled = true;
            Cmb_Sexo.Enabled = true;
            Txb_Domicilio.Enabled = true;
            Cmb_Partido.Enabled = true;
            Cmb_Nacionalidad.Enabled = true;
            Txb_Telefono.Enabled = true;
            Dtp_FeNacimiento.Enabled = true;
            Txb_Comentario.Enabled = true;
            Btn_RegistrarPersona.Enabled = true;
            Txb_Contrasena.Enabled = true;
            Txb_ConfContrasena.Enabled = true;
            Txb_Pregunta1.Enabled = true;
            Txb_Pregunta2.Enabled = true;
            Txb_Pregunta3.Enabled = true;
            Txb_Respuesta1.Enabled = true;
            Txb_Respuesta2.Enabled = true;
            Txb_Respuesta3.Enabled = true;

            if (EsUsuario)
            {

                Txb_UserName.Enabled = true;
                Dtp_FeAlta.Enabled = true;
                Cmb_Familia.Enabled = true;
                Cmb_Estado.Enabled = true;
                Cmb_VenceCada.Enabled = true;
            }
            else if (EsCliente)
            {
                Cmb_Categoria.Enabled = true;
                Txb_Descuento.Enabled = true;
                Txb_ComentarioCliente.Enabled = true;
                Dtp_FeAltaCliente.Enabled = true;
            }

        }
        private void cargarPersonasdeCombobox(DataTable dt, bool EsUsuario, bool EsCliente)
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
                Rbt_Cliente.Enabled = true;
            }
            if (EsUsuario)
            {
                bloquearControles(EsUsuario, false);
                Rbt_Usuario.Checked = true;
                Rbt_Cliente.Enabled = false;
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
            }
            else if (EsCliente)
            {
                Rbt_Usuario.Checked = false;
                Rbt_Cliente.Enabled = true;
                Rbt_Cliente.Checked = true;
                Cmb_Categoria.SelectedValue = CSesion_PersonaSeleccionada.ID_Categoria;
                Txb_ComentarioCliente.Text = CSesion_PersonaSeleccionada.ComentarioCliente;
                Dtp_FeAltaCliente.Value = CSesion_PersonaSeleccionada.FechaAltaCliente;

            }

            else
            {
                Rbt_Cliente.Checked = false;
                Rbt_Usuario.Checked = false;
                CServ_Limpiar.LimpiarPanelBox(Pnb_RegistroUsuario);
                CServ_Limpiar.LimpiarPanelBox(Pnb_RegistroCliente);
            }
        }
        private void seleccionPersona(int idPersonaDelegado, string cliente)
        {
            ID_Persona = idPersonaDelegado;
            Txb_PersonaSeleccionada.Text = cliente;
            if (ID_Persona != 0)
            {
                cargarPersonas();
                Btn_Modificar.Enabled = true;
                Btn_Eliminar.Enabled = true;
            }
        }
        private void cargarPersonas()
        {
            if (ID_Persona!=0)
            {
                DataTable dt = new DataTable();
                dt = GestionPersonas.CargarDatos(ID_Persona);
                bool EsUsuario = GestionPersonas.CargarDatosUsuarios(ID_Persona);
                bool EsCliente = GestionPersonas.CargarDatosClientes(ID_Persona);
                if (EsUsuario)
                {
                    bloquearControles(EsUsuario, false);
                    cargarPersonasdeCombobox(dt, EsUsuario, false);
                }
                else if (EsCliente)
                {
                    bloquearControles(false, EsCliente);
                    cargarPersonasdeCombobox(dt, false, EsCliente);
                }
                else
                {
                    bloquearControles(false, false);
                    cargarPersonasdeCombobox(dt, false, EsCliente);
                }
            }

            else
            {
                CServ_Limpiar.LimpiarFormulario(this);
            }
        }
        private void desbloquearControles()
        {
            Txb_Nombre.Enabled = true;
            Txb_Apellido.Enabled = true;
            Txb_Dni.Enabled = true;
            Txb_Correo.Enabled = true;
            Cmb_Sexo.Enabled = true;
            Txb_Domicilio.Enabled = true;
            Cmb_Partido.Enabled = true;
            Cmb_Nacionalidad.Enabled = true;
            Txb_Telefono.Enabled = true;
            Dtp_FeNacimiento.Enabled = true;
            Btn_RegistrarPersona.Enabled = true;
            Rbt_Cliente.Enabled = true;
            Rbt_Usuario.Enabled = true;
            if (Rbt_Cliente.Checked)
            {
                Txb_ComentarioCliente.Enabled = true;
                Cmb_Categoria.Enabled = true;
                Dtp_FeAltaCliente.Enabled = true;
            }
            else if (Rbt_Usuario.Checked)
            {
                Dtp_FeAlta.Enabled = true;
                Cmb_Familia.Enabled = true;
                Cmb_Estado.Enabled = true;
                Cmb_VenceCada.Enabled = true;
            }
        }


        #endregion

        private void Btn_AsociarCliente_Click(object sender, EventArgs e)
        {
            cargarComboBox(true);
            Size = new Size(710, 400);
            Txb_Descuento.Enabled = false;
            Pnb_RegistroCliente.Location = new System.Drawing.Point(15, 237);
            Pnb_RegistroCliente.Enabled = true;
            Pnb_RegistroCliente.Visible = true;
        }
    }
}
