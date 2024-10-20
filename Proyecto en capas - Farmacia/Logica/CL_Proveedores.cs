using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_Proveedores
    {

        #region Atributos
        CD_Proveedores Proveedores = new CD_Proveedores();
        DataTable Dt = new DataTable();

        #endregion

        #region Properties
        public string ID_Proveedor { get; set; }
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string Matricula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Partido { get; set; } //Localidad
        public string Localidad { get; set; } 
        public string Mail { get; set; }
        public string IVA { get; set; }
        public string IIBB { get; set; }
        #endregion

        #region Métodos
        public DataTable MostrarProveedores()
        {
            return Dt=Proveedores.MostrarProveedores();
        }
        public DataTable ObtenerIVA()
        {
            return Proveedores.MostrarIVA();
        }
        public DataTable BuscarProveedor()
        {
            pasarDatos(true);
            return Proveedores.Buscar();
        }

        public void EliminarProveedor() 
        {
            Proveedores.ID_Proveedor = Convert.ToInt32(ID_Proveedor);
            Proveedores.Eliminar();        
        }

        public void InsertarProveedor() 
        {
            pasarDatos();
            Proveedores.Insertar();
        }
        public void InsertarCambios() 
        {
            pasarDatos();
            Proveedores.GuardarCambios();
        }
        public bool ConsultarCUIT(string CUIT, DataTable Dt)
        {
            bool ExisteLote = false;
            foreach (DataRow item in Dt.Rows)
            {
                if (CUIT == item[5].ToString())
                {
                    ExisteLote = true;
                    break;
                }
                else { ExisteLote = false; }
            }
            return ExisteLote;

        }
        private void pasarDatos() 
        {
            if (ID_Proveedor!= null)
            {
                Proveedores.ID_Proveedor = Convert.ToInt32(ID_Proveedor);
            }
            Proveedores.Mail = Mail;            
            Proveedores.Direccion = Direccion;
            Proveedores.IIBB = Convert.ToBoolean(IIBB);            
            try
            {
                if (RazonSocial == "" || CUIT == "") throw new Exception("Los campos Razon social y CUIT no pueden estar vacios");
                else Proveedores.RazonSocial = RazonSocial;
                try {Proveedores.CUIT = Convert.ToInt64(CUIT); }
                catch (Exception) { throw new Exception ("Por favor ingrese un numero de CUIT válido"); }
                


                if (Proveedores.CUIT >99999999999|| Proveedores.CUIT < 99999999) throw new Exception("Por favor ingrese un numero de CUIT valido");
             
                if (Matricula != "") Proveedores.Matricula = Convert.ToInt32(Matricula);
                else throw new Exception("Por favor, ingrese un numero de matrícula válido");

                if (Telefono !="") Proveedores.Telefono = Convert.ToInt32(Telefono);               
                else Proveedores.Telefono = 0;

                if (Partido != "") Proveedores.Partido = Partido;
                else throw new Exception("Por favor seleccione la Partido a la que pertenece el proveedor");
                if (string.IsNullOrEmpty(Localidad)) Proveedores.Localidad = "Homónimo";
                else Proveedores.Localidad = Localidad;


                if (IVA != "") Proveedores.IVA = IVA;
                else throw new Exception("Por favor seleccione la condicion frente al IVA del proveedor");
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void pasarDatos(bool consulta)
        {
            
            Proveedores.RazonSocial = RazonSocial;
            Proveedores.Mail = Mail;
            Proveedores.Direccion = Direccion;
            Proveedores.IIBB = Convert.ToBoolean(IIBB);
            if (CUIT == "") Proveedores.CUIT = 0; else  Proveedores.CUIT = Convert.ToInt64(CUIT);
            if (Matricula == "") Proveedores.Matricula = 0; else Proveedores.Matricula = Convert.ToInt32(Matricula);
            if (Telefono == "") Proveedores.Telefono = 0; else Proveedores.Telefono = Convert.ToInt32(Telefono);
            Proveedores.Partido = Partido;
            Proveedores.IVA = IVA;
        }

        public DataTable BusquedaRapida(string Palabra)
        {

            Palabra = Palabra.ToLower();

            if (!string.IsNullOrEmpty(Palabra))
            {
                DataTable resultadoFiltro = Dt.Clone();

                var PersonasEncontrados = Dt.AsEnumerable()

                        .Where(row => row.Field<string>("Nombre").ToLower().Contains(Palabra) ||
                        row.Field<string>("Direccion").ToLower().Contains(Palabra) ||
                        row.Field<string>("Partido").ToLower().Contains(Palabra) ||
                        row.Field<string>("MAIL").ToLower().Contains(Palabra));

                foreach (var fila in PersonasEncontrados)
                {
                    resultadoFiltro.ImportRow(fila);
                }

                return resultadoFiltro;
            }
            else
            {
                return Dt;
            }
        }
        #endregion
    }
}
