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
    public class CL_Informes
    {
        CD_Informes Informes = new CD_Informes();
        public string TipoAnalisis { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public List<CM_Informe> ListaInforme { get; set; } = new List<CM_Informe>();
        public List<CM_Informe> RealizarConsulta() 
        {
            ListaInforme.Clear();
            pasarDatos();
            return Informes.MostrarInforme();
        }
        private void pasarDatos() 
        {
            Informes.TipoAnalisis = TipoAnalisis;
            Informes.FechaInicio = Convert.ToDateTime(FechaInicio);
            Informes.FechaFin = Convert.ToDateTime(FechaFin);
        }

        public List<CM_Informe> CalcularPorFecha(List<CM_Informe> ListaInforme) 
        {
            List<CM_Informe> nuevolistado = new List<CM_Informe>();
            foreach (var item in ListaInforme)
            {
                if (item.Tipo == "Compra")
                {
                    bool encontrado = false;
                    foreach (var informe in nuevolistado)
                    {
                        if (informe.Tipo == "Compra" && informe.Fecha.Date == item.Fecha.Date)
                        {
                            informe.Total += item.Total;
                            encontrado = true;
                            break; 
                        }
                    }

                    if (!encontrado)
                    {
                        nuevolistado.Add(new CM_Informe
                        {
                            Fecha = item.Fecha.Date,
                            Total = item.Total,
                            Tipo = "Compra"
                        });
                    }
                }
                else if (item.Tipo == "Venta")
                {
                    bool encontrado = false;
                    foreach (var informe in nuevolistado)
                    {
                        if (informe.Tipo == "Venta" && informe.Fecha.Date == item.Fecha.Date)
                        {
                            informe.Total += item.Total;
                            encontrado = true;
                            break;
                        }
                    }

                    if (!encontrado)
                    {
                        nuevolistado.Add(new CM_Informe
                        {
                            Fecha = item.Fecha.Date,
                            Total = item.Total,
                            Tipo = "Venta"
                        });
                    }
                }
            
            }
            return nuevolistado;
        }
    }
}