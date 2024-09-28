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
        #endregion
        public CV_GestionProveedores()
        {
            InitializeComponent();
        }

        private void CV_GestionProveedores_Load(object sender, EventArgs e)
        {
            cargarComboBox();
            configurarDTGV();
            cargarDTGV();
            configurarLoad();
        }
        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            pasarDatos();
            if (Proveedores.ConsultarCUIT(Txb_Cuit.Text, dt) == false)
            {
                try
                {
                    Proveedores.InsertarProveedor();
                    CServ_MsjUsuario.Exito("El Proveedor fue ingresado exitosamente.");
                    cargarDTGV();
                    CServ_Limpiar.LimpiarFormulario(this);

                }
                catch (Exception ex)
                {
                    CServ_MsjUsuario.MensajesDeError(ex.Message);
                }

            }
            else
            {
                CServ_MsjUsuario.MensajesDeError("Ya existe un proveedor registrado con este numero de CUIT");
            }

        }
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            pasarDatos();
            try
            {
              DTGV_Proveedores.DataSource=  Proveedores.BuscarProveedor();
            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }
        }
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            Btn_Guardar.Enabled = true;
            Pnl_DatosProveedores.Enabled = true;
        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            pasarDatos();
            try
            {
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
            if (DTGV_Proveedores.Rows.Count > 0)
            {
                //Preguntar Si dice que si, lo ejecutamos
                Proveedores.ID_Proveedor = DTGV_Proveedores.SelectedRows[0].Cells["ID_Proveedor"].Value.ToString();
                bool respuesta = CServ_MsjUsuario.Preguntar("¿Está seguro de querer borrar los datos seleccionados?");
                if (respuesta)
                {
                    try
                    {
                        Proveedores.EliminarProveedor();
                        CServ_MsjUsuario.Exito("El producto ha sido eliminado");
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



        private void configurarLoad() 
        {
            DTGV_Proveedores.ClearSelection();
            Btn_Agregar.Enabled = true;
            Btn_Buscar.Enabled = true;
            Btn_Eliminar.Enabled = false;
            Btn_Guardar.Enabled = false;
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
            /*
            DTGV_Proveedores.Columns[0].DisplayIndex = 0;
            DTGV_Proveedores.Columns[1].DisplayIndex = 1;
            DTGV_Proveedores.Columns[2].DisplayIndex = 2;
            DTGV_Proveedores.Columns[3].DisplayIndex = 4;
            DTGV_Proveedores.Columns[4].DisplayIndex = 5;
            DTGV_Proveedores.Columns[5].DisplayIndex = 6;
            DTGV_Proveedores.Columns[6].DisplayIndex = 7;
            DTGV_Proveedores.Columns[7].DisplayIndex = 8;
            DTGV_Proveedores.Columns[8].DisplayIndex = 3;
            */
            DTGV_Proveedores.Columns[0].HeaderText = "ID Proveedor";
            DTGV_Proveedores.Columns[1].HeaderText = "Razon social";
            DTGV_Proveedores.Columns[2].HeaderText = "Matricula";
            DTGV_Proveedores.Columns[3].HeaderText = "Direccion";
            DTGV_Proveedores.Columns[4].HeaderText = "Localidad";
            DTGV_Proveedores.Columns[5].HeaderText = "Telefono";
            DTGV_Proveedores.Columns[6].HeaderText = "CUIT";
            DTGV_Proveedores.Columns[7].HeaderText = "Mail";
            DTGV_Proveedores.Columns[8].HeaderText = "IIBB";
            DTGV_Proveedores.Columns[9].HeaderText = "Condicion IVA";            
        }
        private void cargarComboBox()
        {
            Cmb_Localidad.DataSource = GestionPersonas.ObtenerLocalidad();
            Cmb_Localidad.DisplayMember = "Localidad";
            Cmb_Localidad.ValueMember = "ID_Localidad";
            Cmb_Localidad.SelectedIndex = -1;

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
            Cmb_Localidad.Text = DTGV_Proveedores.CurrentRow.Cells[4].Value.ToString();
            Txb_Telefono.Text = DTGV_Proveedores.CurrentRow.Cells[5].Value.ToString();
            Txb_Cuit.Text = DTGV_Proveedores.CurrentRow.Cells[6].Value.ToString();
            Txb_Mail.Text = DTGV_Proveedores.CurrentRow.Cells[7].Value.ToString();
            Chb_IIBB.Checked = Convert.ToBoolean(DTGV_Proveedores.CurrentRow.Cells[8].Value);
            Cmb_IVA.Text = DTGV_Proveedores.CurrentRow.Cells[9].Value.ToString();
        }


    }
}
