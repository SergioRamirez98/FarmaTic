using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Sesion
{
    public static class CSesion_PreguntasUsuarios
    {
        #region Atributo
        private static bool atr_SesionActiva = true;
        #endregion

        #region Properties
        public static bool SesionActiva { get => atr_SesionActiva; set { atr_SesionActiva = value; } }
        public static string UserName { get; set; }
        public static string Pregunta1 { get; set; }
        public static string Pregunta2 { get; set; }
        public static string Pregunta3 { get; set; }
        public static string Respuesta1 { get; set; }
        public static string Respuesta2 { get; set; }
        public static string Respuesta3 { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido { get; set; }
        public static string Documento { get; set; }
        public static string Direccion { get; set; }

        #endregion
        public static void CachePreguntas(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                DataRow fila = dt.Rows[0];
                DataRow fila1 = dt.Rows[1];
                DataRow fila2 = dt.Rows[2];
                UserName = fila["UserName"].ToString();
                Pregunta1 = fila["Pregunta"].ToString();
                Pregunta2 = fila1["Pregunta"].ToString();
                Pregunta3 = fila2["Pregunta"].ToString();
                Respuesta1 = fila["Respuesta"].ToString();
                Respuesta2 = fila1["Respuesta"].ToString();
                Respuesta3 = fila2["Respuesta"].ToString();
                Nombre = fila["Nombre"].ToString();
                Apellido = fila["Apellido"].ToString();
                Documento = fila["Documento"].ToString();
                Direccion = fila["Direccion"].ToString();
            }
            else
            {
                throw new Exception("Error al vincular los datos en la base de datos");
            }
        }

        public static void LimpiarCache()
        {
            if (atr_SesionActiva == false)
            {
                UserName = null;                
                Pregunta1 = null;
                Respuesta1 = null;
                Pregunta2 = null;
                Respuesta2 = null;
                Pregunta3 = null;
                Respuesta3 = null;

            }
        }
    }
}
