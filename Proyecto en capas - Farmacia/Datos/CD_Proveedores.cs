using Sesion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_Proveedores : CD_EjecutarSP
    {
        #region Properties
        public int ID_Proveedor { get; set; }
        public string RazonSocial { get; set; }
        public long CUIT { get; set; }
        public int Matricula { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string Partido { get; set; } 
        public string Localidad { get; set; } 
        public string Mail { get; set; }
        public string IVA { get; set; }
        public bool IIBB { get; set; }
        SqlParameter[] lista = null;
        #endregion

        public DataTable MostrarProveedores()
        {
            string sSql = "SP_Obtener_Proveedores";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter[] parametros = listaParametros.ToArray();
            DataTable dt = new DataTable();
            try
            {
                dt = ejecutar(sSql, parametros, true);

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Productos||MostrarProveedores.");
            }
            return dt;
        }
        public DataTable MostrarIVA()
        {

            string sSql = "SP_Obtener_CondicionIVA";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter[] parametros = listaParametros.ToArray();
            DataTable dt = new DataTable();
            try
            {
                dt = ejecutar(sSql, parametros, true);

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Productos||MostrarIVA.");
            }
            return dt;
        }
        public DataTable Buscar()
        {
            string sSql = "SP_Buscar_Proveedores";
            SqlParameter param_RazonSocial = new SqlParameter("@RazonSocial", SqlDbType.VarChar, 200);
            param_RazonSocial.Value = RazonSocial;
            SqlParameter param_CUIT = new SqlParameter("@CUIT", SqlDbType.VarChar, 13);
            param_CUIT.Value = CUIT;
            SqlParameter param_Matricula = new SqlParameter("@Matricula", SqlDbType.Int);
            param_Matricula.Value = Matricula;
            SqlParameter param_Telefono = new SqlParameter("@Telefono", SqlDbType.Int);
            param_Telefono.Value = Telefono;
            SqlParameter param_Direccion = new SqlParameter("@Direccion", SqlDbType.VarChar, 200);
            param_Direccion.Value = Direccion;
            SqlParameter param_ID_Partido = new SqlParameter("@Partido", SqlDbType.VarChar, 200);
            param_ID_Partido.Value = Partido;
            SqlParameter param_Localidad = new SqlParameter("@Localidad", SqlDbType.VarChar, 200);
            param_Localidad.Value = Localidad;
            SqlParameter param_Mail = new SqlParameter("@Mail", SqlDbType.VarChar, 200);
            param_Mail.Value = Mail;
            SqlParameter param_IVA = new SqlParameter("@IVA", SqlDbType.VarChar, 200);
            param_IVA.Value = IVA;
            SqlParameter param_IIBB = new SqlParameter("@IIBB", SqlDbType.Bit);
            param_IIBB.Value = IIBB;

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_RazonSocial);
            listaParametros.Add(param_CUIT);
            listaParametros.Add(param_Matricula);
            listaParametros.Add(param_Telefono);
            listaParametros.Add(param_Direccion);
            listaParametros.Add(param_Mail);
            listaParametros.Add(param_ID_Partido);
            listaParametros.Add(param_Localidad);
            listaParametros.Add(param_IVA);
            listaParametros.Add(param_IIBB);
            lista = listaParametros.ToArray();
            DataTable dt = new DataTable();
            try
            {
                dt = ejecutar(sSql, lista, true);

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Productos||MostrarProveedores.");
            }
            return dt;
        }
        public void Insertar()
        {
            try
            {
                string sSql = "SP_Insertar_Proveedor";
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param_UserName.Value = CSesion_SesionIniciada.UserName;
                SqlParameter param_RazonSocial = new SqlParameter("@RazonSocial", SqlDbType.VarChar, 200);
                param_RazonSocial.Value = RazonSocial;
                SqlParameter param_CUIT = new SqlParameter("@CUIT", SqlDbType.VarChar, 13);
                param_CUIT.Value = CUIT;
                SqlParameter param_Matricula = new SqlParameter("@Matricula", SqlDbType.Int);
                param_Matricula.Value = Matricula;
                SqlParameter param_Telefono = new SqlParameter("@Telefono", SqlDbType.Int);
                param_Telefono.Value = Telefono;
                SqlParameter param_Direccion = new SqlParameter("@Direccion", SqlDbType.VarChar, 200);
                param_Direccion.Value = Direccion;
                SqlParameter param_Partido = new SqlParameter("@Partido", SqlDbType.VarChar, 200);
                param_Partido.Value = Partido;
                SqlParameter param_Localidad = new SqlParameter("@Localidad", SqlDbType.VarChar, 200);
                param_Localidad.Value = Localidad;
                SqlParameter param_Mail = new SqlParameter("@Mail", SqlDbType.VarChar,200);
                param_Mail.Value = Mail;
                SqlParameter param_IVA = new SqlParameter("@IVA", SqlDbType.VarChar, 200);
                param_IVA.Value = IVA;
                SqlParameter param_IIBB = new SqlParameter("@IIBB", SqlDbType.Bit);
                param_IIBB.Value = IIBB;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_UserName);
                listaParametros.Add(param_RazonSocial);
                listaParametros.Add(param_CUIT);
                listaParametros.Add(param_Matricula);
                listaParametros.Add(param_Telefono);
                listaParametros.Add(param_Direccion);
                listaParametros.Add(param_Mail);
                listaParametros.Add(param_Partido);
                listaParametros.Add(param_Localidad);
                listaParametros.Add(param_IVA);
                listaParametros.Add(param_IIBB);
                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Proveedores||Insertar.");
            }
        }
        public void GuardarCambios()
        {
            try
            {
                string sSql = "SP_Actualizar_Proveedor";
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param_UserName.Value = CSesion_SesionIniciada.UserName;

                SqlParameter param_ID_Proveedor = new SqlParameter("@ID_Proveedor", SqlDbType.Int);
                param_ID_Proveedor.Value = ID_Proveedor;
                SqlParameter param_RazonSocial = new SqlParameter("@RazonSocial", SqlDbType.VarChar, 200);
                param_RazonSocial.Value = RazonSocial;
                SqlParameter param_CUIT = new SqlParameter("@CUIT", SqlDbType.VarChar, 13);
                param_CUIT.Value = CUIT;
                SqlParameter param_Matricula = new SqlParameter("@Matricula", SqlDbType.Int);
                param_Matricula.Value = Matricula;
                SqlParameter param_Telefono = new SqlParameter("@Telefono", SqlDbType.Int);
                param_Telefono.Value = Telefono;
                SqlParameter param_Direccion = new SqlParameter("@Direccion", SqlDbType.VarChar, 200);
                param_Direccion.Value = Direccion;
                SqlParameter param_Partido = new SqlParameter("@Partido", SqlDbType.VarChar, 200);
                param_Partido.Value = Partido;
                SqlParameter param_Localidad = new SqlParameter("@Localidad", SqlDbType.VarChar, 200);
                param_Localidad.Value = Localidad;
                SqlParameter param_Mail = new SqlParameter("@Mail", SqlDbType.VarChar, 200);
                param_Mail.Value = Mail;
                SqlParameter param_IVA = new SqlParameter("@IVA", SqlDbType.VarChar, 200);
                param_IVA.Value = IVA;
                SqlParameter param_IIBB = new SqlParameter("@IIBB", SqlDbType.Bit);
                param_IIBB.Value = IIBB;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_UserName);
                listaParametros.Add(param_ID_Proveedor);
                listaParametros.Add(param_RazonSocial);
                listaParametros.Add(param_CUIT);
                listaParametros.Add(param_Matricula);
                listaParametros.Add(param_Telefono);
                listaParametros.Add(param_Direccion);
                listaParametros.Add(param_Mail);
                listaParametros.Add(param_Partido);
                listaParametros.Add(param_Localidad);
                listaParametros.Add(param_IVA);
                listaParametros.Add(param_IIBB);
                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Proveedores||GuardarCambios.");
            }
        }
        public void Eliminar() 
        {
            try
            {
                string sSql = "SP_Eliminar_Proveedor";
                SqlParameter param_ID_Proveedor = new SqlParameter("@ID_Proveedor", SqlDbType.Int);
                param_ID_Proveedor.Value = ID_Proveedor;
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param_UserName.Value = CSesion_SesionIniciada.UserName;


                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_ID_Proveedor);
                listaParametros.Add(param_UserName);
                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Proveedores||Eliminar.");
            }
        }

    }
}
