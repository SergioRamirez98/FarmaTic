using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public static class CM_DatosOCDefinitiva
    {
        #region Properties Datos Proveedor
        public static string NombreProveedor { get; set; } //= "transdrogra";
        public static int MatriculaProveedor { get; set; }// = 9780;
        public static string CUITProveedor { get; set; }//= "467";
        public static string IVAProveedor { get; set; }//= "inscripto";
        public static bool IIBBProveedor { get; set; } //= true;

        public static string DireccionProv { get; set; }//= "Direcciondelproveedor";
        public static string CorreoProv { get; set; }//= "@gmail";
        public static string LocalidadProv { get; set; }//= "lomas";
        public static string PartidoProv { get; set; }//= "lomas";
        public static int TelefonoProv { get; set; }// = 123;
        #endregion

        #region Properties Datos OC
        public static string Usuario { get; set; }// ="marx";
        public static string NombreApellido { get; set; }// = "car";
        public static DateTime Fecha { get; set; }// = DateTime.Now;
        #endregion

        #region Properties Datos Empresa
        public static string  NombreEmpresa { get; set; }// = "burzaco";
        public static string DireccionFarma { get; set; }// = "Bilac2579";
        public static string DomicilioEntrega { get; set; }// = "Bilac2579";
        public static DateTime FechaInicioAct { get; set; }// =DateTime.Now;
        public static string CUITEmpresa { get; set; }// = "123";
        public static string PartidoFarma { get; set; }// = "Lomas";
        public static string LocalidadFarma { get; set; }// = "Lomas";

        #endregion

        public static void LimpiarDatos(bool buleano) 
        {
            NombreProveedor = null;
            MatriculaProveedor = 0;

            CUITProveedor = null;
            IVAProveedor = null;
            IIBBProveedor = false;

            DireccionProv = null;
            CorreoProv = null;
            LocalidadProv = null;
            PartidoProv = null;
            TelefonoProv = 0;

            Usuario = null;
            NombreApellido = null;
            Fecha = DateTime.Today;



            NombreEmpresa = null;
            DireccionFarma = null;
            DomicilioEntrega = null;
            FechaInicioAct = DateTime.Today;
            CUITEmpresa = null;
            PartidoFarma = null;
            LocalidadFarma = null;
        }
    }
}
