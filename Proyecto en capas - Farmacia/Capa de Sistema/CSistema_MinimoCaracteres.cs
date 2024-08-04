using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Capa_de_Sistema;

namespace Sistema
{
    public static class CSistema_MinimoCaracteres
    {
        public static bool Caracteres = CSistema_ConfSistema.MinCaracteres;
        public static void CantCaracteres(TextBox Txb_Pass, Label Lbl_MsjUsuario)
        {
            if (Caracteres==true)
            {
                if ( Txb_Pass.TextLength < 8)
                {                    
                    Lbl_MsjUsuario.Visible = true;
                    Lbl_MsjUsuario.Text = "La contraseña ingresada debe ser mayor a 8 dígitos";
                    Lbl_MsjUsuario.ForeColor = Color.Red;
                }
                else 
                {
                    Lbl_MsjUsuario.ForeColor = Color.Green; 
                    Lbl_MsjUsuario.Visible= true;
                }

            }
        }
    }
}
