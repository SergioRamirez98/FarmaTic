﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CM_OrdenDeCompraPorItemsPDF
    {
        public string NombreComercial { get; set; }
        public string Monodroga { get; set; }
        public string Marca { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Subtotal { get; set; }        
    }
}