using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using Modelo;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesion
{
    public static class CSesion_CacheStockMinimo
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
        public static List<CM_CargaStockMinimo> ListaStockMinimo { get; set; } = new List<CM_CargaStockMinimo>();

        public static void CargarStockMinimo(DataTable Dt)
        {
            foreach (DataRow Dr in Dt.Rows)
            {
                CM_CargaStockMinimo Productos = new CM_CargaStockMinimo
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

                ListaStockMinimo.Add(Productos);
            }
        }

    }
}
