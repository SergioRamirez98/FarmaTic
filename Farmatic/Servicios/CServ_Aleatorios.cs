using System;
using System.Text;

namespace Servicios
{
    
    public static class CServ_Aleatorios
    {       
        public static string PassAleatoria() 
        {
            string Caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!#$%&?¿";
            char[] caracArray = Caracteres.ToCharArray();

            Random random = new Random();
            int length = 10;
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int seleccion = random.Next(caracArray.Length);
                char randomCarac = caracArray[seleccion];
                result.Append(randomCarac); 
            }

            string resultado= result.ToString();
            return resultado; 

        }
    }
}
