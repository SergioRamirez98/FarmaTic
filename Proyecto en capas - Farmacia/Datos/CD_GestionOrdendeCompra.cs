using Modelo;
using Sesion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_GestionOrdendeCompra : CD_EjecutarSP
    {
        #region Properties

        public int OrdenDeCompra { get; set; }
        public int ID_Pedido { get; set; }
        public string UserName { get; set; } = CSesion_SesionIniciada.UserName;
        public string Proveedor { get; set; }
        public decimal Total { get; set; }


        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }

        public List<CD_GestionOrdendeCompra> Items = new List<CD_GestionOrdendeCompra>();
        public List<CM_ObtenerPedidodeCompra> CatalogoProductos { get; set; } = new List<CM_ObtenerPedidodeCompra>();
        public List<CM_Pedido> PedidoporItem { get; set; } = new List<CM_Pedido>();
        public List<CM_OrdenDeCompraPorItemsPDF> OCporItem { get; set; } = new List<CM_OrdenDeCompraPorItemsPDF>();
        SqlParameter[] lista = null;
        #endregion

        public List<CM_ObtenerPedidodeCompra> ObtenerPedidos()
        {
            DataTable dt = new DataTable();
            try
            {
                string sSql = "SP_Obtener_Pedido_de_Compra";
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                SqlParameter[] parametros = listaparametros.ToArray();

                dt = ejecutar(sSql, parametros, true);

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_OrdendeCompra||ObtenerPedidos");
            }
            if (dt.Rows.Count > 0)
            {
                cargarCM_Catalogo(dt);
            }
            return CatalogoProductos;
        }
        public List<CM_ObtenerPedidodeCompra> ObtenerHistorialPedidos()
        {
            DataTable dt = new DataTable();
            try
            {
                string sSql = "SP_Obtener_Historial_Pedido_de_Compra";
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                SqlParameter[] parametros = listaparametros.ToArray();

                dt = ejecutar(sSql, parametros, true);

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_OrdendeCompra||ObtenerHistorialPedidos");
            }
            if (dt.Rows.Count > 0)
            {
                cargarCM_Catalogo(dt);
            }
            return CatalogoProductos;
        }
        public List<CM_Pedido> ObtenerPedidosPorItems(int id)
        {
            PedidoporItem.Clear();
            DataTable dt = new DataTable();
            try
            {
                string sSql = "SP_Obtener_Pedido_de_Compra_Por_Items";
                SqlParameter param_ID_Pedido = new SqlParameter("@ID_Pedido", SqlDbType.Int);
                param_ID_Pedido.Value = id;

                List<SqlParameter> listaparametros = new List<SqlParameter>();
                listaparametros.Add(param_ID_Pedido);
                SqlParameter[] parametros = listaparametros.ToArray();

                dt = ejecutar(sSql, parametros, true);

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_OrdendeCompra||ObtenerPedidosPorItems");
            }
            if (dt.Rows.Count > 0)
            {
                cargarCM_PedidoItems(dt);
            }
            return PedidoporItem;
        }
        public int InsertarOC()
        {
            string sSql = "SP_Insertar_Orden_de_Compra";
            SqlParameter param_ID_Pedido = new SqlParameter("@ID_Pedido", SqlDbType.Int);
            param_ID_Pedido.Value = ID_Pedido;
            SqlParameter param_Proveedor = new SqlParameter("@Proveedor", SqlDbType.VarChar, 200);
            param_Proveedor.Value = Proveedor;
            SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 200);
            param_UserName.Value = UserName;
            SqlParameter param_Total = new SqlParameter("@Total", SqlDbType.Decimal);
            param_Total.Value = Total;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_ID_Pedido);
            listaParametros.Add(param_Proveedor);
            listaParametros.Add(param_UserName);
            listaParametros.Add(param_Total);
            lista = listaParametros.ToArray();
            try
            {
                DataTable dt = ejecutar(sSql, lista, true);
                if (dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];
                    OrdenDeCompra = Convert.ToInt32(fila["OC"]);
                    obtenerDatosOrdendeCompra(OrdenDeCompra);
                }
            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_OrdendeCompra||InsertarOC");
            }
            return OrdenDeCompra;

        }
        public void InsertarOCporItems()
        {
            try
            {
                foreach (var item in Items)
                {

                    string sSql = "SP_Insertar_Orden_de_Compra_Por_Items";
                    SqlParameter param_OrdenDeCompra = new SqlParameter("@OrdenDeCompra", SqlDbType.Int);
                    param_OrdenDeCompra.Value = item.OrdenDeCompra;
                    SqlParameter param_Producto = new SqlParameter("@Producto", SqlDbType.VarChar, 200);
                    param_Producto.Value = item.Producto;
                    SqlParameter param_Cantidad = new SqlParameter("@Cantidad", SqlDbType.Int);
                    param_Cantidad.Value = item.Cantidad;
                    SqlParameter param_PrecioUnitario = new SqlParameter("@PrecioUnitario", SqlDbType.Decimal);
                    param_PrecioUnitario.Value = item.PrecioUnitario;
                    SqlParameter param_Subtotal = new SqlParameter("@Subtotal", SqlDbType.Decimal);
                    param_Subtotal.Value = item.Subtotal;

                    List<SqlParameter> listaParametros = new List<SqlParameter>();
                    listaParametros.Add(param_OrdenDeCompra);
                    listaParametros.Add(param_Producto);
                    listaParametros.Add(param_Cantidad);
                    listaParametros.Add(param_PrecioUnitario);
                    listaParametros.Add(param_Subtotal);
                    lista = listaParametros.ToArray();

                    ejecutar(sSql, lista, false);
                    listaParametros.Clear();

                }
            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_OrdendeCompra||InsertarOCporItems");
            }

        }
        public void EliminarPedidodeCompra()
        {
            string sSql = "SP_Eliminar_Pedido_de_Compra";
            SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
            param_UserName.Value = CSesion_SesionIniciada.UserName;
            SqlParameter param_ID_Pedido = new SqlParameter("@ID_Pedido", SqlDbType.Int);
            param_ID_Pedido.Value = ID_Pedido;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_UserName);
            listaParametros.Add(param_ID_Pedido);
            lista = listaParametros.ToArray();
            ejecutar(sSql, lista, false);
        }

        public List<CM_OrdenDeCompraPorItemsPDF> ObtenerOCPorItems(int oc)
        {
            OCporItem.Clear();
             DataTable dt = new DataTable();
            try
            {
                string sSql = "SP_Obtener_OC_Por_Items";
                SqlParameter param_OC = new SqlParameter("@OC", SqlDbType.Int);
                param_OC.Value = oc;

                List<SqlParameter> listaparametros = new List<SqlParameter>();
                listaparametros.Add(param_OC);
                SqlParameter[] parametros = listaparametros.ToArray();

                dt = ejecutar(sSql, parametros, true);

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_OrdendeCompra||ObtenerOCPorItems");
            }
            if (dt.Rows.Count > 0)
            {
                cargarCM_OrdenDeCompraPorItemsPDF(dt);
            }
            return OCporItem;
        }
        private void obtenerDatosOrdendeCompra(int OC)
        {
            string sSql = "SP_Obtener_Datos_Proveedores_Empresa";
            SqlParameter param_OC = new SqlParameter("@OC", SqlDbType.Int);
            param_OC.Value = OC;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_OC); 
            lista = listaParametros.ToArray();

            DataTable dt =ejecutar(sSql, lista, true);
            if (dt.Rows.Count > 0)
            {
             //   CM_DatosOCDefinitiva.. Datos = new CM_DatosOCDefinitiva..();
                DataRow fila = dt.Rows[0];
                CM_DatosOCDefinitiva.NombreProveedor = fila["NombreProveedor"].ToString();
                CM_DatosOCDefinitiva.MatriculaProveedor = Convert.ToInt32(fila["MatriculaProveedor"]);
                CM_DatosOCDefinitiva.CUITProveedor = fila["CUITProveedor"].ToString();
                CM_DatosOCDefinitiva.IVAProveedor = fila["IVAProveedor"].ToString();
                CM_DatosOCDefinitiva.IIBBProveedor = Convert.ToBoolean(fila["IIBBProveedor"]);
                CM_DatosOCDefinitiva.DireccionProv = fila["DireccionProveedor"].ToString();
                CM_DatosOCDefinitiva.CorreoProv = fila["MAILProveedor"].ToString();
                CM_DatosOCDefinitiva.LocalidadProv = fila["LocalidadProveedor"].ToString();
                CM_DatosOCDefinitiva.PartidoProv = fila["PartidoProveedor"].ToString();
                CM_DatosOCDefinitiva.TelefonoProv = Convert.ToInt32(fila["TelefonoProveedor"]);


                CM_DatosOCDefinitiva.Usuario = fila["UserName"].ToString();
                CM_DatosOCDefinitiva.NombreApellido = fila["NombreApellido"].ToString();
                CM_DatosOCDefinitiva.Fecha = Convert.ToDateTime(fila["FechaOrden"]);


                CM_DatosOCDefinitiva.NombreEmpresa = fila["NombreEmpresa"].ToString();
                CM_DatosOCDefinitiva.DireccionFarma = fila["DireccionEmpresa"].ToString();
                CM_DatosOCDefinitiva.DomicilioEntrega = fila["DomicilioEntregaEmpresa"].ToString();
                CM_DatosOCDefinitiva.FechaInicioAct = Convert.ToDateTime(fila["InicioActEmpresa"]);
                CM_DatosOCDefinitiva.CUITEmpresa = fila["CuitEmpresa"].ToString();
                CM_DatosOCDefinitiva.PartidoFarma = fila["PartidoEmpresa"].ToString();
                CM_DatosOCDefinitiva.LocalidadFarma = fila["LocalidadEmpresa"].ToString();
            }

        }
        private void cargarCM_Catalogo(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CM_ObtenerPedidodeCompra catalogo = new CM_ObtenerPedidodeCompra
                    {
                        ID_Pedido = Convert.ToInt32(dr["ID_Pedido"]),
                        UserName = dr["UserName"].ToString(),
                        NombreProveedor = dr["Nombre"].ToString(),
                        Fecha_Pedido = Convert.ToDateTime(dr["Fecha_Pedido"]),
                        MontoPedido = Convert.ToDouble(dr["MontoPedido"])
                    };

                    if (dt.Columns.Count == 6) catalogo.Estado = dr["Descripcion_Estado"].ToString();
                    CatalogoProductos.Add(catalogo);
                }

            }
        }
        private void cargarCM_PedidoItems(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CM_Pedido catalogo = new CM_Pedido
                    {
                        NombreComercial = dr["NombreComercial"].ToString(),
                        Monodroga = dr["Monodroga"].ToString(),
                        Marca = dr["Marca"].ToString(),
                        Proveedor = dr["Nombre"].ToString(),
                        Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        PrecioUnitario = Convert.ToDouble(dr["PrecioUnitario"]),
                        Subtotal = Convert.ToDouble(dr["Subtotal"]),
                        AgregarQuitar = Convert.ToBoolean((dr["AgregarQuitar"]))
                    };

                    PedidoporItem.Add(catalogo);
                }

            }
        }
        private void cargarCM_OrdenDeCompraPorItemsPDF(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CM_OrdenDeCompraPorItemsPDF catalogo = new CM_OrdenDeCompraPorItemsPDF
                    {
                        NombreComercial = dr["NombreComercial"].ToString(),
                        Monodroga = dr["Monodroga"].ToString(),
                        Marca = dr["Marca"].ToString(),                      
                        Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        PrecioUnitario = Convert.ToDouble(dr["PrecioUnitario"]),
                        Subtotal = Convert.ToDouble(dr["Subtotal"])                        
                    };

                    OCporItem.Add(catalogo);
                }

            }
        }

    }
}