using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Sistema
{
    public static class CSistema_MinimoCaracteres
    {
        public static bool Caracteres { get; set; } = true;
        public static void CantCaracteres(TextBox Txb_Pass, Label Lbl_CoincidePass)
        {
            if (Caracteres==true)
            {
                if (Txb_Pass == null || Txb_Pass.TextLength < 8)
                {
                    Txb_Pass.ForeColor = Color.Red;
                    Lbl_CoincidePass.Text = "La contraseña ingresada debe sermayor a 8 dígitos";
                }
                else { Txb_Pass.ForeColor = Color.Black; }

            }
        }
    }
}
