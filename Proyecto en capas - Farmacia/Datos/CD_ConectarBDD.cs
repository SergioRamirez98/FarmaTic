using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public abstract class CD_ConectarBDD
    {
        protected string VariableParaConectar = "data source=DESKTOP-JC9L6DB\\SQLEXPRESS; initial catalog=Farmatic; integrated security=True;";

        public SqlConnection conexion;
        public CD_ConectarBDD()
        {
            conexion = new SqlConnection(VariableParaConectar);
            conexion.Open();
        }
    }
}
