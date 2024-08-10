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
        public string Prop_ID_Producto { get; set; }
        #endregion
        public DataTable MostrarProductos(string datos) 
        {
            return Productos.MostrarProductosDTGV(datos);
        }
        public void InsertarProducto() 
        {
            pasarDatos(false);
            Productos.Insertar();
        }
        public void ModificarProductos() 
        {
            pasarDatos(true);
            Productos.ActualizarProductos();
        }
        private void pasarDatos(bool ProdSeleccionado)
        {
            if (ProdSeleccionado)
            {
                Productos.Prop_ID_Producto = Convert.ToInt32(Prop_ID_Producto);
            }
            if (!string.IsNullOrEmpty(Prop_Nombre))
            {
                Productos.Prop_Nombre = Prop_Nombre;
            }
            else
            {
                throw new Exception("El nombre del producto no puede ser nulo o vacio");
            }

            if (!string.IsNullOrEmpty(Prop_Marca))
            {
                Productos.Prop_Marca = Prop_Marca;
            }
            else
            { throw new Exception("La marca del producto no puede ser nulo o vacio"); }
            Productos.Prop_Descripcion = Prop_Descripcion;
            if (!string.IsNullOrEmpty(Prop_Cantidad) || Prop_Cantidad == "0")
            {
                try
                {
                    Productos.Prop_Cantidad = Convert.ToInt32(Prop_Cantidad);
                }
                catch (Exception)
                {

                    throw new Exception("La cantidad debe ser un formato numérico válido.");
                }
            }
            else
            {
                throw new Exception("La cantidad no puede ser vacia o nula");
            }

            if (!string.IsNullOrEmpty(Prop_Precio) || Prop_Precio =="0")
            {
                try
                {
                    Productos.Prop_Precio = Convert.ToDecimal(Prop_Precio);
                }
                catch (Exception)
                {

                    throw new Exception("El precio debe tener un formato numérico válido.");
                }

            }
            else
            {
                throw new Exception("El precio no puede ser vacio o nulo");
            }
                        
            try
            {
                DateTime Fe_vencimiento = Convert.ToDateTime(Prop_VtoProd);
                if (Fe_vencimiento > DateTime.Today)
                {
                    Productos.Prop_VtoProd = Fe_vencimiento;
                }
                else
                {
                    throw new Exception("El producto a ingresar no puede estar vencido");
                }

            }
            catch (Exception)
            {

                throw ;
            }


            if (!String.IsNullOrEmpty(Prop_NumLote) || Prop_NumLote == "0")
            {
                try
                {
                    Productos.Prop_NumLote = Convert.ToInt32(Prop_NumLote);
                }
                catch (Exception)
                {

                    throw new Exception("El Numero de lote debe tener un formato numérico válido.");
                }

            }
            else
            {
                throw new Exception("El numero de lote no puede ser vacio o nulo");
            }
        }
    }
}
