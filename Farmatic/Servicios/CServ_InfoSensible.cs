using System.Collections.Generic;
using System.Windows.Forms;

namespace Servicios
{
    public static class CServ_InfoSensible
    {
        public static void Contrasena(TextBox txb, CheckBox Cbx) 
        {
            if (Cbx.Checked)
            {
                txb.PasswordChar = '\0';
                Cbx.Text = "Ocultar contraseña";
            }
            else
            {
                txb.PasswordChar = '*';
                Cbx.Text = "Mostrar contraseña";
            }
        }
        public static void Contrasena(TextBox Txb_Pass, TextBox Txb_ConfPass)
        {
            Txb_Pass.PasswordChar = '*';
            Txb_ConfPass.PasswordChar = '*';
        }
        public static void RespuestasUsuario(List<TextBox> Lista)
        {
            foreach (TextBox t in Lista) 
            { t.PasswordChar = '*'; }


        }
    }
}
