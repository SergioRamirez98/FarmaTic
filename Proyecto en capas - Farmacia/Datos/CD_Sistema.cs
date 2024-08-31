using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema;

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
        public bool RepetirPass { get; set; }
        public int AvisosVtoProductos { get; set; }
        public int CantMinimadeStock { get; set; }
        public int CantIntentosFallidos { get; set; }
        
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
                    CSistema_ConfiguracionSistema.ConfigurarSistema(dt);
                }
                return dt;

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Sistema||Configuracion.");
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
                SqlParameter param_RepetirPass = new SqlParameter("@RepetirPass", SqlDbType.Bit);
                param_RepetirPass.Value = RepetirPass;
                SqlParameter param_AvisosVtoProductos = new SqlParameter("@AvisosVtoProductos", SqlDbType.Int);
                param_AvisosVtoProductos.Value = AvisosVtoProductos;
                SqlParameter param_CantMinimadeStock = new SqlParameter("@CantMinimadeStock", SqlDbType.Int);
                param_CantMinimadeStock.Value = CantMinimadeStock;
                SqlParameter param_CantIntentosFallidos = new SqlParameter("@CantIntentosFallidos", SqlDbType.Int);
                param_CantIntentosFallidos.Value = CantIntentosFallidos;
                
                List<SqlParameter> listaParametros = new List<SqlParameter>();

                listaParametros.Add(param_MinCaracteres);
                listaParametros.Add(param_CaractEspecial);
                listaParametros.Add(param_DatosPersonales);
                listaParametros.Add(param_MayusMinus);
                listaParametros.Add(param_NumerosYLetras);
                listaParametros.Add(param_RepetirPass);
                listaParametros.Add(param_AvisosVtoProductos);
                listaParametros.Add(param_CantMinimadeStock);
                listaParametros.Add(param_CantIntentosFallidos);

                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);
            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Sistema||GuardarCambios.");
            }

        }
    }
}
