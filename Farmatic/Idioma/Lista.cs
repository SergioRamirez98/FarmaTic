using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idioma
{
    public class Lista
    {
        public String Nombre { get; set; }
        public String Abreviacion { get; set; }
        public String Pais { get; set; }
        public String AbreviacionPais { get; set; }


        public static List<Lista> ObtenerIdiomas()
        {
            return new List<Lista> {
                new Lista
                {
                    Nombre = "Español",
                    Abreviacion = "es",
                    Pais = "Argentina",
                   AbreviacionPais = "AR"
                },
                new Lista
                {
                    Nombre = "English",
                    Abreviacion = "en",
                    Pais = "Estados Unidos",
                    AbreviacionPais = "US"
                }
            };
        }


    }
}
