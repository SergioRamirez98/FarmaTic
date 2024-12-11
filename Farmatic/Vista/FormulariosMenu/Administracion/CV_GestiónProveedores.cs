using Logica;
using Servicios;
using Sesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class CV_GestionProveedores : Form
    {
        #region Atributos
        CL_Proveedores Proveedores = new CL_Proveedores();
        CL_Personas GestionPersonas = new CL_Personas();
        DataTable dt = new DataTable();
        int ID_Proveedor=0;
        bool Agregar = false;
        bool Eliminar = false;
        bool Modificar = false;
        #endregion
        public CV_GestionProveedores()
        {
            InitializeComponent();
            CV_Idioma.CargarIdioma(this.Controls, this);
        }

        #region Eventos
        private void CV_GestionProveedores_Load(object sender, EventArgs e)
        {
            cargarComboBox();
            configurarDTGV();
            cargarDTGV();
            configurarLoad();
            cargarPermisos();
            CServ_ConfControles.ConfiguraciondeControles(this);
        }
        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            if (Agregar)
            {
                if (Proveedores.ConsultarCUIT(Txb_Cuit.Text, dt) == false)
                {
                    pasarDatos();
                    try
                    {
                        Proveedores.InsertarProveedor();
                        CServ_MsjUsuario.Exito("El Proveedor fue ingresado exitosamente.");
                        cargarDTGV();
                        Btn_Refrescar_Click(sender, e);

                    }
                    catch (Exception ex)
                    {
                        CServ_MsjUsuario.MensajesDeError(ex.Message);
                    }

                }
                else CServ_MsjUsuario.MensajesDeError("Ya existe un proveedor registrado con este numero de CUIT");
            }
            else CServ_MsjUsuario.MensajesDeError("No posee permisos para realizar esta operación");
        }
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                pasarDatos();
                DTGV_Proveedores.DataSource=  Proveedores.BuscarProveedor();
            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }
        }
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Modificar)
            {
                Btn_Guardar.Enabled = true;
                Pnl_DatosProveedores.Enabled = true;
            }
            else CServ_MsjUsuario.MensajesDeError("No posee permisos para realizar esta operación");
            
        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                pasarDatos();
                Proveedores.InsertarCambios();
                CServ_MsjUsuario.Exito("El Proveedor fue actualizado exitosamente.");
                cargarDTGV();
                CServ_Limpiar.LimpiarPanelBox(Pnl_DatosProveedores);
                configurarLoad();
            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }
        }
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (Eliminar)
            {
                if (DTGV_Proveedores.Rows.Count > 0)
                {

                    Proveedores.ID_Proveedor = DTGV_Proveedores.SelectedRows[0].Cells["ID_Proveedor"].Value.ToString();
                    bool respuesta = CServ_MsjUsuario.Preguntar("¿Está seguro de querer borrar los datos seleccionados?");
                    if (respuesta)
                    {
                        try
                        {
                            Proveedores.EliminarProveedor();
                            CServ_MsjUsuario.Exito("El proveedor ha sido eliminado");
                            CServ_Limpiar.LimpiarPanelBox(Pnl_DatosProveedores);
                            Pnl_DatosProveedores.Enabled = true;
                            configurarLoad();
                            cargarDTGV();
                        }
                        catch (Exception ex)
                        {
                            CServ_MsjUsuario.MensajesDeError(ex.Message);
                        }

                    }
                }
            }
            else CServ_MsjUsuario.MensajesDeError("No posee permisos para realizar esta operación");
          }
        private void Btn_Refrescar_Click(object sender, EventArgs e)
        {
            CServ_Limpiar.LimpiarPanelBox(Pnl_DatosProveedores);
            Pnl_DatosProveedores.Enabled= true;
            configurarLoad();
            cargarDTGV();
        }
        private void DTGV_Proveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Pnl_DatosProveedores.Enabled = false;
            Btn_Agregar.Enabled = false;
            Btn_Buscar.Enabled = false;
            Btn_Guardar.Enabled = false;
            Btn_Eliminar.Enabled = true;            
            cargarControles();
            if (DTGV_Proveedores.SelectedRows.Count > 0)
            {
                ID_Proveedor = Convert.ToInt32(DTGV_Proveedores.SelectedRows[0].Cells["ID_Proveedor"].Value);
            }
        }
        private void Cmb_Partido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Partido.SelectedIndex > 0)
            {
                int ID_Seleccionado = Convert.ToInt32(Cmb_Partido.SelectedValue);
                DataTable dt = GestionPersonas.ObtenerLocalidades(ID_Seleccionado);
                if (dt.Rows.Count > 0)
                {
                    Cmb_Localidad.DataSource = dt;
                    Cmb_Localidad.DisplayMember = "Localidad";
                    Cmb_Localidad.ValueMember = "ID_Localidad";
                    Cmb_Localidad.SelectedIndex = -1;
                    Cmb_Localidad.Enabled = true;
                }
                else
                {
                    Cmb_Localidad.Enabled = false;
                    Cmb_Localidad.SelectedIndex = -1;
                }

            }
        }
        
        #endregion

        #region Métodos
        private void configurarLoad() 
        {
            DTGV_Proveedores.ClearSelection();
            Btn_Agregar.Enabled = true;
            Btn_Buscar.Enabled = true;
            Btn_Eliminar.Enabled = false;
            Btn_Guardar.Enabled = false;
            Cmb_Localidad.Enabled = false;
        }
        private void configurarDTGV()
        {
            DTGV_Proveedores.AllowUserToResizeColumns = false;
            DTGV_Proveedores.AllowUserToResizeRows = false;
            DTGV_Proveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_Proveedores.MultiSelect = false;
            DTGV_Proveedores.AllowUserToAddRows = false;
            DTGV_Proveedores.AllowUserToResizeColumns = false;
            DTGV_Proveedores.AllowUserToResizeRows = false;
            DTGV_Proveedores.ReadOnly = true;
            DTGV_Proveedores.RowHeadersVisible = false;
            DTGV_Proveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            DTGV_Proveedores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
        }
        private void cargarDTGV()
        {
            dt= Proveedores.MostrarProveedores();
            DTGV_Proveedores.DataSource = dt;
            
            DTGV_Proveedores.Columns[0].HeaderText = "ID Proveedor";
            DTGV_Proveedores.Columns[1].HeaderText = "Razon social";
            DTGV_Proveedores.Columns[2].HeaderText = "Matricula";
            DTGV_Proveedores.Columns[3].HeaderText = "Direccion";
            DTGV_Proveedores.Columns[4].HeaderText = "Partido";

            DTGV_Proveedores.Columns[5].HeaderText = "Localidad";

            DTGV_Proveedores.Columns[6].HeaderText = "Telefono";
            DTGV_Proveedores.Columns[7].HeaderText = "CUIT";
            DTGV_Proveedores.Columns[8].HeaderText = "Mail";
            DTGV_Proveedores.Columns[9].HeaderText = "IIBB";
            DTGV_Proveedores.Columns[10].HeaderText = "Condicion IVA";   
            DTGV_Proveedores.ClearSelection();
        }
        private void cargarComboBox()
        {
            Cmb_Partido.DataSource = GestionPersonas.ObtenerPartido();
            Cmb_Partido.DisplayMember = "Partido";
            Cmb_Partido.ValueMember = "ID_Partido";
            Cmb_Partido.SelectedIndex = -1;

            Cmb_IVA.DataSource = Proveedores.ObtenerIVA();
            Cmb_IVA.DisplayMember = "DescripcionIVA";
            Cmb_IVA.ValueMember = "ID_IVA";
            Cmb_IVA.SelectedIndex = -1;

        }
        private void pasarDatos() 
        {
            if (ID_Proveedor !=0)
            {
                Proveedores.ID_Proveedor = ID_Proveedor.ToString();
            }
            Proveedores.RazonSocial = Txb_RazonSocial.Text;
            Proveedores.CUIT = Txb_Cuit.Text;
            Proveedores.Matricula = Txb_Matricula.Text;
            Proveedores.Telefono=Txb_Telefono.Text;
            Proveedores.Direccion = Txb_Direccion.Text;
            Proveedores.Partido = Cmb_Partido.Text;
            Proveedores.Localidad = Cmb_Localidad.Text;
            Proveedores.Mail = Txb_Mail.Text;
            Proveedores.IVA = Cmb_IVA.Text;
            Proveedores.IIBB= Chb_IIBB.Checked.ToString();
        }
        private void cargarControles()
        {
            Txb_RazonSocial.Text = DTGV_Proveedores.CurrentRow.Cells[1].Value.ToString();
            Txb_Matricula.Text = DTGV_Proveedores.CurrentRow.Cells[2].Value.ToString();
            Txb_Direccion.Text = DTGV_Proveedores.CurrentRow.Cells[3].Value.ToString();
            Cmb_Partido.Text = DTGV_Proveedores.CurrentRow.Cells[4].Value.ToString();
            Cmb_Localidad.Text = DTGV_Proveedores.CurrentRow.Cells[5].Value.ToString();
            Txb_Telefono.Text = DTGV_Proveedores.CurrentRow.Cells[6].Value.ToString();
            Txb_Cuit.Text = DTGV_Proveedores.CurrentRow.Cells[7].Value.ToString();
            Txb_Mail.Text = DTGV_Proveedores.CurrentRow.Cells[8].Value.ToString();
            Chb_IIBB.Checked = Convert.ToBoolean(DTGV_Proveedores.CurrentRow.Cells[9].Value);
            Cmb_IVA.Text = DTGV_Proveedores.CurrentRow.Cells[10].Value.ToString();
        }
        private void cargarPermisos()
        {
            foreach (var permiso in CSesion_SesionIniciada.Permisos)
            {
                switch (permiso.ID_Rol)
                {
                    case 1:
                        Agregar = true;
                        Modificar = true;
                        Eliminar = true;
                        break;

                    case 43:
                        Agregar = true;
                        break;
                    case 44:
                        Modificar = true;
                        break;

                    case 45:
                        Eliminar = true;
                        break;
                }
            }
        }

        #endregion
    }
}
