using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_RegistrodePersonas
    {
        CD_Personas DatosPersonas = new CD_Personas();
        #region Atributos
        private string atr_nombre;
        private string atr_apellido;
        private string atr_dni;
        private string atr_correo;
        private string atr_sexo;
        private string atr_domicilio;
        private string atr_localidad;
        private string atr_nacionalidad;
        private string atr_telefono;
        private string atr_nacimiento;
        private string atr_comentarios;
        #endregion

        #region Properties
        public string Prop_NOMBRE
        { get => atr_nombre; set { atr_nombre = value; } }
        public string Prop_APELLIDO
        { get => atr_apellido; set { atr_apellido = value; } }
        public string Prop_DNI
        { get => atr_dni; set { atr_dni = value; } }
        public string Prop_CORREO
        { get => atr_correo; set { atr_correo = value; } }
        public string Prop_SEXO
        { get => atr_sexo; set { atr_sexo = value; } }
        public string Prop_DOMICILIO
        { get => atr_domicilio; set { atr_domicilio = value; } }
        public string Prop_LOCALIDAD
        { get => atr_localidad; set { atr_localidad = value; } }
        public string Prop_NACIONALIDAD
        { get => atr_nacionalidad; set { atr_nacionalidad = value; } }
        public string Prop_TELEFONO
        { get => atr_telefono; set { atr_telefono = value; } }
        public string Prop_NACIMIENTO
        { get => atr_nacimiento; set { atr_nacimiento = value; } }
        public string Prop_COMENTARIOS
        { get => atr_comentarios; set { atr_comentarios = value; } }
        #endregion

        #region Métodos
        public DataTable InsertarPersona()
        {
            PasarDatos();
           return DatosPersonas.Insertar();
        }
        public DataTable ObtenerLocalidad() 
        {
            return DatosPersonas.Localidad();
        }
        public DataTable ObtenerPais()
        {
            return DatosPersonas.Pais();
        }
        public DataTable ObtenerPersonas()
        {
            return DatosPersonas.ObtenerPersonaCmb();
        }
        public DataTable ObtenerFamilia()
        {
            return DatosPersonas.Familia();
        }
        public DataTable CargarDatos(int ID_Persona)
        {
            return DatosPersonas.CargarPersonas(ID_Persona);
        }
        private void PasarDatos() 
        {
            try
            {
                try
                {
                    DatosPersonas.Prop_DNI = Convert.ToInt32(atr_dni);
                    DatosPersonas.Prop_TELEFONO = Convert.ToInt32(atr_telefono);
                    DatosPersonas.Prop_NACIMIENTO = Convert.ToDateTime(atr_nacimiento);
                }
                catch (Exception)
                {
                    throw new Exception("Por favor ingrese nuvamente los datos");
                }
                DatosPersonas.Prop_NOMBRE = atr_nombre;
                DatosPersonas.Prop_APELLIDO = atr_apellido;
                DatosPersonas.Prop_CORREO = atr_correo;
                DatosPersonas.Prop_SEXO = atr_sexo;
                DatosPersonas.Prop_DOMICILIO = atr_domicilio;
                DatosPersonas.Prop_LOCALIDAD = atr_localidad;
                DatosPersonas.Prop_NACIONALIDAD = atr_nacionalidad;
                DatosPersonas.Prop_COMENTARIOS = atr_comentarios;

            }
            catch (Exception)
            {

                throw new Exception("Error al insertar la persona, por favor intente nuevamente");
            }
            
        }

        #endregion

    }
}
