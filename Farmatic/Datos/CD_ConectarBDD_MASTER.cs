using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public abstract class CD_ConectarBDD_MASTER
    {
        // protected string VariableParaConectar = "data source=SERGIO\\SQLEXPRESS; initial catalog=Farmatic; integrated security=True;";
        protected string VariableParaConectar = "data source=(local)\\SQLEXPRESS; initial catalog=master; integrated security=True;";



        public SqlConnection conexion;
        public CD_ConectarBDD_MASTER()
        {
            try
            {
                conexion = new SqlConnection(VariableParaConectar);
                conexion.Open();

            }
            catch (Exception)
            {
                throw new Exception("Error al conectar con la base de datos.");   
            }
        }
    }
}
