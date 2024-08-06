using System;
using System.Collections.Generic;
using System.Data;
using Datos;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_Productos
    {
        CD_Productos Productos = new CD_Productos();
        #region Properties
        public string Prop_Nombre { get; set; }
        public string Prop_Marca { get; set; }
        public string Prop_Descripcion { get; set; }
        public string Prop_Cantidad { get; set; }
        public string Prop_Precio { get; set; }
        public string Prop_NumLote { get; set; }
        public string Prop_VtoProd { get; set; }
        #endregion
        public DataTable MostrarProductos(string datos) 
        {
            return Productos.MostrarProductosDTGV(datos);
        }
        public void InsertarProducto() 
        {
            pasarDatos();
            Productos.Insertar();
        }
        public void ActualizarProductos() 
        { 
        }
        private void pasarDatos()
        {
            Productos.Prop_Nombre = Prop_Nombre;
            Productos.Prop_Marca = Prop_Marca;
            Productos.Prop_Descripcion = Prop_Descripcion;
            try
            {
                Productos.Prop_Cantidad = Convert.ToInt32(Prop_Cantidad);
            }
            catch (Exception)
            {

                throw new Exception("La cantidad debe ser un formato numérico válido.");
            }
            try
            {
                Productos.Prop_Precio = Convert.ToDecimal(Prop_Precio);
            }
            catch (Exception)
            {

                throw new Exception("El precio debe tener un formato numérico válido.");
            }
            try
            {
                Productos.Prop_VtoProd = Convert.ToDateTime(Prop_VtoProd);
            }
            catch (Exception)
            {

                throw new Exception("Por favor ingrese una fecha válida.");
            }
            try
            {
                Productos.Prop_NumLote = Convert.ToInt32(Prop_NumLote);
            }
            catch (Exception)
            {

                throw new Exception("El Numero de lote debe tener un formato numérico válido..");
            }




        }
    }
}
