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
    public class CD_ConsultaVentas:CD_EjecutarSP
    {
        #region Properties 
        public string Cliente { get; set; }
        public double PrecDesde { get; set; }
        public double PrecHasta { get; set; }
        public DateTime FeDesde { get; set; }
        public DateTime FeHasta { get; set; }
        SqlParameter[] lista = null;

        #endregion

        public DataTable RealizarConsulta()
        {
            string sSql = "SP_Consulta_Venta_General";

            SqlParameter param_Cliente = new SqlParameter("@Cliente", SqlDbType.VarChar, 200);
            param_Cliente.Value = Cliente;
            SqlParameter param_PrecDesde = new SqlParameter("@PrecDesde", SqlDbType.Decimal);
            param_PrecDesde.Value = PrecDesde;
            SqlParameter param_PrecHasta = new SqlParameter("@PrecHasta", SqlDbType.Decimal);
            param_PrecHasta.Value = PrecHasta;
            SqlParameter param_FeDesde = new SqlParameter("@FeDesde", SqlDbType.DateTime);
            param_FeDesde.Value = FeDesde;
            SqlParameter param_FechaHasta = new SqlParameter("@FeHasta", SqlDbType.DateTime);
            param_FechaHasta.Value = FeHasta;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_Cliente);
            listaParametros.Add(param_PrecDesde);
            listaParametros.Add(param_PrecHasta);
            listaParametros.Add(param_FeDesde);
            listaParametros.Add(param_FechaHasta);
            lista = listaParametros.ToArray();

            try
            {
                DataTable dt = ejecutar(sSql, lista, true);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else throw new Exception("No se ha encontrado ningun registro con los filtros solicitados");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public DataTable VerVentaPorItems(int ID_Venta) 
        {
            string sSql = "SP_Consulta_Venta_Items";

            SqlParameter param_ID_Venta = new SqlParameter("@ID_Venta", SqlDbType.Int);
            param_ID_Venta.Value = ID_Venta;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_ID_Venta);
            lista = listaParametros.ToArray();

            try
            {
                DataTable dt = ejecutar(sSql, lista, true);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else throw new Exception("No se ha encontrado ningun registro con los filtros solicitados");
            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_ConsultaVentas||VerVentaItems");
            }
        }
        public void EliminarVenta(int ID_Venta)
        {
            string sSql = "SP_Eliminar_Venta";
            SqlParameter param_ID_Venta = new SqlParameter("@ID_Venta", SqlDbType.Int);
            param_ID_Venta.Value = ID_Venta;
            SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
            param_UserName.Value = CSesion_SesionIniciada.UserName;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_ID_Venta);
            listaParametros.Add(param_UserName);
            lista = listaParametros.ToArray();
            try
            {
                ejecutar(sSql, lista, false);
            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_ConsultaVentas||VerVentaItems");
            }

        }
    }
}
