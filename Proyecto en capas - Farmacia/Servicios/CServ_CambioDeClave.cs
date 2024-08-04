using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public static class CServ_CambioDeClave
    {
        public static bool CambiarClave()
        {
            bool pregunta=  CServ_MsjUsuario.Preguntar("tenes que cambiar la clave papi");
            return pregunta;
        }

    }
}
