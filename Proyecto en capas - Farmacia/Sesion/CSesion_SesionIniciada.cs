using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Sesion
{
    public static class CSesion_SesionIniciada
    {
        #region Properties
        public static bool Es_Usuario { get; set; }
        public static string UserName { get; set; }
        public static string UserPass { get; set; }
        public static string Encriptacion { get; set; }
        public static int VenceCada { get; set; }
        public static string Nombre {get; set;}
        public static string Apellido { get; set; }
        public static string Dni { get; set; }
        public static string Correo { get; set; }
        public static string Sexo { get; set; }
        public static string Domicilio { get; set; }
        public static string Partido { get; set; }
        public static string Nacionalidad { get; set; }
        public static int Telefono { get; set; }
        public static DateTime FeNacimiento { get; set; }
        public static string Comentario { get; set; }
        public static string Familia { get; set; }
        public static string Pregunta1 { get; set; }
        public static string Respuesta1 { get; set; }
        public static string Pregunta2 { get; set; }
        public static string Respuesta2 { get; set; }
        public static string Pregunta3 { get; set; }
        public static string Respuesta3 { get; set; }
        public static string RolDescripcion { get; set; }
        public static string EstadoCuenta { get; set; }
        public static DateTime FeAlta { get; set; }
        public static bool NuevaPass { get; set; }
        public static bool CambioPass { get; set; }

        #endregion
        public static void CacheSesion(DataTable resultado)
        {
            if (resultado.Rows.Count > 0)
            {
                DataRow fila = resultado.Rows[0];
                Es_Usuario = true;
                UserName = fila["UserName"].ToString();
                UserPass = fila["UserPass"].ToString();
                Encriptacion= fila["Encriptacion"].ToString();
                VenceCada = Convert.ToInt32(fila["VenceCada"]);
                Nombre = fila["Nombre"].ToString();
                Apellido = fila["Apellido"].ToString();
                Dni = fila["Documento"].ToString();
                Correo = fila["Mail"].ToString();
                Sexo = fila["Sexo"].ToString();
                Domicilio = fila["Direccion"].ToString();
                Partido = fila["Localidad"].ToString();
                Nacionalidad = fila["Pais"].ToString();
                Telefono = Convert.ToInt32(fila["Telefono"]);
                FeNacimiento = Convert.ToDateTime(fila["FeNacimiento"]);
                Comentario = fila["Comentarios"].ToString();
                Familia = fila["Familia"].ToString();
                CambioPass = Convert.ToBoolean(fila["NuevaPass"]);
                NuevaPass = Convert.ToBoolean(fila["NuevaPass"]);
                if (NuevaPass==false)
                {
                    DataRow fila1 = resultado.Rows[1];
                    DataRow fila2 = resultado.Rows[2];
                    Pregunta1 = fila["Pregunta"].ToString();
                    Respuesta1 = fila["Respuesta"].ToString();
                    Pregunta2 = fila1["Pregunta"].ToString();
                    Respuesta2 = fila1["Respuesta"].ToString();
                    Pregunta3 = fila2["Pregunta"].ToString();
                    Respuesta3 = fila2["Respuesta"].ToString();
                }

                RolDescripcion = fila["Descripcion"].ToString();
                EstadoCuenta = fila["EstadoCuenta"].ToString();
                FeAlta = Convert.ToDateTime(fila["FeAlta"]);
                
            }
        }
    }
}
