using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_Sistema
    {
        CD_Sistema sistema = new CD_Sistema();
        List<CM_Bitacora> listaBitacora = new List<CM_Bitacora>();
        List<CM_GestionPermisos> listaPermisos = new List<CM_GestionPermisos>();

        List<CM_ListadoPermisosActuales> PermisosActuales = new List<CM_ListadoPermisosActuales>();
        #region Properties
        public bool MinCaracteres { get; set; }
        public bool CaractEspecial { get; set; }
        public bool DatosPersonales { get; set; }
        public bool MayusMinus { get; set; }
        public bool NumerosYLetras { get; set; }
        public bool RepetirPass { get; set; }        
        public int AvisosVtoProductos { get; set; }
        public int CantMinimadeStock { get; set; }
        public int CantIntentosFallidos { get; set; }


        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public string Accion { get; set; }
        public string UserName { get; set; }

        #endregion

        #region Permisos
        public string Familia { get; set; }
        public string Usuario { get; set; }
        List<CM_ListadoPermisosActuales> NuevosPermisos = new List<CM_ListadoPermisosActuales>();
        #endregion

        public DataTable CargarConfiguracion() 
        {
            return sistema.Configuracion();           
        }
        public List<CM_Bitacora> MostrarBitacora() 
        {
            listaBitacora.Clear();
            listaBitacora = sistema.ObtenerBitacora();
            return listaBitacora;
        }
        public List<CM_Bitacora> BuscarBitacora() 
        {
            pasarDatos(); listaBitacora.Clear();
            return listaBitacora = sistema.Buscar();
        }
        public DataTable ObtenerAccion() 
        {
            return sistema.ObtenerAccionBitacora();
        }
        public List<CM_GestionPermisos> ObtenerPermisosUsuarioFamilia(string Usuario) 
        {
            listaPermisos.Clear();
            return sistema.Obtener(Usuario);
        }

        public List<CM_ListadoPermisosActuales> ObtenerPermisosActuales(string FamiliaUsuario, bool Seleccion) 
        {
            PermisosActuales.Clear();
            return PermisosActuales = sistema.PermisosActuales(FamiliaUsuario, Seleccion);
        }
        public void GuardarCambiosDeSeguridad()
        {
            pasarDatosSeguridad();
            sistema.GuardarCambiosSeguridad();
        }
        public void GuardarCambiosDeSistema()
        {
            pasarDatosSistema();
            sistema.GuardarCambiosSistema();
        }
        private void pasarDatosSeguridad() 
        {
            sistema.MinCaracteres= MinCaracteres;
            sistema.CaractEspecial= CaractEspecial;
            sistema.DatosPersonales= DatosPersonales;
            sistema.MayusMinus= MayusMinus;
            sistema.NumerosYLetras = NumerosYLetras;
            sistema.RepetirPass = RepetirPass;
            sistema.CantIntentosFallidos = CantIntentosFallidos;
        }
        private void pasarDatosSistema()
        {
            sistema.AvisosVtoProductos = AvisosVtoProductos;
            sistema.CantMinimadeStock = CantMinimadeStock;
        }
        private void pasarDatos() 
        {
            sistema.FechaDesde = Convert.ToDateTime(FechaDesde);
            sistema.FechaHasta = Convert.ToDateTime(FechaHasta);
           
            sistema.Accion = Convert.ToInt32(Accion);
            if (string.IsNullOrWhiteSpace(UserName)) sistema.UserName = "";
            else sistema.UserName = UserName;
            
    }

        public List<CM_ListadoPermisosActuales> FiltrarPermisos(List<CM_ListadoPermisosActuales> listaCompleta, bool obtenerActuales)
        {
            if (obtenerActuales)
            {
                // Filtrar permisos actuales (que tienen DescripcionPermiso no vacía)
                return listaCompleta
                    .Where(x => !string.IsNullOrEmpty(x.DescripcionPermiso))
                    .ToList();
            }
            else
            {
                // Filtrar permisos totales que no están en DescripcionPermiso
                var permisosActuales = listaCompleta
                    .Where(x => !string.IsNullOrEmpty(x.DescripcionPermiso))
                    .Select(x => x.DescripcionPermiso)
                    .ToHashSet(); // Usamos HashSet para búsqueda rápida

                return listaCompleta
                    .Where(x => !permisosActuales.Contains(x.DescripcionPermisosTotales) && !string.IsNullOrEmpty(x.DescripcionPermisosTotales))
                    .ToList();
            }
        }



    }
}
