using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CM_Bitacora
    {
        public int ID_Bitacora { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }
        public string Descripcion { get; set; }
    }
}
