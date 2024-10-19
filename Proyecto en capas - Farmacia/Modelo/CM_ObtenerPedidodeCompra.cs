using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CM_ObtenerPedidodeCompra
    {
        public int ID_Pedido { get; set; }
        public string UserName { get; set; }
        public string NombreProveedor { get; set; }
        public DateTime Fecha_Pedido { get; set; }
        public double MontoPedido { get; set; }
        public string Estado { get; set; }
    }
}
