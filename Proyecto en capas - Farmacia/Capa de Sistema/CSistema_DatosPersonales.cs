using System;
using System.Drawing;
using System.Windows.Forms;
using Sesion;

namespace Sistema
{
    public static class CSistema_DatosPersonales
    {        
        public static bool DatosPersonales { get;  set; }
        public static void PassDatosPersonales(TextBox Txb_Pass, Label Lbl_MensajeUsuario)
        {
            string Nombre = CSesion_SesionIniciada.Nombre.ToLower();            
            string Apellido = CSesion_SesionIniciada.Apellido.ToLower();
            string DNI = Convert.ToString(CSesion_SesionIniciada.Dni);
            string Domicilio = CSesion_SesionIniciada.Domicilio.ToLower();
            if (DatosPersonales ==true)
            {
                string Pass = Txb_Pass.Text.ToLower();
                if (Pass.Contains(Nombre) ||Pass.Contains(Apellido) ||
                    Pass.Contains(DNI) || Pass.Contains(Domicilio) )
                {
                    Lbl_MensajeUsuario.Visible = true;
                    Lbl_MensajeUsuario.Text = "La contraseña no puede contener datos personales";
                    Txb_Pass.ForeColor = Color.Red;
                }
            }
        }
    }
}
