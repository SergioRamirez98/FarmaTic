using Datos;
using Modelo;
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
        List<CM_Bitacora> listaBitacora = new List<CM_Bitacora>();
        #region Properties
        public bool MinCaracteres { get; set; }
        public bool CaractEspecial { get; set; }
        public bool DatosPersonales { get; set; }
        public bool MayusMinus { get; set; }
        public bool NumerosYLetras { get; set; }
        public bool RepetirPass { get; set; }        
        public int AvisosVtoProductos { get; set; }
        public int CantMinimadeStock { get; set; }
        public int CantIntentosFallidos { get; set; }


        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public string Accion { get; set; }
        public string UserName { get; set; }

        #endregion

        public DataTable CargarConfiguracion() 
        {
            return sistema.Configuracion();           
        }
        public List<CM_Bitacora> MostrarBitacora() 
        {
            listaBitacora.Clear();
            listaBitacora = sistema.ObtenerBitacora();
            return listaBitacora;
        }
        public List<CM_Bitacora> BuscarBitacora() 
        {
            pasarDatos(); listaBitacora.Clear();
            return listaBitacora = sistema.Buscar();
        }
        public DataTable ObtenerAccion() 
        {
            return sistema.ObtenerAccionBitacora();
        }
        public void GuardarCambiosDeSeguridad()
        {
            pasarDatosSeguridad();
            sistema.GuardarCambiosSeguridad();
        }
        public void GuardarCambiosDeSistema()
        {
            pasarDatosSistema();
            sistema.GuardarCambiosSistema();
        }
        private void pasarDatosSeguridad() 
        {
            sistema.MinCaracteres= MinCaracteres;
            sistema.CaractEspecial= CaractEspecial;
            sistema.DatosPersonales= DatosPersonales;
            sistema.MayusMinus= MayusMinus;
            sistema.NumerosYLetras = NumerosYLetras;
            sistema.RepetirPass = RepetirPass;
            sistema.CantIntentosFallidos = CantIntentosFallidos;
        }
        private void pasarDatosSistema()
        {
            sistema.AvisosVtoProductos = AvisosVtoProductos;
            sistema.CantMinimadeStock = CantMinimadeStock;
        }
        private void pasarDatos() 
        {
            sistema.FechaDesde = Convert.ToDateTime(FechaDesde);
            sistema.FechaHasta = Convert.ToDateTime(FechaHasta);
           
            sistema.Accion = Convert.ToInt32(Accion);
            if (string.IsNullOrWhiteSpace(UserName)) sistema.UserName = "";
            else sistema.UserName = UserName;
            
    }
    }
}
