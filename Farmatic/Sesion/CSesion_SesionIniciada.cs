using Servicios;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Sesion
{
    public static class CSesion_SesionIniciada
    {

        #region Properties
        public static bool SesionActiva { get; set ;}
        public static bool Es_Usuario { get; set; }
        public static string UserName { get; set; }
        public static string PassEncriptada { get; set; }
        public static int ID { get; set; }
        public static int VenceCada { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido { get; set; }
        public static string Dni { get; set; }
        public static string Correo { get; set; }
        public static string Sexo { get; set; }
        public static string Domicilio { get; set; }
        public static string Partido { get; set; }
        public static string Localidad { get; set; }
        public static string Nacionalidad { get; set; }
        public static int Telefono { get; set; }
        public static DateTime FeNacimiento { get; set; }
        public static string Comentario { get; set; }
        public static int ID_Familia { get; set; }
        public static string Pregunta1 { get; set; }
        public static string Respuesta1 { get; set; }
        public static string Pregunta2 { get; set; }
        public static string Respuesta2 { get; set; }
        public static string Pregunta3 { get; set; }
        public static string Respuesta3 { get; set; }
        public static string RolDescripcion { get; set; }
        public static int EstadoCuenta { get; set; }
        public static DateTime FeAlta { get; set; }
        public static bool NuevaPass { get; set; }
        public static bool CambioPass { get; set; }
        public static DateTime Fe_CambioPass { get; set; }
        #endregion

        #region Properties Permisos Usuario
        public static int ID_Usuario { get; set; }
        public static int ID_Rol { get; set; }
        public static string Descripcion { get; set; }
        public static List<CM_PermisosUsuarios> Permisos { get; set; } = new List<CM_PermisosUsuarios>();
        
        #endregion
        public static void CacheSesion(DataTable resultado)
        {
            if (resultado.Rows.Count > 0)
            {
                try
                {
                    SesionActiva = true;
                    DataRow fila = resultado.Rows[0];
                    Es_Usuario = true;
                    UserName = fila["UserName"].ToString();
                    PassEncriptada = fila["PassEncriptada"].ToString();
                    VenceCada = Convert.ToInt32(fila["DiasParaVencimiento"]);
                    Nombre = fila["Nombre"].ToString();
                    Apellido = fila["Apellido"].ToString();
                    Dni = fila["Documento"].ToString();
                  //  Correo = fila["Mail"].ToString();
                  //  Sexo = fila["Sexo"].ToString();
                    Domicilio = fila["Direccion"].ToString();
                   // Partido = fila["Partido"].ToString();
                   // Localidad = fila["Localidad"].ToString();
                   // Nacionalidad = fila["Pais"].ToString();
                    //Telefono = Convert.ToInt32(fila["Telefono"]);
                   // FeNacimiento = Convert.ToDateTime(fila["FeNacimiento"]);
                   // Comentario = fila["Comentarios"].ToString();
                  //  ID_Familia = Convert.ToInt32(fila["ID_Familia"]);
                    NuevaPass = Convert.ToBoolean(fila["NuevaPass"]);
                    if (resultado.Rows.Count == 3)
                    {
                        try
                        {
                            DataRow fila1 = resultado.Rows[1];
                            DataRow fila2 = resultado.Rows[2];
                            Pregunta1 = fila["Pregunta"].ToString();
                            Respuesta1 = fila["Respuesta"].ToString();
                            Pregunta2 = fila1["Pregunta"].ToString();
                            Respuesta2 = fila1["Respuesta"].ToString();
                            Pregunta3 = fila2["Pregunta"].ToString();
                            Respuesta3 = fila2["Respuesta"].ToString();
                            /*
                             */
                        }
                        catch (Exception)
                        {
                            throw new Exception("error al capturar las preguntas, el usuario debe responder primero.");
                        }
                    }

                  //  RolDescripcion = fila["Descripcion"].ToString();
                    EstadoCuenta = Convert.ToInt32(fila["ID_Estado"]);
                    FeAlta = Convert.ToDateTime(fila["FeAlta"]);
                    if (NuevaPass == false)
                    {
                        Fe_CambioPass = Convert.ToDateTime(fila["Fe_CambioPass"]);

                        DateTime fechaVencimiento = Fe_CambioPass.AddDays(VenceCada);

                        DateTime hoy = DateTime.Today;
                        if (VenceCada !=0)
                        {
                            if ((fechaVencimiento - hoy).Days <= 10) { CambioPass = true; }
                            else if (hoy >= fechaVencimiento)
                            {
                                bool pregunta = CServ_CambioDeClave.CambiarClave();
                                if (pregunta) CambioPass = true;

                            }

                        }
                    }
                }
                catch (Exception)
                {

                    throw new Exception("Error al vincular los datos en la base de datos");
                }
            }
        }
        public static void CachePermisos (DataTable Resultado)
        {
            Permisos.Clear();
            foreach (DataRow Row in Resultado.Rows)
            {
                CM_PermisosUsuarios PermisosdelUsuario = new CM_PermisosUsuarios
                {
                    ID_Usuario = Convert.ToInt32(Row["ID_Usuario"]),
                    ID_Rol = Convert.ToInt32(Row["ID_Rol"]),
                    Descripcion = Row["Descripcion"].ToString(),
                };
                Permisos.Add(PermisosdelUsuario);
            }
            DataRow fila = Resultado.Rows[0];
            ID_Usuario = Convert.ToInt32(fila["ID_Usuario"]);
        }
        public static void LimpiarCache()
        {
            if (SesionActiva == false)
            {
                Es_Usuario = false;
                UserName = null;
                PassEncriptada = null;
                VenceCada = 0;
                Nombre = null;
                Apellido = null;
                Dni = null;
                Correo = null;
                Sexo = null;
                Domicilio = null;
                Partido = null;
                Localidad = null;
                Nacionalidad = null;
                Telefono = 0;
                FeNacimiento = DateTime.Today;
                Comentario = null;
                ID_Familia = 0;
                Pregunta1 = null;
                Respuesta1 = null;
                Pregunta2 = null;
                Respuesta2 = null;
                Pregunta3 = null;
                Respuesta3 = null;
                RolDescripcion = null;
                EstadoCuenta = 0;
                FeAlta = DateTime.Today;
                NuevaPass = false;
                CambioPass = false;
                Fe_CambioPass = DateTime.Today;
                foreach (var item in Permisos)
                {
                    item.ID_Usuario = 0;
                    item.ID_Rol = 0;
                    item.Descripcion = null;
                }

            }
        }
    }
}