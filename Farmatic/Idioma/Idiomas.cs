﻿using Vista.Properties;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Vista;

namespace Idioma
{
    public class Idiomas
    {
        public String Nombre { get; set; }
        public String Abreviacion { get; set; }
        public String Pais { get; set; }
        public String AbreviacionPais { get; set; }
        public String NombrePais { get => Nombre + "(" + Pais + ")"; }
        //public String NombrePais { get { return Nombre + "(" + Pais + ")"; } }
        public String InfoCultura { get => Abreviacion + "-" + AbreviacionPais; }

        public static List<Idiomas> ObtenerIdiomas()
        {
            return new List<Idiomas> {
                new Idiomas
                {
                    Nombre = "Español",
                    Abreviacion = "es",
                    Pais = "Argentina",
                    AbreviacionPais = "AR"
                },
                new Idiomas
                {
                    Nombre = "English",
                    Abreviacion = "en",
                    Pais = "Estados Unidos",
                    AbreviacionPais = "US"
                }
            };
        }

        public static void CargarIdioma(Control.ControlCollection controls, Form frm)
        {
            //Este metodo recibe dos parametros, 
            //Asigno el idioma a utilizar 
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Settings.Default.Idioma);
            //Llamo al metodo interno pasandole los parametros necesarios
            //para que cambie los nombres de los objetos
            CambiarTexto(controls, frm);
        }

        private static void CambiarTexto(Control.ControlCollection controls, Form frm)
        {
            frm.Text = Strings.ResourceManager.GetString(frm.Name);
           
            foreach (Control c in controls)
            {
                if (c is Panel | c is GroupBox)
                {
                    CambiarTexto(c.Controls, frm);
                }
                String text = Strings.ResourceManager.GetString(c.Name);
                if (text != null)
                {
                    c.Text = text;
                }
            }
        }
    }

}
