﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Datos;
using Servicios;
using Sesion;
using Sistema;

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
        { get => atr_ContrasenaUsuarioLogin; set {
                if (string.IsNullOrEmpty(atr_ContrasenaUsuarioLogin))
                {
                    throw new Exception("Por favor, ingrese la contraseña del usuario.");
                }
               else atr_ContrasenaUsuarioLogin = value; } }
        public string Prop_EncriptacionLogin
        {
            get => atr_EncriptacionLogin; set
            {
                if (string.IsNullOrEmpty(atr_NombreUsuarioLogin))
                {
                    throw new Exception("Por favor, ingrese el nombre de usuario.");
                }
                else atr_EncriptacionLogin = value; } }
        public string Prop_UserName { get; set ; } 
        public string Prop_Contrasena { get; set; }
        public string Prop_Encriptacion { get; set; }
        public string Prop_FeAlta { get; set; }
        public string Prop_Familia { get; set; }
        public string Prop_Estado { get; set; }
        public string Prop_Preg1 { get; set; }
        public string Prop_Resp1 { get; set; }
        public string Prop_Preg2 { get; set; }
        public string Prop_Resp2 { get; set; }
        public string Prop_Preg3 { get; set; }
        public string Prop_Resp3 { get; set; }
        public string Prop_VtoPass { get; set; }
        public string Prop_NuevaPass{ get; set; }
        public string Prop_CambioPass { get; set; }
        public string Prop_Comentarios { get; set; }

        #endregion
        public bool Logear()
        {
            PasarDatos(); 
            bool Resultado = false;
            Resultado = Usuario.Logear();
            return Resultado;
        }
        public void BloqueodeUsuarios() 
        {
            Usuario.BloqueoUsuario();
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
            CServ_EnvioMail.EnviarCorreo();
            Usuario.Insertar();

        }
        public void GuardarNuevaPass()
        {
            try
            {
                PasarDatos(true);
                {
                    if (CSistema_ConfiguracionSistema.RepetirPass)
                    {
                        bool Repite =Usuario.RepitePass();
                        if (Repite) { throw new Exception("No puede repetir la contraseña"); }
                    }
                    else Usuario.CambiarPass();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool CompararDatos()
        {
            if (Prop_Resp1.ToLower() == CSesion_PreguntasUsuarios.Respuesta1
                & Prop_Resp2.ToLower() == CSesion_PreguntasUsuarios.Respuesta2
                & Prop_Resp3.ToLower() == CSesion_PreguntasUsuarios.Respuesta3 || Prop_Resp1.ToLower() == CSesion_SesionIniciada.Respuesta1
                & Prop_Resp2.ToLower() == CSesion_SesionIniciada.Respuesta2
                & Prop_Resp3.ToLower() == CSesion_SesionIniciada.Respuesta3)
            {
                return true;
            }
            else
            {                
                throw new Exception("Lasr respuestas brindadas no son correctas");                
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
                Usuario.Prop_EncriptacionLogin = CServ_Encriptacion.SHA256(atr_EncriptacionLogin);
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
                        Usuario.Prop_Encriptacion = CServ_Encriptacion.SHA256(Prop_Encriptacion);
                        Usuario.Prop_NuevaPass = Convert.ToBoolean(Prop_NuevaPass);
                        DateTime hoy = DateTime.Today;
                        Usuario.Prop_FeCambioPass = hoy.AddDays(CSesion_SesionIniciada.VenceCada);

                        
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
                string contra = Prop_UserName + passaleatoria;
                Usuario.Prop_Encriptacion = CServ_Encriptacion.SHA256(contra);
                CServ_EnvioMail.Prop_UserName = Prop_UserName;
                CServ_EnvioMail.Prop_PassAleatoria = passaleatoria;
                CServ_EnvioMail.Prop_Correo = CSesion_PersonaSeleccionada.Correo;

                try
                {
                    Usuario.Prop_FeAlta = Convert.ToDateTime(Prop_FeAlta);
                    switch (Prop_VtoPass)
                    {
                        case "30 Dias": Usuario.Prop_VtoPass = 30;
                            break;
                        case "60 Dias":
                            Usuario.Prop_VtoPass = 60;
                            break;
                        case "120 Dias":
                            Usuario.Prop_VtoPass = 120;
                            break;
                        case "Nunca":
                            Usuario.Prop_VtoPass = 0;
                            break;
                    }
                    
                }
                catch (Exception)
                {
                    throw new Exception("Error al guardar las fechas, por favor intente nuevamente");
                }

                Usuario.Prop_Familia = Prop_Familia;
                Usuario.Prop_Estado = Prop_Estado;
                Usuario.Prop_NuevaPass = Convert.ToBoolean(Prop_NuevaPass);
                Usuario.Prop_CambioPass = Convert.ToBoolean(Prop_CambioPass);
                Usuario.Prop_Comentarios = Prop_Comentarios;
            }
            catch (Exception)
            {

                throw new Exception ("Error al guardar los datos, verifique que todos los campos estén completos");
            }         

        }
    }
}
