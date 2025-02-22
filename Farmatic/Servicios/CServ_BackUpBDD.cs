using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Servicios
{
    public static class CServ_BackUpBDD
    {
        #region properties
        public static DateTime FechaUltimoRespaldo { get; set; }
        #endregion
        public static string CrearCarpetaBackUp()
        {
            string carpetaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string carpetaBase = Path.Combine(carpetaDocumentos, "Farmatic");
            if (!Directory.Exists(carpetaBase))
            {
                Directory.CreateDirectory(carpetaBase);
            }
            string carpetaEspecifica = Path.Combine(carpetaBase, "Back up");
            if (!Directory.Exists(carpetaEspecifica))
            {
                Directory.CreateDirectory(carpetaEspecifica);
            }
                        
            return carpetaEspecifica;
        }
        public static void CargarBackUps(DataGridView DTGV) 
        {
            string carpetaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string carpetaBackup = Path.Combine(carpetaDocumentos, "Farmatic", "Back up");

            if (Directory.Exists(carpetaBackup))
            {
                string[] archivosBackup = Directory.GetFiles(carpetaBackup, "*.bak");
                DTGV.Rows.Clear();               
                foreach (var archivo in archivosBackup)
                {
                    DTGV.Rows.Add(Path.GetFileName(archivo));
                }
            }
        }
        public static string ObtenerUbicacionBackup(string nombreArchivo)
        {
            string carpetaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string carpetaBackup = Path.Combine(carpetaDocumentos, "Farmatic", "Back up");
            try
            {
                if (Directory.Exists(carpetaBackup))
                {
                    string rutaCompleta = Path.Combine(carpetaBackup, nombreArchivo);

                    if (File.Exists(rutaCompleta))
                    {
                        return rutaCompleta;
                    }
                    else
                    {
                        throw new Exception($"El archivo {nombreArchivo} no se encuentra en la ubicación esperada.");
                    }
                }
                else
                {
                    throw new Exception("La carpeta de backups no se encuentra.");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool ListadeBackUps()
        {
            bool Resultado= false;
            string carpetaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string carpetaBackup = Path.Combine(carpetaDocumentos, "Farmatic", "Back up");

            if (Directory.Exists(carpetaBackup))
            {
                string[] archivosBackup = Directory.GetFiles(carpetaBackup, "*.bak");
                foreach (var archivo in archivosBackup)
                {
                    DateTime fechaCreacion = File.GetCreationTime(archivo);
                    DateTime fechaHoy = DateTime.Today;
                    if (fechaCreacion.Date == fechaHoy)
                    {
                        TimeSpan diferencia = DateTime.Now - fechaCreacion;

                        if (diferencia.TotalHours < 8)
                        {
                            FechaUltimoRespaldo = fechaCreacion;
                            Resultado = true;
                            break;
                        }
                        else
                        {
                            Resultado = false;
                        }
                    }
                }
            }
            return Resultado;
        }
    }
}
