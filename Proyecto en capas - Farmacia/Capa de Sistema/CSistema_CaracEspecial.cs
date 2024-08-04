using Capa_de_Sistema;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public static class CSistema_CaracEspecial
    {
        public static bool CaractEspecial = CSistema_ConfSistema.CaractEspecial;
        
        public static void CacaterEspecial(TextBox Txb_Pass, Label Lbl_MsjUsuario)
        {
            if (CaractEspecial==true)
            {
                string Caracteres = Txb_Pass.Text;
                bool tieneCaracterEspecial = false;
                Lbl_MsjUsuario.Text = "La contraseña debe tener al menos un carácter especial";
                Lbl_MsjUsuario.Visible = true;
                foreach (char carac in Caracteres)
                {
                    if (Char.IsSymbol(carac))
                    {
                        tieneCaracterEspecial = true;
                        break;
                    }
                }

                if (tieneCaracterEspecial==false)
                {
                    Lbl_MsjUsuario.ForeColor = Color.Red;
                }
                else
                {
                    Lbl_MsjUsuario.ForeColor = Color.Green;
                }
            }

        }
    }
}
