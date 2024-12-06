using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Sesion;
using Sistema;

namespace Datos
{
    public class CD_Sistema : CD_EjecutarSP
    {
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

        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int Accion { get; set; }
        public string UserName { get; set; }

        public string UsuarioGrupo { get; set; }
        public string PermisoNuevo { get; set; }


        public List<CM_Bitacora> ListaBitacora { get; set; } = new List<CM_Bitacora>();
        public List<CM_GestionPermisos> ListaPermisos { get; set; } = new List<CM_GestionPermisos>();
        public List<CM_ListadoPermisosActuales> ListaActual { get; set; } = new List<CM_ListadoPermisosActuales>();

        public List<CD_Sistema> PermisosNuevos = new List<CD_Sistema>();


        SqlParameter[] lista = null;

        #endregion
        public DataTable Configuracion()
        {
            string sSql = "SP_Obtener_Configuracion";
            try
            {
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                SqlParameter[] parametros = listaparametros.ToArray();
                DataTable dt = new DataTable();
                dt = ejecutar(sSql, parametros, true);
                if (dt.Rows.Count > 0)
                {
                    CSistema_ConfiguracionSistema.ConfigurarSistema(dt);
                }
                return dt;

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Sistema||Configuracion.");
            }
        }
        public List<CM_Bitacora> ObtenerBitacora()
        {
            string sSql = "SP_Obtener_Bitacora";
            ListaBitacora.Clear();
            try
            {
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                SqlParameter[] parametros = listaparametros.ToArray();
                DataTable dt = new DataTable();
                dt = ejecutar(sSql, parametros, true);
                if (dt.Rows.Count > 0)
                {
                    cargarBitacora(dt);
                }

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Sistema||ObtenerBitacora.");
            }
            return ListaBitacora;
        }
        public void GuardarCambiosSeguridad()
        {
            try
            {
                string sSql = "SP_Guardar_Config_Seguridad";

                SqlParameter param_MinCaracteres = new SqlParameter("@MinCaracteres", SqlDbType.Bit);
                param_MinCaracteres.Value = MinCaracteres;
                SqlParameter param_CaractEspecial = new SqlParameter("@CaractEspecial", SqlDbType.Bit);
                param_CaractEspecial.Value = CaractEspecial;
                SqlParameter param_DatosPersonales = new SqlParameter("@DatosPers", SqlDbType.Bit);
                param_DatosPersonales.Value = DatosPersonales;
                SqlParameter param_MayusMinus = new SqlParameter("@MayusMinus", SqlDbType.Bit);
                param_MayusMinus.Value = MayusMinus;
                SqlParameter param_NumerosYLetras = new SqlParameter("@NumerosYLetras", SqlDbType.Bit);
                param_NumerosYLetras.Value = NumerosYLetras;
                SqlParameter param_RepetirPass = new SqlParameter("@RepetirPass", SqlDbType.Bit);
                param_RepetirPass.Value = RepetirPass;
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param_UserName.Value = CSesion_SesionIniciada.UserName;
                SqlParameter param_CantIntentosFallidos = new SqlParameter("@CantIntentosFallidos", SqlDbType.Int);
                param_CantIntentosFallidos.Value = CantIntentosFallidos;


                List<SqlParameter> listaParametros = new List<SqlParameter>();

                listaParametros.Add(param_MinCaracteres);
                listaParametros.Add(param_CaractEspecial);
                listaParametros.Add(param_DatosPersonales);
                listaParametros.Add(param_MayusMinus);
                listaParametros.Add(param_NumerosYLetras);
                listaParametros.Add(param_RepetirPass);
                listaParametros.Add(param_UserName);
                listaParametros.Add(param_CantIntentosFallidos);

                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);
            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Sistema||GuardarCambios.");
            }

        }
        public void GuardarCambiosSistema()
        {
            try
            {
                string sSql = "SP_Guardar_Config_Sistema";


                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param_UserName.Value = CSesion_SesionIniciada.UserName;

                SqlParameter param_AvisosVtoProductos = new SqlParameter("@AvisosVtoProductos", SqlDbType.Int);
                param_AvisosVtoProductos.Value = AvisosVtoProductos;
                SqlParameter param_CantMinimadeStock = new SqlParameter("@CantMinimadeStock", SqlDbType.Int);
                param_CantMinimadeStock.Value = CantMinimadeStock;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_UserName);
                listaParametros.Add(param_AvisosVtoProductos);
                listaParametros.Add(param_CantMinimadeStock);

                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);
            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Sistema||GuardarCambios.");
            }

        }

        public List<CM_Bitacora> Buscar()
        {
            string sSql = "SP_Buscar_Bitacora";
            ListaBitacora.Clear();
            try
            {
                SqlParameter param_FechaDesde = new SqlParameter("@FechaDesde", SqlDbType.DateTime);
                param_FechaDesde.Value = FechaDesde;
                SqlParameter param_FechaHasta = new SqlParameter("@FechaHasta", SqlDbType.DateTime);
                param_FechaHasta.Value = FechaHasta;
                SqlParameter param_Accion = new SqlParameter("@Accion", SqlDbType.Int);
                param_Accion.Value = Accion;
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param_UserName.Value = UserName;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_FechaDesde);
                listaParametros.Add(param_FechaHasta);
                listaParametros.Add(param_Accion);
                listaParametros.Add(param_UserName);
                lista = listaParametros.ToArray();

                DataTable dt = new DataTable();
                dt = ejecutar(sSql, lista, true);
                if (dt.Rows.Count > 0)
                {
                    cargarBitacora(dt);
                }

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Sistema||Buscar.");
            }
            return ListaBitacora;

        }


        public void GuardarNuevosPermisos(bool Familia)
        {
            string sSql;
            try
            {
                sSql = "SP_Eliminar_Permisos_Actuales";
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                SqlParameter param_FamiliaUsuario = new SqlParameter("@UsuarioFamilia", SqlDbType.VarChar, 200);
                param_FamiliaUsuario.Value = UsuarioGrupo;
                SqlParameter param_UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param_UserName.Value = CSesion_SesionIniciada.UserName;
                SqlParameter param_EsFamilia = new SqlParameter("@EsFamilia", SqlDbType.Bit);
                param_EsFamilia.Value = Familia;


                listaParametros.Add(param_FamiliaUsuario);
                listaParametros.Add(param_UserName);
                listaParametros.Add(param_EsFamilia);
                lista = listaParametros.ToArray();
                ejecutar(sSql, lista, false);
                listaParametros.Clear();

                if (Familia) sSql = "SP_Modificar_Permisos_Por_Familia"; else sSql = "SP_Modificar_Permisos_Por_Usuario";

                foreach (var item in PermisosNuevos)
                {
                    SqlParameter param_UsuarioGrupo = new SqlParameter("@UsuarioFamilia", SqlDbType.VarChar, 200);
                    param_UsuarioGrupo.Value = item.UsuarioGrupo;
                    SqlParameter param_PermisoNuevo = new SqlParameter("@Permiso", SqlDbType.VarChar, 200);
                    param_PermisoNuevo.Value = item.PermisoNuevo;
                    listaParametros.Add(param_UsuarioGrupo);
                    listaParametros.Add(param_PermisoNuevo);                 
                    lista = listaParametros.ToArray();
                    ejecutar(sSql, lista, false);
                    listaParametros.Clear();
                }
                if (PermisosNuevos != null) PermisosNuevos.Clear();
            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Sistema||GuardarNuevosPermisos.");
            }

        }
        public DataTable ObtenerAccionBitacora()
        {
            string sSql = "SP_Obtener_Accion_Bitacora";

            try
            {
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                SqlParameter[] parametros = listaparametros.ToArray();
                DataTable dt = new DataTable();
                dt = ejecutar(sSql, parametros, true);
                return dt;

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Sistema||ObtenerBitacora.");
            }

        }
        public List<CM_GestionPermisos> Obtener(string UsuarioFamilia)
        {
            ListaPermisos.Clear();
            if (UsuarioFamilia == "Usuario")
            {
                string sSql = "SP_Obtener_Lista_Usuarios";
                try
                {
                    List<SqlParameter> listaparametros = new List<SqlParameter>();
                    SqlParameter[] parametros = listaparametros.ToArray();
                    DataTable dt = new DataTable();
                    dt = ejecutar(sSql, parametros, true);
                    if (dt.Rows.Count > 0)
                    {
                        cargarListaPermisos(dt);
                    }

                }
                catch (Exception)
                {
                    throw new Exception("No se ha podido realizar la operación. Error CD_Sistema||Obtener.");
                }

            }
            else
            {
                string sSql = "SP_Obtener_Lista_Familias";
                try
                {
                    List<SqlParameter> listaparametros = new List<SqlParameter>();
                    SqlParameter[] parametros = listaparametros.ToArray();
                    DataTable dt = new DataTable();
                    dt = ejecutar(sSql, parametros, true);
                    if (dt.Rows.Count > 0)
                    {
                        cargarListaPermisos(dt);
                    }

                }
                catch (Exception)
                {
                    throw new Exception("No se ha podido realizar la operación. Error CD_Sistema||Buscar.");
                }

            }
            return ListaPermisos;
        }

        public List<CM_ListadoPermisosActuales> PermisosActuales(string FamiliaUsuario, bool Seleccion)
        {
            ListaActual.Clear();
            if (Seleccion)
            {
                string sSql = "SP_Obtener_Lista_Permisos_Por_Grupo"; //Grupo
                try
                {
                    SqlParameter param_FamiliaUsuario = new SqlParameter("@FamiliaUsuario", SqlDbType.VarChar, 100);
                    param_FamiliaUsuario.Value = FamiliaUsuario;


                    List<SqlParameter> listaParametros = new List<SqlParameter>();
                    listaParametros.Add(param_FamiliaUsuario);

                    lista = listaParametros.ToArray();
                    DataTable dt = new DataTable();
                    dt = ejecutar(sSql, lista, true);
                    if (dt.Rows.Count > 0)
                    {
                        cargarListaPermisosActuales(dt);
                    }

                }
                catch (Exception)
                {
                    throw new Exception("No se ha podido realizar la operación. Error CD_Sistema||PermisosActuales.");
                }

            }
            else
            {
                string sSql = "SP_Obtener_Lista_Permisos_Por_Usuario";
                try
                {
                    SqlParameter param_FamiliaUsuario = new SqlParameter("@FamiliaUsuario", SqlDbType.VarChar, 100);
                    param_FamiliaUsuario.Value = FamiliaUsuario;


                    List<SqlParameter> listaParametros = new List<SqlParameter>();
                    listaParametros.Add(param_FamiliaUsuario);

                    lista = listaParametros.ToArray();
                    DataTable dt = new DataTable();
                    dt = ejecutar(sSql, lista, true);
                    if (dt.Rows.Count > 0)
                    {
                        cargarListaPermisosActuales(dt);
                    }

                }
                catch (Exception)
                {
                    throw new Exception("No se ha podido realizar la operación. Error CD_Sistema||PermisosActuales.");
                }

            }
            string sSql2 = "SP_Obtener_Lista_Permisos_Totales";
            try
            {
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                SqlParameter[] parametros = listaparametros.ToArray();
                DataTable dt = new DataTable();
                dt = ejecutar(sSql2, parametros, true);

                if (dt.Rows.Count > 0)
                {
                    cargarListaPermisosTotales(dt);
                }

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Sistema||PermisosActuales.");
            }

            return ListaActual;
        }
        private void cargarBitacora(DataTable dt)
        {
            ListaBitacora.Clear();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CM_Bitacora bitacora = new CM_Bitacora
                    {
                        ID_Bitacora = Convert.ToInt32(dr["ID_Bitacora"]),
                        Usuario = dr["UserName"].ToString(),
                        Fecha = Convert.ToDateTime(dr["Fecha"]),
                        Accion = dr["Accion"].ToString(),
                        Descripcion = dr["Descripcion"].ToString()
                    };

                    ListaBitacora.Add(bitacora);
                }

            }
        }
        public void cargarListaPermisos(DataTable dt)
        {
            ListaPermisos.Clear();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CM_GestionPermisos FamiliaPersona = new CM_GestionPermisos
                    {
                        FamiliaUsuario = dr["FamiliaUsuario"].ToString()
                    };

                    ListaPermisos.Add(FamiliaPersona);
                }

            }
        }

        private void cargarListaPermisosActuales(DataTable dt)
        {
            ListaActual.Clear();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CM_ListadoPermisosActuales FamiliaPersona = new CM_ListadoPermisosActuales
                    {
                        DescripcionPermiso = dr["DescripcionPermiso"].ToString()
                    };
                    ListaActual.Add(FamiliaPersona);
                }

            }
        }
        private void cargarListaPermisosTotales(DataTable dt)
        {
            //ListaActual.Clear();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CM_ListadoPermisosActuales FamiliaPersona = new CM_ListadoPermisosActuales
                    {
                        DescripcionPermisosTotales = dr["Descripcion"].ToString()
                    };
                    ListaActual.Add(FamiliaPersona);
                }

            }
        }
    }
}