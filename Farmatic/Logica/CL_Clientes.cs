using Datos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_Clientes
    {        
        CD_Clientes Clientes = new CD_Clientes();

        #region Properties
        public string ID_Persona { get; set; }
        public string ID_Categoria { get; set; }
        public string Comentarios { get; set; }
        public string FeAlta { get; set; }
        #endregion

        public void AltaCliente() 
        {
            pasarDatos();
            Clientes.InsertarCliente();
        }
        public void ModificarCliente() 
        {
            pasarDatos();
            Clientes.Modificar();
        }
        public DataTable ObtenerCategoria()
        {
            DataTable dt= Clientes.ObtenerCategoriasCmb();          
            return dt;
        }

        
        private void pasarDatos() 
        {
            if (ID_Persona== "0"||ID_Categoria=="0")
            {
                throw new Exception("No se ha asoaciado ninguna persona o categoria al cliente. Por favor intente nuevamente.");

            }
            else
            {
                Clientes.ID_Persona = Convert.ToInt32(ID_Persona);
                Clientes.ID_Categoria = Convert.ToInt32(ID_Categoria);
                Clientes.Comentarios = Comentarios;
                Clientes.FeAlta = Convert.ToDateTime(FeAlta);
            }
         
        }

    }
}
