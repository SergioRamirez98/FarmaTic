﻿using Sesion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_Personas:CD_EjecutarSP
    {
        #region Atributos
        private string atr_nombre;
        private string atr_apellido;
        private int atr_dni;
        private string atr_correo;
        private string atr_sexo;
        private string atr_domicilio;
        private string atr_localidad;
        private string atr_nacionalidad;
        private int atr_telefono;
        private DateTime atr_nacimiento;
        private string atr_comentarios;
        SqlParameter [] lista = null;


        #endregion

        #region Properties
        public string Prop_NOMBRE
        { get => atr_nombre; set { atr_nombre = value; } }
        public string Prop_APELLIDO
        { get => atr_apellido; set { atr_apellido = value; } }
        public int Prop_DNI
        { get => atr_dni; set { atr_dni = value; } }
        public string Prop_CORREO
        { get => atr_correo; set { atr_correo = value; } }
        public string Prop_SEXO
        { get => atr_sexo; set { atr_sexo = value; } }
        public string Prop_DOMICILIO
        { get => atr_domicilio; set { atr_domicilio = value; } }
        public string Prop_LOCALIDAD
        { get => atr_localidad; set { atr_localidad = value; } }
        public string Prop_NACIONALIDAD
        { get => atr_nacionalidad; set { atr_nacionalidad = value; } }
        public int Prop_TELEFONO
        { get => atr_telefono; set { atr_telefono = value; } }
        public DateTime Prop_NACIMIENTO
        { get => atr_nacimiento; set { atr_nacimiento = value; } }
        public string Prop_COMENTARIOS
        { get => atr_comentarios; set { atr_comentarios = value; } }
        #endregion       
        public DataTable Insertar()
        {
            try
            {
                string sSql = "SP_Insertar_Persona";

                SqlParameter param_nombre = new SqlParameter("@Nombre", SqlDbType.VarChar, 50);
                param_nombre.Value = atr_nombre;
                SqlParameter param_apellido = new SqlParameter("@Apellido", SqlDbType.VarChar, 50);
                param_apellido.Value = atr_apellido;
                SqlParameter param_direccion = new SqlParameter("@Direccion", SqlDbType.VarChar, 50);
                param_direccion.Value = atr_domicilio;
                SqlParameter param_mail = new SqlParameter("@Mail", SqlDbType.VarChar, 50);
                param_mail.Value = atr_correo;
                SqlParameter param_documento = new SqlParameter("@Documento", SqlDbType.VarChar, 50);
                param_documento.Value = atr_dni;
                SqlParameter param_sexo = new SqlParameter("@Sexo", SqlDbType.VarChar, 50);
                param_sexo.Value = atr_sexo;
                SqlParameter param_telefono = new SqlParameter("@Telefono", SqlDbType.Int);
                param_telefono.Value = atr_telefono;
                SqlParameter param_Nacimiento = new SqlParameter("@FeNacimiento", SqlDbType.DateTime);
                param_Nacimiento.Value = atr_nacimiento;
                SqlParameter param_localidad = new SqlParameter("@Localidad", SqlDbType.VarChar, 50);
                param_localidad.Value = atr_localidad;
                SqlParameter param_Nacionalidad = new SqlParameter("@Pais", SqlDbType.VarChar, 50);
                param_Nacionalidad.Value = atr_nacionalidad;
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_nombre);
                listaParametros.Add(param_apellido);
                listaParametros.Add(param_direccion);
                listaParametros.Add(param_mail);
                listaParametros.Add(param_documento);
                listaParametros.Add(param_sexo);
                listaParametros.Add(param_telefono);
                listaParametros.Add(param_Nacimiento);
                listaParametros.Add(param_localidad);
                listaParametros.Add(param_Nacionalidad);

                lista = listaParametros.ToArray();

                return ejecutar(sSql, lista, true);

            }
            catch (Exception)
            {

                throw new Exception ("No se ha podido realizar la operación. Error CD_Personas||Insertar");
            }
        }
        public DataTable Localidad()
        {

            string sSql = "SP_Obtener_Localidades";
            try
            {
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                SqlParameter[] parametros = listaparametros.ToArray();
                return ejecutar(sSql, parametros, true);

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Personas||Localidad.");
            }
        }
        public DataTable Pais()
        {
            string sSql = "SP_Obtener_Paises";
            try
            {
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                SqlParameter[] parametros = listaparametros.ToArray();

                return ejecutar(sSql, parametros, true);

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Personas||Pais.");
            }
        }
        public DataTable CargarPersonas(int ID_Persona)
        {
            DataTable Dt = new DataTable();
            try
            {
                string sSql = "SP_Cache_Personas";
                SqlParameter param_ID_Usuario = new SqlParameter("@ID_Persona", SqlDbType.Int);
                param_ID_Usuario.Value = ID_Persona;
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                listaparametros.Add(param_ID_Usuario);
                SqlParameter[] parametros = listaparametros.ToArray();

                Dt= ejecutar(sSql, parametros, true);
                CSesion_PersonaSeleccionada.ActualizaFormularioPersonas(Dt);

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Personas||CargarPersonas.");
            }
            return Dt;
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
                CSesion_PersonaSeleccionada.ActualizaFormularioUsuarios(Dt);
                if (Dt.Rows.Count>1)
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
                throw new Exception("No se ha podido realizar la operación. Error CD_Personas||CargarUsuarios.");
            }            
        }
        public bool CargarClientes(int ID_Persona)
        {
            DataTable Dt = new DataTable();
            try
            {
                string sSql = "SP_Cache_Clientes";
                SqlParameter param_ID_Usuario = new SqlParameter("@ID_Persona", SqlDbType.Int);
                param_ID_Usuario.Value = ID_Persona;
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                listaparametros.Add(param_ID_Usuario);
                SqlParameter[] parametros = listaparametros.ToArray();

                Dt = ejecutar(sSql, parametros, true);
                if (Dt.Rows.Count > 0)
                {
                    CSesion_PersonaSeleccionada.ActualizaFormularioClientes(Dt);
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
        public DataTable ObtenerPersonaCmb()
        {
            string sSql = "SP_Obtener_Personas_ComboBox";

            try
            {
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                SqlParameter[] parametros = listaparametros.ToArray();

                return ejecutar(sSql, parametros, true);

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Personas||ObtenerPersonaCmb");
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
    }
}
