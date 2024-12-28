using Logica;
using Modelo;
using Servicios;
using Sesion;
using Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.FormulariosMenu
{
    public partial class CV_ConfiguracionSistema : Form
    {
        CL_Sistema Sistema = new CL_Sistema();
        List<CM_ListadoPermisosActuales> listaCompleta = new List<CM_ListadoPermisosActuales>();
        List<CM_ListadoPermisosActuales> permisosActuales = new List<CM_ListadoPermisosActuales>();
        List<CM_ListadoPermisosActuales> permisosRestantes = new List<CM_ListadoPermisosActuales>();
        List<CL_Sistema> NuevosPermisos = new List<CL_Sistema>();

        bool Familia = false;
        string UsuarioGrupo;
        public CV_ConfiguracionSistema()
        {
            InitializeComponent(); 
            CV_Idioma.CargarIdioma(this.Controls, this);
        }

        #region Eventos
        private void CV_ConfiguracionSistema_Load(object sender, EventArgs e)
        {
            configurarLoad();
            configurarDTGV();
            CServ_ConfControles.ConfiguraciondeControles(this);
        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                capturarDatos();
                Sistema.GuardarCambiosDeSistema();
                //if (DTGV_PermisosActuales.Rows.Count > 0)
                //{
                //    Sistema.GuardarPermisos(Familia);
                //}

                CServ_MsjUsuario.Exito("¡Configuración guardada con éxito!");
            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }
        }
        private void Rbt_Usuario_CheckedChanged(object sender, EventArgs e)
        {
            DTGV_PermisosActuales.DataSource = null;
            DTGV_PermisosRestantes.DataSource = null;
            DTGV_FamiliaUsuario.DataSource = null;
            DTGV_FamiliaUsuario.DataSource = Sistema.ObtenerPermisosUsuarioFamilia("Usuario");
            DTGV_FamiliaUsuario.Columns[0].HeaderText = "Nombre Usuario";
            DTGV_FamiliaUsuario.ClearSelection();
            Familia = false;

        }
        private void Rbt_Grupo_CheckedChanged(object sender, EventArgs e)
        {
            DTGV_PermisosActuales.DataSource = null;
            DTGV_PermisosRestantes.DataSource = null;
            DTGV_FamiliaUsuario.DataSource = null;
            DTGV_FamiliaUsuario.DataSource = Sistema.ObtenerPermisosUsuarioFamilia("Familia");
            DTGV_FamiliaUsuario.Columns[0].HeaderText = "Nombre de la familia";
            DTGV_FamiliaUsuario.ClearSelection();
            Familia = true;

        }
        private void DTGV_FamiliaUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DTGV_FamiliaUsuario.SelectedRows.Count > 0)
            {
                int Seleccion = DTGV_FamiliaUsuario.CurrentRow.Index;
                string FamiliaUsuario = DTGV_FamiliaUsuario.Rows[Seleccion].Cells[0].Value.ToString();
                if (Familia) UsuarioGrupo = DTGV_FamiliaUsuario.Rows[Seleccion].Cells[0].Value.ToString();
                else UsuarioGrupo = DTGV_FamiliaUsuario.Rows[Seleccion].Cells[0].Value.ToString();


                listaCompleta = Sistema.ObtenerPermisosActuales(FamiliaUsuario, Familia);
                cargarListaPermisos(true);
                Btn_Funcion.Visible = false;
            }
        }
        private void DTGV_PermisosActuales_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Btn_Funcion.Visible = true;
            DTGV_PermisosRestantes.ClearSelection();
            Btn_Funcion.Text = "Quitar";
        }
        private void DTGV_PermisosRestantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Btn_Funcion.Visible = true;
            DTGV_PermisosActuales.ClearSelection();
            Btn_Funcion.Text = "Agregar";
        }
        private void Btn_Funcion_Click(object sender, EventArgs e)
        {
            int seleccion = 0;

            if (Btn_Funcion.Text == "Agregar")
            {
                if (DTGV_PermisosRestantes.CurrentRow != null)
                {

                    seleccion = DTGV_PermisosRestantes.CurrentRow.Index;

                    var permisoSeleccionado = permisosRestantes[seleccion];
                    var nuevoPermiso = new CM_ListadoPermisosActuales
                    {
                        DescripcionPermiso = permisoSeleccionado.DescripcionPermisosTotales,
                        DescripcionPermisosTotales = null
                    };
                    permisosActuales.Add(nuevoPermiso);
                    permisosRestantes.RemoveAt(seleccion);
                }
            }
            else
            {
                if (DTGV_PermisosActuales.CurrentRow != null)
                {


                    seleccion = DTGV_PermisosActuales.CurrentRow.Index;

                    var permisoAEliminar = permisosActuales[seleccion];
                    var nuevoPermisoRestante = new CM_ListadoPermisosActuales
                    {
                        DescripcionPermisosTotales = permisoAEliminar.DescripcionPermiso,
                        DescripcionPermiso = null
                    };
                    permisosRestantes.Add(nuevoPermisoRestante);
                    permisosActuales.RemoveAt(seleccion);
                }
            }

            cargarListaPermisos(false);
        }
        private void Txb_BuscarPermisoActual_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Txb_BuscarPermisoActual.Text) && Txb_BuscarPermisoActual.Text != "Buscar")
            {
                DTGV_PermisosActuales.DataSource = null;
                DTGV_PermisosActuales.DataSource = Sistema.FiltrarBusqueda(Txb_BuscarPermisoActual.Text, permisosActuales);
                DTGV_PermisosActuales.Columns[0].HeaderText = "Permiso Actual";
                DTGV_PermisosActuales.Columns[1].Visible = false;
                DTGV_PermisosActuales.ClearSelection();
            }
            else { cargarListaPermisos(false); DTGV_PermisosActuales.ClearSelection(); }
        }
        private void Txb_BuscarPermisoRestante_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Txb_BuscarPermisoRestante.Text) && Txb_BuscarPermisoRestante.Text != "Buscar")
            {
                DTGV_PermisosRestantes.DataSource = null;
                DTGV_PermisosRestantes.DataSource = Sistema.FiltrarBusqueda(Txb_BuscarPermisoRestante.Text, permisosRestantes, "");
                DTGV_PermisosRestantes.Columns[1].HeaderText = "Permisos restantes";
                DTGV_PermisosRestantes.Columns[0].Visible = false;
                DTGV_PermisosRestantes.ClearSelection();
            }
            else { cargarListaPermisos(false); DTGV_PermisosRestantes.ClearSelection(); }
            }
        #endregion

        #region Métodos
        private void configurarLoad()
        {
            Txb_BuscarPermisoActual.Text = "Buscar";
            Txb_BuscarPermisoRestante.Text = "Buscar";
            Nud_CantMinStock.Value = CSistema_ConfiguracionSistema.CantMinimadeStock;
            Nud_VtoProd.Value = CSistema_ConfiguracionSistema.AvisosVtoProductos;
            Nud_CantMinStock.Enabled = false;
            Nud_VtoProd.Enabled = false;
            Gpb_Permisos.Enabled = false;
            if (DTGV_PermisosActuales.Rows.Count <1 && DTGV_PermisosRestantes.Rows.Count <1) 
            {
                Btn_Funcion.Visible = false;
            }
            foreach (var permiso in CSesion_SesionIniciada.Permisos)
            {
                switch (permiso.ID_Rol)
                {
                    case 1:
                        Nud_CantMinStock.Enabled = true;
                        Nud_VtoProd.Enabled = true;
                        Gpb_Permisos.Enabled = true;
                        break;

                    case 63:
                        Nud_CantMinStock.Enabled = true;
                        Nud_VtoProd.Enabled = true;
                        break;
                    case 64:
                        Gpb_Permisos.Enabled = true;
                        break;
                }
            }
        }
        private void cargarListaPermisos(bool booleano)
        {
            if (booleano)
            {
                permisosActuales = Sistema.FiltrarPermisos(listaCompleta, true);
                permisosRestantes = Sistema.FiltrarPermisos(listaCompleta, false);

            }
            DTGV_PermisosActuales.DataSource = null;
            DTGV_PermisosActuales.DataSource = permisosActuales;
            DTGV_PermisosActuales.Columns[0].HeaderText = "Permiso Actual";
            DTGV_PermisosActuales.Columns[1].Visible = false;
            DTGV_PermisosActuales.ClearSelection();

            DTGV_PermisosRestantes.DataSource = null;
            DTGV_PermisosRestantes.DataSource = permisosRestantes;
            DTGV_PermisosRestantes.Columns[1].HeaderText = "Permisos restantes";
            DTGV_PermisosRestantes.Columns[0].Visible = false;
            DTGV_PermisosRestantes.ClearSelection();

        }
        private void configurarDTGV()
        {

            DTGV_FamiliaUsuario.AllowUserToResizeColumns = false;
            DTGV_FamiliaUsuario.AllowUserToResizeRows = false;
            DTGV_FamiliaUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_FamiliaUsuario.MultiSelect = false;
            DTGV_FamiliaUsuario.AllowUserToAddRows = false;
            DTGV_FamiliaUsuario.AllowUserToResizeColumns = false;
            DTGV_FamiliaUsuario.AllowUserToResizeRows = false;
            DTGV_FamiliaUsuario.ReadOnly = true;
            DTGV_FamiliaUsuario.RowHeadersVisible = false;
            DTGV_FamiliaUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DTGV_FamiliaUsuario.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            DTGV_PermisosActuales.AllowUserToResizeColumns = false;
            DTGV_PermisosActuales.AllowUserToResizeRows = false;
            DTGV_PermisosActuales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_PermisosActuales.MultiSelect = false;
            DTGV_PermisosActuales.AllowUserToAddRows = false;
            DTGV_PermisosActuales.AllowUserToResizeColumns = false;
            DTGV_PermisosActuales.AllowUserToResizeRows = false;
            DTGV_PermisosActuales.ReadOnly = true;
            DTGV_PermisosActuales.RowHeadersVisible = false;
            DTGV_PermisosActuales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DTGV_PermisosActuales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;



            DTGV_PermisosRestantes.AllowUserToResizeColumns = false;
            DTGV_PermisosRestantes.AllowUserToResizeRows = false;
            DTGV_PermisosRestantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_PermisosRestantes.MultiSelect = false;
            DTGV_PermisosRestantes.AllowUserToAddRows = false;
            DTGV_PermisosRestantes.AllowUserToResizeColumns = false;
            DTGV_PermisosRestantes.AllowUserToResizeRows = false;
            DTGV_PermisosRestantes.ReadOnly = true;
            DTGV_PermisosRestantes.RowHeadersVisible = false;
            DTGV_PermisosRestantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DTGV_PermisosRestantes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;



        }
        private void capturarDatos()
        {
            Sistema.AvisosVtoProductos = Convert.ToInt32(Nud_VtoProd.Value);
            Sistema.CantMinimadeStock = Convert.ToInt32(Nud_CantMinStock.Value);
            CSistema_ConfiguracionSistema.AvisosVtoProductos = Sistema.AvisosVtoProductos;
            CSistema_ConfiguracionSistema.CantMinimadeStock= Sistema.CantMinimadeStock;
            //Sistema.UsuarioGrupo = UsuarioGrupo;
            //if (DTGV_FamiliaUsuario.SelectedRows.Count > 0)
            //{
            //    if (Sistema.NuevosPermisos != null) Sistema.NuevosPermisos.Clear();

            //    if (Familia)
            //    {
            //        foreach (var item in permisosActuales)
            //        {
            //            CL_Sistema sistema = new CL_Sistema();
            //            sistema.PermisoNuevo = item.DescripcionPermiso;
            //            sistema.UsuarioGrupo = UsuarioGrupo;
            //            NuevosPermisos.Add(sistema);
            //        }
            //        Sistema.NuevosPermisos = NuevosPermisos;

            //    }
            //    else
            //    {
            //        foreach (var item in permisosActuales)
            //        {
            //            CL_Sistema sistema = new CL_Sistema();
            //            sistema.PermisoNuevo = item.DescripcionPermiso;
            //            sistema.UsuarioGrupo = UsuarioGrupo;
            //            NuevosPermisos.Add(sistema);
            //        }
            //        Sistema.NuevosPermisos = NuevosPermisos;

            //    }
            //}
        }
        #endregion

    }
}