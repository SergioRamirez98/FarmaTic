using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sesion;
using System.Data.SqlTypes;
using Sistema;

namespace Datos
{
    public class CD_Usuarios : CD_EjecutarSP
    {
        #region Atributos
        private string atr_NombreUsuarioLogin;
        private string atr_EncriptacionLogin;
        SqlParameter[] lista = null;
        #endregion

        #region Properties
        public string Prop_NombreUsuarioLogin
        { get => atr_NombreUsuarioLogin; set { atr_NombreUsuarioLogin = value; } }       
        public string Prop_EncriptacionLogin
        { get => atr_EncriptacionLogin; set { atr_EncriptacionLogin = value; } }

        public int ID_Persona { get; set; }
        public string Prop_UserName { get; set; }
        public string Prop_Contrasena { get; set; }
        public string Prop_Encriptacion { get; set; }
        public DateTime Prop_FeAlta { get; set; }
        public int Prop_Familia { get; set; }
        public int Prop_Estado { get; set; }
        public string Prop_Preg1 { get; set; }
        public string Prop_Preg2 { get; set; }
        public string Prop_Preg3 { get; set; }
        public string Prop_Resp1 { get; set; }
        public string Prop_Resp2 { get; set; }
        public string Prop_Resp3 { get; set; }
        public int Prop_VtoPass { get; set; }
        public bool Prop_NuevaPass{ get; set; }
        public bool Prop_CambioPass { get; set; }
        public DateTime Prop_FeCambioPass { get; set; }
        public string Prop_Comentarios { get; set; }

        #endregion

        public bool Logear()
        {
            string sSql = "SP_Login";

            SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 20);
            param_UserName.Value = atr_NombreUsuarioLogin;
            SqlParameter param_Encriptacion = new SqlParameter("@PassEncriptada", SqlDbType.VarChar, 500);
            param_Encriptacion.Value = atr_EncriptacionLogin;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_UserName);
            listaParametros.Add(param_Encriptacion);
            lista = listaParametros.ToArray();
            DataTable resultado = ejecutar(sSql, lista, true);

            if (resultado.Rows.Count > 0)
            {
                CSesion_SesionIniciada.CacheSesion(resultado);
                listaParametros.Clear();
                string sSql2 = "SP_Obtener_Permisos_Usuario";
                SqlParameter UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 20);
                UserName.Value = atr_NombreUsuarioLogin;
                listaParametros.Add(UserName);                
                lista = listaParametros.ToArray();
                DataTable permisos = ejecutar(sSql2, lista, true);
                CSesion_SesionIniciada.CachePermisos(permisos);
                
