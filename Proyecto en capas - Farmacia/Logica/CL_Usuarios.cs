using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Capa_Servicios;
using Datos;
using Servicios;
using Sesion;

namespace Logica
{
    public class CL_Usuarios
    {
        CD_Usuarios Usuario = new CD_Usuarios();

        #region Atributos
        private string atr_NombreUsuarioLogin;
        private string atr_ContrasenaUsuarioLogin;
        private string atr_EncriptacionLogin;

        #endregion

        #region Properties
        public int Prop_ID_Persona
        { get; set; }
        public string Prop_NombreUsuarioLogin
        { get => atr_NombreUsuarioLogin; set { atr_NombreUsuarioLogin = value; } }
        public string Prop_ContrasenaUsuarioLogin
        { get => atr_ContrasenaUsuarioLogin; set { atr_ContrasenaUsuarioLogin = value; } }
        public string Prop_EncriptacionLogin
        { get => atr_EncriptacionLogin; set { atr_EncriptacionLogin = value; } }
        public string Prop_UserName
        { get; set ; } 
        public string Prop_Contrasena
        { get; set; }
        public string Prop_Encriptacion
        { get; set; }
        public string Prop_FeAlta
        { get; set; }
        public string Prop_Familia
        { get; set; }
        public string Prop_Estado
        { get; set; }
        public string Prop_Preg1
        { get; set; }
        public string Prop_Resp1
        { get; set; }
        public string Prop_Preg2
        { get; set; }
        public string Prop_Resp2
        { get; set; }
        public string Prop_Preg3
        { get; set; }
        public string Prop_Resp3
        { get; set; }
        public string Prop_VtoPass
        { get; set; }
        public string Prop_NuevaPass
        { get; set; }
        public string Prop_CambioPass
        { get; set; }
        #endregion
        public bool Logear()
        {
            PasarDatos();            
            return Usuario.Logear();
        }
        public DataTable BuscarUsuario()
        {
            Usuario.Prop_UserName = Prop_UserName;
            return Usuario.BuscarUser();
        }
        public DataTable ObtenerPreguntas()
        {
            return Usuario.ObtenerPreguntasAleatorias();            
        }
        public void InsertarRespuestasdeSeguridad()
        {
            try
            {
                PasarDatos();
                Usuario.InsertarRespuestas();
            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError( ex.Message);
            }
        }
        public bool CompararRespuestas()
        {
            return CompararDatos();
        }
        public void CrearUsuario()
        {
            string passaleatoria=CServ_Aleatorios.PassAleatoria();
            PasarDatos(passaleatoria);
         //   CServ_EnvioMail.EnviarCorreo();
            Usuario.Insertar();

        }
        public void GuardarNuevaPass()
        {
            try
            {
                PasarDatos(true);
                Usuario.CambiarPass();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CompararDatos()
        {
            if (Prop_Resp1 == CSesion_PreguntasUsuarios.Respuesta1 
                && Prop_Resp2 == CSesion_PreguntasUsuarios.Respuesta2 
                && Prop_Resp3 == CSesion_PreguntasUsuarios.Respuesta3)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
        public void PasarDatos() 
        {
            if (CSesion_SesionIniciada.NuevaPass == true)
            {
                try
                {
                    Usuario.Prop_UserName = CSesion_SesionIniciada.UserName;

                    if (String.IsNullOrEmpty(Prop_Resp1) || String.IsNullOrEmpty(Prop_Resp2) || String.IsNullOrEmpty(Prop_Resp3))
                    {
                        throw new Exception("Los campos 'respuesta' no pueden estar vacios, " +
                            "por favor ingrese una respuesta válida.");
                    }
                    else
                    {
                        Usuario.Prop_Preg1 = Prop_Preg1;
                        Usuario.Prop_Preg2 = Prop_Preg2;
                        Usuario.Prop_Preg3 = Prop_Preg3;
                        Usuario.Prop_Resp1 = Prop_Resp1;
                        Usuario.Prop_Resp2 = Prop_Resp2;
                        Usuario.Prop_Resp3 = Prop_Resp3;
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                Usuario.Prop_NombreUsuarioLogin = atr_NombreUsuarioLogin;
                Usuario.Prop_ContrasenaUsuarioLogin = atr_ContrasenaUsuarioLogin;
                Usuario.Prop_EncriptacionLogin = CServ_Encriptacion.Encriptar(atr_EncriptacionLogin);
               
            }
        }
        public void PasarDatos(bool nuevaContrasena)
        {
            if (nuevaContrasena)
            {
                try
                {
                    if (string.IsNullOrEmpty(Prop_UserName) || string.IsNullOrEmpty(Prop_Contrasena))
                    {
                        throw new Exception("Error al guardar las contraseñas.");
                    }
                    else
                    {
                        Usuario.Prop_UserName = Prop_UserName;
                        Usuario.Prop_Contrasena = Prop_Contrasena;
                        Usuario.Prop_Encriptacion = CServ_Encriptacion.Encriptar(Prop_Encriptacion);
                        Usuario.Prop_NuevaPass = Convert.ToBoolean(Prop_NuevaPass);
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }
                        
        }
        public void PasarDatos(string passaleatoria)
        {
            try
            {
                Usuario.ID_Persona = Prop_ID_Persona;
                Usuario.Prop_UserName = Prop_UserName;
                Usuario.Prop_Contrasena = passaleatoria;
                Usuario.Prop_Encriptacion = CServ_Encriptacion.Encriptar(Prop_UserName, passaleatoria);
                CServ_EnvioMail.Prop_UserName = Prop_UserName;
                CServ_EnvioMail.Prop_PassAleatoria = passaleatoria;
                CServ_EnvioMail.Prop_Correo = CSesion_PersonaSeleccionada.Correo;

                try
                {
                    Usuario.Prop_FeAlta = Convert.ToDateTime(Prop_FeAlta);
                    Usuario.Prop_VtoPass = Convert.ToInt32(Prop_VtoPass);
                }
                catch (Exception)
                {
                    throw new Exception("Error al guardar las fechas, por favor intente nuevamente");
                }

                Usuario.Prop_Familia = Prop_Familia;
                Usuario.Prop_Estado = Prop_Estado;
                Usuario.Prop_Preg1 = Prop_Preg1;
                Usuario.Prop_Preg2 = Prop_Preg2;
                Usuario.Prop_Preg3 = Prop_Preg3;
                Usuario.Prop_NuevaPass = Convert.ToBoolean(Prop_NuevaPass);
                Usuario.Prop_CambioPass = Convert.ToBoolean(Prop_CambioPass);
            }
            catch (Exception)
            {

                throw new Exception ("Error al guardar los datos, verifique que todos los campos estén completos");
            }
           

        }

    }
}
