using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CM_DatosVenta
    {
        public string NombreProducto { get; set; }
        public string Monodroga { get; set; }
        public string Marca { get; set; }
        public int Cantidad { get; set; }
        public double PrecUnit { get; set; }
        public double Subtotal { get; set; }
        public double Descuento { get; set; }
        public double Total { get; set; }
    }
}
