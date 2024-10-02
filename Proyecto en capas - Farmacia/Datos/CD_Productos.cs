using Sesion;
using Sistema;
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
    public class CD_Productos:CD_EjecutarSP
    {
        #region Properties
        public string Prop_NombreComercial { get; set; }
        public string Prop_Monodroga { get; set; }
        public string Prop_Marca { get; set; }
        public string Prop_Descripcion { get; set; }
        public int Prop_Cantidad { get; set; }
        public decimal Prop_Precio { get; set; }
        public int Prop_NumLote { get; set; }
        public int Prop_ID_Producto { get; set; }
        public DateTime Prop_VtoProd { get; set; }
        public string Prop_Categoria { get; set; }

        SqlParameter[] lista = null;
        #endregion

        #region Properties para consulta
        public int Prop_CantDesde { get; set; }
        public int Prop_CantHasta { get; set; }
        public double Prop_PrecDesde { get; set; }
        public double Prop_PrecHasta { get; set; }
        public int Prop_NLoteBusq { get; set; }        
        public DateTime Prop_VtoDesde { get; set; }
        public DateTime Prop_VtoHasta { get; set; }
        #endregion
        public DataTable MostrarProductosDTGV()
        {
            string sSql = "SP_Obtener_Inventario";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter[] parametros = listaParametros.ToArray();
            DataTable dt = new DataTable();
            try
            {
                dt= ejecutar(sSql, parametros, true);
                
            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Productos||MostrarProductosDTGV.");
            }
            return dt;
        }
        public DataTable VtoProductos()
        {
            string sSql = "SP_Obtener_Productos_Prox_Vencer";
            SqlParameter param_Dias_Vto = new SqlParameter("@Dias_Vto", SqlDbType.Int);
            param_Dias_Vto.Value = CSistema_ConfiguracionSistema.AvisosVtoProductos; 

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_Dias_Vto);
            SqlParameter[] parametros = listaParametros.ToArray();
            DataTable dt = new DataTable();
            try
            {
                dt = ejecutar(sSql, parametros, true);
                CSesion_CacheVtoProductos.CargarProductosVencidos(dt);
                
            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Productos||VtoProductos.");
            }
            return dt;
        }
        public DataTable StockMinimo() 
        {
            string sSql = "SP_Stock_Minimo";
            SqlParameter param_StockMinimo = new SqlParameter("@StockMinimo", SqlDbType.Int);
            param_StockMinimo.Value = CSistema_ConfiguracionSistema.CantMinimadeStock;

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_StockMinimo);
            SqlParameter[] parametros = listaParametros.ToArray();
            DataTable dt = new DataTable();
            try
            {
                dt = ejecutar(sSql, parametros, true);
                CSesion_CacheStockMinimo.CargarStockMinimo(dt);
            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Productos||StockMinimo.");
            }
            return dt;
        }
        public DataTable Consultar()
        {
            string sSql = "SP_Consultar_Producto_Inventario";
            SqlParameter param_NombreComercial = new SqlParameter("@NombreComercial", SqlDbType.VarChar, 200);
            param_NombreComercial.Value = Prop_NombreComercial;
            SqlParameter param_Monodroga = new SqlParameter("@NombreProd", SqlDbType.VarChar, 200);
            param_Monodroga.Value = Prop_Monodroga;
            SqlParameter param_Marca = new SqlParameter("@Marca", SqlDbType.VarChar, 200);
            param_Marca.Value = Prop_Marca; 
            SqlParameter param_Descripcion = new SqlParameter("@DescripProd", SqlDbType.VarChar, 200);
            param_Descripcion.Value = Prop_Descripcion;
            SqlParameter param_CantidadDesde = new SqlParameter("@CantidadDesde", SqlDbType.Int);
            param_CantidadDesde.Value = Prop_CantDesde;
            SqlParameter param_CantidadHasta = new SqlParameter("@CantidadHasta", SqlDbType.Int);
            param_CantidadHasta.Value = Prop_CantHasta;
            SqlParameter param_PrecDesde = new SqlParameter("@PrecDesde", SqlDbType.Float);
            param_PrecDesde.Value = Prop_PrecDesde;
            SqlParameter param_PrecHasta = new SqlParameter("@PrecHasta", SqlDbType.Float);
            param_PrecHasta.Value = Prop_PrecHasta;
            SqlParameter param_VtoDesde = new SqlParameter("@FeVtoDesde", SqlDbType.DateTime);
            param_VtoDesde.Value = Prop_VtoDesde;
            SqlParameter param_VtoHasta = new SqlParameter("@FeVtoHasta", SqlDbType.DateTime);
            param_VtoHasta.Value = Prop_VtoHasta;
            SqlParameter param_NumLote = new SqlParameter("@NumLote", SqlDbType.Int);                 
            param_NumLote.Value = Prop_NLoteBusq;
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_NombreComercial);
            listaParametros.Add(param_Monodroga);
            listaParametros.Add(param_Marca);
            listaParametros.Add(param_Descripcion);
            listaParametros.Add(param_CantidadDesde);
            listaParametros.Add(param_CantidadHasta);
            listaParametros.Add(param_PrecDesde);
            listaParametros.Add(param_PrecHasta);
            listaParametros.Add(param_VtoDesde);
            listaParametros.Add(param_VtoHasta);                
            listaParametros.Add(param_NumLote);
            
            lista = listaParametros.ToArray();
            DataTable Dt = new DataTable();

            try
            {
                Dt= ejecutar(sSql, lista, true);
            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Productos||Consultar.");
            }
            return Dt;
        }
        public DataTable ProductosVencidos()
        {
            string sSql = "SP_Obtener_Productos_Vencidos";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter[] parametros = listaParametros.ToArray();
            DataTable dt = new DataTable();
            try
            {
                dt = ejecutar(sSql, parametros, true);
            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Productos||ProductosVencidos.");
            }
            return dt;
        }
        public void Insertar()
        {
            try
            {
                string sSql = "SP_Insertar_Producto_Inventario";
                SqlParameter param_NombreComercial = new SqlParameter("@NombreComercial", SqlDbType.VarChar, 200);
                param_NombreComercial.Value = Prop_NombreComercial;
                SqlParameter param_Monodroga = new SqlParameter("@NombreProd", SqlDbType.VarChar, 200);
                param_Monodroga.Value = Prop_Monodroga;
                SqlParameter param_Marca = new SqlParameter("@Marca", SqlDbType.VarChar, 200);
                param_Marca.Value = Prop_Marca;
                SqlParameter param_Descripcion = new SqlParameter("@DescripProd", SqlDbType.VarChar, 200);
                param_Descripcion.Value = Prop_Descripcion;
                SqlParameter param_Cantidad = new SqlParameter("@Cantidad", SqlDbType.Int);
                param_Cantidad.Value = Prop_Cantidad;
                SqlParameter param_Precio = new SqlParameter("@PrecUnit", SqlDbType.Decimal);
                param_Precio.Value = Prop_Precio;
                SqlParameter param_VtoProd = new SqlParameter("@FeVtoProd", SqlDbType.DateTime);
                param_VtoProd.Value = Prop_VtoProd;
                SqlParameter param_NumLote = new SqlParameter("@NumLote", SqlDbType.Int);
                param_NumLote.Value = Prop_NumLote;
                SqlParameter param_Categoria = new SqlParameter("@Categoria", SqlDbType.VarChar, 200);
                param_Categoria.Value = Prop_Categoria;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_NombreComercial);
                listaParametros.Add(param_Monodroga);
                listaParametros.Add(param_Marca);
                listaParametros.Add(param_Descripcion);
                listaParametros.Add(param_Cantidad);
                listaParametros.Add(param_Precio);
                listaParametros.Add(param_NumLote);
                listaParametros.Add(param_VtoProd);
                listaParametros.Add(param_Categoria);
                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Productos||Insertar.");
            }
        }
        public void ActualizarProductos()
        {
            try
            {
                string sSql = "SP_Actualizar_Producto_Inventario";
                SqlParameter param_ID_Producto = new SqlParameter("@ID_Producto", SqlDbType.Int);
                param_ID_Producto.Value = Prop_ID_Producto;
                SqlParameter param_NombreComercial = new SqlParameter("@NombreComercial", SqlDbType.VarChar, 200);
                param_NombreComercial.Value = Prop_NombreComercial;
                SqlParameter param_Monodroga = new SqlParameter("@NombreProd", SqlDbType.VarChar, 200);
                param_Monodroga.Value = Prop_Monodroga;
                SqlParameter param_Marca = new SqlParameter("@Marca", SqlDbType.VarChar, 200);
                param_Marca.Value = Prop_Marca;
                SqlParameter param_Descripcion = new SqlParameter("@DescripProd", SqlDbType.VarChar, 200);
                param_Descripcion.Value = Prop_Descripcion;
                SqlParameter param_Cantidad = new SqlParameter("@Cantidad", SqlDbType.Int);
                param_Cantidad.Value = Prop_Cantidad;
                SqlParameter param_Precio = new SqlParameter("@PrecUnit", SqlDbType.Decimal);
                param_Precio.Value = Prop_Precio;
                SqlParameter param_VtoProd = new SqlParameter("@FeVtoProd", SqlDbType.DateTime);
                param_VtoProd.Value = Prop_VtoProd;
                SqlParameter param_NumLote = new SqlParameter("@NumLote", SqlDbType.Int);
                param_NumLote.Value = Prop_NumLote;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_ID_Producto);
                listaParametros.Add(param_NombreComercial);
                listaParametros.Add(param_Monodroga);
                listaParametros.Add(param_Marca);
                listaParametros.Add(param_Descripcion);
                listaParametros.Add(param_Cantidad);
                listaParametros.Add(param_Precio);
                listaParametros.Add(param_NumLote);
                listaParametros.Add(param_VtoProd);

                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Productos||ActualizarProducto.");
            }
        }
        public void Eliminar(int ID_Producto)
        {
            try
            {
                string sSql = "SP_Eliminar_Producto_Inventario";
                SqlParameter param_ID_Producto = new SqlParameter("@ID_Producto", SqlDbType.Int);
                param_ID_Producto.Value = ID_Producto;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_ID_Producto);

                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Productos||Eliminar.");
            }
        }
        public void ElimProdVencidos(DateTime FechaActual)
        {
            try
            {
                string sSql = "SP_Eliminar_Prod_Vencidos";
                SqlParameter param_FeActual = new SqlParameter("@FeActual", SqlDbType.Date);
                param_FeActual.Value = FechaActual;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_FeActual);

                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Productos||ElimProdVencidos.");
            }
        }
    }
}