using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_Ventas: CD_EjecutarSP
    {
        #region Properties
        public string ID_UsuarioVendedor { get; set; }
        public string ID_Cliente { get; set; }
        public string ID_Producto { get; set; }
        public string NombreProducto { get; set; }
        public string Marca { get; set; }
        public string Cantidad { get; set; }
        public string PrecUnitario { get; set; }
        public string Subtotal { get; set; }
        public string FechaVenta { get; set; }
        public string NumeroLote { get; set; }
        public string TotalVenta { get; set; }

        #endregion
    }
}
