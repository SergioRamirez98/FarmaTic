using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_Ventas
    {
        CD_Ventas Ventas = new CD_Ventas();

        List<CD_Ventas> Items = new List<CD_Ventas>();

        #region Properties

        public string ID_UsuarioVendedor { get; set; }
        public string ID_Cliente { get; set; }
        public string ID_Venta { get; set; }
        public string ID_Producto { get; set; }
        public string Cantidad { get; set; }
        public string PrecUnitario { get; set; }
        public string Subtotal { get; set; }
        public string FechaVenta { get; set; }
        public string TotalVenta { get; set; }
        public string Descuento { get; set; }
        public string TotalconDescuento { get; set; }
        public List<CL_Ventas> VentaItems {get;set;}

        #endregion
        public DataTable ObtenerClientes()
        {
            return Ventas.CargarClientes();
        }
        public DataTable BusquedaRapida(string Palabra, DataTable Dt) 
        {
            if (!string.IsNullOrEmpty(Palabra.ToLower()))
                { 
            DataTable resultadoFiltro = Dt.Clone();

                var ProductosEncontrados = Dt.AsEnumerable()

                        .Where(row => row.Field<string>("NombreProd").ToLower().Contains(Palabra) ||
                        row.Field<string>("NombreComercial").ToLower().Contains(Palabra) ||
                        row.Field<string>("Marca").ToLower().Contains(Palabra) ||
                        row.Field<string>("DescripProd").ToLower().Contains(Palabra) ||
                        row.Field<string>("Categoria").ToLower().Contains(Palabra) 
                        );
                foreach (var fila in ProductosEncontrados)
                {
                    resultadoFiltro.ImportRow(fila);
                }

            return resultadoFiltro;
            }
            else 
            {
                return Dt; 
            }
        }
        public int RealizarVenta()
        {
            try
            {
                pasarDatos();
                int Id= Ventas.InsertarVenta();
                return Id;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void RealizarVentaItem() 
        {
            try
            {
                pasarDatos(true);
                Ventas.InsertarVentaItem();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public double CalcularTotalConDescuento(double Desc, double totalventa) 
        {
            double Descuento = totalventa * (Desc/100);
            double total = totalventa - Descuento;
            return total;
        }
        public string CalcularTotalConDescuentoporItem(string Subtotal, double Desc) 
        {
            double subtotal=Convert.ToDouble(Subtotal);


            double Descuento= subtotal * (Desc/100);
            double total= subtotal - Descuento;
            return total.ToString() ;
        }
        private void pasarDatos()
        {
            Ventas.ID_UsuarioVendedor = Convert.ToInt32(ID_UsuarioVendedor);
            if (ID_Cliente!="0")
            {
                Ventas.ID_Cliente = Convert.ToInt32(ID_Cliente);
            }
            else
            {
                throw new Exception("Debe seleccionar un cliente para avanzar en la compra");
            }
            Ventas.FechaVenta = Convert.ToDateTime(FechaVenta);
            Ventas.TotalVenta = Convert.ToDecimal(TotalVenta);
            Ventas.Descuento = Convert.ToDecimal(Descuento);
        }
        private void pasarDatos(bool boleano)
        {
            if (true)
            {
                foreach (var item in VentaItems)
                {
                    CD_Ventas VentaItems = new CD_Ventas();
                    VentaItems.ID_Producto = Convert.ToInt32(item.ID_Producto);
                    VentaItems.ID_Venta = Convert.ToInt32(item.ID_Venta);
                    VentaItems.Cantidad = Convert.ToInt32(item.Cantidad);
                    VentaItems.PrecUnitario = Convert.ToDecimal(item.PrecUnitario);
                    VentaItems.Subtotal = Convert.ToDecimal(item.Subtotal);
                    VentaItems.TotalconDescuento = Convert.ToDecimal(item.TotalconDescuento);
                    Items.Add(VentaItems);

                }
                Ventas.Items = Items;
            }
        }
    }
}
            