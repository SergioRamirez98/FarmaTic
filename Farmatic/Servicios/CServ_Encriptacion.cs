using Org.BouncyCastle.Math;

using System;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;


namespace Servicios
{
    public static class CServ_Encriptacion
    {
        // Encripta una cadena
        public static string Encriptar(string atr_EncriptacionLogin)
        {
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(atr_EncriptacionLogin);
            string result = Convert.ToBase64String(encryted);
            return result;
        }
        public static string Encriptar(string atr_UserName, string PassAleatoria)
        {
            string Encriptar = atr_UserName + PassAleatoria;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(Encriptar);
            string result = Convert.ToBase64String(encryted);
            return result;
        }

        // Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncriptar(this string _cadenaAdesencriptar)
        {
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            string result = Encoding.Unicode.GetString(decryted);
            return result;
        }

        public static string SHA256(string atr_EncriptacionLogin)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            StringBuilder sb = new StringBuilder();
            byte[] stream = sha256.ComputeHash(encoding.GetBytes(atr_EncriptacionLogin));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        public static int convertiraCadena(string cadena)
        {
            string resultado = "";

            foreach (char c in cadena)
            {
                if (char.IsDigit(c))
                {
                    resultado += c;
                }
                else if (char.IsLetter(c))
                {                    
                    int valorDecimal = Convert.ToInt32(c.ToString(), 16);
                    resultado += valorDecimal.ToString();
                }
            }

          return  digitoVerificador(resultado);            
        }
        private static int digitoVerificador(string resultado)
        {
            int suma = 0;
            bool doble = false;

            
            for (int i = resultado.Length - 1; i >= 0; i--)
            {
                int digito = int.Parse(resultado[i].ToString());

                if (doble)
                {
                    digito *= 2;
                    if (digito > 9) digito -= 9;
                }

                suma += digito;
                doble = !doble; 
            }

            suma =suma % 10;
            return suma;
        }

    }
}
