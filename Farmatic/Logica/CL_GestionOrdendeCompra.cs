using Datos;
using Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_GestionOrdendeCompra
    {
        public CD_GestionOrdendeCompra OC = new CD_GestionOrdendeCompra();
        public List<CD_GestionOrdendeCompra> Items = new List<CD_GestionOrdendeCompra>();
        public List<CM_ObtenerPedidodeCompra> PedidosdeCompra { get; set; } = new List<CM_ObtenerPedidodeCompra>();
        public List<CM_Pedido> PedidosdeCompraItems { get; set; } = new List<CM_Pedido>();

        List<CM_OrdenDeCompraPorItemsPDF> ItemsOCDef = new List<CM_OrdenDeCompraPorItemsPDF>();

        #region Properties
        public string OrdenDeCompra { get; set; }
        public string ID_Pedido { get; set; }
        public string Proveedor { get; set; }
        public string Total { get; set; }

        public string PrecioUnitario { get; set; }
        public string Producto { get; set; }
        public string Cantidad { get; set; }
        public string Subtotal { get; set; }
        public List<CL_GestionOrdendeCompra> ListaItems { get; set; }
        #endregion

        public void EliminarPedido()
        {
            pasarDatos();
            OC.EliminarPedidodeCompra();
        }
        public int InsertarOrden()
        {
            pasarDatos();
            return OC.InsertarOC();
        }
        public void InsertarOrdenPorItems()
        {
            pasarDatos(true);
            OC.InsertarOCporItems();
        }

        public List<CM_OrdenDeCompraPorItemsPDF> ObtenerItemsOC(int oc) 
        {
            ItemsOCDef.Clear();
            return ItemsOCDef = OC.ObtenerOCPorItems(oc);
        }
        public List<CM_Pedido> MostrarPedidosPorItem(int ID)
        {
            PedidosdeCompraItems.Clear();
            PedidosdeCompraItems = OC.ObtenerPedidosPorItems(ID);
            return PedidosdeCompraItems;
        }
        public List<CM_ObtenerPedidodeCompra> MostrarPedidos()
        {
            PedidosdeCompra.Clear();
            PedidosdeCompra = OC.ObtenerPedidos();
            return PedidosdeCompra;
        }

        public List<CM_ObtenerPedidodeCompra> BuscarFiltrado(List<CM_ObtenerPedidodeCompra> Lista, string Palabra)
        {
            if (string.IsNullOrEmpty(Palabra))
            {
                return Lista; 
            }
            string palabraMayus=Palabra;
            string palabraMinus=Palabra.ToLower();
            var productosFiltrados = Lista
                .Where(p => p.UserName.ToLower().Contains(palabraMinus) ||
                             p.NombreProveedor.ToLower().Contains(palabraMinus) ||
                             p.Fecha_Pedido.ToString().Contains(palabraMayus) ||
                             p.MontoPedido.ToString().Contains(palabraMayus))
                .ToList();

            return productosFiltrados;
    }
        public List<CM_ObtenerPedidodeCompra> MostrarHistorialPedidos()
        {
            PedidosdeCompra.Clear();
            PedidosdeCompra = OC.ObtenerHistorialPedidos();
            return PedidosdeCompra;
        }
        private void pasarDatos()
        {
            OC.ID_Pedido = Convert.ToInt32(ID_Pedido);
            OC.Proveedor = Proveedor;
            OC.Total = Convert.ToDecimal(Total);
        }
        private void pasarDatos(bool booleano)
        {
            if (ListaItems.Count > 0 || ListaItems != null)
            {
                foreach (var item in ListaItems)
                {
                    CD_GestionOrdendeCompra ListaItems = new CD_GestionOrdendeCompra();
                    ListaItems.OrdenDeCompra = Convert.ToInt32(item.OrdenDeCompra);
                    ListaItems.Producto = item.Producto;
                    ListaItems.Cantidad = Convert.ToInt32(item.Cantidad);
                    ListaItems.PrecioUnitario = Convert.ToDecimal(item.PrecioUnitario);
                    ListaItems.Subtotal = Convert.ToDecimal(item.Subtotal);
                    Items.Add(ListaItems);
                }
                OC.Items = Items;
            }
        }
    }
}