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
        public int Cantidad { get; set; }
        public double PrecUnitario { get; set; }
        public double Subtotal { get; set; }
        public DateTime FechaVenta { get; set; }
        public double TotalVenta { get; set; }
        public List <CD_Ventas> items { get; set; }

        SqlParameter[] lista = null;

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
            string sSql = "SP_Insertar_Venta";
            SqlParameter param_ID_Usuario = new SqlParameter("@ID_Usuario", SqlDbType.Int);
            param_ID_Usuario.Value = ID_UsuarioVendedor;
            SqlParameter param_ID_Cliente = new SqlParameter("@ID_Cliente", SqlDbType.Int);
            param_ID_Cliente.Value = ID_Cliente;
            SqlParameter param_Fe_Venta = new SqlParameter("@Fe_Venta", SqlDbType.DateTime);
            param_Fe_Venta.Value = FechaVenta;
            SqlParameter param_TotalVenta = new SqlParameter("@Total", SqlDbType.Decimal);
            param_TotalVenta.Value = TotalVenta;

            SqlParameter param_ID_Producto = new SqlParameter("@ID_Producto", SqlDbType.Int);
            param_ID_Producto.Value = ID_Producto;
            SqlParameter param_PrecUnitario = new SqlParameter("@PrecioUnitario", SqlDbType.Decimal);
            param_PrecUnitario.Value = PrecUnitario;
            SqlParameter param_Cantidad = new SqlParameter("@Cantidad", SqlDbType.Int);
            param_Cantidad.Value = Cantidad;
            SqlParameter param_Subtotal = new SqlParameter("@Subtotal", SqlDbType.Decimal);
            param_Subtotal.Value = Subtotal;

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_ID_Usuario);
            listaParametros.Add(param_ID_Cliente);
            listaParametros.Add(param_Fe_Venta);
            listaParametros.Add(param_TotalVenta);

            listaParametros.Add(param_ID_Producto);
            listaParametros.Add(param_PrecUnitario);
            listaParametros.Add(param_Cantidad);
            listaParametros.Add(param_Subtotal);

            lista = listaParametros.ToArray();

            try
            {
                ejecutar(sSql, lista, true);
            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Ventas||CargarClientes");
            }
        }
    }
}
