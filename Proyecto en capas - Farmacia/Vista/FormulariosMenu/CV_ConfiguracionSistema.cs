using Logica;
using Modelo;
using Servicios;
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

        bool Familia =false;
        string Usuario, Grupo;
        public CV_ConfiguracionSistema()
        {
            InitializeComponent();
        }

        private void CV_ConfiguracionSistema_Load(object sender, EventArgs e)
        {
            configurarDTGV();
            Nud_CantMinStock.Value = CSistema_ConfiguracionSistema.CantMinimadeStock;
            Nud_VtoProd.Value = CSistema_ConfiguracionSistema.AvisosVtoProductos;
        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                capturarDatos();
                Sistema.GuardarCambiosDeSistema();
                CServ_MsjUsuario.Exito("¡Configuración guardada con éxito!");
            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }
        }
        private void capturarDatos()
        {
            Sistema.AvisosVtoProductos = Convert.ToInt32(Nud_VtoProd.Value);
            Sistema.CantMinimadeStock = Convert.ToInt32(Nud_CantMinStock.Value);
            if (DTGV_FamiliaUsuario.SelectedRows.Count>0)
            {
                if (Familia)
                {
                    foreach (var item in permisosActuales)
                    {
                        Console.WriteLine(item.DescripcionPermiso);
                    }
                }
            }
            
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

        private void Btn_Usuarios_Click(object sender, EventArgs e)
        {
            DTGV_PermisosActuales.DataSource = null;
            DTGV_PermisosRestantes.DataSource = null;
            DTGV_FamiliaUsuario.DataSource = null;
            DTGV_FamiliaUsuario.DataSource = Sistema.ObtenerPermisosUsuarioFamilia("Usuario");
            DTGV_FamiliaUsuario.Columns[0].HeaderText = "Nombre Usuario";
            DTGV_FamiliaUsuario.ClearSelection();
            Familia = false;
        }

        private void Btn_Grupo_Click(object sender, EventArgs e)
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
                if (Familia) Grupo = DTGV_FamiliaUsuario.Rows[Seleccion].Cells[0].Value.ToString();                
                else Usuario = DTGV_FamiliaUsuario.Rows[Seleccion].Cells[0].Value.ToString();


                listaCompleta = Sistema.ObtenerPermisosActuales(FamiliaUsuario, Familia);
                cargarListaPermisos(true);
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
            DTGV_PermisosRestantes.DataSource= permisosRestantes;
            DTGV_PermisosRestantes.Columns[1].HeaderText = "Permiso restantes";
            DTGV_PermisosRestantes.Columns[0].Visible = false;
            DTGV_PermisosRestantes.ClearSelection();

        }

        private void DTGV_PermisosActuales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DTGV_PermisosRestantes.ClearSelection();
            Btn_Funcion.Text = "Quitar";
        }

        private void DTGV_PermisosRestantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DTGV_PermisosActuales.ClearSelection();
            Btn_Funcion.Text = "Agregar";
        }

        private void Btn_Funcion_Click(object sender, EventArgs e)
        {
            int seleccion = 0;
            if (Btn_Funcion.Text == "Agregar")
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
            else
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
                        
            cargarListaPermisos(false);
        }
    }
}
