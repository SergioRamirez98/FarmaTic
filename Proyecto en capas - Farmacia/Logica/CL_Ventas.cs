using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_Ventas
    {
        public DataTable BusquedaRapida(string Palabra, DataTable Dt) 
        {
            if (!string.IsNullOrEmpty(Palabra.ToLower()))
                { 
            // Crea un nuevo DataTable con la misma estructura que el DataTable original
            DataTable resultadoFiltro = Dt.Clone();

            // Filtra las filas usando LINQ
            //AsEnumerable convierte al dt en un objeto legible para LINQ, sino no se puede ejecutar
            var ProductosEncontrados = Dt.AsEnumerable()                    
                                                         
                    .Where(row => row.Field<string>("NombreProd").ToLower().Contains(Palabra) || 
                    row.Field<string>("Marca").ToLower().Contains(Palabra) ||     
                    row.Field<string>("DescripProd").ToLower().Contains(Palabra)||
                    row.Field<string>("Categoria").ToLower().Contains(Palabra));
                //Row.Field lo que hace es leer el campo, en este caso
                //la fila que se ubique en nombProd y que contenga
                //lapalabra que yo le paso por parámetro

                // Agrega las filas filtradas al nuevo DataTable
                foreach (var fila in ProductosEncontrados)
                {
                    resultadoFiltro.ImportRow(fila);
                }

            return resultadoFiltro;
            }
            else { return Dt; }
        }
    }
}
            