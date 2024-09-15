using Logica;
using Sesion;
using System;
using Servicios;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Vista.FormulariosMenu
{
    public partial class CV_Ventas : Form
    {
        #region Atributos
        CL_Productos Productos = new CL_Productos();
        CL_Ventas Ventas = new CL_Ventas();
        List<CL_Ventas> VentaItems = new List<CL_Ventas>();    
        DataTable Dt = new DataTable();
        double totalventa = 0, Desc =0;
        int ID_Cliente = 0;
        string cat;
        public delegate void ClienteSeleccionadoHandler(string cliente, int idCliente, double Descuento, string Categoria);

        //Tengo que poner el descuento aplicado en la consulta SQL

        public event ClienteSeleccionadoHandler ClienteSeleccionado;

        #endregion
        public CV_Ventas()
        {
            InitializeComponent();
        }

        private void CV_Ventas_Load(object sender, EventArgs e)
        {
            cargarDTGV();
            configurarDTGV();
            configurarLoad();

        }

        #region Eventos
        private void Txb_BusquedaRapida_TextChanged(object sender, EventArgs e)
        {
            DTGV_Ventas.DataSource = Ventas.BusquedaRapida(Txb_BusquedaRapida.Text, Dt);
        }
        private void Btn_AgregarCompra_Click(object sender, EventArgs e)
        {
            if (DTGV_Ventas.SelectedRows.Count > 0 && Nud_Cantidad.Value > 0)
            {
                int Seleccion = DTGV_Ventas.CurrentRow.Index;
                int Id = Convert.ToInt32(DTGV_Ventas.Rows[Seleccion].Cells[0].Value);
                bool ProductoenCarrito = compararCarrito(Id);
                if (ProductoenCarrito)
                {
                    agregarCantidadAlCarrito(Id);
                }
                else
                {
                    agregarAlCarrito(Seleccion);
                }
            }
            else
            {
                CServ_MsjUsuario.MensajesDeError("No se ha seleccionado ningun producto.");
            }
            configurarLoad();
        }
        private void Btn_EliminardeCompra_Click(object sender, EventArgs e)
        {
            if (DTGV_Carrito.SelectedRows.Count > 0)
            {
                eliminardeCarrito();
                calculoTotalVenta();
                configurarLoad();
            }
            else
            {
                CServ_MsjUsuario.MensajesDeError("No se ha seleccionado ningun producto.");
            }
        }
        private void Btn_FinalizarCompra_Click(object sender, EventArgs e)
        {
            if (DTGV_Carrito.Rows.Count >0)
            {
                try
                {
                    pasarDatos();
                    int ID_Venta = Ventas.RealizarVenta();
                    pasarDatos(ID_Venta);
                    Ventas.RealizarVentaItem();
                    CServ_MsjUsuario.Exito("Venta Generada con éxito");
                    Txb_Cliente.Text = "";
                    DTGV_Carrito.Rows.Clear();
                    cargarDTGV();
                }
                catch (Exception ex)
                {

                    CServ_MsjUsuario.MensajesDeError(ex.Message);
                }
            }
            else
            {
                CServ_MsjUsuario.MensajesDeError("No ha seleccionado ningun producto.");
            }            

        }        
        private void Btn_BuscarCliente_Click(object sender, EventArgs e)
        {
            CV_ObtenerClientes obtenerClientes = new CV_ObtenerClientes();
            obtenerClientes.ClienteSeleccionado += new CV_ObtenerClientes.ClienteSeleccionadoHandler(SeleccionCliente);
            obtenerClientes.ShowDialog();
        }
        #endregion
        #region Metodos
        private void configurarDTGV()
        {
            DTGV_Ventas.AllowUserToResizeColumns = false;
            DTGV_Ventas.AllowUserToResizeRows = false;
            DTGV_Ventas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_Ventas.MultiSelect = false;
            DTGV_Ventas.AllowUserToAddRows = false;
            DTGV_Ventas.AllowUserToResizeColumns = false;
            DTGV_Ventas.AllowUserToResizeRows = false;
            DTGV_Ventas.ReadOnly = true;
            DTGV_Ventas.RowHeadersVisible = false;
            DTGV_Ventas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            DTGV_Ventas.Columns[0].DisplayIndex = 0;
            DTGV_Ventas.Columns[1].DisplayIndex = 1;
            DTGV_Ventas.Columns[2].DisplayIndex = 2;
            DTGV_Ventas.Columns[3].DisplayIndex = 4;
            DTGV_Ventas.Columns[4].DisplayIndex = 5;
            DTGV_Ventas.Columns[5].DisplayIndex = 6;
            DTGV_Ventas.Columns[5].DefaultCellStyle.Format = "#,##0.00";
            DTGV_Ventas.Columns[6].DisplayIndex = 7;
            DTGV_Ventas.Columns[7].DisplayIndex = 8;
            DTGV_Ventas.Columns[8].DisplayIndex = 3;

            DTGV_Ventas.Columns[0].HeaderText = "ID producto";
            DTGV_Ventas.Columns[1].HeaderText = "Nombre del producto";
            DTGV_Ventas.Columns[2].HeaderText = "Marca";
            DTGV_Ventas.Columns[3].HeaderText = "Descripcion del producto";
            DTGV_Ventas.Columns[4].HeaderText = "Cantidad";
            DTGV_Ventas.Columns[5].HeaderText = "Precio unitario";
            DTGV_Ventas.Columns[6].HeaderText = "Vencimiento";
            DTGV_Ventas.Columns[7].HeaderText = "Numero de lote";
            DTGV_Ventas.Columns[8].HeaderText = "Categoría";




            DTGV_Carrito.Rows.Clear();
            DTGV_Carrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_Carrito.MultiSelect = true;
            DTGV_Carrito.AllowUserToAddRows = false;
            DTGV_Carrito.ReadOnly = true;
            DTGV_Carrito.RowHeadersVisible = false;
            DTGV_Carrito.AllowUserToResizeColumns = false;
            DTGV_Carrito.AllowUserToResizeRows = false;
            DTGV_Carrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DTGV_Carrito.Columns.Add("ID", "ID Producto");
            DTGV_Carrito.Columns.Add("Nombre", "Nombre");
            DTGV_Carrito.Columns.Add("Marca", "Marca");
            DTGV_Carrito.Columns.Add("Cantidad", "Cantidad");
            DTGV_Carrito.Columns.Add("Precio", "Precio Unitario");
            DTGV_Carrito.Columns["Precio"].DefaultCellStyle.Format = "#,##0.00";
            DTGV_Carrito.Columns.Add("Subtotal", "SubTotal");
            DTGV_Carrito.Columns["Subtotal"].DefaultCellStyle.Format = "#,##0.00";
            DTGV_Carrito.Columns.Add("Vencimiento", "Vencimiento");
            DTGV_Carrito.Columns.Add("NumLote", "Numero de lote");

            //            
            DTGV_Carrito.Columns.Add("Descuento", "Descuento por cliente");
            //DTGV_Carrito.Columns["Descuento"].DefaultCellStyle.Format = "0.00%";
        }
        private void cargarDTGV()
        {
            Dt = Productos.MostrarProductos();
            DTGV_Ventas.DataSource = Dt;
            DTGV_Ventas.ClearSelection();

        }
        private void configurarLoad()
        {
            Size = new Size(1250, 798);
            //Txb_UserName.Text = CSesion_SesionIniciada.UserName;
            Txb_UserName.Enabled = false;
            Txb_BusquedaRapida.Text = string.Empty;
            Nud_Cantidad.Value = 1;
            Txb_Cliente.Enabled = false;
            Lbl_Fecha.Text = DateTime.Today.ToString("D");
            Lbl_Total.Text = "El valor total a cobrar es: " + calculoTotalVenta().ToString("#,##0.00");
        }
        private void pasarDatos()
        {
            Ventas.ID_UsuarioVendedor = 1.ToString();// CSesion_SesionIniciada.UserName;
            if (ID_Cliente!=0)Ventas.ID_Cliente = ID_Cliente.ToString(); 
            else Ventas.ID_Cliente = 2.ToString();

            Ventas.FechaVenta = DateTime.Today.ToString();
            Ventas.TotalVenta = totalventa.ToString();
            Ventas.Descuento=Desc.ToString();
        }
        private void pasarDatos(int ID_Venta)
        {
            foreach (DataGridViewRow itemCarrito in DTGV_Carrito.Rows)
            {
                CL_Ventas NuevaVenta = new CL_Ventas();
                NuevaVenta.ID_Venta = ID_Venta.ToString();
                NuevaVenta.ID_Producto = itemCarrito.Cells[0].Value.ToString();
                NuevaVenta.PrecUnitario = itemCarrito.Cells[4].Value.ToString();
                NuevaVenta.Cantidad = itemCarrito.Cells[3].Value.ToString();
                NuevaVenta.Subtotal = itemCarrito.Cells[5].Value.ToString();
                NuevaVenta.TotalconDescuento = Ventas.CalcularTotalConDescuentoporItem(NuevaVenta.Subtotal,Desc);
                VentaItems.Add(NuevaVenta);
            }
            Ventas.VentaItems = VentaItems;
        }
        private double calculoTotalVenta()
        {
            totalventa = 0;
            foreach (DataGridViewRow subtotal in DTGV_Carrito.Rows)
            {
                double valor = Convert.ToDouble(subtotal.Cells[5].Value);
                totalventa = valor + totalventa;
            }
            totalventa= Ventas.CalcularTotalConDescuento(Desc, totalventa);
            return totalventa;
        }
        private void agregarAlCarrito(int ProdSeleccionado)
        {
            int Id = Convert.ToInt32(DTGV_Ventas.Rows[ProdSeleccionado].Cells[0].Value);
            string Nombre = DTGV_Ventas.Rows[ProdSeleccionado].Cells[1].Value.ToString();
            string Marca = DTGV_Ventas.Rows[ProdSeleccionado].Cells[2].Value.ToString();
            int Cantidad = Convert.ToInt32(Nud_Cantidad.Value);
            double Precio = Convert.ToDouble(DTGV_Ventas.Rows[ProdSeleccionado].Cells[5].Value);
            double SubTotal = Cantidad * Precio;
            DateTime Vto = Convert.ToDateTime(DTGV_Ventas.Rows[ProdSeleccionado].Cells[6].Value);
            int NumeroLote = Convert.ToInt32(DTGV_Ventas.Rows[ProdSeleccionado].Cells[7].Value);       

            DTGV_Carrito.Rows.Add(Id, Nombre, Marca, Cantidad, Precio, SubTotal, Vto, NumeroLote,Desc);
            DTGV_Ventas.ClearSelection();
            DTGV_Carrito.ClearSelection();
        }
        private bool compararCarrito(int ProdSeleccionado)
        {
            bool SeRepite = false;
            if (DTGV_Carrito.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in DTGV_Carrito.Rows)
                {
                    int valor = Convert.ToInt32(item.Cells["ID"].Value);
                    if (valor == ProdSeleccionado)
                    { SeRepite = true; break; }
                }
            }
            return SeRepite;

        }
        private void agregarCantidadAlCarrito(int Id)
        {
            foreach (DataGridViewRow item in DTGV_Carrito.Rows)
            {
                int productoEnCarrito = Convert.ToInt32(item.Cells["Id"].Value);
                if (Id == productoEnCarrito)
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
        private void eliminardeCarrito()
        {
            try
            {
                DataGridViewSelectedRowCollection filasSeleccionadas;
                filasSeleccionadas = DTGV_Carrito.SelectedRows;
                foreach (DataGridViewRow fila in filasSeleccionadas)
                {
                    DTGV_Carrito.Rows.Remove(fila);
                }
            }
            catch (Exception)
            {
                CServ_MsjUsuario.MensajesDeError("No se ha seleccionado ningun producto.");
            }
        }

        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
            CV_ConsultaVentas consulta = new CV_ConsultaVentas();
            consulta.Show();
        }

        private void SeleccionCliente(string cliente, int idClienteDelegado, double Descuento, string Categoria)
        {
            Txb_Cliente.Text = cliente;
            ID_Cliente = idClienteDelegado;
            Desc=Descuento;
            cat = Categoria;
        }
        #endregion

    }
}
