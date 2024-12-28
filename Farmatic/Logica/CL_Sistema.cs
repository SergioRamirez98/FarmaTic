using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_Sistema
    {
        CD_Sistema sistema = new CD_Sistema();
        CD_Backup Bak = new CD_Backup();

        List<CM_Bitacora> listaBitacora = new List<CM_Bitacora>();
        List<CM_GestionPermisos> listaPermisos = new List<CM_GestionPermisos>();
        List<CM_ListadoPermisosActuales> PermisosActuales = new List<CM_ListadoPermisosActuales>();
        List<CD_Sistema> PermisosNuevos = new List<CD_Sistema>();

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

        public string NombreBDD { get; set; }

        #endregion

        #region Permisos
        public string UsuarioGrupo { get; set; }
        public List<CL_Sistema> NuevosPermisos { get; set; }
        public string PermisoNuevo { get; set; }

        #endregion

        #region Métodos
        public DataTable CargarConfiguracion()
        {
         //   ejecutarBackUp();
            return sistema.Configuracion();
        }
        public void RestaurarBDD() 
        {
            Bak.NombreBDD = NombreBDD;
            Bak.RestaurarBasedeDatos();
        }
        private void ejecutarBackUp() 
        {
            
            Timer temporizador = new Timer(ejecutarMetodo, null, TimeSpan.Zero, TimeSpan.FromHours(8));

        }
        private void ejecutarMetodo(object state) 
        {
            sistema.EjecutarBackUp();
        }
        public List<CM_Bitacora> MostrarBitacora()
        {
            listaBitacora.Clear();
            listaBitacora = sistema.ObtenerBitacora();
            return listaBitacora;
        }
        public List<CM_Bitacora> BuscarBitacora()
        {
            pasarDatos(1);
            listaBitacora.Clear();
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

        public List<CM_ListadoPermisosActuales> FiltrarBusqueda(string Permiso, List<CM_ListadoPermisosActuales> listado, string s = null) 
        {
            Permiso= Permiso.ToLower();

            if (!string.IsNullOrEmpty(Permiso))
            {
                if (s!=null)
                {
                    return listado
                    .Where(x => x.DescripcionPermisosTotales.ToLower().Contains(Permiso))
                    .ToList();

                }
                else
                {
                    return listado
                    .Where(x=> x.DescripcionPermiso.ToLower().Contains(Permiso))
                    
                    .ToList();
                }
            }
            else
            {
                return listado;
            }
        }
        public void GuardarCambiosDeSeguridad()
        {
            pasarDatos(2);
            sistema.GuardarCambiosSeguridad();
        }
        public void GuardarCambiosDeSistema()
        {        
            pasarDatos(3);
            sistema.GuardarCambiosSistema();
        }
        public void GuardarPermisos(bool Familia)
        {

            pasarDatos(4);
            NuevosPermisos.Clear();
            sistema.GuardarNuevosPermisos(Familia);
        }
        private void pasarDatos(int valor)
        {
            switch (valor)
            {
                case 1:
                    sistema.FechaDesde = Convert.ToDateTime(FechaDesde);
                    sistema.FechaHasta = Convert.ToDateTime(FechaHasta);

                    sistema.Accion = Convert.ToInt32(Accion);
                    if (string.IsNullOrWhiteSpace(UserName)) sistema.UserName = "";
                    else sistema.UserName = UserName;

                    break;
                case 2:
                    sistema.MinCaracteres = MinCaracteres;
                    sistema.CaractEspecial = CaractEspecial;
                    sistema.DatosPersonales = DatosPersonales;
                    sistema.MayusMinus = MayusMinus;
                    sistema.NumerosYLetras = NumerosYLetras;
                    sistema.RepetirPass = RepetirPass;
                    sistema.CantIntentosFallidos = CantIntentosFallidos;
                    break;
                case 3:
                    sistema.AvisosVtoProductos = AvisosVtoProductos;
                    sistema.CantMinimadeStock = CantMinimadeStock;
                    break;
              
                case 4:
                    sistema.UsuarioGrupo = UsuarioGrupo;
                    foreach (var item in NuevosPermisos)
                    {
                        CD_Sistema NuevosPermisos = new CD_Sistema();
                        NuevosPermisos.PermisoNuevo = item.PermisoNuevo;
                        NuevosPermisos.UsuarioGrupo = item.UsuarioGrupo;
                        PermisosNuevos.Add(NuevosPermisos);

                    }
                    sistema.PermisosNuevos = PermisosNuevos;
                    break;
            }
        }
        public List<CM_ListadoPermisosActuales> FiltrarPermisos(List<CM_ListadoPermisosActuales> listaCompleta, bool obtenerActuales)
        {
            if (obtenerActuales)
            {
                return listaCompleta
                    .Where(x => !string.IsNullOrEmpty(x.DescripcionPermiso))
                    .ToList();
            }
            else
            {
                var permisosActuales = listaCompleta
                    .Where(x => !string.IsNullOrEmpty(x.DescripcionPermiso))
                    .Select(x => x.DescripcionPermiso)
                    .ToHashSet(); // Usamos HashSet para búsqueda rápida

                return listaCompleta
                    .Where(x => !permisosActuales.Contains(x.DescripcionPermisosTotales) && !string.IsNullOrEmpty(x.DescripcionPermisosTotales))
                    .ToList();
            }
        }
        #endregion
    }
}