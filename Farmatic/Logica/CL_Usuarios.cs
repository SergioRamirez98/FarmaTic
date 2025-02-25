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
        { get => atr_NombreUsuarioLogin; set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Por favor, ingrese el nombre de usuario.");
                }
                atr_NombreUsuarioLogin = value; } }
        public string Prop_ContrasenaUsuarioLogin
        { get => atr_ContrasenaUsuarioLogin; set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Por favor, ingrese la contraseña del usuario.");
                }
               else atr_ContrasenaUsuarioLogin = value; } }
        public string Prop_EncriptacionLogin
        { get => atr_EncriptacionLogin; set{ atr_EncriptacionLogin = value; } }
        public string Prop_UserName { get; set ; } 
        public string Prop_Contrasena { get; set; }
        public string Prop_Encriptacion { get; set; }
        public string Prop_FeAlta { get; set; }
        public string Prop_Familia { get; set; }
        public string Prop_Estado { get; set; }
        public string DigitoVerificador { get; set; }
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
        public void ModificarUsuario()
        {
            PasarDatosModificacion();
            Usuario.ActualizarUsuario();
        }
        public void BloqueodeUsuarios() 
        {
            Usuario.BloqueoUsuario();
        }
        public void Eliminar(int id_Persona) 
        {
            Usuario.EliminarUsuario(id_Persona);
        }
        public DataTable ObtenerFamilia()
        {
            return Usuario.Familia();
        }
        public bool CargarDatosUsuarios(int ID_Persona)
        {
            return Usuario.CargarUsuarios(ID_Persona);
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
        public DataTable ObtenerEstadoUsuarios()
        {
            DataTable dt = Usuario.ObtenerEstadoCmb();
            return dt;
        }
        public DataTable ObtenerVtosdePass()
        {
            DataTable dt = Usuario.ObtenerVencimientosPass();
            DataTable VtoConvertido= convertirVto(dt);
            return VtoConvertido;
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
        public bool ExisteUsuario() 
        {
            Usuario.Prop_UserName=Prop_UserName;
            Usuario.ID_Persona = Prop_ID_Persona;
            return Usuario.ComprobarUsuario();
        }
        public int ReactivarUsuario() 
        {            
            Usuario.Prop_UserName = Prop_UserName;
            Usuario.ID_Persona = Prop_ID_Persona;
            return Prop_ID_Persona= Usuario.ReestablecerUsuario();
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
            if (string.IsNullOrEmpty(CSesion_PreguntasUsuarios.Respuesta1))
            {
                if (Prop_Resp1.ToLower() == CSesion_SesionIniciada.Respuesta1.ToLower()
                    & Prop_Resp2.ToLower() == CSesion_SesionIniciada.Respuesta2.ToLower()
                    & Prop_Resp3.ToLower() == CSesion_SesionIniciada.Respuesta3.ToLower())
                {
                    return true;
                }
                else
                {
                    throw new Exception("Lasr respuestas brindadas no son correctas");
                }

            }
            else
            {

                if (Prop_Resp1.ToLower() == CSesion_PreguntasUsuarios.Respuesta1.ToLower()
                    & Prop_Resp2.ToLower() == CSesion_PreguntasUsuarios.Respuesta2.ToLower()
                    & Prop_Resp3.ToLower() == CSesion_PreguntasUsuarios.Respuesta3.ToLower())
                {
                    return true;
                }
                else
                {
                    throw new Exception("Lasr respuestas brindadas no son correctas");
                }

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
                Usuario.DigitoVerificador = CServ_Encriptacion.convertiraCadena(Usuario.Prop_EncriptacionLogin);
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
                        Usuario.DigitoVerificador = CServ_Encriptacion.convertiraCadena(Usuario.Prop_Encriptacion);
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
            {if (Prop_ID_Persona==0) throw new Exception("No ha seleccionado ninguna persona para dar de alta como cliente");
                else Usuario.ID_Persona = Prop_ID_Persona;


                Usuario.Prop_UserName = Prop_UserName;
                Usuario.Prop_Contrasena = passaleatoria;
                string contra = Prop_UserName + passaleatoria;
                Usuario.Prop_Encriptacion = CServ_Encriptacion.SHA256(contra);
                Usuario.DigitoVerificador = CServ_Encriptacion.convertiraCadena(Usuario.Prop_Encriptacion);
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
                    throw new Exception("Error al guardar los vencimientos, por favor intente nuevamente");
                }

                Usuario.Prop_Familia = Convert.ToInt32(Prop_Familia);
                Usuario.Prop_Estado = Convert.ToInt32(Prop_Estado);
                Usuario.Prop_NuevaPass = Convert.ToBoolean(Prop_NuevaPass);
                Usuario.Prop_CambioPass = Convert.ToBoolean(Prop_CambioPass);
                Usuario.Prop_Comentarios = Prop_Comentarios;
            }
            catch (Exception ex)
            {

                throw new Exception (ex.Message);
            }         

        }
        public void PasarDatosModificacion()
        {
            try
            {
                Usuario.ID_Persona = Prop_ID_Persona;
                Usuario.Prop_UserName = Prop_UserName;
                Usuario.Prop_Comentarios = Prop_Comentarios;

                try
                {
                    Usuario.Prop_Familia = Convert.ToInt32(Prop_Familia);
                    Usuario.Prop_Estado = Convert.ToInt32(Prop_Estado);
                    Usuario.Prop_VtoPass = Convert.ToInt32(Prop_VtoPass);

                    Usuario.Prop_FeAlta = Convert.ToDateTime(Prop_FeAlta);

                }
                catch (Exception)
                {
                    throw new Exception("Error al guardar los vencimientos, por favor intente nuevamente");
                }

            }
            catch (Exception)
            {

                throw new Exception("Error al guardar los datos, verifique que todos los campos estén completos");
            }

        }
        public DataTable convertirVto(DataTable dt) 
        {
            DataTable DtModificado = new DataTable();
            DtModificado.Columns.Add("ID_Vencimiento", typeof(int));
            DtModificado.Columns.Add("DiasParaVencimiento", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                var fila = DtModificado.NewRow();
                fila["ID_Vencimiento"] = row["ID_Vencimiento"];

                if ((int)row["DiasParaVencimiento"] == 0)
                {
                    fila["DiasParaVencimiento"] = "Nunca vence";
                }
                else
                {
                    fila["DiasParaVencimiento"] = row["DiasParaVencimiento"].ToString();
                }

                DtModificado.Rows.Add(fila);
            }

            return DtModificado;
        }

    }
}
