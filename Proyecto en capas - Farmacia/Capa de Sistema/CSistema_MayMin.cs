using Capa_de_Sistema;
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
        public static bool MayMin = CSistema_ConfSistema.MayusMinus;
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
                    
                    if (Minuscula && Mayuscula)
                    {
                        Txb_Pass.ForeColor = Color.Black;
                        break;
                    }
                }
                if (!Mayuscula)
                {                    
                    Lbl_MsjUsuario.Visible = true;
                    Lbl_MsjUsuario.Text = "La contraseña debe tener al menos una mayúscula";
                    Lbl_MsjUsuario.ForeColor = Color.Red;
                }
                else if (!Minuscula)
                {                 
                    Lbl_MsjUsuario.Visible = true;
                    Lbl_MsjUsuario.Text = "La contraseña debe tener al menos una minúscula";
                    Lbl_MsjUsuario.ForeColor= Color.Red;
                }
                else
                {
                    Lbl_MsjUsuario.Visible = true;
                    Lbl_MsjUsuario.Text = "La contraseña debe combinar mayúsculas y una minúsculas";
                    Lbl_MsjUsuario.ForeColor = Color.Green;
                }
            }
            
        }
    }
}
