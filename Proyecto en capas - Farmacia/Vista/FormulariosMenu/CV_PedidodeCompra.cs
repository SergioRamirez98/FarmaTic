using Logica;
using Modelo;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.FormulariosMenu
{
    public partial class CV_PedidodeCompra : Form
    {
        CL_Catalogo Catalogo = new CL_Catalogo();
        CL_PedidodeCompra PedidodeCompra = new CL_PedidodeCompra();
        List<CM_PedidosdeCompra> ListaPedidos = new List<CM_PedidosdeCompra>();
        List<CM_Catalogo> ListaCatalogo = new List<CM_Catalogo>();
        public CV_PedidodeCompra()
        {
            InitializeComponent();
        }
        #region Eventos
        private void CV_OrdendeCompra_Load(object sender, EventArgs e)
        {
            configurarDTGV();
            mostrarCatalogo();
        }
        private void Btn_AgregarAlPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (DTGV_Catalogo.SelectedRows.Count > 0 && Nud_Cantidad.Value > 0)
                {
                    int Seleccion = DTGV_Catalogo.CurrentRow.Index;
                    int Id = Convert.ToInt32(DTGV_Catalogo.Rows[Seleccion].Cells[0].Value);
                    bool ProductoenCarrito = compararPedido(Id);
                    if (ProductoenCarrito)  agregarCantidadAlPedido(Id);
                    else
                    {
                        if (Nud_Cantidad.Value >= Convert.ToInt32(DTGV_Catalogo.Rows[Seleccion].Cells[6].Value)) agregarAlPedido(Seleccion);                        
                        else throw new Exception("La cantidad no puede ser menos que la cantidad mínima de compra indicada por el proveedor.");
                    }
                    ordenarPorProveedor();
                }
                else
                {
                    CServ_MsjUsuario.MensajesDeError("No se ha seleccionado ningun producto.");
                }

            }
            catch (Exception ex)
            {

                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }         
        }
        private void Btn_EliminardePedido_Click(object sender, EventArgs e)
        {

            if (DTGV_PedidodeCompra.SelectedRows.Count > 0)
            {
                eliminarDePedido();
                ordenarPorProveedor();
            }
            else
            {
                CServ_MsjUsuario.MensajesDeError("No se ha seleccionado ningun producto.");
            }
        }
        private void Btn_FinalizarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarPedido();
                CServ_MsjUsuario.Exito("Pedido de compra ingresado con Exito");
                DTGV_PedidodeCompra.Rows.Clear();
                
            }
            catch (Exception ex)
            {

                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }
        }
        private void DTGV_Catalogo_SelectionChanged(object sender, EventArgs e)
        {
            int Seleccion = DTGV_Catalogo.CurrentRow.Index;
            Nud_Cantidad.Value = Convert.ToInt32(DTGV_Catalogo.Rows[Seleccion].Cells[6].Value);
        }
        private void Txb_BusqCatalogo_TextChanged(object sender, EventArgs e)
        {            
            DTGV_Catalogo.DataSource = PedidodeCompra.BusquedaRapida(Txb_BusqCatalogo.Text, ListaCatalogo);
            DTGV_Catalogo.ClearSelection();
        }
        #endregion

        #region Metodos
        private void mostrarCatalogo()
        {
            DTGV_Catalogo.DataSource = null;
            ListaCatalogo= Catalogo.MostrarProductos();
            DTGV_Catalogo.DataSource = ListaCatalogo;
            DTGV_Catalogo.ClearSelection();
            nombrarColumnas();
        }
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

            DTGV_PedidodeCompra.AllowUserToResizeColumns = false;
            DTGV_PedidodeCompra.AllowUserToResizeRows = false;
            DTGV_PedidodeCompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_PedidodeCompra.MultiSelect = false;
            DTGV_PedidodeCompra.AllowUserToAddRows = false;
            DTGV_PedidodeCompra.AllowUserToResizeColumns = false;
            DTGV_PedidodeCompra.AllowUserToResizeRows = false;
            DTGV_PedidodeCompra.ReadOnly = true;
            DTGV_PedidodeCompra.RowHeadersVisible = false;
            DTGV_PedidodeCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            DTGV_PedidodeCompra.Rows.Clear();
            DTGV_PedidodeCompra.Columns.Add("ID", "ID Producto");
            DTGV_PedidodeCompra.Columns.Add("NombreComercial", "Nombre Comercial");
            DTGV_PedidodeCompra.Columns.Add("Monodroga", "Monodroga");
            DTGV_PedidodeCompra.Columns.Add("Marca", "Marca");
            DTGV_PedidodeCompra.Columns.Add("Proveedor", "Proveedor");
            DTGV_PedidodeCompra.Columns.Add("Cantidad", "Cantidad");
            DTGV_PedidodeCompra.Columns.Add("Precio", "Precio Unitario");
            DTGV_PedidodeCompra.Columns["Precio"].DefaultCellStyle.Format = "#,##0.00";
            DTGV_PedidodeCompra.Columns.Add("Subtotal", "SubTotal");
            DTGV_PedidodeCompra.Columns["Subtotal"].DefaultCellStyle.Format = "#,##0.00";

            DTGV_Catalogo.ClearSelection();
            DTGV_PedidodeCompra.DataSource = null;
            DTGV_PedidodeCompra.ClearSelection();
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
        private void agregarAlPedido(int ProdSeleccionado)
        {
            int Id = Convert.ToInt32(DTGV_Catalogo.Rows[ProdSeleccionado].Cells[0].Value);
            string NombreComercial = DTGV_Catalogo.Rows[ProdSeleccionado].Cells[1].Value.ToString();
            string Monodroga = DTGV_Catalogo.Rows[ProdSeleccionado].Cells[2].Value.ToString();
            string Marca = DTGV_Catalogo.Rows[ProdSeleccionado].Cells[3].Value.ToString();
            string Proveedor = DTGV_Catalogo.Rows[ProdSeleccionado].Cells[4].Value.ToString();
            int Cantidad = Convert.ToInt32(Nud_Cantidad.Value);
            double PrecioUnitario = Convert.ToDouble(DTGV_Catalogo.Rows[ProdSeleccionado].Cells[7].Value) / Convert.ToDouble(DTGV_Catalogo.Rows[ProdSeleccionado].Cells[5].Value);
                        
            double SubTotal = Cantidad * PrecioUnitario;

            DTGV_PedidodeCompra.Rows.Add(Id, NombreComercial, Monodroga, Marca, Proveedor, Cantidad, PrecioUnitario, SubTotal);
            


            DTGV_Catalogo.ClearSelection();
            DTGV_PedidodeCompra.ClearSelection();
        }
        private bool compararPedido(int ProdSeleccionado)
        {            
            
            bool SeRepite = false;
            if (DTGV_PedidodeCompra.Rows.Count > 0)
            {
                List<CM_Catalogo> pedidodecompra = new List<CM_Catalogo>();
                foreach (DataGridViewRow item in DTGV_PedidodeCompra.Rows)
                {
                    CM_Catalogo pedido = new CM_Catalogo() {
                        ID_Producto = Convert.ToInt32(item.Cells["ID"].Value)
                    };
                    pedidodecompra.Add(pedido);
                }
                SeRepite = PedidodeCompra.Comparar(pedidodecompra,ProdSeleccionado); 

            }
            return SeRepite;

        }
        private void agregarCantidadAlPedido(int ProdSeleccionado)
        {
            foreach (DataGridViewRow item in DTGV_PedidodeCompra.Rows)
            {
                int productoEnCarrito = Convert.ToInt32(item.Cells["ID"].Value);
                if (ProdSeleccionado == productoEnCarrito)
                {
                    int contadorActual = Convert.ToInt32(item.Cells["Cantidad"].Value);
                    int nuevoContador = contadorActual + Convert.ToInt32(Nud_Cantidad.Value);
                    item.Cells["Cantidad"].Value = nuevoContador;
                    double precio = Convert.ToDouble(item.Cells["Precio"].Value);
                    item.Cells["Subtotal"].Value = nuevoContador * precio;
                    break;
                }
            }
        }
        private void ordenarPorProveedor()
        {
            ListaPedidos.Clear();
            foreach (DataGridViewRow item in DTGV_PedidodeCompra.Rows)
            {
                CM_PedidosdeCompra pedido = new CM_PedidosdeCompra()
                {
                    ID_Producto = Convert.ToInt32(item.Cells["ID"].Value),
                    NombreComercial= (item.Cells["NombreComercial"].Value).ToString(),
                    Monodroga = (item.Cells["Monodroga"].Value).ToString(),
                    Marca = (item.Cells["Marca"].Value).ToString(),
                    Proveedor= (item.Cells["Proveedor"].Value).ToString(),
                    Cantidad = Convert.ToInt32(item.Cells["Cantidad"].Value),
                    PrecioUnitario = Convert.ToDouble(item.Cells["Precio"].Value),
                    Subtotal = Convert.ToDouble(item.Cells["Subtotal"].Value)
                };
                ListaPedidos.Add(pedido);
            }
            DTGV_PedidodeCompra.DataSource = null;            
            DTGV_PedidodeCompra.Rows.Clear();
            ordenarDTGV(PedidodeCompra.OrdenarPorProveedores(ListaPedidos));
            DTGV_PedidodeCompra.ClearSelection();
        }
        private void ordenarDTGV(List<CM_PedidosdeCompra> lista) 
        {
            foreach (var item in lista)
            {
                int Id = item.ID_Producto;
                string NombreComercial = item.NombreComercial;
                string Monodroga = item.Monodroga;
                string Marca = item.Marca;
                string Proveedor = item.Proveedor;
                int Cantidad = item.Cantidad;
                double PrecioUnitario= item.PrecioUnitario;
                double SubTotal = item.Subtotal;
                DTGV_PedidodeCompra.Rows.Add(Id, NombreComercial, Monodroga, Marca, Proveedor, Cantidad, PrecioUnitario, SubTotal);

            }
        }
        private void eliminarDePedido()
        {
            try
            {
                DataGridViewSelectedRowCollection filasSeleccionadas;
                filasSeleccionadas = DTGV_PedidodeCompra.SelectedRows;
                foreach (DataGridViewRow fila in filasSeleccionadas)
                {
                    DTGV_PedidodeCompra.Rows.Remove(fila);
                }
            }
            catch (Exception)
            {
                CServ_MsjUsuario.MensajesDeError("No se ha seleccionado ningun producto.");
            }
        }
        private void InsertarPedido()
        {
            ListaPedidos.Clear();

            int i = 0;
            while (i < DTGV_PedidodeCompra.Rows.Count)
            {
                string proveedorActual = DTGV_PedidodeCompra.Rows[i].Cells["Proveedor"].Value.ToString();
                List<CL_PedidodeCompra> listaProveedores = new List<CL_PedidodeCompra>();
                decimal totalProveedor = 0;

                while (i < DTGV_PedidodeCompra.Rows.Count)
                {

                    if (DTGV_PedidodeCompra.Rows[i].Cells["Proveedor"].Value.ToString() == proveedorActual)
                    {
                        CL_PedidodeCompra pedido = new CL_PedidodeCompra()
                        {
                            ID_Producto = DTGV_PedidodeCompra.Rows[i].Cells["ID"].Value.ToString(),
                            NombreComercial = DTGV_PedidodeCompra.Rows[i].Cells["NombreComercial"].Value.ToString(),
                            Monodroga = DTGV_PedidodeCompra.Rows[i].Cells["Monodroga"].Value.ToString(),
                            Marca = DTGV_PedidodeCompra.Rows[i].Cells["Marca"].Value.ToString(),
                            Proveedor = proveedorActual,
                            Cantidad = DTGV_PedidodeCompra.Rows[i].Cells["Cantidad"].Value.ToString(),
                            Precio = DTGV_PedidodeCompra.Rows[i].Cells["Precio"].Value.ToString(),
                            Subtotal = DTGV_PedidodeCompra.Rows[i].Cells["Subtotal"].Value.ToString()
                        };
                        listaProveedores.Add(pedido);
                        totalProveedor += Convert.ToDecimal(pedido.Subtotal);
                    }
                    else break;
                    i++;
                }

                PedidodeCompra.TotalporProveedor = totalProveedor.ToString();
                PedidodeCompra.Proveedor = proveedorActual;
                PedidodeCompra.ProductosPorProveedor = listaProveedores;
                int ID = PedidodeCompra.InsertarCompraProveedor();
                PedidodeCompra.InsertarCompraItems(ID);
            }
        }
        #endregion

    }
}
