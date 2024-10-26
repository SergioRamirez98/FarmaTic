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
    public class CD_Ventas : CD_EjecutarSP
    {
        #region Properties
        public int ID_UsuarioVendedor { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Producto { get; set; }
        public int Cantidad { get; set; }
        public int ID_Venta { get; set; }
        public decimal PrecUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal Descuento { get; set; }
        public decimal TotalconDescuento { get; set; }

        public List<CD_Ventas> Items = new List<CD_Ventas>();

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
        public int InsertarVenta()
        {
            int Venta=0;
            string sSql = "SP_Insertar_Venta";
            SqlParameter param_ID_Usuario = new SqlParameter("@ID_Usuario", SqlDbType.Int);
            param_ID_Usuario.Value = ID_UsuarioVendedor;
            SqlParameter param_ID_Cliente = new SqlParameter("@ID_Cliente", SqlDbType.Int);
            param_ID_Cliente.Value = ID_Cliente;
            SqlParameter param_Fe_Venta = new SqlParameter("@Fe_Venta", SqlDbType.DateTime);
            param_Fe_Venta.Value = FechaVenta;
            SqlParameter param_TotalVenta = new SqlParameter("@Total", SqlDbType.Decimal);
            param_TotalVenta.Value = TotalVenta;
            SqlParameter param_Descuento = new SqlParameter("@Descuento", SqlDbType.Decimal);
            param_Descuento.Value = Descuento;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_ID_Usuario);
            listaParametros.Add(param_ID_Cliente);
            listaParametros.Add(param_Fe_Venta);
            listaParametros.Add(param_TotalVenta);
            listaParametros.Add(param_Descuento);
            lista = listaParametros.ToArray();

            try
            {
                DataTable dt = ejecutar(sSql, lista, true);
                if (dt.Rows.Count>0)
                {
                    DataRow fila = dt.Rows[0];
                    Venta = Convert.ToInt32(fila["ID_Venta"]);                    
                }
            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Ventas||InsertarVenta");
            }
            return Venta;
        }
        public void InsertarVentaItem()
        {
            try
            {
                string sSql = "SP_Insertar_Venta_Item";
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                foreach (var item in Items)
                {

                    SqlParameter param_ID_Venta = new SqlParameter("@ID_Venta", SqlDbType.Int);
                    param_ID_Venta.Value = item.ID_Venta;
                    SqlParameter param_ID_Producto = new SqlParameter("@ID_Producto", SqlDbType.Int);
                    param_ID_Producto.Value = item.ID_Producto;
                    SqlParameter param_PrecUnitario = new SqlParameter("@PrecioUnitario", SqlDbType.Decimal);
                    param_PrecUnitario.Value = item.PrecUnitario;
                    SqlParameter param_Cantidad = new SqlParameter("@Cantidad", SqlDbType.Int);
                    param_Cantidad.Value = item.Cantidad;
                    SqlParameter param_Subtotal = new SqlParameter("@Subtotal", SqlDbType.Decimal);
                    param_Subtotal.Value = item.Subtotal;

                    SqlParameter param_ItemDescuento = new SqlParameter("@ItemDescuento", SqlDbType.Decimal);
                    param_ItemDescuento.Value = item.TotalconDescuento;


                    listaParametros.Add(param_ID_Venta);
                    listaParametros.Add(param_ID_Producto);
                    listaParametros.Add(param_PrecUnitario);
                    listaParametros.Add(param_Cantidad);
                    listaParametros.Add(param_Subtotal);
                    listaParametros.Add(param_ItemDescuento);
                    lista = listaParametros.ToArray();
                    ejecutar(sSql, lista, false);
                    listaParametros.Clear();
                }

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Ventas||InsertarVentaItem");
            }
        }
    }
}
