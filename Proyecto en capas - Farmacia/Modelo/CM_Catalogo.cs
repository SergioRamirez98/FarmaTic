using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CM_Catalogo
    {
        public int ID_Producto { get; set; }  
        public string NombreComercial { get; set; }
        public string Monodroga { get; set; }
        public string Marca { get; set; }
        public string Proveedor { get; set; }
        public int UnidadporLote { get; set; }
        public int CompraMinima { get; set; }
        public double PrecioProveedor { get; set; }
        
    }
}
