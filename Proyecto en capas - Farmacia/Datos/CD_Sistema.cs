using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_Sistema;

namespace Datos
{
    public class CD_Sistema: CD_EjecutarSP
    {
        #region Properties
        public bool MinCaracteres { get; set; }
        public bool CaractEspecial { get; set; }
        public bool DatosPersonales { get; set; }
        public bool MayusMinus { get; set; }
        public bool NumerosYLetras { get; set; }
        public int AvisosVtoProductos { get; set; }
        SqlParameter [] lista = null;

        #endregion
        public DataTable Configuracion()
        {
            string sSql = "SP_Obtener_Configuracion";
            try
            {
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                SqlParameter[] parametros = listaparametros.ToArray();
                DataTable dt = new DataTable();
                dt = ejecutar(sSql, parametros, true);
                if (dt.Rows.Count > 0)
                {
                    CSistema_ConfSistema.ConfigurarSistema(dt);
                }
                return dt;

            }
            catch (Exception)
            {
                throw new Exception("Error al recuperar la configuración");
            }
        }

        public void GuardarCambios() 
        {
            try
            {
                string sSql = "SP_Guardar_Config";

                SqlParameter param_MinCaracteres = new SqlParameter("@MinCaracteres", SqlDbType.Bit);
                param_MinCaracteres.Value = MinCaracteres;
                SqlParameter param_CaractEspecial = new SqlParameter("@CaractEspecial", SqlDbType.Bit);
                param_CaractEspecial.Value = CaractEspecial;
                SqlParameter param_DatosPersonales = new SqlParameter("@DatosPers", SqlDbType.Bit);
                param_DatosPersonales.Value = DatosPersonales;
                SqlParameter param_MayusMinus = new SqlParameter("@MayusMinus", SqlDbType.Bit);
                param_MayusMinus.Value = MayusMinus;
                SqlParameter param_NumerosYLetras = new SqlParameter("@NumerosYLetras", SqlDbType.Bit);
                param_NumerosYLetras.Value = NumerosYLetras;
                SqlParameter param_AvisosVtoProductos = new SqlParameter("@AvisosVtoProductos", SqlDbType.Int);
                param_AvisosVtoProductos.Value = AvisosVtoProductos; 
                List<SqlParameter> listaParametros = new List<SqlParameter>();

                listaParametros.Add(param_MinCaracteres);
                listaParametros.Add(param_CaractEspecial);
                listaParametros.Add(param_DatosPersonales);
                listaParametros.Add(param_MayusMinus);
                listaParametros.Add(param_NumerosYLetras);

                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);
            }
            catch (Exception)
            {

                throw new Exception("Error al guardar en la base de datos.");
            }

        }
    }
}
