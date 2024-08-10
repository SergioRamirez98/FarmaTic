using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Servicios;

namespace Vista
{
    public partial class CV_GestionStock : Form
    {
        CL_Productos Productos = new CL_Productos();
        public CV_GestionStock()
        {
            InitializeComponent();
        }
        #region Eventos
        private void CV_GestionStock_Load(object sender, EventArgs e)
        {
            configurarDTGV();
            mostrarProductos();
        }
        
        private void configurarDTGV()
        {            
            DTGV_Productos.AllowUserToResizeColumns = false;
            DTGV_Productos.AllowUserToResizeRows = false;
            DTGV_Productos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_Productos.MultiSelect = false;
            DTGV_Productos.AllowUserToAddRows = false;
            DTGV_Productos.AllowUserToResizeColumns = false;
            DTGV_Productos.AllowUserToResizeRows = false;
            DTGV_Productos.ReadOnly = true;
            DTGV_Productos.RowHeadersVisible = false;
            DTGV_Productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
           // DTGV_Productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void mostrarProductos()
        {
            DTGV_Productos.DataSource = null;
            DTGV_Productos.DataSource = Productos.MostrarProductos("");
            DTGV_Productos.Columns[0].HeaderText = "ID del producto";
            DTGV_Productos.Columns[1].HeaderText = "Nombre del producto";
            DTGV_Productos.Columns[2].HeaderText = "Marca";
            DTGV_Productos.Columns[3].HeaderText = "Descripcion del producto";
            DTGV_Productos.Columns[4].HeaderText = "Cantidad";
            DTGV_Productos.Columns[5].HeaderText = "Precio unitario";
            DTGV_Productos.Columns[6].HeaderText = "Vencimiento";
            DTGV_Productos.Columns[7].HeaderText = "Numero de lote";
        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            pasarDatos();        
            if (consultarLote(Txb_NumLote.Text) == false)
            {
                try
                {
                    Productos.InsertarProducto();
                    CServ_MsjUsuario.Exito("El producto fue ingresado exitosamente.");
                    mostrarProductos();
                }
                catch (Exception ex)
                {
                    CServ_MsjUsuario.MensajesDeError(ex.Message);
                }

            }
            else
            {
                if (CServ_MsjUsuario.Preguntar("El lote cargado ya existe. ¿Desea actualizar el lote existente?") == true)
                {
                    try
                    {
                        pasarDatos();
                        Productos.ModificarProductos();
                    }
                    catch (Exception ex)
                    {

                        CServ_MsjUsuario.MensajesDeError(ex.Message);
                    }
                } 
            }
            
        }
        private void DTGV_Productos_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            cargarControles();
            bloquearControles();
            Btn_Agregar.Enabled = false;
            Btn_Buscar.Enabled = false;
            Btn_GuardarCambios.Enabled = false;
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            desbloquearControles();
            Btn_GuardarCambios.Enabled = true;
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {

        }

        private void Btn_GuardarCambios_Click(object sender, EventArgs e)
        {
            if (DTGV_Productos.SelectedRows.Count >0)
            {
                int ID_Producto = Convert.ToInt32(DTGV_Productos.SelectedRows[0].Cells["ID_Producto"].Value);
                pasarDatos(ID_Producto);
                try
                {
                    Productos.ModificarProductos();
                    CServ_MsjUsuario.Exito("Producto actualizado");
                    mostrarProductos();
                    CServ_LimpiarControles.LimpiarFormulario(this);
                }
                catch (Exception ex)
                {

                    CServ_MsjUsuario.MensajesDeError(ex.Message);
                }

            }

        }
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Metodos
        private void pasarDatos()
        {
            Productos.Prop_Nombre = Txb_Nombre.Text;
            Productos.Prop_Marca = Txb_Marca.Text;
            Productos.Prop_Descripcion = Txb_Descripcion.Text;
            Productos.Prop_Cantidad = Txb_Cantidad.Text;
            Productos.Prop_Precio = Txb_Precio.Text;
            Productos.Prop_NumLote = Txb_NumLote.Text;
            Productos.Prop_VtoProd = Dtp_FeVto.Value.ToString("yyyy-MM-dd 00:00:00");
        }
        private void pasarDatos(int ID_Producto)
        {
            Productos.Prop_ID_Producto = ID_Producto.ToString();
            Productos.Prop_Nombre = Txb_Nombre.Text;
            Productos.Prop_Marca = Txb_Marca.Text;
            Productos.Prop_Descripcion = Txb_Descripcion.Text;
            Productos.Prop_Cantidad = Txb_Cantidad.Text;
            Productos.Prop_Precio = Txb_Precio.Text;
            Productos.Prop_NumLote = Txb_NumLote.Text;
            Productos.Prop_VtoProd = Dtp_FeVto.Value.ToString("yyyy-MM-dd 00:00:00");
        }
        private bool consultarLote(string NLote)
        {
            bool ExisteLote = false;
            foreach (DataGridViewRow item in DTGV_Productos.Rows)
            {
                if (NLote == item.Cells[7].Value.ToString())
                {
                    ExisteLote = true;
                    break;
                }
                else { ExisteLote = false; }
            }
            return ExisteLote;
        }

        private void cargarControles()
        {
            Txb_Nombre.Text = DTGV_Productos.CurrentRow.Cells[1].Value.ToString();
            Txb_Marca.Text = DTGV_Productos.CurrentRow.Cells[2].Value.ToString();
            Txb_Descripcion.Text = DTGV_Productos.CurrentRow.Cells[3].Value.ToString();
            Txb_Cantidad.Text = DTGV_Productos.CurrentRow.Cells[4].Value.ToString();
            Txb_Precio.Text = DTGV_Productos.CurrentRow.Cells[5].Value.ToString();
            Dtp_FeVto.Value = Convert.ToDateTime(DTGV_Productos.CurrentRow.Cells[6].Value.ToString());
            Txb_NumLote.Text = DTGV_Productos.CurrentRow.Cells[7].Value.ToString();
        }
        private void bloquearControles()
        {
            Txb_Nombre.Enabled = false;
            Txb_Marca.Enabled = false;
            Txb_Descripcion.Enabled = false;
            Txb_Cantidad.Enabled = false;
            Txb_Precio.Enabled = false;
            Txb_NumLote.Enabled = false;
            Dtp_FeVto.Enabled = false;
        }
        private void desbloquearControles()
        {
            Txb_Nombre.Enabled = true;
            Txb_Marca.Enabled = true;
            Txb_Descripcion.Enabled = true;
            Txb_Cantidad.Enabled = true;
            Txb_Precio.Enabled = true;
            Txb_NumLote.Enabled = true;
            Dtp_FeVto.Enabled = true;
        }

        #endregion


    }
}
