using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelo;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sesion;

namespace Datos
{
    public class CD_Catalogo: CD_EjecutarSP
    {
        #region Properties
        public int ID_Producto { get; set; }
        public string NombreComercial { get; set; }
        public string Monodroga { get; set; }
        public string Marca { get; set; }
        public string NombreProveedor { get; set; }
        public int ID_Proveedor { get; set; }
        public int UnidadporLote { get; set; }
        public int CompraMinima { get; set; }
        public decimal PrecioProveedor { get; set; }

        SqlParameter[] lista = null;
        public List<CM_Catalogo> CatalogoProductos { get; set; } = new List<CM_Catalogo>();
        #endregion

        #region Properties Busqueda
        public int UnidadporLoteDesde { get; set; }
        public int UnidadporLoteHasta { get; set; }
        public int CompraMinimaDesde { get; set; }
        public int CompraMinimaHasta { get; set; }
        public decimal PrecioProveedorDesde { get; set; }
        public decimal PrecioProveedorHasta { get; set; }

        #endregion


        #region Métodos
        public List <CM_Catalogo> ObtenerProductos()
        {
            DataTable dt = new DataTable();
            try
            {
                string sSql = "SP_Obtener_Catalogo";
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                SqlParameter[] parametros = listaparametros.ToArray();

                dt= ejecutar(sSql, parametros, true);

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Catalogo||ObtenerProductos");
            }
            if (dt.Rows.Count>0)
            {
                cargarCM_Catalogo(dt);
            }
            return CatalogoProductos;
        }
        public List<CM_Catalogo> Busqueda()
        {
            DataTable dt = new DataTable();
            try
            {
                string sSql = "SP_Consultar_Producto_Catalogo";
                SqlParameter param_NombreComercial = new SqlParameter("@NombreComercial", SqlDbType.VarChar, 200);
                param_NombreComercial.Value = NombreComercial;
                SqlParameter param_Monodroga = new SqlParameter("@Monodroga", SqlDbType.VarChar, 200);
                param_Monodroga.Value = Monodroga;
                SqlParameter param_Marca = new SqlParameter("@Marca", SqlDbType.VarChar, 200);
                param_Marca.Value = Marca;
                SqlParameter param_ID_Proveedor = new SqlParameter("@ID_Proveedor", SqlDbType.Int);
                param_ID_Proveedor.Value = ID_Proveedor;

                SqlParameter param_UnidadporLoteDesde = new SqlParameter("@UnidadporLoteDesde", SqlDbType.Int);
                param_UnidadporLoteDesde.Value = UnidadporLoteDesde;
                SqlParameter param_UnidadporLoteHasta = new SqlParameter("@UnidadporLoteHasta", SqlDbType.Int);
                param_UnidadporLoteHasta.Value = UnidadporLoteHasta;


                SqlParameter param_CompraMinimaDesde = new SqlParameter("@CompraMinimaDesde", SqlDbType.Int);
                param_CompraMinimaDesde.Value = CompraMinimaDesde;
                SqlParameter param_CompraMinimaHasta = new SqlParameter("@CompraMinimaHasta", SqlDbType.Int);
                param_CompraMinimaHasta.Value = CompraMinimaHasta;


                SqlParameter param_PrecioProveedorDesde = new SqlParameter("@PrecioProveedorDesde", SqlDbType.Float);
                param_PrecioProveedorDesde.Value = PrecioProveedorDesde;
                SqlParameter param_PrecioProveedorHasta = new SqlParameter("@PrecioProveedorHasta", SqlDbType.Float);
                param_PrecioProveedorHasta.Value = PrecioProveedorHasta;

                List<SqlParameter> listaparametros = new List<SqlParameter>();
                listaparametros.Add(param_NombreComercial);
                listaparametros.Add(param_Monodroga);
                listaparametros.Add(param_Marca);
                listaparametros.Add(param_ID_Proveedor);
                listaparametros.Add(param_UnidadporLoteDesde);
                listaparametros.Add(param_UnidadporLoteHasta);
                listaparametros.Add(param_CompraMinimaDesde);
                listaparametros.Add(param_CompraMinimaHasta);
                listaparametros.Add(param_PrecioProveedorDesde);
                listaparametros.Add(param_PrecioProveedorHasta);
                lista = listaparametros.ToArray();

                dt = ejecutar(sSql, lista, true);

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Catalogo||Busqueda");
            }
            if (dt.Rows.Count > 0)
            {
                cargarCM_Catalogo(dt);
            }
            return CatalogoProductos;
        }
        public void InsertarProductoCatalogo() 
        {
            try
            {
                string sSql = "SP_Insertar_Producto_Catalogo";
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param_UserName.Value = CSesion_SesionIniciada.UserName;

                SqlParameter param_NombreComercial = new SqlParameter("@NombreComercial", SqlDbType.VarChar, 200);
                param_NombreComercial.Value = NombreComercial;
                SqlParameter param_Monodroga = new SqlParameter("@Monodroga", SqlDbType.VarChar, 200);
                param_Monodroga.Value = Monodroga;
                SqlParameter param_Marca = new SqlParameter("@Marca", SqlDbType.VarChar, 200);
                param_Marca.Value = Marca;
                SqlParameter param_ID_Proveedor = new SqlParameter("@ID_Proveedor", SqlDbType.Int);
                param_ID_Proveedor.Value = ID_Proveedor;
                SqlParameter param_UnidadporLote = new SqlParameter("@UnidadporLote", SqlDbType.Int);
                param_UnidadporLote.Value = UnidadporLote;
                SqlParameter param_CompraMinima = new SqlParameter("@CompraMinima", SqlDbType.Int);
                param_CompraMinima.Value = CompraMinima;
                SqlParameter param_PrecioProveedor = new SqlParameter("@PrecioProveedor", SqlDbType.Decimal);
                param_PrecioProveedor.Value = PrecioProveedor;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_UserName);
                listaParametros.Add(param_NombreComercial);
                listaParametros.Add(param_Monodroga);
                listaParametros.Add(param_Marca);
                listaParametros.Add(param_ID_Proveedor);
                listaParametros.Add(param_UnidadporLote);
                listaParametros.Add(param_CompraMinima);
                listaParametros.Add(param_PrecioProveedor);
                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Catalogo||InsertarProductoCatalogo.");
            }
        }
        public void ModificarProductoCatalogo()
        {
            try
            {
                string sSql = "SP_Modificar_Producto_Catalogo";
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param_UserName.Value = CSesion_SesionIniciada.UserName;

                SqlParameter param_ID_Producto = new SqlParameter("@ID_Producto", SqlDbType.Int);
                param_ID_Producto.Value = ID_Producto;
                SqlParameter param_NombreComercial = new SqlParameter("@NombreComercial", SqlDbType.VarChar, 200);
                param_NombreComercial.Value = NombreComercial;
                SqlParameter param_Monodroga = new SqlParameter("@Monodroga", SqlDbType.VarChar, 200);
                param_Monodroga.Value = Monodroga;
                SqlParameter param_Marca = new SqlParameter("@Marca", SqlDbType.VarChar, 200);
                param_Marca.Value = Marca;

                SqlParameter param_Nombre_Proveedor = new SqlParameter("@NombreProveedor", SqlDbType.VarChar, 200);
                param_Nombre_Proveedor.Value = ID_Proveedor;
                param_Nombre_Proveedor.Value = NombreProveedor;

                SqlParameter param_UnidadporLote = new SqlParameter("@UnidadporLote", SqlDbType.Int);
                param_UnidadporLote.Value = UnidadporLote;
                SqlParameter param_CompraMinima = new SqlParameter("@CompraMinima", SqlDbType.Int);
                param_CompraMinima.Value = CompraMinima;
                SqlParameter param_PrecioProveedor = new SqlParameter("@PrecioProveedor", SqlDbType.Decimal);
                param_PrecioProveedor.Value = PrecioProveedor;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_UserName);
                listaParametros.Add(param_NombreComercial);
                listaParametros.Add(param_Monodroga);
                listaParametros.Add(param_Marca);
                listaParametros.Add(param_Nombre_Proveedor);
                listaParametros.Add(param_UnidadporLote);
                listaParametros.Add(param_CompraMinima);
                listaParametros.Add(param_PrecioProveedor);
                listaParametros.Add(param_ID_Producto);
                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Catalogo||ModificarProductoCatalogo.");
            }
        }
        public void EliminarProductoCatalogo()
        {
            try
            {
                string sSql = "SP_Eliminar_Producto_Catalogo";
                SqlParameter param_ID_Producto = new SqlParameter("@ID_Producto", SqlDbType.Int);
                param_ID_Producto.Value = ID_Producto;
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param_UserName.Value = CSesion_SesionIniciada.UserName;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_ID_Producto);
                listaParametros.Add(param_UserName);
                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Catalogo||EliminarProductoCatalogo.");
            }
        }
        private void cargarCM_Catalogo(DataTable dt) 
        {
            if (dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CM_Catalogo catalogo = new CM_Catalogo
                    {
                        ID_Producto = Convert.ToInt32(dr["ID_Producto"]),
                        NombreComercial = dr["NombreComercial"].ToString(),
                        Monodroga = dr["Monodroga"].ToString(),
                        Marca = dr["Marca"].ToString(),
                        Proveedor = dr["Nombre"].ToString(),
                        UnidadporLote = Convert.ToInt32(dr["UnidadesporLote"]),
                        CompraMinima = Convert.ToInt32(dr["CompraMinima"]),
                        PrecioProveedor = Convert.ToDouble(dr["PrecioProveedor"])
                    };

                    CatalogoProductos.Add(catalogo);
                }

            }
        }
        #endregion
    }
}
