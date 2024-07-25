using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_de_Sistema
{
    public static class CSistema_CaracEspecial
    {
        public static bool CaracEspecial { get; set; }
        public static void CacaterEspecial(TextBox Txb_Pass, Label Lbl_MsjUsuario)
        {
            if (CaracEspecial)
            {
                string Caracteres = Txb_Pass.Text;
                bool tieneCaracterEspecial = false;

                foreach (char carac in Caracteres)
                {
                    if (Char.IsSymbol(carac))
                    {
                        tieneCaracterEspecial = true;
                        break;
                    }
                }

                if (!tieneCaracterEspecial)
                {
                    Txb_Pass.ForeColor = Color.Red;
                    Lbl_MsjUsuario.Visible = true;
                    Lbl_MsjUsuario.Text = "La contraseña debe tener al menos un carácter especial";
                }
                else
                {
                    Txb_Pass.ForeColor = Color.Black;
                    Lbl_MsjUsuario.Visible = false;
                }
            }

        }
    }
}
