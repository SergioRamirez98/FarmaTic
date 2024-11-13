using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_Informes:CD_EjecutarSP
    {
        public string TipoAnalisis { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<CM_Informe> ListaInforme { get; set; } = new List<CM_Informe>();

        SqlParameter[] lista = null;
        public List<CM_Informe> MostrarInforme() 
        {
            DataTable dt = new DataTable();
            ListaInforme.Clear();
            string sSql = null;
            try
            {
                switch (TipoAnalisis)
                {
                    case "Balance general":
                        sSql = "SP_Informe_General";
                        break;
                    case "Ingresos":
                        sSql = "SP_Informe_Ventas";
                        break;
                    case "Egresos":
                        sSql = "SP_Informe_Compras";
                        break;
                    default:
                        sSql = "SP_Informe_General";
                        break;
                }

                SqlParameter param_FechaInicio = new SqlParameter("@FechaInicio", SqlDbType.DateTime);
                param_FechaInicio.Value = FechaInicio;
                SqlParameter param_FechaFin = new SqlParameter("@FechaFin", SqlDbType.DateTime);
                param_FechaFin.Value = FechaFin;
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                listaparametros.Add(param_FechaInicio);
                listaparametros.Add(param_FechaFin);                
                lista = listaparametros.ToArray();

                dt = ejecutar(sSql, lista, true);

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Informes||MostrarInforme");
            }
            if (dt.Rows.Count > 0) cargarInforme(dt);
            return ListaInforme;
        }
        private void cargarInforme(DataTable dt) 
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CM_Informe informe = new CM_Informe
                    {
                        Tipo = dr["Tipo"].ToString(),
                        ID= Convert.ToInt32(dr["ID"]),
                        Fecha = Convert.ToDateTime(dr["Fecha"]),
                        Total = Convert.ToDouble(dr["total"])
                    };

                    ListaInforme.Add(informe);
                }

            }
        }

    }
}
