using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_Sistema
    {
        CD_Sistema sistema = new CD_Sistema();
        #region Properties
        public bool MinCaracteres { get; set; }
        public bool CaractEspecial { get; set; }
        public bool DatosPersonales { get; set; }
        public bool MayusMinus { get; set; }
        public bool NumerosYLetras { get; set; }
        #endregion

        public DataTable CargarConfiguracion() 
        {
            return sistema.Configuracion();           
        }

        public void GuardarCambios()
        {
            PasarDatos();
            sistema.GuardarCambios();
        }
        private void PasarDatos() 
        {
            sistema.MinCaracteres= MinCaracteres;
            sistema.CaractEspecial= CaractEspecial;
            sistema.DatosPersonales= DatosPersonales;
            sistema.MayusMinus= MayusMinus;
            sistema.NumerosYLetras= NumerosYLetras;
            
        }
    }
}
