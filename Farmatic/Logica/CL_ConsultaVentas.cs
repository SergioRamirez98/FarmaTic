using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Logica
{
    public class CL_ConsultaVentas
    {
        CD_ConsultaVentas Consulta = new CD_ConsultaVentas();
        #region Properties
        public string Cliente { get; set; }
        public string PrecioDesde { get; set; }
        public string PrecioHasta { get; set; }
        public string FechaDesde{ get; set; }
        public string FechaHasta{ get; set; }
        #endregion

        public DataTable ConsultarVenta() 
        {
            pasarDatos();
            return Consulta.RealizarConsulta();
        }
        private void pasarDatos() 
        {
            try
            {
                Consulta.Cliente= Cliente;
                Consulta.FeDesde = Convert.ToDateTime(FechaDesde);
                Consulta.FeHasta = Convert.ToDateTime(FechaHasta);
                if (Consulta.FeHasta < Consulta.FeDesde) 
                {
                    throw new Exception("La fecha 'hasta' no puede ser mayor a la fecha 'desde'");
                }
                try
                {
                    if (string.IsNullOrEmpty(PrecioDesde)){ Consulta.PrecDesde = int.MinValue; } else Consulta.PrecDesde = Convert.ToDouble(PrecioDesde);
                    if (string.IsNullOrEmpty(PrecioHasta)) {  Consulta.PrecHasta = int.MaxValue; } else Consulta.PrecHasta = Convert.ToDouble(PrecioHasta);

                }
                catch (Exception)
                {

                    throw new Exception ("El precio debe ser un valor numérico.");
                }
                if (Consulta.PrecDesde> Consulta.PrecHasta)
                {
                    throw new Exception("El precio 'Hasta' no puede ser menor que el precio 'Desde'");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public DataTable VerVentaItems(int ID_Venta) 
        {
            return Consulta.VerVentaPorItems(ID_Venta);
        }

        public void EliminarVenta(int ID_Venta)
        {
            Consulta.EliminarVenta(ID_Venta);        
        }
    }
}
