using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesion
{
    public static class CSesion_PersonaSeleccionada
    {
        #region Properties
        public static string Nombre { get; set; }
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
        #endregion
        public static void ActualizaFormulario(DataTable dt, int ID_Persona)
        {
            if (dt.Rows.Count > 0)
            {
                DataRow fila = dt.Rows[0];
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
            }
        }

    }
}
