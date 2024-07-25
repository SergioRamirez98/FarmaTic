using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public static class CSistema_MayMin
    {
        public static bool MayMin { get; set; }
        public static void CombinarMayMin(TextBox Txb_Pass, Label Lbl_MsjUsuario)
        {
            if (MayMin) 
            {
                bool Mayuscula = false;
                bool Minuscula = false;
                string Caracteres = Txb_Pass.Text;
                char[] caracArray = Caracteres.ToCharArray();
                foreach (char carac in caracArray)
                {
                    if (Char.IsUpper(carac))
                    {
                        Mayuscula = true;
                    }
                    else if (Char.IsLower(carac))
                    {
                        Minuscula = true;
                    }

                    // Si ya hemos encontrado al menos una mayúscula y una minúscula, podemos salir del bucle
                    if (Minuscula && Mayuscula)
                    {
                        Txb_Pass.ForeColor = Color.Black;
                        break;
                    }
                }
                if (!Mayuscula)
                {
                    Txb_Pass.ForeColor = Color.Red;
                    Lbl_MsjUsuario.Visible = true;
                    Lbl_MsjUsuario.Text = "La contraseña debe tener al menos una mayúscula";
                }
                else if (!Minuscula)
                {
                    Txb_Pass.ForeColor = Color.Red;
                    Lbl_MsjUsuario.Visible = true;
                    Lbl_MsjUsuario.Text = "La contraseña debe tener al menos una minúscula";
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
