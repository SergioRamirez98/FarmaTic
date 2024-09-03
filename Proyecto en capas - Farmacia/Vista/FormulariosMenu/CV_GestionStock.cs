using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Servicios;

namespace Vista
{
    public partial class CV_Stock : Form
    {
        CL_Productos Productos = new CL_Productos();
        public CV_Stock()
        {
            InitializeComponent();
        }
        #region Eventos
        private void CV_GestionStock_Load(object sender, EventArgs e)
        {
            configurarDTGV();
            Productos.EliminarProductosVencidos();
            mostrarProductos();
            configurarLoad();
        }
        private void Chb_Busqueda_CheckedChanged(object sender, EventArgs e)
        {
            if (Chb_Busqueda.Checked)
            {
                nuevosControles();
                Txb_Nombre.Text = "";
                Txb_Marca.Text = "";
                Txb_Descripcion.Text="";
                Txb_Nombre.Enabled = true;
                Txb_Marca.Enabled = true;
                Txb_Descripcion.Enabled = true;
                Btn_Buscar.Enabled = true;
                Btn_Modificar.Enabled = false;
                Btn_Eliminar.Enabled = false;

            }
            else {reestablecerControles(); CServ_Limpiar.LimpiarFormulario(this); desbloquearControles(); }

        }
        private void CV_GestionStock_Click(object sender, EventArgs e)
        {
            configurarLoad();
            desbloquearControles();
        }
        private void DTGV_Productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Chb_Busqueda.Checked = false;
            cargarControles();
            bloquearControles();
            if (Pnl_Busqueda.Visible)
            {
                Chb_Busqueda.Checked = false;

            }
            Btn_Modificar.Enabled = true;
            Btn_Agregar.Enabled = false;
            Btn_GuardarCambios.Enabled = false;
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
                    CServ_Limpiar.LimpiarFormulario(this);

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
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            desbloquearControles();
            Btn_GuardarCambios.Enabled = true;
        }
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            pasarDatos();
            DTGV_Productos.DataSource = Productos.ConsultarProductos();
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
                    CServ_Limpiar.LimpiarFormulario(this);
                }
                catch (Exception ex)
                {

                    CServ_MsjUsuario.MensajesDeError(ex.Message);
                }
            }
        }
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (DTGV_Productos.SelectedRows.Count > 0)
            {
                int ID_Producto = Convert.ToInt32(DTGV_Productos.SelectedRows[0].Cells["ID_Producto"].Value);
                bool respuesta = CServ_MsjUsuario.Preguntar("¿Está seguro de querer borrar los datos seleccionados?");
                if (respuesta)
                {
                    try
                    {
                        Productos.EliminarProducto(ID_Producto);
                        CServ_MsjUsuario.Exito("El producto ha sido eliminado");
                        mostrarProductos();
                        CServ_Limpiar.LimpiarFormulario(this);
                        desbloquearControles();
                    }
                    catch (Exception ex)
                    {
                        CServ_MsjUsuario.MensajesDeError(ex.Message);
                    }
                    

                }
            }
            else
            {
                CServ_MsjUsuario.MensajesDeError("No ha seleccionado ningun producto.");

            }

        }
        private void Btn_VtoProductos_Click(object sender, EventArgs e)
        {
            CV_ControlVencimientos ControldeVencimientos = new CV_ControlVencimientos();
            ControldeVencimientos.Show();
        }
        private void Btn_StockCritico_Click(object sender, EventArgs e)
        {
            CV_StockMinimo ControldeVencimientos = new CV_StockMinimo();
            ControldeVencimientos.Show();
        }
        private void Btn_VerProdVencidos_Click(object sender, EventArgs e)
        {
            CV_ProdVencido ProductosVencidos = new CV_ProdVencido();
            ProductosVencidos.Show();
        }
        #endregion

        #region Metodos

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
        }
        private void mostrarProductos()
        {
            DTGV_Productos.DataSource = null;
            DTGV_Productos.DataSource = Productos.MostrarProductos();
            DTGV_Productos.Columns[0].DisplayIndex = 0;
            DTGV_Productos.Columns[1].DisplayIndex = 1;
            DTGV_Productos.Columns[2].DisplayIndex = 2;
            DTGV_Productos.Columns[3].DisplayIndex = 4;
            DTGV_Productos.Columns[4].DisplayIndex = 5;
            DTGV_Productos.Columns[5].DefaultCellStyle.Format = "#,##0.00";
            DTGV_Productos.Columns[5].DisplayIndex = 6;
            DTGV_Productos.Columns[6].DisplayIndex = 7;
            DTGV_Productos.Columns[7].DisplayIndex = 8;
            DTGV_Productos.Columns[8].DisplayIndex = 3;

            DTGV_Productos.Columns[0].HeaderText = "ID";
            DTGV_Productos.Columns[1].HeaderText = "Nombre del producto";
            DTGV_Productos.Columns[2].HeaderText = "Marca";
            DTGV_Productos.Columns[3].HeaderText = "Descripcion del producto";
            DTGV_Productos.Columns[4].HeaderText = "Cantidad";
            DTGV_Productos.Columns[5].HeaderText = "Precio unitario";
            DTGV_Productos.Columns[6].HeaderText = "Vencimiento";
            DTGV_Productos.Columns[7].HeaderText = "Numero de lote";
            DTGV_Productos.Columns[8].HeaderText = "Categoría";
            DTGV_Productos.ClearSelection();
        }        
        private void pasarDatos()
        {
            Productos.Prop_Nombre = Txb_Nombre.Text;
            Productos.Prop_Marca = Txb_Marca.Text;
            Productos.Prop_Descripcion = Txb_Descripcion.Text;
            Productos.Prop_Cantidad = Txb_Cantidad.Text;
            Productos.Prop_Precio = Txb_Precio.Text;
            Productos.Prop_NumLote = Txb_NumLote.Text;
            Productos.Prop_VtoProd = Dtp_FeVto.Value.ToString("yyyy-MM-dd 00:00:00");
            Productos.Prop_Categoria = Cmb_Categoria.Text;

            if (Chb_Busqueda.Checked)
            {
                Productos.Prop_CantDesde = Txb_CantDesde.Text;
                Productos.Prop_CantHasta = Txb_CantHasta.Text;
                Productos.Prop_PrecDesde = Txb_PrecDesde.Text;
                Productos.Prop_PrecHasta = Txb_PrecHasta.Text;
                Productos.Prop_NLoteBusq = Txb_NLoteBusq.Text;
                Productos.Prop_VtoDesde = Dtp_VtoDesde.Value.ToString("yyyy-MM-dd 00:00:00");
                Productos.Prop_VtoHasta = Dtp_VtoHasta.Value.ToString("yyyy-MM-dd 00:00:00");

            }
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
            Cmb_Categoria.Text = DTGV_Productos.CurrentRow.Cells[8].Value.ToString();
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
            Cmb_Categoria.Enabled = false;
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
            Cmb_Categoria.Enabled=true;
        }
        private void nuevosControles() 
        {
            Pnl_Busqueda.Enabled = true;
            Pnl_Busqueda.Visible = true;

            Lbl_Cantidad.Visible = false;
            Txb_Cantidad.Visible = false;
            Txb_Cantidad.Enabled=false;

            Lbl_NroLote.Visible = false;
            Txb_NumLote.Enabled = false;
            Txb_NumLote.Visible = false;

            Lbl_Precio.Visible = false;
            Txb_Precio.Enabled = false;
            Txb_Precio.Visible = false;

            Lbl_Vto.Visible = false;
            Dtp_FeVto.Visible = false;
            Dtp_FeVto.Enabled = false;

            Lbl_Categoria.Visible = false;
            Cmb_Categoria.Visible = false;
            Cmb_Categoria.Enabled = false;


            Btn_Buscar.Enabled = true;
            Btn_Agregar.Enabled = false;
            
        }
        private void reestablecerControles()
        {
            Pnl_Busqueda.Enabled = false;
            Pnl_Busqueda.Visible = false;

            Lbl_Cantidad.Visible = true;
            Txb_Cantidad.Visible = true;
            Txb_Cantidad.Enabled = true;

            Lbl_NroLote.Visible = true;
            Txb_NumLote.Enabled = true;
            Txb_NumLote.Visible = true;

            Lbl_Precio.Visible = true;
            Txb_Precio.Enabled = true;
            Txb_Precio.Visible = true;

            Lbl_Vto.Visible = true;
            Dtp_FeVto.Visible = true;
            Dtp_FeVto.Enabled = true;

            Lbl_Categoria.Visible = true;
            Cmb_Categoria.Visible = true;
            Cmb_Categoria.Enabled = true;

            Btn_Buscar.Enabled = false;
            Btn_Agregar.Enabled = true;
        }
        private void configurarLoad()
        {
            CServ_Limpiar.LimpiarFormulario(this);
            Pnl_Busqueda.Visible = false;
            Pnl_Busqueda.Enabled = false;
            Btn_Agregar.Enabled = true;
            Btn_Modificar.Enabled = false;
            Btn_Buscar.Enabled = false;
            Btn_GuardarCambios.Enabled = false;
            Btn_Eliminar.Enabled = true;
            Size = new Size(1050, 555);
            Pnl_Busqueda.Location = new Point(350, 20);

            Cmb_Categoria.Items.Add("Medicamentos");
            Cmb_Categoria.Items.Add("Cuidado personal");
            Cmb_Categoria.Items.Add("Higiene");
            Cmb_Categoria.Items.Add("Cuidado bucal");
            Cmb_Categoria.Items.Add("Suplementos");
            Cmb_Categoria.Items.Add("Primeros auxilios");

            Dtp_VtoHasta.Value = DateTime.Now.AddYears(2);

            DataTable Dt = Productos.CargarVtoProductos();
            if (Dt.Rows.Count>0)
            {
                Timer timer = new Timer();
                timer.Interval = 500; 
                timer.Tick += (sender, e) =>
                {
                    if (Btn_VtoProductos.BackColor == Color.Yellow)
                    { Btn_VtoProductos.BackColor = Color.White; }
                    else
                    { Btn_VtoProductos.BackColor = Color.Yellow; }
                };
                timer.Start();
            }
            else
            {
                Btn_VtoProductos.BackColor = Color.White; ;
            }
            DataTable DT2 = Productos.CargarStockMinimo();
            if (DT2.Rows.Count > 0)
            {
                Timer timer = new Timer();
                timer.Interval = 500;
                timer.Tick += (sender, e) =>
                {
                    if (Btn_StockCritico.BackColor == Color.Yellow)
                    { Btn_StockCritico.BackColor = Color.White; }
                    else
                    { Btn_StockCritico.BackColor = Color.Yellow; }
                };
                timer.Start();
            }
            else
            {
                Btn_StockCritico.BackColor = Color.White; ;
            }
            DTGV_Productos.ClearSelection();

        }

        #endregion

    }
}
