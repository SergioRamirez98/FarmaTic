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
using Vista.FormulariosMenu;

namespace Vista
{
    public partial class CV_ModulodeSeguridad : Form
    {
        CL_Sistema Sistema = new CL_Sistema();

        List<CM_ListadoPermisosActuales> listaCompleta = new List<CM_ListadoPermisosActuales>();
        List<CM_ListadoPermisosActuales> permisosActuales = new List<CM_ListadoPermisosActuales>();
        List<CM_ListadoPermisosActuales> permisosRestantes = new List<CM_ListadoPermisosActuales>();
        List<CL_Sistema> NuevosPermisos = new List<CL_Sistema>();

        bool Familia = false;
        string UsuarioGrupo;


        public CV_ModulodeSeguridad()
        {
            Sistema.CargarConfiguracion();
            InitializeComponent();
            CV_Idioma.CargarIdioma(this.Controls, this); 
        }

        #region Eventos
        private void CV_Configuracion_Load(object sender, EventArgs e)
        {
            configurarLoad();
            configurarDTGV();
            cargarDTGV();
            Chb_NumYLetras.Checked = CSistema_ConfiguracionSistema.NumerosYLetras;
            Chb_CaracEspec.Checked = CSistema_ConfiguracionSistema.CaractEspecial;
            Chb_DatosPersonales.Checked = CSistema_ConfiguracionSistema.DatosPersonales;
            Chb_MayMin.Checked = CSistema_ConfiguracionSistema.MayusMinus;
            Nud_CantidadIntentosFallidos.Value = CSistema_ConfiguracionSistema.CantIntentosFallidos;

            CServ_ConfControles.ConfiguraciondeControles(this);

        }
        private void Chb_NumYLetras_CheckedChanged(object sender, EventArgs e)
        {
            if (Chb_NumYLetras.Checked)
            {
                CSistema_NumyLetr.NumerosYLetras = true;
            }

        }
        private void Chb_CaracEspec_CheckedChanged(object sender, EventArgs e)
        {
            if (Chb_CaracEspec.Checked)
            {
                CSistema_CaracEspecial.CaractEspecial = true;
            }

        }
        private void Chb_DatosPersonales_CheckedChanged(object sender, EventArgs e)
        {
            if (Chb_DatosPersonales.Checked)
            {
                CSistema_DatosPersonales.DatosPersonales = true;
            }

        }
        private void Chb_MayMin_CheckedChanged(object sender, EventArgs e)
        {
            if (Chb_MayMin.Checked)
            {
                CSistema_MayMin.MayMin = true;
            }

        }
        private void Chb_MinCaracteres_CheckedChanged(object sender, EventArgs e)
        {
            if (Chb_MinCaracteres.Checked)
            {
                CSistema_MinimoCaracteres.Caracteres = true;
            }
        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                capturarDatos(0);
                capturarDatos(2);
                Sistema.GuardarCambiosDeSeguridad();
                Sistema.GuardarCambiosDeSistema();
                if (DTGV_PermisosActuales.Rows.Count > 0)
                {
                    Sistema.GuardarPermisos(Familia);
                }
                CServ_MsjUsuario.Exito("¡Configuración guardada con éxito!");

            }
            catch (Exception)
            {
                CServ_MsjUsuario.MensajesDeError("No se ha podido guardar los cambios realizados");
            }
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
        private void Btn_RestaurarBDD_Click(object sender, EventArgs e)
        {
            if (CServ_MsjUsuario.Preguntar("¿Está seguro que desea restaurar la base de datos? Posterior a esto, el programa se reiniciará."))
            {
                try
                {
                    capturarDatos(3);
                    Sistema.RestaurarBDD(); 
                    Application.Restart();
                    return;
                }
                catch (Exception ex)
                {
                    CServ_MsjUsuario.MensajesDeError(ex.Message);
                }
            }
          
        }

#endregion








