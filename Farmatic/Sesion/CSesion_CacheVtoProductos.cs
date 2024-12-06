using System;
using System.Collections.Generic;
using System.Data;
using Servicios;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Sesion
{
    public static class CSesion_CacheVtoProductos
    {
        public static int ID_Producto { get; set; }
        public static string NombreProd { get; set; }
        public static string Marca { get; set; }
        public static string DescripProd { get; set; }
        public static int Cantidad { get; set; }
        public static double PrecUnit { get; set; }
        public static DateTime FeVtoProd { get; set; }
        public static int NumLote { get; set; }
        public static string Categoria { get; set; }
        public static List<CM_CargaProductos> ListaVtoProductos { get; set; } = new List<CM_CargaProductos>();

        public static void CargarProductosVencidos(DataTable Dt)
        {
            foreach (DataRow Dr in Dt.Rows) 
            {
                CM_CargaProductos Productos = new CM_CargaProductos
                {
                    ID_Producto = Convert.ToInt32(Dr["ID_Producto"]),
                    NombreProd = Dr["NombreProd"].ToString(),
                    Marca = Dr["Marca"].ToString(),
                    DescripProd = Dr["DescripProd"].ToString(),
                    Cantidad = Convert.ToInt32(Dr["Cantidad"]),
                    PrecUnit = Convert.ToDouble(Dr["PrecUnit"]),
                    FeVtoProd = Convert.ToDateTime(Dr["FeVtoProd"]),
                    NumLote = Convert.ToInt32(Dr["NumLote"]),
                    Categoria = Dr["Categoria"].ToString(),
                };

                ListaVtoProductos.Add(Productos);
            }
        }

    }
}
