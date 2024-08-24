using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Cserv_CargaProductos
    {
        public int ID_Producto { get; set; }
        public string NombreProd { get; set; }
        public string Marca { get; set; }
        public string DescripProd { get; set; }
        public int Cantidad { get; set; }
        public double PrecUnit { get; set; }
        public DateTime FeVtoProd { get; set; }
        public int NumLote { get; set; }
        public string Categoria { get; set; }
    }
}
