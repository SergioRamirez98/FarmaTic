using Modelo;
using Sesion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_PedidodeCompra : CD_EjecutarSP
    {
        #region Properties
        public string UserName { get; set; } = CSesion_SesionIniciada.UserName;
        public int ID_Producto { get; set; }
        public string NombreComercial { get; set; }
        public string Monodroga { get; set; }
        public string Marca { get; set; }
        public string Proveedor { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }
        public int ID_Pedido { get; set; }
        public decimal TotalporProveedor { get; set; }

        public List<CD_PedidodeCompra> Items = new List<CD_PedidodeCompra>();

        SqlParameter[] lista = null;

        #endregion

        public int InsertarCompraPorProveedor()
        {
            string sSql = "SP_Insertar_Pedido_de_Compra_Por_Proveedor";
            SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 200);
            param_UserName.Value = UserName;
            SqlParameter param_Proveedor = new SqlParameter("@Proveedor", SqlDbType.VarChar, 200);
            param_Proveedor.Value = Proveedor;
            SqlParameter param_TotalporProveedor = new SqlParameter("@TotalporProveedor", SqlDbType.Decimal);
            param_TotalporProveedor.Value = TotalporProveedor;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_UserName);
            listaParametros.Add(param_Proveedor);
            listaParametros.Add(param_TotalporProveedor);
            lista = listaParametros.ToArray();

            try
            {
                DataTable dt = ejecutar(sSql, lista, true);
                if (dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];
                    ID_Pedido = Convert.ToInt32(fila["ID_Pedido"]);

                    obtenerDatosPedidodeCompra(ID_Pedido);


                }
            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_PedidodeCompra||InsertarCompraPorProveedor");
            }
            return ID_Pedido;
        }
        public void InsertarCompraPorItems()
        {
            string sSql = "SP_Insertar_Pedido_de_Compra_Por_Item";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            foreach (var item in Items)
            {

                SqlParameter param_ID_Pedido = new SqlParameter("@ID_Pedido", SqlDbType.Int);
                param_ID_Pedido.Value = item.ID_Pedido;

                SqlParameter param_ID_Producto = new SqlParameter("@ID_Producto", SqlDbType.Int);
                param_ID_Producto.Value = item.ID_Producto;
                SqlParameter param_Cantidad = new SqlParameter("@Cantidad", SqlDbType.Int);
                param_Cantidad.Value = item.Cantidad;
                SqlParameter param_PrecUnitario = new SqlParameter("@PrecioUnitario", SqlDbType.Decimal);
                param_PrecUnitario.Value = item.Precio;
                SqlParameter param_Subtotal = new SqlParameter("@Subtotal", SqlDbType.Decimal);
                param_Subtotal.Value = item.Subtotal;

                listaParametros.Add(param_ID_Pedido);
                listaParametros.Add(param_ID_Producto);
                listaParametros.Add(param_Cantidad);
                listaParametros.Add(param_PrecUnitario);
                listaParametros.Add(param_Subtotal);
                lista = listaParametros.ToArray();
                ejecutar(sSql, lista, false);
                listaParametros.Clear();
            }
        }

        private void obtenerDatosPedidodeCompra(int PC)
        {
            string sSql = "SP_Obtener_Datos_Proveedores_Empresa_Para_PC";
            SqlParameter param_PC = new SqlParameter("@OC", SqlDbType.Int);
            param_PC.Value = PC;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_PC);
            lista = listaParametros.ToArray();

            DataTable dt = ejecutar(sSql, lista, true);
            if (dt.Rows.Count > 0)
            {
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

    }
}
