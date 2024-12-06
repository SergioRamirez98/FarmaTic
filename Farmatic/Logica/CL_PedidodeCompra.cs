using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_PedidodeCompra
    {
        CD_PedidodeCompra Pedido= new CD_PedidodeCompra();
        List<CD_PedidodeCompra> CompraItems = new List<CD_PedidodeCompra>();

        #region Properties
        public string ID_Producto { get; set; }
        public string NombreComercial { get; set; }
        public string Monodroga { get; set; }
        public string Marca { get; set; }
        public string Proveedor { get; set; }
        public string Cantidad { get; set; }
        public string Precio { get; set; }
        public string Subtotal { get; set; }
        public string ID_Pedido { get; set; }
        public string TotalporProveedor { get; set; }
        public List<CL_PedidodeCompra> ProductosPorProveedor { get; set; }
        #endregion

        public int InsertarCompraProveedor() 
        {
            pasarDatos();
            return Pedido.InsertarCompraPorProveedor();
        }
        public void InsertarCompraItems(int ID) 
        {
            pasarDatos(ID);
            Pedido.InsertarCompraPorItems();
        }
        public bool Comparar(List<CM_Catalogo> pedidodecompra, int ProdSeleccionado)
        {
            bool SeRepite = false;
            foreach (var item in pedidodecompra)
            {
                int valor = item.ID_Producto;
                if (valor == ProdSeleccionado)
                { SeRepite = true; break; }

            }
            return SeRepite;
        }
        public List<CM_PedidosdeCompra> OrdenarPorProveedores(List<CM_PedidosdeCompra> Lista)
        {
            if (Lista != null)
            {
                var pedidosAgrupados = Lista
                    .GroupBy(p => p.Proveedor) 
                    .SelectMany(g => g.Select(p => new CM_PedidosdeCompra
                    {
                        ID_Producto = p.ID_Producto,
                        NombreComercial = p.NombreComercial,
                        Monodroga = p.Monodroga,
                        Marca = p.Marca,
                        Proveedor = g.Key,
                        Cantidad = p.Cantidad, 
                        PrecioUnitario = p.PrecioUnitario,
                        Subtotal = p.PrecioUnitario * p.Cantidad
                    }))
                    .OrderBy(p => p.Proveedor)
                    .ToList();

                return pedidosAgrupados;
            }
            else return Lista;
        }
        public List<CM_Catalogo> BusquedaRapida(string Palabra, List<CM_Catalogo> Lista)
        {
            string palabra = Palabra.ToLower();

            List<CM_Catalogo> ListaCompleta = Lista;
            if (!string.IsNullOrEmpty(palabra))
            {

                var ProductosEncontrados = Lista.Where(p =>
                p.NombreComercial.ToLower().Contains(palabra) ||
                p.Marca.ToLower().Contains(palabra) ||
                p.Monodroga.ToLower().Contains(palabra) ||
                p.Proveedor.ToLower().Contains(palabra)).ToList();
                return ProductosEncontrados;
            }
            else
            {
                return Lista;
            }

        }
        private void pasarDatos()
        {
            Pedido.Proveedor = Proveedor;
            Pedido.TotalporProveedor = Convert.ToDecimal(TotalporProveedor);
        }
        private void pasarDatos(int ID)
        {
            Pedido.Items.Clear();
            foreach (var item in ProductosPorProveedor)
                {
                CD_PedidodeCompra Items = new CD_PedidodeCompra();
                Items.ID_Producto = Convert.ToInt32(item.ID_Producto);
                Items.NombreComercial = item.NombreComercial;
                Items.Monodroga = item.Monodroga;
                Items.Marca = item.Marca;
                Items.Proveedor = item.Proveedor;
                Items.Cantidad = Convert.ToInt32(item.Cantidad);
                Items.Precio = Convert.ToDecimal(item.Precio);
                Items.Subtotal = Convert.ToDecimal(item.Subtotal);
                Items.ID_Pedido = ID;
                CompraItems.Add(Items);
            }
            Pedido.Items = CompraItems;
        }
    }
}