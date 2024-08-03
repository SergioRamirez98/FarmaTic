﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Sistema
{
    public static class CSistema_ConfSistema
    {
        public static bool MinCaracteres { get; set; }
        public static bool CaractEspecial { get; set; }
        public static bool DatosPersonales { get; set; }   
        public static bool MayusMinus { get; set; }
        public static bool NumerosYLetras { get; set; }
        public static void ConfigurarSistema(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                DataRow fila = dt.Rows[0];
                MinCaracteres = Convert.ToBoolean(fila["Min_Caracteres"]);
                CaractEspecial = Convert.ToBoolean(fila["Caract_Especial"]);
                DatosPersonales = Convert.ToBoolean(fila["Datos_Pers"]);
                MayusMinus = Convert.ToBoolean(fila["May_Min"]);
                NumerosYLetras = Convert.ToBoolean(fila["Numeros"]);
            }
        }


    }
    
}
