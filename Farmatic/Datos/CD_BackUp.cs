using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Servicios;
using Sesion;
using Sistema;

namespace Datos
{
    public class CD_Backup : CD_EjecutarBackUp
    {
        #region Properties
        public string NombreBDD { get; set; }

        SqlParameter[] lista = null;



        #endregion      
                
        public void RestaurarBasedeDatos()
        {
            try
            {
                string direccion = CServ_BackUpBDD.ObtenerUbicacionBackup(NombreBDD);
                string sSql = $@"
                USE master;  
                ALTER DATABASE Farmatic SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                RESTORE DATABASE Farmatic FROM DISK = '{direccion}';
                ALTER DATABASE Farmatic SET MULTI_USER;";


                List<SqlParameter> listaParametros = new List<SqlParameter>();
                lista = listaParametros.ToArray();

                ejecutar(sSql, lista, false);

               
            }
            catch (Exception)
            {

                throw ;
            }
        }
    }
}