using Logica;
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

namespace Vista.FormulariosMenu
{
    public partial class CV_Ventas : Form
    {
        CL_Productos Productos = new CL_Productos();
        CL_Ventas Ventas = new CL_Ventas();
        DataTable Dt = new DataTable();
        public CV_Ventas()
        {
            InitializeComponent();
        }

        private void CV_Ventas_Load(object sender, EventArgs e)
        {
            configurarDTGV();
            cargarDTGV();
            configurarLoad();

        }
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
            // DTGV_Ventas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            DTGV_Carrito.Columns.Add("Subtotal", "SubTotal");
            DTGV_Carrito.Columns.Add("Vencimiento", "Vencimiento");
            DTGV_Carrito.Columns.Add("NumLote", "Numero de lote");

        }
        private void cargarDTGV()
        {
            Dt = Productos.MostrarProductos();
            DTGV_Ventas.DataSource = Dt;

            DTGV_Ventas.Columns[0].DisplayIndex = 0;
            DTGV_Ventas.Columns[1].DisplayIndex = 1;
            DTGV_Ventas.Columns[2].DisplayIndex = 2;
            DTGV_Ventas.Columns[3].DisplayIndex = 4;
            DTGV_Ventas.Columns[4].DisplayIndex = 5;
            DTGV_Ventas.Columns[5].DisplayIndex = 6;
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
        }
        private void configurarLoad()
        {
            Size = new Size(1250,798);
            //Txb_UserName.Text = CSesion_SesionIniciada.UserName;
            Txb_UserName.Enabled = false;
            Txb_BusquedaRapida.Text = string.Empty;
            Nud_Cantidad.Value = 1;
            Lbl_Fecha.Text = DateTime.Today.ToString("D");
        }
        private void pasarDatos()
        {
            foreach (DataGridViewRow itemCarrito in DTGV_Carrito.Rows)
            {
                CL_Ventas NuevaVenta = new CL_Ventas();
               /* NuevaVenta.ID_Cliente = Txb_Cliente.Text;
                NuevaVenta.NombreProducto = itemCarrito.Cells[1].Value.ToString();
                NuevaVenta.ID_Cliente = itemCarrito.Cells[1].Value.ToString();
                NuevaVenta.NombreProducto = itemCarrito.Cells[1].Value.ToString(); 
                NuevaVenta.Marca = itemCarrito.Cells[1].Value.ToString();
                NuevaVenta.Cantidad = itemCarrito.Cells[1].Value.ToString();
                NuevaVenta.PrecUnitario = itemCarrito.Cells[1].Value.ToString();
                NuevaVenta.Subtotal = itemCarrito.Cells[1].Value.ToString();
                NuevaVenta.NumeroLote = itemCarrito.Cells[1].Value.ToString();
                NuevaVenta.FechaVenta = itemCarrito.Cells[1].Value.ToString();*/
            }

            Ventas.ID_UsuarioVendedor = CSesion_SesionIniciada.UserName;
            Ventas.FechaVenta = Lbl_Fecha.Text;
            Ventas.TotalVenta = calculoTotalVenta().ToString();
            //Ventas.ID_UsuarioVendedor = CSesion_SesionIniciada.UserName;
            //   Ventas.ID_Cliente = Txb_Cliente.Text;
            //aca estoy pasando solamente la fila seleccionada. tengo que modificarlo para que sean todos los que estan en el dtgv
            // Ventas.NombreProducto = DTGV_Carrito.CurrentRow.Cells[1].Value.ToString();
        }
        private double calculoTotalVenta()
        {
            double totalVenta = 0;
            foreach (DataGridViewRow subtotal in DTGV_Carrito.Rows) 
            {
                double valor = Convert.ToDouble(subtotal.Cells[5].Value);
                totalVenta = valor + totalVenta;
            }
            return totalVenta;
        }
        private void agregarAlCarrito(int ProdSeleccionado) 
        {
            int Id = Convert.ToInt32(DTGV_Ventas.Rows[ProdSeleccionado].Cells[0].Value);
            string Nombre = DTGV_Ventas.Rows[ProdSeleccionado].Cells[1].Value.ToString().ToString();
            string Marca = DTGV_Ventas.Rows[ProdSeleccionado].Cells[2].Value.ToString();
            int Cantidad = Convert.ToInt32(Nud_Cantidad.Value);            
            double Precio = Convert.ToInt32(DTGV_Ventas.Rows[ProdSeleccionado].Cells[5].Value);
            double Total = Cantidad * Precio;
            DateTime Vto = Convert.ToDateTime(DTGV_Ventas.Rows[ProdSeleccionado].Cells[6].Value);
            int NumeroLote = Convert.ToInt32(DTGV_Ventas.Rows[ProdSeleccionado].Cells[7].Value);
            DTGV_Carrito.Rows.Add(Id, Nombre, Marca, Cantidad, Precio,Total, Vto, NumeroLote);
            
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
            configurarLoad();
        }

        private void Btn_EliminardeCompra_Click(object sender, EventArgs e)
        {

        }

        private void Btn_FinalizarCompra_Click(object sender, EventArgs e)
        {
            pasarDatos();
        }
    }
}
