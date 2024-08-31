using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public static class CSistema_NumyLetr
    {
        public static bool NumerosYLetras = CSistema_ConfiguracionSistema.NumerosYLetras;

        public static void NumYLetras(TextBox Txb_Pass, Label Lbl_MsjUsuario)
        {
            if (NumerosYLetras==true)
            {
                string Caracteres = Txb_Pass.Text;
                bool Numero = false;
                char[] caracArray = Caracteres.ToCharArray();
                foreach (char c in caracArray) 
                {
                    if (Char.IsDigit(c))
                    {
                        Numero = true;
                    }
                }
                if (Numero==false) 
                {
                    Lbl_MsjUsuario.Visible = true;
                    Lbl_MsjUsuario.ForeColor = Color.Red;
                    Lbl_MsjUsuario.Text = "La contraseña debe tener al menos un número";
                }
                else
                {
                    Lbl_MsjUsuario.ForeColor = Color.Green;
                }
            }        
        }
    }
}
