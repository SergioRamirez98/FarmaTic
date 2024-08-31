using System;
using System.Drawing;
using System.Windows.Forms;
using Sesion;

namespace Sistema
{
    public static class CSistema_DatosPersonales
    {
        public static bool DatosPersonales = CSistema_ConfiguracionSistema.DatosPersonales;
        public static void PassDatosPersonales(TextBox Txb_Pass, Label Lbl_MensajeUsuario)
        {
            string Nombre, Apellido, DNI, Domicilio;
            if (CSesion_PreguntasUsuarios.Nombre== null) 
            {
                 Nombre = CSesion_SesionIniciada.Nombre.ToLower();
                 Apellido = CSesion_SesionIniciada.Apellido.ToLower();
                 DNI = Convert.ToString(CSesion_SesionIniciada.Dni);
                 Domicilio = CSesion_SesionIniciada.Domicilio.ToLower();
            }
            else
            {
                Nombre = CSesion_PreguntasUsuarios.Nombre.ToLower();
                Apellido = CSesion_PreguntasUsuarios.Apellido.ToLower();
                DNI = Convert.ToString(CSesion_PreguntasUsuarios.Documento);
                Domicilio = CSesion_PreguntasUsuarios.Direccion.ToLower();

            }
            if (DatosPersonales)
            {
                string Pass = Txb_Pass.Text.ToLower();
                if (Pass.Contains(Nombre) ||Pass.Contains(Apellido) ||
                    Pass.Contains(DNI) || Pass.Contains(Domicilio) || String.IsNullOrEmpty(Txb_Pass.Text))
                {
                    Lbl_MensajeUsuario.Visible = true;
                    Lbl_MensajeUsuario.Text = "La contraseña no puede contener datos personales";
                    Lbl_MensajeUsuario.ForeColor = Color.Red;
                }
                else 
                {
                    Lbl_MensajeUsuario.Visible = true;
                    Lbl_MensajeUsuario.Text = "La contraseña no puede contener datos personales";
                    Lbl_MensajeUsuario.ForeColor= Color.Green; }
            }
        }
    }
}
