using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_Clientes: CD_EjecutarSP
    {
        #region Properties
        public int ID_Persona { get; set; }
        public int ID_Categoria { get; set; }
        public string Comentarios { get; set; }
        public DateTime FeAlta { get; set; }

        SqlParameter[] lista = null;
        #endregion

        public void InsertarCliente()
        {
            try
            {
                string sSql = "SP_Insertar_Cliente";
                SqlParameter param_ID_Persona = new SqlParameter("@ID_Persona", SqlDbType.Int);
                param_ID_Persona.Value = ID_Persona;
                SqlParameter param_Categoria = new SqlParameter("@ID_Categoria", SqlDbType.Int);
                param_Categoria.Value = ID_Categoria;
                SqlParameter param_Comentarios = new SqlParameter("@Comentarios", SqlDbType.VarChar, 200);
                param_Comentarios.Value = Comentarios;
                SqlParameter param_FeAlta = new SqlParameter("@FeAlta", SqlDbType.DateTime);
                param_FeAlta.Value = FeAlta;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_Categoria);
                listaParametros.Add(param_ID_Persona);
                listaParametros.Add(param_Comentarios);
                listaParametros.Add(param_FeAlta);

                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Clientes||InsertarCliente");
            }
        }
        public void Modificar()
        {
            try
            {
                string sSql = "SP_Modificar_Cliente";
                SqlParameter param_ID_Persona = new SqlParameter("@ID_Persona", SqlDbType.Int);
                param_ID_Persona.Value = ID_Persona;
                SqlParameter param_Categoria = new SqlParameter("@ID_Categoria", SqlDbType.Int);
                param_Categoria.Value = ID_Categoria;
                SqlParameter param_Comentarios = new SqlParameter("@Comentarios", SqlDbType.VarChar, 200);
                param_Comentarios.Value = Comentarios;
                SqlParameter param_FeAlta = new SqlParameter("@FeAlta", SqlDbType.DateTime);
                param_FeAlta.Value = FeAlta;

                List<SqlParameter> listaParametros = new List<SqlParameter>();
                listaParametros.Add(param_Categoria);
                listaParametros.Add(param_ID_Persona);
                listaParametros.Add(param_Comentarios);
                listaParametros.Add(param_FeAlta);

                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);

            }
            catch (Exception)
            {

                throw new Exception("No se ha podido realizar la operación. Error CD_Clientes||Modificar");
            }
        }
        public DataTable ObtenerCategoriasCmb()
        {
            try
            {
                string sSql = "SP_Obtener_Categorias";
                List<SqlParameter> listaparametros = new List<SqlParameter>();
                SqlParameter[] parametros = listaparametros.ToArray();

                return ejecutar(sSql, parametros, true);

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido realizar la operación. Error CD_Cliente||ObtenerCategoriaCmb");
            }
        }
       
        
    }
}
