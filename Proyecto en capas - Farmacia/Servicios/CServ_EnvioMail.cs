using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Capa_Servicios;

namespace Servicios
{
    public static class CServ_EnvioMail
    {
        #region Properties
        public static string Prop_UserName { get; set; }
            public static string Prop_PassAleatoria { get; set; }
            public static string Prop_Correo { get; set; }
        #endregion
        public static void EnviarCorreo()
        {            
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
                     
            string CorreoOrigen = "ramirez.98.sergio@gmail.com";
            string passCorreoOrigen = "nsmp vhqa lzat alqw";
            client.Credentials = new NetworkCredential(CorreoOrigen, passCorreoOrigen);
            
            MailMessage mensaje = new MailMessage();
            mensaje.From = new MailAddress(CorreoOrigen);
            mensaje.To.Add("sergio.delomas79@gmail.com"/*Prop_Correo*/);
            mensaje.Subject = "Credenciales de ingreso a Farmatic";
            mensaje.Body = "Estimado, espero se encuentre muy bien, en esta oportunidad queremos"
                + " brindarle sus credenciales de acceso al sistema Farmatic." +
                " " +
                "Usuario: " +Prop_UserName+
                " " +
                "Contraseña: " + Prop_PassAleatoria+
                " " +
                "por favor, respete mayúsculas, minúsculas, numeros y caracteres especiales. " +
                "Una vez dentro del sistema, deberá modificar su contraseña";

            try
            {
                client.Send(mensaje);
                Console.WriteLine("Correo electrónico enviado correctamente.");
                mensaje.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo electrónico: " + ex.Message);
            }
        }

    }
}
