﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sesion;
using System.Data.SqlTypes;

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
        public string Prop_Familia { get; set; }
        public string Prop_Estado { get; set; }
        public string Prop_Preg1 { get; set; }
        public string Prop_Preg2 { get; set; }
        public string Prop_Preg3 { get; set; }
        public string Prop_Resp1 { get; set; }
        public string Prop_Resp2 { get; set; }
        public string Prop_Resp3 { get; set; }
        public int Prop_VtoPass { get; set; }
        public bool Prop_NuevaPass{ get; set; }
        public bool Prop_CambioPass { get; set; }
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
                return true;
            }
            else
            {
                throw new Exception("Error en la base de datos");
            }
        }
        public DataTable BuscarUser()
        {
            string sSql = "SP_Buscar_Usuario";
            SqlParameter param_UserName = new SqlParameter ("@UserName", SqlDbType.VarChar, 20);
            param_UserName.Value = Prop_UserName;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_UserName);
            lista = listaParametros.ToArray();
            DataTable Dt = ejecutar(sSql, lista, true);
            /* DataTable Dt= ejecutar(sSql, parametros, true);*/
            CSesion_PreguntasUsuarios.CachePreguntas(Dt);
            return Dt;

        }
        public DataTable ObtenerPreguntasAleatorias()
        {

            string sSql = "SP_Obtener_Preguntas";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter[] parametros = listaParametros.ToArray();

            try
            {
                return ejecutar(sSql, parametros, true);
            }
            catch (Exception)
            {

                throw new Exception("Usuario no encontrado, por favor ingrese nuevamente");
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
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_UserName);            
            listaParametros.Add(param_Encriptacion);
            listaParametros.Add(param_NuevaPass);
            lista = listaParametros.ToArray();
            DataTable resultado = ejecutar(sSql, lista, true);

            if (resultado.Rows.Count > 0)
            {
                CSesion_SesionIniciada.CacheSesion(resultado);
                return true;
            }
            else
            {
                throw new Exception("Error en la base de datos");
            }

        }
        public void Insertar()
        {
            try
            {
                string sSql = "SP_Insertar_Usuario";
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 20);
                param_UserName.Value = Prop_UserName;
                SqlParameter param_ID_Persona = new SqlParameter("@ID_Persona", SqlDbType.Int);
                param_ID_Persona.Value = ID_Persona;               
                SqlParameter param_PassEncriptada = new SqlParameter("@PassEncriptada", SqlDbType.VarChar, 500);
                param_PassEncriptada.Value = Prop_Encriptacion;
                SqlParameter param_FeAlta = new SqlParameter("@FeAlta", SqlDbType.DateTime);
                param_FeAlta.Value = Prop_FeAlta;
                SqlParameter param_Familia = new SqlParameter("@Familia", SqlDbType.VarChar, 50);
                param_Familia.Value = Prop_Familia;
                SqlParameter param_Estado = new SqlParameter("@EstadoCuenta", SqlDbType.VarChar, 50);
                param_Estado.Value = Prop_Estado;
                SqlParameter param_VtoPass = new SqlParameter("@VenceCada", SqlDbType.Int);
                param_VtoPass.Value = Prop_VtoPass;
                SqlParameter param_NuevaPass = new SqlParameter("@NuevaPass", SqlDbType.Bit);
                param_NuevaPass.Value = Prop_NuevaPass;
                SqlParameter param_CambioPass = new SqlParameter("@CambioPass", SqlDbType.Bit);
                param_CambioPass.Value = Prop_CambioPass;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_UserName);
                listaParametros.Add(param_ID_Persona);
                listaParametros.Add(param_PassEncriptada);
                listaParametros.Add(param_FeAlta);
                listaParametros.Add(param_Familia);
                listaParametros.Add(param_Estado);
                listaParametros.Add(param_VtoPass);
                listaParametros.Add(param_NuevaPass);
                listaParametros.Add(param_CambioPass);

                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);               

            }
            catch (Exception)
            {

                throw new Exception ("Error al comprobar los datos en la base de datos.");
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

                throw new Exception ("No se han podido guardar las preguntas.");
            }        
        }
    }
}