        #region Métodos
        private void capturarDatos(int Numero)
        {
            switch (Numero)
            {
                case 0:
                    Sistema.NumerosYLetras = Chb_NumYLetras.Checked;
                    Sistema.CaractEspecial = Chb_CaracEspec.Checked;
                    Sistema.DatosPersonales = Chb_DatosPersonales.Checked;
                    Sistema.MayusMinus = Chb_MayMin.Checked;
                    Sistema.MinCaracteres = Chb_MinCaracteres.Checked;
                    Sistema.RepetirPass = Chb_RepetirPass.Checked;
                    Sistema.CantIntentosFallidos = Convert.ToInt32(Nud_CantidadIntentosFallidos.Value);

                    break;
            case 1:
                    Sistema.UserName = Txb_UserName.Text;
                    Sistema.FechaDesde = Dtp_Desde.Value.ToString();
                    Sistema.FechaHasta = Dtp_Hasta.Value.ToString();
                    if (Cmb_Tipo.SelectedValue == null) Sistema.Accion = 0.ToString();
                    else Sistema.Accion = Cmb_Tipo.SelectedValue.ToString();
                    break;
            case 2:
                    Sistema.UsuarioGrupo = UsuarioGrupo;
                    if (DTGV_FamiliaUsuario.SelectedRows.Count > 0)
                    {
                        if (Sistema.NuevosPermisos != null) Sistema.NuevosPermisos.Clear();

                        if (Familia)
                        {
                            foreach (var item in permisosActuales)
                            {
                                CL_Sistema sistema = new CL_Sistema();
                                sistema.PermisoNuevo = item.DescripcionPermiso;
                                sistema.UsuarioGrupo = UsuarioGrupo;
                                NuevosPermisos.Add(sistema);
                            }
                            Sistema.NuevosPermisos = NuevosPermisos;

                        }
                        else
                        {
                            foreach (var item in permisosActuales)
                            {
                                CL_Sistema sistema = new CL_Sistema();
                                sistema.PermisoNuevo = item.DescripcionPermiso;
                                sistema.UsuarioGrupo = UsuarioGrupo;
                                NuevosPermisos.Add(sistema);
                            }
                            Sistema.NuevosPermisos = NuevosPermisos;

                        }
                    }
                    break;
                case 3:    
                    string nombreArchivo = DTGV_BackUp.SelectedRows[0].Cells[0].Value.ToString();
                    Sistema.NombreBDD = nombreArchivo;
                    break;
            }

        }
        private void Btn_Bitacora_Click(object sender, EventArgs e)
        {
            Pnl_Bitacora.Visible = true;
        }
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                capturarDatos(1);
                DTGV_Bitacora.DataSource = null;
                DTGV_Bitacora.DataSource = Sistema.BuscarBitacora();
                nombrarColumnas();
                DTGV_Bitacora.ClearSelection();
            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }
        }
        private void Btn_VerTodo_Click(object sender, EventArgs e)
        {
            cargarDTGV();

        }
        private void configurarLoad()
        {
            Dtp_Hasta.Value = DateTime.Now.AddYears(2);

            Cmb_Tipo.DataSource = Sistema.ObtenerAccion();
            Cmb_Tipo.DisplayMember = "DescripcionAccion";
            Cmb_Tipo.ValueMember = "ID_Accion";
            Cmb_Tipo.SelectedIndex = -1;
            ///////////////////////////////////////


            if (DTGV_PermisosActuales.Rows.Count < 1 && DTGV_PermisosRestantes.Rows.Count < 1)
            {
                Btn_Funcion.Visible = false;
            }
            Btn_RestaurarBDD.Enabled = false;            
            Pnl_Permisos.Enabled = false;
            Pnl_ConfPass.Enabled = false;
            Pnl_Backup.Enabled = false;
            Pnl_Bitacora.Enabled = false;
            Pnl_Backup.Enabled=false;
            foreach (var permiso in CSesion_SesionIniciada.Permisos)
            {
                switch (permiso.ID_Rol)
                {
                    case 1:
                        Btn_RestaurarBDD.Enabled = true;
                        Pnl_Backup.Enabled = true;
                        Pnl_Bitacora.Enabled = true;
                        Pnl_Backup.Enabled = true;
                        Pnl_Permisos.Enabled = true;
                        Pnl_ConfPass.Enabled = true;
                        break;
                    case 18:
                        Pnl_ConfPass.Enabled = true;
                        break;
                    case 62:
                        Pnl_Backup.Enabled = true;
                        Btn_RestaurarBDD.Enabled = true;
                        break;
                    case 64:
                        Pnl_Permisos.Enabled = true;
                        break;
                    case 65:
                        Pnl_ConfPass.Enabled = true;
                        break;
                }
            }
        }
        private void configurarDTGV()
        {
            DTGV_Bitacora.AllowUserToResizeColumns = false;
            DTGV_Bitacora.AllowUserToResizeRows = false;
            DTGV_Bitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_Bitacora.MultiSelect = false;
            DTGV_Bitacora.AllowUserToAddRows = false;
            DTGV_Bitacora.AllowUserToResizeColumns = false;
            DTGV_Bitacora.AllowUserToResizeRows = false;
            DTGV_Bitacora.ReadOnly = true;
            DTGV_Bitacora.RowHeadersVisible = false;
            DTGV_Bitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DTGV_Bitacora.ClearSelection();

            DTGV_BackUp.Rows.Clear();
            DTGV_BackUp.AllowUserToResizeColumns = false;
            DTGV_BackUp.AllowUserToResizeRows = false;
            DTGV_BackUp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_BackUp.MultiSelect = false;
            DTGV_BackUp.AllowUserToAddRows = false;
            DTGV_BackUp.AllowUserToResizeColumns = false;
            DTGV_BackUp.AllowUserToResizeRows = false;
            DTGV_BackUp.ReadOnly = true;
            DTGV_BackUp.RowHeadersVisible = false;
            DTGV_BackUp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;          
            DTGV_BackUp.Columns.Add("NombreArchivo", "Nombre del Archivo");

            CServ_BackUpBDD.CargarBackUps(DTGV_BackUp);
            DTGV_BackUp.ClearSelection();
            ///////////////////////////////////////////////////////////////////////////////////////


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
        private void cargarDTGV()
        {
            DTGV_Bitacora.DataSource = null;
            DTGV_Bitacora.DataSource = Sistema.MostrarBitacora();
            nombrarColumnas();
            DTGV_Bitacora.ClearSelection();
        }
        private void nombrarColumnas()
        {
            DTGV_Bitacora.Columns[0].HeaderText = "ID";
            DTGV_Bitacora.Columns[1].HeaderText = "Usuario";
            DTGV_Bitacora.Columns[2].HeaderText = "Fecha";
            DTGV_Bitacora.Columns[3].HeaderText = "Acción";
            DTGV_Bitacora.Columns[4].HeaderText = "Descripción";
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

        #endregion
    }
}
