﻿using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_Personas
    {
        CD_Personas Personas = new CD_Personas();
        #region Atributos
        private string atr_nombre;
        private string atr_apellido;
        private string atr_dni;
        private string atr_correo;
        private string atr_sexo;
        private string atr_domicilio;
        private string atr_Partido;
        private string atr_Localidad;
        private string atr_nacionalidad;
        private string atr_telefono;
        private string atr_nacimiento;
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
        public string Prop_Partido
        { get => atr_Partido; set { atr_Partido = value; } }
        public string Prop_Localidad
        { get => atr_Localidad; set { atr_Localidad = value; } }
        public string Prop_NACIONALIDAD
        { get => atr_nacionalidad; set { atr_nacionalidad = value; } }
        public string Prop_TELEFONO
        { get => atr_telefono; set { atr_telefono = value; } }
        public string Prop_NACIMIENTO
        { get => atr_nacimiento; set { atr_nacimiento = value; } }
        #endregion

        #region Métodos
        public void ModificarPersona(int ID_Persona) 
        {
            PasarDatos();
            Personas.Modificar(ID_Persona);
        }
        public DataTable InsertarPersona()
        {
            PasarDatos();
            return Personas.Insertar();
        }
        public bool ExistePersona() 
        {
            PasarDatos();
            return Personas.ComprobarPersona();
        }
        public void Eliminar(int ID_Persona) 
        {
            Personas.EliminarPersona(ID_Persona);
        }
        public DataTable ObtenerPartido() 
        {
            return Personas.Partido();
        }
        public DataTable ObtenerLocalidades(int ID_Seleccionado)
        {
            return Personas.Localidades(ID_Seleccionado);
        }
        public DataTable ObtenerPais()
        {
            return Personas.Pais();
        }
        public DataTable ObtenerPersonas()
        {
            return Personas.ObtenerPersonaCmb();
        }        
        public DataTable CargarDatos(int ID_Persona)
        {
            return Personas.CargarPersonas(ID_Persona);
        }
        public bool CargarDatosUsuarios(int ID_Persona)
        {
            return Personas.CargarUsuarios(ID_Persona);
        }
        public bool CargarDatosClientes(int ID_Persona)
        {
            return Personas.CargarClientes(ID_Persona);
        }
        private void PasarDatos() 
        {
            try
            {
                try
                {
                    Personas.Prop_DNI = Convert.ToInt32(atr_dni);
                    Personas.Prop_TELEFONO = Convert.ToInt32(atr_telefono);
                    Personas.Prop_NACIMIENTO = Convert.ToDateTime(atr_nacimiento);
                }
                catch (Exception)
                {
                    throw new Exception("Los campos DNI, Telefono deben ser numeros.");
                }
                if (!string.IsNullOrEmpty(atr_nombre)|| !string.IsNullOrEmpty(atr_apellido))
                {
                    Personas.Prop_NOMBRE = atr_nombre;
                    Personas.Prop_APELLIDO = atr_apellido;
                }
                else throw new Exception("El campo nombre y apellido no pueden estar vacios.");
                Personas.Prop_CORREO = atr_correo;
                Personas.Prop_SEXO = atr_sexo;
                Personas.Prop_DOMICILIO = atr_domicilio;
                if (atr_Partido != null) Personas.Prop_Partido = atr_Partido;
                else throw new Exception("Debe seleccionar un partido.");
                if (string.IsNullOrEmpty(atr_Localidad)) Personas.Prop_Localidad = "Homónimo";
                else Personas.Prop_Localidad = atr_Localidad;

                if (atr_nacionalidad != null) Personas.Prop_NACIONALIDAD = atr_nacionalidad;
                else throw new Exception("Debe seleccionar la nacionalidad.");
                

            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public DataTable BusquedaRapida(string Palabra, DataTable Dt) 
        {
            Palabra= Palabra.ToLower();

            if (!string.IsNullOrEmpty(Palabra))
            {
                DataTable resultadoFiltro = Dt.Clone();
                             
                var PersonasEncontrados = Dt.AsEnumerable()

                        .Where(row => row.Field<string>("NombreCompleto").ToLower().Contains(Palabra) ||
                        row.Field<string>("Documento").ToLower().Contains(Palabra) ||
                        row.Field<string>("Direccion").ToLower().Contains(Palabra) ||
                        row.Field<string>("Mail").ToLower().Contains(Palabra));
                
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
