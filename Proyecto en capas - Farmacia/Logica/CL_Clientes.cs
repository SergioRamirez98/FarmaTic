using Datos;
using Servicios;
using System;
using System.Collections.Generic;
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
        public string Categoria { get; set; }
        public string Comentarios { get; set; }
        public string FeAlta { get; set; }
        #endregion

        public void AltaCliente() 
        {
            PasarDatos();
            Clientes.InsertarCliente();
        }
        private void PasarDatos() 
        {
            Clientes.ID_Persona = Convert.ToInt32(ID_Persona);
            Clientes.Categoria = Categoria;
            Clientes.Comentarios = Comentarios;
            Clientes.FeAlta= Convert.ToDateTime(FeAlta);
         
        }
    }
}
