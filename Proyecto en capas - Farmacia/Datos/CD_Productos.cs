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
        public DateTime Prop_VtoProd { get; set; }

        SqlParameter[] lista = null;
        #endregion
        public DataTable MostrarProductosDTGV(string datos)
        {
            string sSql = "SP_MostrarProductos";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter[] parametros = listaParametros.ToArray();

            try
            {
                return ejecutar(sSql, parametros, true);
            }
            catch (Exception)
            {

                throw new Exception("Usuario no encontrado, por favor ingrese nuevamente");
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
    }
}