                return true;
            }
            else
            {
                return false;                
            }
        }
        public DataTable ObtenerEstadoCmb()
        {
            try
            {
                string sSql = "SP_Obtener_Estado_ComboBox";
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                SqlParameter[] parametros = listaparametros.ToArray();

                return ejecutar(sSql, parametros, true);

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Cliente||ObtenerEstadoCmb");
            }
        }
        public DataTable ObtenerVencimientosPass()
        {
            try
            {
                string sSql = "SP_Obtener_VtodePass";
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                SqlParameter[] parametros = listaparametros.ToArray();

                return ejecutar(sSql, parametros, true);

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Cliente||ObtenerVencimientosPass");
            }
        }
        public void BloqueoUsuario()
        {
            try
            {
                string Sql = "SP_Bloqueo_Usuario";
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 20);
                param_UserName.Value = atr_NombreUsuarioLogin;
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_UserName);
                lista = listaParametros.ToArray();
                DataTable DT = ejecutar(Sql, lista, true);
                
                if (DT.Rows.Count >= CSistema_ConfiguracionSistema.CantIntentosFallidos)
                {
                    throw new Exception("Usuario bloqueado");
                }
                else if(DT.Rows.Count > 0)
                {
                    throw new Exception("Contraseña incorrecta. Recuerde que tiene unicamente 3 intentos o puede ser bloqueado");
                }
                else
                {
                    throw new Exception("Usuario inexistente. Por favor, intente nuevamente");
                }

                

            }
            catch (Exception)
            {

                throw;
            }

        }
        public void EliminarUsuario(int ID_Persona) 
        {
            try
            {
                string sSql = "SP_Eliminar_Usuario";
                SqlParameter param_ID_Persona = new SqlParameter("@ID_Persona", SqlDbType.Int);
                param_ID_Persona.Value = ID_Persona; 
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param_UserName.Value = CSesion_SesionIniciada.UserName;
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_ID_Persona);
                listaParametros.Add(param_UserName);
                lista = listaParametros.ToArray();
                ejecutar(sSql, lista, false);
            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Personas||EliminarUsuario");
            }
        }
        public DataTable BuscarUser()
        {
            try
            {
                string sSql = "SP_Buscar_Usuario";
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 20);
                param_UserName.Value = Prop_UserName;
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_UserName);
                lista = listaParametros.ToArray();
                DataTable Dt = ejecutar(sSql, lista, true);
                CSesion_PreguntasUsuarios.CachePreguntas(Dt);
                return Dt;

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Usuarios||Logear.");
            }

        }
        public DataTable Familia()
        {
            try
            {
                string sSql = "SP_Obtener_Familias_ComboBox";
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                SqlParameter[] parametros = listaparametros.ToArray();

                return ejecutar(sSql, parametros, true);

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Personas||Familia");
            }
        }
        public DataTable ObtenerPreguntasAleatorias()
        {

            string sSql = "SP_Obtener_Preguntas_Aleatorias";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter[] parametros = listaParametros.ToArray();

            try
            {
                return ejecutar(sSql, parametros, true);
            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Usuarios||Logear");
            }
        }
        public bool CargarUsuarios(int ID_Persona)
        {
            DataTable Dt = new DataTable();
            try
            {
                string sSql = "SP_Cache_Usuarios";
                SqlParameter param_ID_Usuario = new SqlParameter("@ID_Persona", SqlDbType.Int);
                param_ID_Usuario.Value = ID_Persona;
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                listaparametros.Add(param_ID_Usuario);
                SqlParameter[] parametros = listaparametros.ToArray();

                Dt = ejecutar(sSql, parametros, true);
                if (Dt.Rows.Count > 1)
                {
                    CSesion_PersonaSeleccionada.ActualizaFormularioUsuarios(Dt);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Personas||CargarUsuarios.");
            }
        }
        public bool CambiarPass()
        {
            string sSql = "SP_Actualizar_Pass";

            SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 20);
            param_UserName.Value = Prop_UserName;           
            SqlParameter param_Encriptacion = new SqlParameter("@PassEncriptada", SqlDbType.VarChar, 500);
            param_Encriptacion.Value = Prop_Encriptacion;
            SqlParameter param_NuevaPass = new SqlParameter("@NuevaPass", SqlDbType.Bit);
            param_NuevaPass.Value = Prop_NuevaPass;
            SqlParameter param_FeCambioPass = new SqlParameter("@Fe_CambioPass", SqlDbType.DateTime);
            param_FeCambioPass.Value = Prop_FeCambioPass;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_UserName);            
            listaParametros.Add(param_Encriptacion);
            listaParametros.Add(param_NuevaPass);
            listaParametros.Add(param_FeCambioPass);
            lista = listaParametros.ToArray();
            DataTable resultado = ejecutar(sSql, lista, true);

            if (resultado.Rows.Count > 0)
            {
                if (CSesion_SesionIniciada.NuevaPass == true)
                {
                    CSesion_SesionIniciada.CacheSesion(resultado);
                }
                return true;
            }
            else
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Usuarios||CambiarPass");
            }

        }
        public bool RepitePass() 
        {
            string sSql = "SP_Consulta_RepitePass";
            SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 20);
            param_UserName.Value = Prop_UserName;
            SqlParameter param_Pass = new SqlParameter("@UserPass", SqlDbType.VarChar, 200);
            param_Pass.Value = Prop_Contrasena;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_UserName);
            listaParametros.Add(param_Pass);
            lista = listaParametros.ToArray();
            DataTable Dt = ejecutar(sSql, lista, true);
            if (Dt.Rows.Count >0)
            {
                return true;
            }
            else return false;
        }
        public void Insertar()
        {
            try
            {
                string sSql = "SP_Insertar_Usuario";

                SqlParameter param_UsuarioEjecutor = new SqlParameter("@UsuarioEjecutor", SqlDbType.VarChar, 50);
                param_UsuarioEjecutor.Value = CSesion_SesionIniciada.UserName;
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param_UserName.Value = Prop_UserName;
                SqlParameter param_ID_Persona = new SqlParameter("@ID_Persona", SqlDbType.Int);
                param_ID_Persona.Value = ID_Persona;               
                SqlParameter param_PassEncriptada = new SqlParameter("@PassEncriptada", SqlDbType.VarChar, 500);
                param_PassEncriptada.Value = Prop_Encriptacion;
                SqlParameter param_FeAlta = new SqlParameter("@FeAlta", SqlDbType.DateTime);
                param_FeAlta.Value = Prop_FeAlta;
                SqlParameter param_Familia = new SqlParameter("@Familia", SqlDbType.Int);
                param_Familia.Value = Prop_Familia;
                SqlParameter param_Comentarios = new SqlParameter("@Comentarios", SqlDbType.VarChar, 200);
                param_Comentarios.Value = Prop_Comentarios;
                //Agregar Comentarios al insertar un usuario
                SqlParameter param_Estado = new SqlParameter("@EstadoCuenta", SqlDbType.Int);
                param_Estado.Value = Prop_Estado;
                SqlParameter param_VtoPass = new SqlParameter("@VenceCada", SqlDbType.Int);
                param_VtoPass.Value = Prop_VtoPass;
                SqlParameter param_NuevaPass = new SqlParameter("@NuevaPass", SqlDbType.Bit);
                param_NuevaPass.Value = Prop_NuevaPass;
                SqlParameter param_CambioPass = new SqlParameter("@CambioPass", SqlDbType.Bit);
                param_CambioPass.Value = Prop_CambioPass;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_UserName); listaParametros.Add(param_UsuarioEjecutor);
                listaParametros.Add(param_ID_Persona);
                listaParametros.Add(param_PassEncriptada);
                listaParametros.Add(param_FeAlta);
                listaParametros.Add(param_Familia);
                listaParametros.Add(param_Comentarios);
                listaParametros.Add(param_Estado);
                listaParametros.Add(param_VtoPass);
                listaParametros.Add(param_NuevaPass);
                listaParametros.Add(param_CambioPass);

                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);     

            }
            catch (Exception)
            {

                throw new Exception ("No se ha podido realizar la operación. Error CD_Usuarios||Insertar.");
            }
            try
            {
                string sSql = "SP_Asignar_Roles_A_Usuario_Por_Familia";

                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param_UserName.Value = Prop_UserName;
                SqlParameter param_Familia = new SqlParameter("@ID_Familia", SqlDbType.Int);
                param_Familia.Value = Prop_Familia;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_UserName);
                listaParametros.Add(param_Familia);

                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Usuarios||Insertar.");
            }
        }

        public int ReestablecerUsuario()
        {
            try
            {
                string sSql = "SP_Reestablecer_Usuario";
                SqlParameter param_ID_Usuario = new SqlParameter("@ID_Persona", SqlDbType.Int);
                param_ID_Usuario.Value = ID_Persona;
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param_UserName.Value = Prop_UserName;
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                listaparametros.Clear();
                listaparametros.Add(param_ID_Usuario);
                listaparametros.Add(param_UserName);
                SqlParameter[] parametros = listaparametros.ToArray();

                DataTable Dt = ejecutar(sSql, parametros, true);
                if (Dt.Rows.Count > 0)
                {
                    return ID_Persona = Convert.ToInt32(Dt.Rows[0]["ID_Persona"]);
                   // ID_Persona;
                }
                else
                {
                    return ID_Persona;
                }

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Personas||ComprobarUsuario.");

            }
        }
        public bool ComprobarUsuario()
        {
            try
            {
                string sSql = "SP_Comprobar_Si_Existe_Usuario";
                SqlParameter param_ID_Usuario = new SqlParameter("@ID_Persona", SqlDbType.Int);
                param_ID_Usuario.Value = ID_Persona;
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param_UserName.Value = Prop_UserName;
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                listaparametros.Add(param_ID_Usuario);
                listaparametros.Add(param_UserName);
                SqlParameter[] parametros = listaparametros.ToArray();

                DataTable Dt = ejecutar(sSql, parametros, true);
                if (Dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Personas||ComprobarUsuario.");
            }

        }
        public void ActualizarUsuario() {
            try
            {
                string sSql = "SP_Modificar_Usuario";
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param_UserName.Value = CSesion_SesionIniciada.UserName;
                SqlParameter param_ID_Persona = new SqlParameter("@ID_Persona", SqlDbType.Int);
                param_ID_Persona.Value = ID_Persona;
                SqlParameter param_FeAlta = new SqlParameter("@FeAlta", SqlDbType.DateTime);
                param_FeAlta.Value = Prop_FeAlta;
                SqlParameter param_Familia = new SqlParameter("@Familia", SqlDbType.Int);
                param_Familia.Value = Prop_Familia;
                SqlParameter param_Comentarios = new SqlParameter("@Comentarios", SqlDbType.VarChar, 200);
                param_Comentarios.Value = Prop_Comentarios;
                SqlParameter param_VtoPass = new SqlParameter("@VenceCada", SqlDbType.Int);
                param_VtoPass.Value = Prop_VtoPass;
                SqlParameter param_Estado = new SqlParameter("@EstadoCuenta", SqlDbType.Int);
                param_Estado.Value = Prop_Estado;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_UserName);
                listaParametros.Add(param_ID_Persona);
                listaParametros.Add(param_Familia);
                listaParametros.Add(param_Estado);
                listaParametros.Add(param_Comentarios);
                listaParametros.Add(param_FeAlta);
                listaParametros.Add(param_VtoPass);  

                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Usuarios||Insertar.");
            }
        }
        public void InsertarRespuestas()
        {
            try
            {
                string sSql = "SP_Insertar_Respuestas";
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 20);
                param_UserName.Value = Prop_UserName;
                SqlParameter param_Preg1 = new SqlParameter("@Pregunta1", SqlDbType.VarChar, 100);
                param_Preg1.Value = Prop_Preg1;
                SqlParameter param_Resp1 = new SqlParameter("@Respuesta1", SqlDbType.VarChar, 100);
                param_Resp1.Value = Prop_Resp1;
                SqlParameter param_Preg2 = new SqlParameter("@Pregunta2", SqlDbType.VarChar, 100);
                param_Preg2.Value = Prop_Preg2;
                SqlParameter param_Resp2 = new SqlParameter("@Respuesta2", SqlDbType.VarChar, 100);
                param_Resp2.Value = Prop_Resp2;
                SqlParameter param_Preg3 = new SqlParameter("@Pregunta3", SqlDbType.VarChar, 100);
                param_Preg3.Value = Prop_Preg3;
                SqlParameter param_Resp3 = new SqlParameter("@Respuesta3", SqlDbType.VarChar, 100);
                param_Resp3.Value = Prop_Resp3;


                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_UserName);
                listaParametros.Add(param_Preg1);
                listaParametros.Add(param_Resp1);
                listaParametros.Add(param_Preg2);
                listaParametros.Add(param_Resp2);
                listaParametros.Add(param_Preg3);
                listaParametros.Add(param_Resp3);

                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);


            }
            catch (Exception)
            {

                throw new Exception ("No se ha podido realizar la operación. Error CD_Usuarios||InsertarRespuesta.");
            }        
        }
    }
}
