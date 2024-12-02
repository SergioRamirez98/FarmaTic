using Logica;
using Servicios;
using Sesion;
using Sistema;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    public partial class CV_OlvidoPass : Form
    {
        CL_Usuarios Usuarios = new CL_Usuarios();
        CL_Sistema Sistema = new CL_Sistema();
        bool VerificarCondiciones = true;
        public CV_OlvidoPass()
        {
            InitializeComponent();
        }
        #region Eventos
        private void CV_OlvidoPass_Load(object sender, EventArgs e)
        {
            Pnl_GuardarPass.Visible = false;            
            Btn_Buscar.Visible = false;
            Txb_Preg1.Enabled = false;
            Txb_Respuesta1.Enabled  = false;
            Txb_Preg2.Enabled = false;      
            Txb_Respuesta2.Enabled = false;
            Txb_Preg3.Enabled = false;
            Txb_Respuesta3.Enabled = false;
            Btn_Guardar.Enabled = false;
            Lbl_CoincidePass.Visible = false;
            Lbl_PregGuardada.Visible = false;
            Btn_GuardarPass.Enabled = false;
            
            CServ_InfoSensible.Contrasena(Txb_Pass, Txb_ConfPass);
            Size = new Size(400,360) ;
            if (CSesion_SesionIniciada.NuevaPass == true || CSesion_SesionIniciada.CambioPass == true)
            {
                CargarLoad(true);          
            }
            else
            {
                CargarLoad(false);
            }
            Sistema.CargarConfiguracion();

            CServ_ConfBotones.ConfiguracionDeBotones(this);
        }
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            Usuarios.Prop_UserName = Txb_UserName.Text;
            try
            {
                DataTable NombreUsuario = Usuarios.BuscarUsuario();
                if (NombreUsuario.Rows.Count > 0)
                {
                    Txb_UserName.Text = CSesion_PreguntasUsuarios.UserName;
                    Txb_UserName.Enabled = false;
                    Txb_Preg1.Text = CSesion_PreguntasUsuarios.Pregunta1;
                    Txb_Preg2.Text = CSesion_PreguntasUsuarios.Pregunta2;
                    Txb_Preg3.Text = CSesion_PreguntasUsuarios.Pregunta3;
                    Txb_Respuesta1.Enabled = true;
                    Txb_Respuesta2.Enabled = true;
                    Txb_Respuesta3.Enabled = true;
                    Btn_Guardar.Enabled = true;
                }

            }
            catch (Exception ex) { CServ_MsjUsuario.MensajesDeError(ex.Message); }
        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
                if (CSesion_SesionIniciada.NuevaPass == true)
                {
                    if (!String.IsNullOrEmpty(CSesion_SesionIniciada.Pregunta1))
                    {
                        try
                        {
                            PasarDatos();
                            bool resultado = Usuarios.CompararRespuestas();
                            if (resultado == true)
                            {
                                Size = new Size(400, 569);
                                BloquearControles();
                                Pnl_GuardarPass.Visible = true;
                            }
                            else
                            {
                                throw new Exception("Las respuestas brindadas no son correctas.");
                            }

                        }
                        catch (Exception ex)
                        {
                            CServ_MsjUsuario.MensajesDeError(ex.Message);
                        }

                    }
                    else
                    {
                        PasarDatos();
                        try
                        {
                            Usuarios.InsertarRespuestasdeSeguridad();
                            BloquearControles();
                            Size = new Size(400, 569);
                            Lbl_PregGuardada.Visible = true;
                            Pnl_GuardarPass.Visible = true;
                        }
                        catch (Exception ex)
                        {

                            CServ_MsjUsuario.MensajesDeError(ex.Message);
                        }
                    }
                }

                else
                {
                    try
                    {
                        PasarDatos();
                        bool resultado = Usuarios.CompararRespuestas();
                        if (resultado == true)
                        {
                            Size = new Size(400, 569);//669
                            BloquearControles();
                            Pnl_GuardarPass.Visible = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        CServ_MsjUsuario.MensajesDeError(ex.Message);
                    }
                }        

        }          
        private void Btn_GuardarPass_Click(object sender, EventArgs e)
        {

            if (VerificarCondiciones)
            {
                if (CSesion_SesionIniciada.NuevaPass == true) //Va por esta opcion cuando ingresa por primera vez y cambia de pass
                {
                    try
                    {
                        PasarDatos(true);
                        Usuarios.GuardarNuevaPass();
                        CServ_MsjUsuario.Exito("Contraseña guardada con éxito");
                        this.Close();
                        CV_Menu menu = new CV_Menu();
                        menu.Show();
                    }
                    catch (Exception ex) { CServ_MsjUsuario.MensajesDeError(ex.Message); }
                }
                else //Va por esta opcion cuando es un cambio de contraseña
                {
                    try
                    {
                        PasarDatos(true);
                        Usuarios.GuardarNuevaPass();
                        CServ_MsjUsuario.Exito("Contraseña guardada con éxito");
                        this.Close(); 

                    }
                    catch (Exception ex) { CServ_MsjUsuario.MensajesDeError(ex.Message); }
                }
            }
            else
            {
                CServ_MsjUsuario.MensajesDeError("Revise los errores en rojo.");
            }
        }
        private void Txb_Pass_TextChanged(object sender, EventArgs e)
        {

            if (CSistema_ConfiguracionSistema.CaractEspecial)
            {
                CSistema_CaracEspecial.CacaterEspecial(Txb_Pass, Lbl_CacaterEspecial);
                if (Lbl_CacaterEspecial.ForeColor != Color.Green)
                {
                    VerificarCondiciones = false;
                }
            }
            if (CSistema_ConfiguracionSistema.DatosPersonales)
            {
                CSistema_DatosPersonales.PassDatosPersonales(Txb_Pass, Lbl_DatosPersonales);
                if (Lbl_DatosPersonales.ForeColor != Color.Green)
                {
                    VerificarCondiciones = false;
                }
            }
            if (CSistema_ConfiguracionSistema.MayusMinus)
            {
                CSistema_MayMin.CombinarMayMin(Txb_Pass, Lbl_MayusMinus);
                if (Lbl_MayusMinus.ForeColor != Color.Green)
                {
                    VerificarCondiciones = false;
                }
            }
            if (CSistema_ConfiguracionSistema.NumerosYLetras)
            {
                CSistema_NumyLetr.NumYLetras(Txb_Pass, Lbl_NumerosYLetras);
                if (Lbl_NumerosYLetras.ForeColor != Color.Green)
                {
                    VerificarCondiciones = false;
                }
            }
            if (CSistema_ConfiguracionSistema.MinCaracteres)
            {
                CSistema_MinimoCaracteres.CantCaracteres(Txb_Pass, Lbl_MinCaracteres);
                if (Lbl_MinCaracteres.ForeColor != Color.Green)
                {
                    VerificarCondiciones = false;
                }
            }
            
        }
        private void Txb_ConfPass_TextChanged_1(object sender, EventArgs e)
        {

            if (Txb_ConfPass.Text == Txb_Pass.Text)
            {
                Btn_GuardarPass.Enabled = true;
                VerificarCondiciones = true;
                Lbl_CoincidePass.Visible = true;
                Lbl_CoincidePass.ForeColor = Color.Green;
                Lbl_CoincidePass.Text = "Las contraseñas coinciden";
            }


            else
            {
                Btn_GuardarPass.Enabled = false;
                Lbl_CoincidePass.Visible = false;
                Lbl_CoincidePass.ForeColor = Color.Red;
                Lbl_CoincidePass.Text = "Las contraseñas no coinciden";
                VerificarCondiciones =false;
            }
        }
        private void CV_OlvidoPass_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CSesion_SesionIniciada.NuevaPass == false)
            {
                CSesion_SesionIniciada.SesionActiva = true;
            }
            CSesion_SesionIniciada.LimpiarCache();
            Program.Login.Show();
        }
        #endregion

        #region Métodos
        private void PasarDatos()
        {
            if (CSesion_SesionIniciada.NuevaPass == true)
            {
                Usuarios.Prop_Preg1 = Txb_Preg1.Text;
                Usuarios.Prop_Resp1 = Txb_Respuesta1.Text;
                Usuarios.Prop_Preg2 = Txb_Preg2.Text;
                Usuarios.Prop_Resp2 = Txb_Respuesta2.Text;
                Usuarios.Prop_Preg3 = Txb_Preg3.Text;
                Usuarios.Prop_Resp3 = Txb_Respuesta3.Text;
            }
            else
            {
                Usuarios.Prop_UserName = Txb_UserName.Text;
                if (string.IsNullOrEmpty(CSesion_PreguntasUsuarios.Pregunta1))
                {
                    Usuarios.Prop_Preg1 = CSesion_SesionIniciada.Pregunta1;
                    Usuarios.Prop_Preg2 = CSesion_SesionIniciada.Pregunta2;
                    Usuarios.Prop_Preg3 = CSesion_SesionIniciada.Pregunta3;
                }
                else
                {
                    Usuarios.Prop_Preg1 = CSesion_PreguntasUsuarios.Pregunta1;
                    Usuarios.Prop_Preg2 = CSesion_PreguntasUsuarios.Pregunta2;
                    Usuarios.Prop_Preg3 = CSesion_PreguntasUsuarios.Pregunta3;

                }
                Usuarios.Prop_Resp1 = Txb_Respuesta1.Text;
                Usuarios.Prop_Resp2 = Txb_Respuesta2.Text;
                Usuarios.Prop_Resp3 = Txb_Respuesta3.Text;
            }
        }
        private void PasarDatos(bool cambioPass)
        {
            Usuarios.Prop_UserName = Txb_UserName.Text;
            if (cambioPass)
            {      
                Usuarios.Prop_NuevaPass = false.ToString();
                if (Txb_ConfPass.Text == Txb_Pass.Text)
                {
                    Usuarios.Prop_Contrasena = Txb_Pass.Text;
                    Usuarios.Prop_Encriptacion = Txb_UserName.Text + Txb_Pass.Text;
                }
                else
                {
                    Lbl_CoincidePass.Visible = true;
                }

            }

        }
        private void BloquearControles()
        {
            Txb_Preg1.Enabled = false;
            Txb_Preg2.Enabled = false;
            Txb_Preg3.Enabled = false;
            Txb_Respuesta1.Enabled = false;
            Txb_Respuesta2.Enabled = false;
            Txb_Respuesta3.Enabled = false;
            
            Btn_Guardar.Enabled = false;
        }
        private void CargarLoad(bool Load) 
        {
            if (Load)
            {
                Txb_UserName.Location = new System.Drawing.Point(140, 12);
                Lbl_UserName.Location = new System.Drawing.Point(140, 36);
                this.Text = "Cambio de contraseña";
                Txb_UserName.Text = CSesion_SesionIniciada.UserName;
                Txb_UserName.Enabled = false;
                
                if (String.IsNullOrEmpty(CSesion_SesionIniciada.Pregunta1))
                {
                    DataTable Preguntas = Usuarios.ObtenerPreguntas();
                    if (Preguntas.Rows.Count == 3)
                    {
                        Txb_Preg1.Text = Preguntas.Rows[0]["Pregunta"].ToString();
                        Txb_Respuesta1.Enabled = true;
                        Txb_Preg2.Text = Preguntas.Rows[1]["Pregunta"].ToString();
                        Txb_Respuesta2.Enabled = true;
                        Txb_Preg3.Text = Preguntas.Rows[2]["Pregunta"].ToString();
                        Txb_Respuesta3.Enabled = true;
                        Btn_Guardar.Enabled = true;
                    }
                }
                else
                {

                    Txb_Preg1.Text = CSesion_SesionIniciada.Pregunta1;
                    Txb_Respuesta1.Enabled = true;
                    Txb_Preg2.Text = CSesion_SesionIniciada.Pregunta2;
                    Txb_Respuesta2.Enabled = true;
                    Txb_Preg3.Text = CSesion_SesionIniciada.Pregunta3;
                    Txb_Respuesta3.Enabled = true;
                    Btn_Guardar.Enabled = true;

                    Btn_Guardar.Text = "Comprobar";

                }
               
            }
            else
            {
                Txb_UserName.Text = CSesion_SesionIniciada.UserName;

                Btn_Buscar.Visible = true;

                Txb_Preg1.Text = CSesion_SesionIniciada.Pregunta1;                
                Txb_Preg2.Text = CSesion_SesionIniciada.Pregunta2;                
                Txb_Preg3.Text = CSesion_SesionIniciada.Pregunta3;

                Btn_Guardar.Text = "Comprobar";

            }
        }
        #endregion        
    }
}