using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_de_Sistema
{
    public static class CSistema_DatosPersonales
    {        
        public static bool DatosPersonales { get;  set; }
        public static void PassDatosPersonales(TextBox Txb_Pass, Label Lbl_MensajeUsuario)
        {
            if (DatosPersonales)
            {
                string Pass = Txb_Pass.Text;
                if (!string.IsNullOrEmpty(Pass))
                {

                }
            }
        }
    }
}
