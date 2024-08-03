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
            if (CSesion_SesionIniciada.NuevaPass == true)
            {
                CargarLoad(true);          
            }
            else
            {
                CargarLoad(false);
            }
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
                        Size = new Size(400, 669);
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
                        Size = new Size(400, 669);
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
            if (CSesion_SesionIniciada.CambioPass == true)
            {
                try
                {
                    PasarDatos(true);
                    Usuarios.GuardarNuevaPass();      
                    this.Close();
                    CV_Menu menu = new CV_Menu();
                    menu.Show();
                }
                catch (Exception ex) { CServ_MsjUsuario.MensajesDeError(ex.Message); }
            }
            else 
            {
                try
                {
                    PasarDatos(true);
                    Usuarios.GuardarNuevaPass();
                    CV_Menu menu = new CV_Menu();
                    menu.Show();
                }
                catch (Exception ex) { CServ_MsjUsuario.MensajesDeError(ex.Message); }
            }
        }
        private void Txb_Pass_TextChanged(object sender, EventArgs e)
        {                        
            CSistema_CaracEspecial.CacaterEspecial(Txb_Pass, Lbl_msj1);
            CSistema_DatosPersonales.PassDatosPersonales(Txb_Pass, Lbl_msj2);
            CSistema_MayMin.CombinarMayMin(Txb_Pass, Lbl_msj3);
            CSistema_NumyLetr.NumYLetras(Txb_Pass, Lbl_msj4);
            CSistema_MinimoCaracteres.CantCaracteres(Txb_Pass, Lbl_msj5);            
        }
        private void Txb_ConfPass_TextChanged(object sender, EventArgs e)
        {
            if (Txb_ConfPass != Txb_Pass)
            {
                Txb_Pass.ForeColor = Color.Red;
                Btn_GuardarPass.Enabled = false;
            }

            else
            {
                Btn_GuardarPass.Enabled=true;
            }
        }
        private void CV_OlvidoPass_FormClosed(object sender, FormClosedEventArgs e)
        {
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
                Usuarios.Prop_Preg1 = CSesion_PreguntasUsuarios.Pregunta1;
                Usuarios.Prop_Preg2 = CSesion_PreguntasUsuarios.Pregunta2;
                Usuarios.Prop_Preg3 = CSesion_PreguntasUsuarios.Pregunta3;
                Usuarios.Prop_Resp1 = Txb_Respuesta1.Text;
                Usuarios.Prop_Resp2 = Txb_Respuesta2.Text;
                Usuarios.Prop_Resp3 = Txb_Respuesta3.Text;
            }
        }
        private void PasarDatos(bool cambioPass) 
        {
            if (cambioPass)
            {                
                Usuarios.Prop_UserName = Txb_UserName.Text;
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
