using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Servicios
{
    public static class CServ_BackUpBDD
    {
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
    }
}
