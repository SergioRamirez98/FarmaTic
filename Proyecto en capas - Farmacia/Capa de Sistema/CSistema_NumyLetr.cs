using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public static class CSistema_NumyLetr
    {
        public static bool NumerosYLetras { get; set; }

        public static void NumYLetras(TextBox Txb_Pass, Label Lbl_MsjUsuario)
        {
            if (NumerosYLetras==true)
            {
                string Caracteres = Txb_Pass.Text;
                bool Letra = false;
                bool Numero = false;
                char[] caracArray = Caracteres.ToCharArray();
                foreach (char c in caracArray) 
                {
                    if (Char.IsLetter(c))
                    {
                        Letra = true;
                    }
                    else if (Char.IsDigit(c))
                    {
                        Numero = true;
                    }
                }
                if (Numero==false|| Letra==false) 
                {
                    Lbl_MsjUsuario.Visible = true;
                    Lbl_MsjUsuario.Text = "La contraseña debe tener al menos una letra y un número";
                }

            }        
        }
    }
}
