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
using Vista.FormulariosMenu.GestionPersonas;

namespace Vista.FormulariosMenu
{
    public partial class CV_CatalogoProductos : Form
    {
        CL_Catalogo Catalogo = new CL_Catalogo();

        public delegate void ProveedorSeleccionadoHandler(int ID, string proveedor);
        public event ProveedorSeleccionadoHandler ProveedorSeleccionado;        
        int ID_Proveedor = 0;
        int ID_Producto = 0;
        bool Agregar = false;
        bool Buscar= false;
        bool Modificar = false;
        bool Eliminar= false;
        
        public CV_CatalogoProductos()
        {
            InitializeComponent();
        }

        #region Eventos
        private void CV_CatalogoProductos_Load(object sender, EventArgs e)
        {
            configurarDTGV();
            configurarLoad();
            mostrarProductos();
            cargarPermisos();
            CServ_ConfControles.ConfiguraciondeControles(this);
        }
        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            if (Agregar)
            {
                if (Catalogo.ConsultarCatalogo(Txb_NombreComercial.Text) == false)
                {
                    try
                    {
                        pasarDatos(false);
                        Catalogo.InsertarProducto();
                        CServ_MsjUsuario.Exito("El producto fue ingresado exitosamente.");
                        CServ_Limpiar.LimpiarFormulario(this);
                        mostrarProductos();

                    }
                    catch (Exception ex)
                    {
                        CServ_MsjUsuario.MensajesDeError(ex.Message);
                    }

                }
                else
                {
                    if (CServ_MsjUsuario.Preguntar("El producto ya existe. ¿Desea modificarlo?") == true)
                    {
                        try
                        {
                            pasarDatos(false);
                            Catalogo.ModificarProductos();
                        }
                        catch (Exception ex)
                        {

                            CServ_MsjUsuario.MensajesDeError(ex.Message);
                        }
                    }
                    else if (CServ_MsjUsuario.Preguntar("El producto ya existe. ¿Desea agregarlo como producto con promoción/descuento?") == true)
                    {
                        try
                        {
                            pasarDatos(false);
                            Catalogo.InsertarProducto();
                            CServ_MsjUsuario.Exito("El producto fue ingresado exitosamente.");
                            CServ_Limpiar.LimpiarFormulario(this);
                            mostrarProductos();
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
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            if (Buscar)
            {
                try
                {
                    pasarDatos(true);
                    DTGV_Catalogo.DataSource = null;
                    DTGV_Catalogo.DataSource = Catalogo.RealizarBusqueda();
                    nombrarColumnas();
                }
                catch (Exception ex)
                {
                    CServ_MsjUsuario.MensajesDeError(ex.Message);
                }
            }
            else CServ_MsjUsuario.MensajesDeError("No posee permisos para realizar esta operación");
            
        }
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Modificar)
            {
                desbloquearControles();
                Btn_GuardarCambios.Enabled = true;
            }
            else CServ_MsjUsuario.MensajesDeError("No posee permisos para realizar esta operación");
            
        }
        private void Btn_GuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                pasarDatos(false);
                Catalogo.ModificarProductos();
                CServ_MsjUsuario.Exito("Modificación realizada con éxito");
                mostrarProductos();
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
                if (DTGV_Catalogo.SelectedRows.Count > 0)
                {
                    if (CServ_MsjUsuario.Preguntar("Esta seguro que desea eliminar el producto seleccionado"))
                    {
                        pasarDatos(false);
                        Catalogo.EliminarProducto();
                        CServ_MsjUsuario.Exito("Producto eliminado con éxito");
                        mostrarProductos();
                        configurarLoad();
                    }
                }
                else
                {
                    CServ_MsjUsuario.MensajesDeError("No se ha seleccionado ningun producto para eliminar");
                }
            }
            else CServ_MsjUsuario.MensajesDeError("No posee permisos para realizar esta operación");
            
        }
        private void DTGV_Catalogo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DTGV_Catalogo.SelectedRows.Count >0)
            {
                Chb_Busqueda.Checked = false;
                Chb_Busqueda.Enabled= false;
                bloquearControles();
                cargarControles();
                Btn_Agregar.Enabled = true;
                Btn_Eliminar.Enabled = true;
                Btn_Modificar.Enabled = true;
            }
        }
        private void Btn_SeleccionarProveedor_Click(object sender, EventArgs e)
        {
            CV_ObtenerProveedores Proveedores = new CV_ObtenerProveedores();
            Proveedores.ProveedorSeleccionado += new CV_ObtenerProveedores.ProveedorSeleccionadoHandler(seleccionProveedor);
            Proveedores.ShowDialog();
        }
        private void Chb_Busqueda_CheckedChanged(object sender, EventArgs e)
        {
            if (Chb_Busqueda.Checked)
            {
                Pnl_Busqueda.Enabled = true;
                Pnl_Busqueda.Visible = true;
                Btn_Buscar.Enabled = true;
                Pnl_Busqueda.Location = new Point(360, 75);

            }
            else
            {
                CServ_Limpiar.LimpiarFormulario(this);
                Btn_Buscar.Enabled = false;
                Pnl_Busqueda.Enabled = false;
                Pnl_Busqueda.Visible = false;
            }
        }
        private void Btn_Refrescar_Click(object sender, EventArgs e)
        {
            CV_CatalogoProductos_Load(sender, e);
        }
        #endregion

        #region Métodos

        private void configurarDTGV()
        {
            DTGV_Catalogo.AllowUserToResizeColumns = false;
            DTGV_Catalogo.AllowUserToResizeRows = false;
            DTGV_Catalogo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_Catalogo.MultiSelect = false;
            DTGV_Catalogo.AllowUserToAddRows = false;
            DTGV_Catalogo.AllowUserToResizeColumns = false;
            DTGV_Catalogo.AllowUserToResizeRows = false;
            DTGV_Catalogo.ReadOnly = true;
            DTGV_Catalogo.RowHeadersVisible = false;
            DTGV_Catalogo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void mostrarProductos()
        {
            DTGV_Catalogo.DataSource = null;
            DTGV_Catalogo.DataSource = Catalogo.MostrarProductos();
            nombrarColumnas();
            DTGV_Catalogo.ClearSelection();
        }
        private void configurarLoad()
        {
            CServ_Limpiar.LimpiarFormulario(this);
            Btn_Agregar.Enabled = true;
            Btn_Modificar.Enabled = false;
            Btn_Buscar.Enabled = false;
            Btn_GuardarCambios.Enabled = false;
            Btn_Eliminar.Enabled = false;
            Txb_Proveedor.Enabled = false;
            Nud_CompraMinima.Value = 1;
            Nud_UnidadporLote.Value = 1;
            DTGV_Catalogo.ClearSelection();
            Chb_Busqueda.Checked= false;
            Pnl_Busqueda.Enabled = false;
            Pnl_Busqueda.Visible = false;
            CServ_Limpiar.LimpiarPanelBox(Pnl_Busqueda);
        }
        private void cargarPermisos() 
        {
            foreach (var permiso in CSesion_SesionIniciada.Permisos)
            {
                switch (permiso.ID_Rol)
                {
                    case 1:
                        Agregar= true;
                        Buscar= true;
                        Eliminar= true;                        
                        Modificar= true;
                        break;

                    case 47:
                        Agregar= true;
                        break;
                    case 48:
                        Modificar= true;
                        break;
                    case 49:
                        Buscar= true;
                        break;
                    case 50:
                        Eliminar= true;
                        break;                    
                }
            }
        }
        private void pasarDatos(bool busqueda) 
        {
            Catalogo.NombreComercial = Txb_NombreComercial.Text;
            Catalogo.Monodroga = Txb_Monodroga.Text;
            Catalogo.Marca = Txb_Marca.Text;
            Catalogo.ID_Proveedor = ID_Proveedor.ToString();
            Catalogo.ID_Producto = ID_Producto.ToString();

            if (busqueda)
            {
                Catalogo.CompraMinimaDesde = Txb_CompraMinDesde.Text;
                Catalogo.UnidadporLoteDesde = Txb_CantDesde.Text;
                Catalogo.PrecioProveedorDesde = Txb_PrecDesde.Text;
                Catalogo.CompraMinimaHasta = Txb_CompraMinHasta.Text;
                Catalogo.UnidadporLoteHasta = Txb_CantHasta.Text;
                Catalogo.PrecioProveedorHasta = Txb_PrecHasta.Text;
            }
            else
            {
                Catalogo.UnidadporLote = Nud_UnidadporLote.Value.ToString();
                Catalogo.CompraMinima = Nud_CompraMinima.Value.ToString();
                Catalogo.NombreProveedor = Txb_Proveedor.Text;
                Catalogo.PrecioProveedor = Txb_PrecioporLote.Text;
            }
            
        }
        private void seleccionProveedor(int idPersonaDelegado, string cliente)
        {
            ID_Proveedor = idPersonaDelegado;
            Txb_Proveedor.Text = cliente;
           
        }
        private void bloquearControles() 
        {
            Txb_NombreComercial.Enabled = false;
            Txb_Monodroga.Enabled = false;
            Txb_Marca.Enabled = false;
            Nud_CompraMinima.Enabled = false;
            Nud_UnidadporLote.Enabled = false;
            Txb_PrecioporLote.Enabled = false;
        }
        private void desbloquearControles()
        {
            Txb_NombreComercial.Enabled = true;
            Txb_Monodroga.Enabled = true;
            Txb_Marca.Enabled = true;
            Nud_CompraMinima.Enabled = true;
            Nud_UnidadporLote.Enabled = true;
            Txb_PrecioporLote.Enabled = true;
            
        }
        private void cargarControles()
        {
            ID_Producto= Convert.ToInt32(DTGV_Catalogo.CurrentRow.Cells[0].Value);
            Txb_NombreComercial.Text = DTGV_Catalogo.CurrentRow.Cells[1].Value.ToString(); 
            Txb_Monodroga.Text = DTGV_Catalogo.CurrentRow.Cells[2].Value.ToString();
            Txb_Marca.Text = DTGV_Catalogo.CurrentRow.Cells[3].Value.ToString();
            Txb_Proveedor.Text = DTGV_Catalogo.CurrentRow.Cells[4].Value.ToString();
            Nud_UnidadporLote.Value = Convert.ToInt32(DTGV_Catalogo.CurrentRow.Cells[5].Value);
            Nud_CompraMinima.Value = Convert.ToInt32(DTGV_Catalogo.CurrentRow.Cells[6].Value);
            Txb_PrecioporLote.Text = DTGV_Catalogo.CurrentRow.Cells[7].Value.ToString();

        }
        private void nombrarColumnas()
        {
            DTGV_Catalogo.Columns[0].HeaderText = "ID";
            DTGV_Catalogo.Columns[1].HeaderText = "Nombre Comercial";
            DTGV_Catalogo.Columns[2].HeaderText = "Monodroga";
            DTGV_Catalogo.Columns[3].HeaderText = "Marca";
            DTGV_Catalogo.Columns[4].HeaderText = "Proveedor";
            DTGV_Catalogo.Columns[5].HeaderText = "Unidades por Lote";
            DTGV_Catalogo.Columns[6].HeaderText = "Compra Minima";
            DTGV_Catalogo.Columns[7].DefaultCellStyle.Format = "#,##0.00";
            DTGV_Catalogo.Columns[7].HeaderText = "Precio por Lote";
        }
        #endregion
    }
}
