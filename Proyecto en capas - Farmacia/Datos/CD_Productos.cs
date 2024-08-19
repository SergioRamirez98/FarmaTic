using Capa_de_Sistema;
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
        public string Prop_Nombre { get; set; }
        public string Prop_Marca { get; set; }
        public string Prop_Descripcion { get; set; }
        public int Prop_Cantidad { get; set; }
        public decimal Prop_Precio { get; set; }
        public int Prop_NumLote { get; set; }
        public int Prop_ID_Producto { get; set; }
        public DateTime Prop_VtoProd { get; set; }

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
        public DataTable MostrarProductosDTGV(string datos)
        {
            string sSql = "SP_Mostrar_Productos";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter[] parametros = listaParametros.ToArray();

            try
            {
                return ejecutar(sSql, parametros, true);
            }
            catch (Exception)
            {

                throw new Exception("Error al conectar con la base de datos.");
            }
        }
        public DataTable VtoProductos()
        {
            string sSql = "SP_Vto_Productos";
            SqlParameter param_Dias_Vto = new SqlParameter("@Dias_Vto", SqlDbType.VarChar, 200);
            param_Dias_Vto.Value = CSistema_ConfSistema.AvisosVtoProductos; //el valor de configuracion vto dias

            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(param_Dias_Vto);
            SqlParameter[] parametros = listaParametros.ToArray();
            try
            {
                return ejecutar(sSql, parametros, true);
            }
            catch (Exception)
            {

                throw new Exception("Error al conectar con la base de datos.");
            }
        }
        public DataTable Consultar()
        {
            try
            {
                string sSql = "SP_Consultar_Producto";
                SqlParameter param_Nombre = new SqlParameter("@NombreProd", SqlDbType.VarChar, 200);
                param_Nombre.Value = Prop_Nombre;
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
                listaParametros.Add(param_Nombre);
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

                return ejecutar(sSql, lista, true);

            }
            catch (Exception)
            {

                throw new Exception("Error al comprobar los datos en la base de datos.");
            }
        }        
        public void Insertar()
        {
            try
            {
                string sSql = "SP_Insertar_Producto";
                SqlParameter param_Nombre = new SqlParameter("@NombreProd", SqlDbType.VarChar, 200);
                param_Nombre.Value = Prop_Nombre;
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
                listaParametros.Add(param_Nombre);
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

                throw new Exception("Error al comprobar los datos en la base de datos.");
            }
        }
        public void ActualizarProductos()
        {
            try
            {
                string sSql = "SP_Actualizar_Producto";
                SqlParameter param_ID_Producto = new SqlParameter("@ID_Producto", SqlDbType.Int);
                param_ID_Producto.Value = Prop_ID_Producto;
                SqlParameter param_Nombre = new SqlParameter("@NombreProd", SqlDbType.VarChar, 200);
                param_Nombre.Value = Prop_Nombre;
                SqlParameter param_Marca = new SqlParameter("@Marca", SqlDbType.VarChar, 200);
                param_Marca.Value = Prop_Marca;
                SqlParameter param_Descripcion = new SqlParameter("@DescripProd", SqlDbType.VarChar, 200);
                param_Descripcion.Value = Prop_Descripcion;
                SqlParameter param_Cantidad = new SqlParameter("@Cantidad", SqlDbType.Int);
                param_Cantidad.Value = Prop_Cantidad;
                SqlParameter param_Precio = new SqlParameter("@PrecUnit", SqlDbType.Float);
                param_Precio.Value = Prop_Precio;
                SqlParameter param_VtoProd = new SqlParameter("@FeVtoProd", SqlDbType.DateTime);
                param_VtoProd.Value = Prop_VtoProd;
                SqlParameter param_NumLote = new SqlParameter("@NumLote", SqlDbType.Int);
                param_NumLote.Value = Prop_NumLote;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_ID_Producto);
                listaParametros.Add(param_Nombre);
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

                throw new Exception("Error al guardar los datos en la base de datos.");
            }
        }
        public void Eliminar(int ID_Producto)
        {
            try
            {
                string sSql = "SP_Eliminar_Producto";
                SqlParameter param_ID_Producto = new SqlParameter("@ID_Producto", SqlDbType.Int);
                param_ID_Producto.Value = ID_Producto;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_ID_Producto);

                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);

            }
            catch (Exception)
            {

                throw new Exception("Error al eliminar los datos seleccionados.");
            }
        }
    }
}