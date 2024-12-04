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
using Modelo;
using Vista.FormulariosMenu.GestionPersonas;

namespace Vista.FormulariosMenu
{
    public partial class CV_Ventas : Form
    {
        #region Properties
        CL_Productos Productos = new CL_Productos();
        CL_Ventas Ventas = new CL_Ventas();
        List<CL_Ventas> VentaItems = new List<CL_Ventas>();
        DataTable Dt = new DataTable();

        List<CM_DatosVenta> ItemsVendidos = new List<CM_DatosVenta>();

        double totalventa = 0, Desc = 0;
        int ID_Cliente = 0;
        string cat;
        bool RegistrarVenta = false;
        bool AgregarCarrito = false;
        bool EliminarCarrito = false;
        bool SeleccionarCliente = false;
        bool ConsultarVenta = false;
        public delegate void ClienteSeleccionadoHandler(string cliente, int idCliente, double Descuento, string Categoria);
        public event ClienteSeleccionadoHandler ClienteSeleccionado;


        #endregion
        public CV_Ventas()
        {
            InitializeComponent();
        }

        #region Eventos
        private void CV_Ventas_Load(object sender, EventArgs e)
        {
            cargarDTGV();
            configurarDTGV();
            configurarLoad();
            cargarPermisos();
            CServ_ConfControles.ConfiguraciondeControles(this);
        }
        private void Txb_BusquedaRapida_TextChanged(object sender, EventArgs e)
        {
            DTGV_Ventas.DataSource = Ventas.BusquedaRapida(Txb_BusquedaRapida.Text, Dt);
        }
        private void Btn_AgregarCompra_Click(object sender, EventArgs e)
        {
            if (AgregarCarrito)
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
            else CServ_MsjUsuario.MensajesDeError("No posee permisos para realizar esta operación");
        }
        private void Btn_EliminardeCompra_Click(object sender, EventArgs e)
        {
            if (EliminarCarrito)
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
            else CServ_MsjUsuario.MensajesDeError("No posee permisos para realizar esta operación");
        }
        private void Btn_FinalizarCompra_Click(object sender, EventArgs e)
        {
            if (RegistrarVenta)
            {
                if (DTGV_Carrito.Rows.Count > 0)
                {
                    try
                    {
                        pasarDatos();
                        int ID_Venta = Ventas.RealizarVenta();
                        pasarDatos(ID_Venta);
                        Ventas.RealizarVentaItem();
                        try
                        {
                            pasarDatosVenta(ID_Venta);
                            CServ_CrearPDF.GenerarPDF(3);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        CServ_MsjUsuario.Exito("Venta Generada con éxito");
                        Txb_Cliente.Text = "";
                        Desc = 0;
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
            else CServ_MsjUsuario.MensajesDeError("No posee permisos para realizar esta operación");

        }
        private void Btn_BuscarCliente_Click(object sender, EventArgs e)
        {
            if (SeleccionarCliente)
            {
                CV_ObtenerClientes obtenerClientes = new CV_ObtenerClientes();
                obtenerClientes.ClienteSeleccionado += new CV_ObtenerClientes.ClienteSeleccionadoHandler(SeleccionCliente);
                obtenerClientes.ShowDialog();
            }
            else CServ_MsjUsuario.MensajesDeError("No posee permisos para realizar esta operación");
        }
        private void Btn_CrearCliente_Click(object sender, EventArgs e)
        {
            CV_GestionUsuariosPersonas AltaCliente = new CV_GestionUsuariosPersonas();
            AltaCliente.Show();
        }
        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
            if (ConsultarVenta)
            {
                Form FrmOpen = Application.OpenForms["CV_ConsultaVentas"];
                if (FrmOpen == null)
                {
                    CV_ConsultaVentas consulta = new CV_ConsultaVentas();
                    consulta.MdiParent = (CV_Menu)this.MdiParent;
                    CV_Menu Menu = this.MdiParent as CV_Menu;

                    if (Menu != null)
                    {                       
                        consulta.MdiParent = Menu;                        
                        Menu.Size = new Size(
                            consulta.Width,
                            consulta.Height
                        );
                        consulta.Show();
                    }

                }
                else FrmOpen.BringToFront();
            }
            else CServ_MsjUsuario.MensajesDeError("No posee permisos para realizar esta operación");
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

            DTGV_Ventas.Columns[0].HeaderText = "ID producto";
            DTGV_Ventas.Columns[1].HeaderText = "Nombre del producto";
            DTGV_Ventas.Columns[2].HeaderText = "Monodroga";
            DTGV_Ventas.Columns[3].HeaderText = "Marca";
            DTGV_Ventas.Columns[4].HeaderText = "Descripcion del producto";
            DTGV_Ventas.Columns[5].HeaderText = "Cantidad";
            DTGV_Ventas.Columns[6].HeaderText = "Precio Unitario";
            DTGV_Ventas.Columns[6].DefaultCellStyle.Format = "#,##0.00";
            DTGV_Ventas.Columns[7].HeaderText = "Vencimiento";
            DTGV_Ventas.Columns[8].HeaderText = "N°de Lote";
            DTGV_Ventas.Columns[9].HeaderText = "Categoría";



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
            DTGV_Carrito.Columns.Add("Monodroga", "Monodroga");
            DTGV_Carrito.Columns.Add("Nombre", "Nombre");
            DTGV_Carrito.Columns.Add("Marca", "Marca");
            DTGV_Carrito.Columns.Add("Cantidad", "Cantidad");
            DTGV_Carrito.Columns.Add("Precio", "Precio Unitario");
            DTGV_Carrito.Columns["Precio"].DefaultCellStyle.Format = "#,##0.00";
            DTGV_Carrito.Columns.Add("Subtotal", "SubTotal");
            DTGV_Carrito.Columns["Subtotal"].DefaultCellStyle.Format = "#,##0.00";
            DTGV_Carrito.Columns.Add("Vencimiento", "Vencimiento");
            DTGV_Carrito.Columns.Add("NumLote", "Numero de lote");
            DTGV_Carrito.Columns.Add("Descuento", "Descuento por cliente");
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
            Txb_UserName.Text = CSesion_SesionIniciada.UserName;
            Txb_UserName.Enabled = false;
            Txb_BusquedaRapida.Text = string.Empty;
            Nud_Cantidad.Value = 1;
            Txb_Cliente.Enabled = false;
            Lbl_Fecha.Text = DateTime.Today.ToString("D");
            Lbl_Total.Text = "El valor total a cobrar es: " + calculoTotalVenta().ToString("#,##0.00");
        }
        private void pasarDatos()
        {
            Ventas.ID_UsuarioVendedor = CSesion_SesionIniciada.ID_Usuario.ToString();
            if (ID_Cliente != 0) Ventas.ID_Cliente = ID_Cliente.ToString();
            else Ventas.ID_Cliente = 2.ToString();

            Ventas.FechaVenta = DateTime.Today.ToString();
            Ventas.TotalVenta = totalventa.ToString();
            Ventas.Descuento = Desc.ToString();
            CServ_CrearPDF.Fecha= DateTime.Now;
            CServ_CrearPDF.NombreCliente = Txb_Cliente.Text;
            CServ_CrearPDF.UsuarioVendedor = CSesion_SesionIniciada.Nombre +" "+ CSesion_SesionIniciada.Apellido;
            CServ_CrearPDF.CategoriaCliente = cat;
            CServ_CrearPDF.Descuento = Desc;
        }
        private void pasarDatos(int ID_Venta)
        {
            foreach (DataGridViewRow itemCarrito in DTGV_Carrito.Rows)
            {
                CL_Ventas NuevaVenta = new CL_Ventas();
                NuevaVenta.ID_Venta = ID_Venta.ToString();
                NuevaVenta.ID_Producto = itemCarrito.Cells[0].Value.ToString();
                NuevaVenta.Cantidad = itemCarrito.Cells[4].Value.ToString();
                NuevaVenta.PrecUnitario = itemCarrito.Cells[5].Value.ToString();
                NuevaVenta.Subtotal = itemCarrito.Cells[6].Value.ToString();
                NuevaVenta.TotalconDescuento = Ventas.CalcularTotalConDescuentoporItem(NuevaVenta.Subtotal, Desc);
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
            totalventa = Ventas.CalcularTotalConDescuento(Desc, totalventa);
            return totalventa;
        }
        private void agregarAlCarrito(int ProdSeleccionado)
        {
            int Id = Convert.ToInt32(DTGV_Ventas.Rows[ProdSeleccionado].Cells[0].Value);
            string Nombre = DTGV_Ventas.Rows[ProdSeleccionado].Cells[1].Value.ToString();
            string Monodroga = DTGV_Ventas.Rows[ProdSeleccionado].Cells[2].Value.ToString();
            string Marca = DTGV_Ventas.Rows[ProdSeleccionado].Cells[3].Value.ToString();
            int Cantidad = Convert.ToInt32(Nud_Cantidad.Value);
            double Precio = Convert.ToDouble(DTGV_Ventas.Rows[ProdSeleccionado].Cells[6].Value);
            double SubTotal = Cantidad * Precio;
            DateTime Vto = Convert.ToDateTime(DTGV_Ventas.Rows[ProdSeleccionado].Cells[7].Value);
            int NumeroLote = Convert.ToInt32(DTGV_Ventas.Rows[ProdSeleccionado].Cells[8].Value);

            DTGV_Carrito.Rows.Add(Id, Nombre,Monodroga, Marca, Cantidad, Precio, SubTotal, Vto, NumeroLote, Desc);
            foreach (DataGridViewRow row in DTGV_Carrito.Rows)
            {
                row.Cells[9].Value = Desc;
            }


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
            calculoTotalVenta();
            configurarLoad();
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
        private void SeleccionCliente(string cliente, int idClienteDelegado, double Descuento, string Categoria)
        {
            Txb_Cliente.Text = cliente;
            ID_Cliente = idClienteDelegado;
            Desc = Descuento;
            foreach (DataGridViewRow row in DTGV_Carrito.Rows)
            {
                row.Cells[9].Value = Desc;
            }
            cat = Categoria;
            calculoTotalVenta();
            configurarLoad();
        }

        private void pasarDatosVenta(int ID_Venta) 
        {
            foreach (DataGridViewRow itemCarrito in DTGV_Carrito.Rows)
            {
                CM_DatosVenta DatosVenta = new CM_DatosVenta();

                DatosVenta.NombreProducto = itemCarrito.Cells[1].Value.ToString();
                DatosVenta.Monodroga = itemCarrito.Cells[2].Value.ToString();
                DatosVenta.Marca = itemCarrito.Cells[3].Value.ToString();
                DatosVenta.Cantidad = Convert.ToInt32(itemCarrito.Cells[4].Value);
                DatosVenta.PrecUnit = Convert.ToDouble(itemCarrito.Cells[5].Value);
                DatosVenta.Subtotal = Convert.ToDouble(itemCarrito.Cells[6].Value);
                DatosVenta.Descuento = Desc;
                DatosVenta.Total= totalventa;
                ItemsVendidos.Add(DatosVenta);              

            }

            CServ_CrearPDF.ImgFarmacia = Properties.Resources.FarmaciaPasteur;
            CServ_CrearPDF.ImgFarmatic = Properties.Resources.farmaTic_logo;
            CServ_CrearPDF.ID_Venta= ID_Venta;
            CServ_CrearPDF.ItemsVendidos = ItemsVendidos;

        }

        private void cargarPermisos()
        {
            foreach (var permiso in CSesion_SesionIniciada.Permisos)
            {
                switch (permiso.ID_Rol)
                {
                    case 1:
                        RegistrarVenta = true;
                        AgregarCarrito = true;
                        EliminarCarrito = true;
                        SeleccionarCliente = true;
                        ConsultarVenta = true;
                        break;

                    case 34:
                        RegistrarVenta = true;
                        break;

                    case 36:
                        SeleccionarCliente = true;
                        break;
                    case 37:
                        AgregarCarrito = true;
                        break;
                    case 38:
                        EliminarCarrito = true;
                        break;
                    case 39:
                        EliminarCarrito = true;
                        break;

                }
            }
        }

        #endregion

    }
}
