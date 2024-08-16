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
        #region Properties Adicionales de Busqueda
        public string Prop_CantDesde { get; set; }
        public string Prop_CantHasta { get; set; }
        public string Prop_PrecDesde { get; set; }
        public string Prop_PrecHasta { get; set; }
        public string Prop_NLoteBusq { get; set; }
        public string Prop_VtoDesde { get; set; }
        public string Prop_VtoHasta { get; set; }
        #endregion
        public DataTable MostrarProductos(string datos) 
        {
            return Productos.MostrarProductosDTGV(datos);
        }
        public DataTable ConsultarProductos()
        {
            pasarDatosConsulta();
            return Productos.Consultar();
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
        public void EliminarProducto(int ID_Producto)
        {
            Productos.Eliminar(ID_Producto);
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
                //char.ToUpper(Prop_Nombre[0]) + Prop_Nombre.Substring(1).ToLower(); convierte la primer letra en mayus y el resto en minus.
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
        private void pasarDatosConsulta()
        {

            Productos.Prop_Nombre = Prop_Nombre;
            Productos.Prop_Marca = Prop_Marca;
            Productos.Prop_Descripcion = Prop_Descripcion;
            
            try
            {
                if (string.IsNullOrEmpty(Prop_CantDesde))
                {
                    Productos.Prop_CantDesde = int.MinValue;
                }
                else
                {
                    Productos.Prop_CantDesde = Convert.ToInt32(Prop_CantDesde);
                }
                if (string.IsNullOrEmpty(Prop_CantHasta))
                {
                    Productos.Prop_CantHasta = int.MaxValue;
                }
                else
                {
                    Productos.Prop_CantHasta = Convert.ToInt32(Prop_CantHasta);
                }

            }
            catch (Exception)
            {
                throw new Exception("La cantidad debe ser un formato numérico válido.");
            }

            try
            {
                if (string.IsNullOrEmpty(Prop_PrecDesde))
                {
                    Productos.Prop_PrecDesde = double.MinValue;
                }
                else
                {
                    Productos.Prop_PrecDesde = Convert.ToDouble(Prop_PrecDesde);
                }
                if (string.IsNullOrEmpty(Prop_PrecHasta))
                {
                    Productos.Prop_PrecHasta = double.MaxValue;
                }
                else
                {
                    Productos.Prop_PrecHasta = Convert.ToDouble(Prop_PrecHasta);
                }
            }
            catch (Exception)
            {
                throw new Exception("El precio debe tener un formato numérico válido.");
            }

            

            try
            {
                DateTime Fe_vencimientoDesde = Convert.ToDateTime(Prop_VtoDesde);
                DateTime Fe_vencimientoHasta = Convert.ToDateTime(Prop_VtoHasta);
                if (Fe_vencimientoDesde <= Fe_vencimientoHasta)
                {
                    Productos.Prop_VtoDesde = Fe_vencimientoDesde;
                    Productos.Prop_VtoHasta = Fe_vencimientoHasta;
                }
                else
                {
                    throw new Exception("El producto a ingresar no puede estar vencido");
                }
            }
            catch (Exception)
            {

                throw;
            }


            if (String.IsNullOrEmpty(Prop_NLoteBusq)  )
            {
                Productos.Prop_NLoteBusq = 0;
                
            }
            else
            {
                try
                {
                    Productos.Prop_NLoteBusq = Convert.ToInt32(Prop_NLoteBusq);
                }
                catch (Exception)
                {

                    throw new Exception("El Numero de lote debe tener un formato numérico válido.");
                }
            }
        }
    }
}


/* Prop_CantDesde // Prop_CantHasta // Prop_PrecDesde // Prop_PrecHasta // Prop_NLoteBusq // Prop_VtoDesde // Prop_VtoHasta */
