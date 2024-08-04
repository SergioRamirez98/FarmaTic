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
        #region Atributo
        private static bool atr_SesionActiva=true;
        #endregion

        #region Properties
        public static bool SesionActiva { get => atr_SesionActiva;set { atr_SesionActiva = value; } }

        public static string Nombre { get; set; }
        public static string Apellido { get; set; }
        public static int Dni { get; set; }
        public static string Correo { get; set; }
        public static string Sexo { get; set; }
        public static string Domicilio { get; set; }
        public static string Partido { get; set; }
        public static string Nacionalidad { get; set; }
        public static int Telefono { get; set; }
        public static DateTime FeNacimiento { get; set; }
        public static string Comentario { get; set; }

        public static string UserName { get; set; }
        public static string PassEncriptada { get; set; }
        public static int VenceCada { get; set; }
        public static string Familia { get; set; }
        public static string Pregunta1 { get; set; }
        public static string Pregunta2 { get; set; }
        public static string Pregunta3 { get; set; }
        public static string Respuesta1 { get; set; }
        public static string Respuesta2 { get; set; }
        public static string Respuesta3 { get; set; }
        public static string Descripcion { get; set; }
        public static string EstadoCuenta { get; set; }
        public static DateTime FeAlta { get; set; }
        public static bool NuevaPass { get; set; }
        public static DateTime Fe_CambioPass { get; set; }

        #endregion
        public static void ActualizaFormularioPersonas(DataTable dt)
        {
            try
            {

                if (dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];
                    Nombre = fila["Nombre"].ToString();
                    Apellido = fila["Apellido"].ToString();
                    Dni = Convert.ToInt32(fila["Documento"]);
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
            catch (Exception)
            {

                throw new Exception("Error al recuperar los datos de la persona en la base de datos");
            }
        }
        public static void ActualizaFormularioUsuarios(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];
                    DataRow fila1 = dt.Rows[1];
                    DataRow fila2 = dt.Rows[2];
                    UserName = fila["UserName"].ToString();
                    PassEncriptada = fila["PassEncriptada"].ToString();
                    VenceCada = Convert.ToInt32(fila["VenceCada"]);
                    Familia = fila["Familia"].ToString();
                    Pregunta1 = fila["Pregunta"].ToString();
                    Respuesta1 = fila["Respuesta"].ToString();
                    Pregunta2 = fila1["Pregunta"].ToString();
                    Respuesta2 = fila1["Respuesta"].ToString();
                    Pregunta3 = fila2["Pregunta"].ToString();
                    Respuesta3 = fila2["Respuesta"].ToString();
                    Descripcion = fila["Descripcion"].ToString();
                    EstadoCuenta = fila["EstadoCuenta"].ToString();
                    FeAlta = Convert.ToDateTime(fila["FeAlta"]);
                    NuevaPass = Convert.ToBoolean(fila["NuevaPass"]);
                    Fe_CambioPass = Convert.ToDateTime(fila["Fe_CambioPass"]);
                }
                else
                {
                    Console.WriteLine("No se encontró ningun registro, debe registarse");
                }

            }
            catch (Exception)
            {

                throw new Exception("Error al repuerar los datos de la persona, como usuario en la base de datos");
            }
        }

        public static void LimpiarCache() 
        {
            if (atr_SesionActiva ==false)
            {
                UserName = null;
                PassEncriptada = null;
                Nombre = null;
                Apellido = null;
                Dni = 0;
                Correo = null;
                Sexo = null;
                Domicilio = null;
                Partido = null;
                Nacionalidad = null;
                Telefono = 0;
                FeNacimiento = DateTime.Today;
                Comentario = null;
                VenceCada = 0;
                Familia = null;
                Pregunta1 = null;
                Respuesta1 = null;
                Pregunta2 = null;
                Respuesta2 = null;
                Pregunta3 = null;
                Respuesta3 = null;
                Descripcion = null;
                EstadoCuenta=null;
                FeAlta = DateTime.Today;
                NuevaPass = false;
                Fe_CambioPass = DateTime.Today;
            }
        }

    }
}
