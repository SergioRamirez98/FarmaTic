using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_Ventas: CD_EjecutarSP
    {
        #region Properties
        public int ID_UsuarioVendedor { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Producto { get; set; }
        public string NombreProducto { get; set; }
        public string Marca { get; set; }
        public int Cantidad { get; set; }
        public double PrecUnitario { get; set; }
        public double Subtotal { get; set; }
        public DateTime FechaVenta { get; set; }
        public int NumeroLote { get; set; }
        public double TotalVenta { get; set; }

        #endregion

        public DataTable CargarClientes()
        {

            string sSql = "SP_Obtener_Clientes";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter[] parametros = listaParametros.ToArray();

            try
            {
                return ejecutar(sSql, parametros, true);
            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Ventas||CargarClientes");
            }
        }
        public void InsertarVenta()
        {
            string sSql = "SP_Obtener_Clientes";/*
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
            listaParametros.Add(param_FeCambioPass);*/
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter[] parametros = listaParametros.ToArray();

            try
            {
                ejecutar(sSql, parametros, true);
            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Ventas||CargarClientes");
            }
        }
    }
}
