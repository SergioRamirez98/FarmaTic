using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_Catalogo
    {
        CD_Catalogo Catalogo = new CD_Catalogo();

        #region Properties
        public string ID_Producto { get; set; }
        public string NombreComercial { get; set; }
        public string Monodroga { get; set; }
        public string Marca { get; set; }
        public string ID_Proveedor { get; set; }
        public string UnidadporLote { get; set; }
        public string CompraMinima { get; set; }
        public string NombreProveedor { get; set; }
        public string PrecioProveedor { get; set; }
        public List <CM_Catalogo> CatalogoProductos { get; set; } = new List<CM_Catalogo>();
        #endregion
        #region Properties Busqueda
        public string UnidadporLoteDesde { get; set; }
        public string UnidadporLoteHasta { get; set; }
        public string CompraMinimaDesde { get; set; }
        public string CompraMinimaHasta { get; set; }
        public string PrecioProveedorDesde { get; set; }
        public string PrecioProveedorHasta { get; set; }
        
        #endregion

        #region Métodos
        public List<CM_Catalogo> MostrarProductos() 
        {
            CatalogoProductos.Clear();
            CatalogoProductos= Catalogo.ObtenerProductos();
            return CatalogoProductos;
        }

        public List<CM_Catalogo> RealizarBusqueda()
        {
            pasarDatos(true);
            CatalogoProductos.Clear();
            CatalogoProductos = Catalogo.Busqueda();
            return CatalogoProductos;
        }
        public void InsertarProducto()
        {
            pasarDatos();
            Catalogo.InsertarProductoCatalogo();
        }
        public void ModificarProductos() 
        {
            pasarDatos();
            Catalogo.ModificarProductoCatalogo();
        }
        public void EliminarProducto()
        {
            pasarDatos();
            Catalogo.EliminarProductoCatalogo();
        }

        public bool ConsultarCatalogo(string nombre) 
        {
            nombre.ToLower();
            
            bool ExisteProducto = false;
            if (string.IsNullOrEmpty(nombre)) { ExisteProducto = false; }
            else
            {
                foreach (var item in CatalogoProductos)
                {
                    if (nombre == item.NombreComercial.ToLower())
                    {
                        ExisteProducto = true;
                        break;
                    }
                    else ExisteProducto = false;
                }

            }
            return ExisteProducto; 
        }
        public void pasarDatos() 
        {
            try
            {
                Catalogo.ID_Producto = Convert.ToInt32(ID_Producto);
                if (String.IsNullOrEmpty(NombreComercial) || String.IsNullOrEmpty(Marca) || String.IsNullOrEmpty(NombreProveedor) || String.IsNullOrEmpty(Monodroga))
                {
                    throw new Exception("El nombre comercial, la monodroga, la marca y el nombre del proveedor no pueden estar vacios");
                }
                else
                {
                    Catalogo.NombreComercial = NombreComercial;
                    Catalogo.Monodroga = Monodroga;
                    Catalogo.Marca = Marca;
                    Catalogo.NombreProveedor = NombreProveedor;
                }
                if (String.IsNullOrEmpty(NombreProveedor) && ID_Proveedor == "0")
                {
                    throw new Exception("Debe indicar un proveedor para el producto");
                }
                else Catalogo.ID_Proveedor = Convert.ToInt32(ID_Proveedor);

                if (UnidadporLote == "0" || CompraMinima == "0")
                {
                    throw new Exception("Las unidades por lote y la compra mínima no pueden ser 0");
                }
                else
                {
                    Catalogo.UnidadporLote = Convert.ToInt32(UnidadporLote);
                    Catalogo.CompraMinima = Convert.ToInt32(CompraMinima);
                }
                if (String.IsNullOrEmpty(PrecioProveedor)) throw new Exception("Debe indicar el precio para el producto");
                else if (PrecioProveedor == "0") throw new Exception("Debe indicar el precio para el producto");
                else
                {
                    try
                    {
                        Catalogo.PrecioProveedor = Convert.ToDecimal(PrecioProveedor);
                    }
                    catch (Exception)
                    {

                        throw new Exception("Ingrese un valor numérico para el precio");
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

           
        }
        public void pasarDatos(bool Busqueda)
        {
            try
            {
                Catalogo.NombreComercial = NombreComercial;
                Catalogo.Monodroga = Monodroga;
                Catalogo.Marca = Marca;
                Catalogo.NombreProveedor = NombreProveedor;
                Catalogo.ID_Proveedor = Convert.ToInt32(ID_Proveedor);

                if (Busqueda)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(UnidadporLoteDesde)) UnidadporLoteDesde = int.MinValue.ToString();
                        Catalogo.UnidadporLoteDesde = Convert.ToInt32(UnidadporLoteDesde);

                        if (string.IsNullOrEmpty(UnidadporLoteHasta)) UnidadporLoteHasta = int.MaxValue.ToString();
                        Catalogo.UnidadporLoteHasta = Convert.ToInt32(UnidadporLoteHasta);

                        if (string.IsNullOrEmpty(CompraMinimaDesde)) CompraMinimaDesde = int.MinValue.ToString();
                        Catalogo.CompraMinimaDesde = Convert.ToInt32(CompraMinimaDesde);

                        if (string.IsNullOrEmpty(CompraMinimaHasta)) CompraMinimaHasta = int.MaxValue.ToString();
                        Catalogo.CompraMinimaHasta = Convert.ToInt32(CompraMinimaHasta);

                        if (string.IsNullOrEmpty(PrecioProveedorDesde)) PrecioProveedorDesde = decimal.MinValue.ToString();
                        Catalogo.PrecioProveedorDesde = Convert.ToDecimal(PrecioProveedorDesde);


                        if (string.IsNullOrEmpty(PrecioProveedorHasta)) PrecioProveedorHasta = decimal.MaxValue.ToString();
                        Catalogo.PrecioProveedorHasta = Convert.ToDecimal(PrecioProveedorHasta);

                    }
                    catch (Exception)
                    {

                        throw new Exception("Los campos de unidad por lote, compra minima y precio deben ser numéricos");
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }


        }
        #endregion
    }
}
