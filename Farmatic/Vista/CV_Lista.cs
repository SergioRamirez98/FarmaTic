using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vista
{
    public class CV_Lista
    {
        public String Nombre { get; set; }
        public String Abreviacion { get; set; }
        public String Pais { get; set; }
        public String AbreviacionPais { get; set; }


        public static List<CV_Lista> ObtenerIdiomas()
        {
            return new List<CV_Lista> {
                new CV_Lista
                {
                    Nombre = "Español",
                    Abreviacion = "es",
                    Pais = "Argentina",
                   AbreviacionPais = "AR"
                },
                new CV_Lista
                {
                    Nombre = "English",
                    Abreviacion = "en",
                    Pais = "Estados Unidos",
                    AbreviacionPais = "US"
                },
                new CV_Lista
                {
                    Nombre = "Deutsch",
                    Abreviacion = "de",
                    Pais = "Alemania",
                    AbreviacionPais = "DE"
                }
            };
        }

    }
}
