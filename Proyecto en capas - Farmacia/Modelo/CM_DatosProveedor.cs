using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CM_DatosOCDefinitiva
    {
        #region Properties Datos Proveedor
        public string DireccionProv { get; set; }
        public string CorreoProv { get; set; }
        public string LocalidadProv { get; set; }
        public string PartidoProv { get; set; }
        public int TelefonoProv { get; set; }
        #endregion
        #region Properties Datos OC
        public string Usuario { get; set; }
        public string NombreApellido { get; set; }
        public DateTime Fecha { get; set; }
        #endregion
        #region Properties Datos Empresa
        public string  NombreEmpresa { get; set; }
        public string DireccionFarma { get; set; }
        public string DomicilioEntrega { get; set;  }
        public DateTime FechaInicioAct { get; set; }
        public string PartidoFarma { get; set; }
        public string LocalidadFarma { get; set; }

        #endregion
    }
}
