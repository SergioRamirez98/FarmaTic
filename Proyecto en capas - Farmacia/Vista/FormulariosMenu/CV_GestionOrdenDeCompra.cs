using Logica;
using Modelo;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
/*
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Geom;
using iText.Layout.Properties;
*/

using System.Windows.Forms;


namespace Vista.FormulariosMenu
{
    public partial class CV_GestionOrdenDeCompra : Form
    {
        CL_GestionOrdendeCompra OC = new CL_GestionOrdendeCompra();
        List<CL_GestionOrdendeCompra> ListaItems = new List<CL_GestionOrdendeCompra>();
        List<CM_Pedido> Pedido = new List<CM_Pedido>();
        List<CM_ObtenerPedidodeCompra> ListaPedidos = new List<CM_ObtenerPedidodeCompra>();
        decimal TotalOC = 0;


        public CV_GestionOrdenDeCompra()
        {
            InitializeComponent();
        }

        private void CV_OrdenDeCompra_Load(object sender, EventArgs e)
        {
            configurarLoad();
            configurarDTGV();
            mostrarPedidos();
        }
        private void DTGV_Pedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Btn_Descartar.Enabled = true;
            Btn_ConfTotal.Enabled = true;
            if (DTGV_Pedidos.SelectedRows.Count > 0)
            {
                int Seleccion = DTGV_Pedidos.CurrentRow.Index;
                int Id = Convert.ToInt32(DTGV_Pedidos.Rows[Seleccion].Cells[0].Value);
                mostrarPedidosPorItems(Id);
            }
            else
            {
                DTGV_OC.DataSource = null;
            }
            calculoTotalOC();

        }
        private void Btn_Confirmar_Click(object sender, EventArgs e)
        {
            calculoTotalOC();
            try
            {
                if (DTGV_Pedidos.SelectedRows.Count > 0 && TotalOC > 0)
                {
                    pasarDatos();
                    int oc = 1;
                    //int oc = OC.InsertarOrden();
                    pasarDatos(oc);
                    //OC.InsertarOrdenPorItems();
                    generarPDF(oc);

                    CServ_MsjUsuario.Exito("La Orden de compra se ha generado con éxito.");                    
                    DTGV_OC.DataSource = null;
                    DTGV_OC.Columns.Clear();
                    DTGV_OC.Rows.Clear();
                    mostrarPedidos();
                    calculoTotalOC();
                    CV_OrdenDeCompra_Load(sender, e);
                }
                else throw new Exception("No ha seleccionado ningun pedido de compra");


            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }
        }
        private void Btn_Descartar_Click(object sender, EventArgs e)
        {
            try
            {
                bool respuesta = CServ_MsjUsuario.Preguntar("¿Está seguro de eliminar el pedido de compra");
                if (respuesta)
                {
                    if (DTGV_Pedidos.SelectedRows.Count > 0)
                    {
                        pasarDatos();
                        OC.EliminarPedido();
                        CServ_MsjUsuario.Exito("El pedido de compra ha sido descartado");
                        DTGV_Pedidos.ClearSelection();
                        DTGV_OC.DataSource = null;
                        DTGV_OC.Columns.Clear();
                        DTGV_OC.Rows.Clear();
                        DTGV_OC.ClearSelection();
                        mostrarPedidos();
                        TotalOC = 0;
                        calculoTotalOC();
                    }
                }
            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }
            
            CV_OrdenDeCompra_Load(sender, e);
        }
        private void Btn_Historial_Click(object sender, EventArgs e)
        {
            mostrarHistorialPedidos();
            DTGV_Pedidos.Columns[5].Visible = true;
            DTGV_Pedidos.Size = new System.Drawing.Size(610, 228);
            Btn_Descartar.Enabled = false;
        }
        private void Btn_Refrescar_Click(object sender, EventArgs e)
        {
            CV_OrdenDeCompra_Load(sender, e);
        }
        private void DTGV_OC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Seleccion = DTGV_OC.CurrentRow.Index;
            bool  Agregar = Convert.ToBoolean(DTGV_OC.Rows[Seleccion].Cells[7].Value);
            if (Agregar)
            {
                DTGV_OC.Rows[Seleccion].Cells[7].Value = false;
            }
            else
            {
                DTGV_OC.Rows[Seleccion].Cells[7].Value = true;
            }
            calculoTotalOC();
            
        }
        private void Txb_Buscar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Txb_Buscar.Text) && Txb_Buscar.Text != "Buscar")
            {
                List<CM_ObtenerPedidodeCompra> Lista = new List<CM_ObtenerPedidodeCompra>();
                Lista = OC.BuscarFiltrado(ListaPedidos,Txb_Buscar.Text);
                DTGV_Pedidos.DataSource= Lista;
                DTGV_Pedidos.ClearSelection();
            }
            else
            {
                DTGV_Pedidos.DataSource = ListaPedidos;
                DTGV_Pedidos.ClearSelection();
            }
        }
        private void Txb_Buscar_Click(object sender, EventArgs e)
        {
            Txb_Buscar.Text = string.Empty;
        }

        #region Metodos
        private void configurarLoad() 
        {
            Lbl_Total.Text = "El monto total de la orden de compra es: $" + TotalOC.ToString("#,##0.00");
            DTGV_Pedidos.Size = new System.Drawing.Size(535, 228);
            Btn_Descartar.Enabled=false;
            Btn_ConfTotal.Enabled = false;
            Btn_Historial.Enabled = true;
            Txb_Buscar.Text = "Buscar";
        }
        private void configurarDTGV()
        {
            DTGV_Pedidos.AllowUserToResizeColumns = false;
            DTGV_Pedidos.AllowUserToResizeRows = false;
            DTGV_Pedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_Pedidos.MultiSelect = false;
            DTGV_Pedidos.AllowUserToAddRows = false;
            DTGV_Pedidos.AllowUserToResizeColumns = false;
            DTGV_Pedidos.AllowUserToResizeRows = false;
            DTGV_Pedidos.ReadOnly = true;

            DTGV_Pedidos.RowHeadersVisible = false;
            DTGV_Pedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DTGV_Pedidos.ClearSelection();

            DTGV_OC.AllowUserToResizeColumns = false;
            DTGV_OC.AllowUserToResizeRows = false;
            DTGV_OC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_OC.MultiSelect = false;
            DTGV_OC.AllowUserToAddRows = false;
            DTGV_OC.AllowUserToResizeColumns = false;
            DTGV_OC.AllowUserToResizeRows = false;
            DTGV_OC.RowHeadersVisible = false;
            DTGV_OC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DTGV_OC.DataSource = null;            
            DTGV_OC.ClearSelection();
        }        
        private void mostrarPedidos()
        {
            DTGV_Pedidos.DataSource = null;
            ListaPedidos = OC.MostrarPedidos();
            DTGV_Pedidos.DataSource = ListaPedidos;
            DTGV_Pedidos.ClearSelection();
            nombrarColumnas();

        }
        private void mostrarHistorialPedidos()
        {
            DTGV_Pedidos.DataSource = null;
            ListaPedidos = OC.MostrarHistorialPedidos();
            DTGV_Pedidos.DataSource = ListaPedidos;
            DTGV_Pedidos.ClearSelection();
            nombrarColumnas();
        }
        private void nombrarColumnas()
        {
            DTGV_Pedidos.Columns[0].HeaderText = "ID";
            DTGV_Pedidos.Columns[1].HeaderText = "Usuario encargado";
            DTGV_Pedidos.Columns[2].HeaderText = "Proveedor";
            DTGV_Pedidos.Columns[3].HeaderText = "Fecha";
            DTGV_Pedidos.Columns[4].HeaderText = "Monto";
            DTGV_Pedidos.Columns[4].DefaultCellStyle.Format = "#,##0.00";
            DTGV_Pedidos.Columns[5].Visible = false;
            if (DTGV_OC.Rows.Count > 0)
            {
                DTGV_OC.Columns[0].HeaderText = "Nombre";
                DTGV_OC.Columns[1].HeaderText = "Monodroga";
                DTGV_OC.Columns[2].HeaderText = "Marca";
                DTGV_OC.Columns[3].HeaderText = "Proveedor";
                DTGV_OC.Columns[4].HeaderText = "Cantidad";
                DTGV_OC.Columns[5].HeaderText = "Precio Unitario";
                DTGV_OC.Columns[6].HeaderText = "Subtotal";
                DTGV_OC.Columns[5].DefaultCellStyle.Format = "#,##0.00";
                DTGV_OC.Columns[6].DefaultCellStyle.Format = "#,##0.00";
                DTGV_OC.Columns[7].HeaderText = "Agregar/Quitar";
                for (int i = 0; i < 7; i++) DTGV_OC.Columns[i].ReadOnly = true;

                foreach (DataGridViewColumn item in DTGV_OC.Columns)
                {
                    if (item == DTGV_OC.Columns[7])
                    {
                        DTGV_OC.Columns[7].ReadOnly = false;
                    }
                }
            }
        }
        private void mostrarPedidosPorItems(int ID)
        {
            DTGV_OC.DataSource = null;
            Pedido.Clear();
            Pedido = OC.MostrarPedidosPorItem(ID);
            DTGV_OC.Columns.Clear();
            DTGV_OC.Rows.Clear();
            DTGV_OC.DataSource = Pedido;
            nombrarColumnas();
            DTGV_OC.ClearSelection();
        }
        private void pasarDatos()
        {
            int Seleccion = DTGV_Pedidos.CurrentRow.Index;
            OC.ID_Pedido = DTGV_Pedidos.Rows[Seleccion].Cells[0].Value.ToString();
            OC.Proveedor = DTGV_Pedidos.Rows[Seleccion].Cells[2].Value.ToString();
            OC.Total = TotalOC.ToString();

        }
        private void pasarDatos(int oc)
        {
            foreach (DataGridViewRow item in DTGV_OC.Rows)
            {
                CL_GestionOrdendeCompra OrdenItems = new CL_GestionOrdendeCompra();
                OrdenItems.OrdenDeCompra = oc.ToString();
                OrdenItems.Producto = item.Cells[0].Value.ToString();
                OrdenItems.Cantidad = item.Cells[4].Value.ToString();
                OrdenItems.PrecioUnitario = item.Cells[5].Value.ToString();
                OrdenItems.Subtotal = item.Cells[6].Value.ToString();
                ListaItems.Add(OrdenItems);
            }
            OC.ListaItems= ListaItems;
        }
        private decimal calculoTotalOC()
        {

            TotalOC = 0;

            foreach (DataGridViewRow fila in DTGV_OC.Rows)
            {
                bool booleano = Convert.ToBoolean(fila.Cells[7].Value);
                if (booleano)
                {
                    decimal valor = Convert.ToInt32(fila.Cells[6].Value);
                    TotalOC = valor + TotalOC;
                }
            }
            Lbl_Total.Text = "El monto total de la orden de compra es: $" + TotalOC.ToString("#,##0.00");
            return TotalOC;
        }
        private void generarPDF(int oc)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = oc.ToString() + ".pdf";
            string pagina = "<table border=1><tr><td>HOLAMUNDO</td></tr></table>";
            if (guardar.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    Document pdf = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdf, stream);
                    pdf.Open();

                    /*esto es desde chat gpt


                    string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Plantilla.html");
                    string html = File.ReadAllText(rutaArchivo);

                    // Obtén el contenido dinámico de tu lista de productos
                    List<Producto> productos = ObtenerProductos(); // Método que retorna la lista de productos
                    string contenidoDinamico = ObtenerContenidoDesdeBaseDeDatos(productos); // Genera el contenido HTML

                    // Reemplaza el marcador de posición en el HTML
                    html = html.Replace("<!-- CONTENIDO DINAMICO -->", contenidoDinamico);*/
                    // Agregar información del proveedor
                    pdf.Add(new Paragraph($"Proveedor: {OC.Proveedor}"));
                    pdf.Add(new Paragraph($"ID Pedido: {OC.ID_Pedido}"));
                    pdf.Add(new Paragraph($"Total: ${Convert.ToDecimal(OC.Total).ToString("#,##0.00")}"));//($"Total: ${OC.Total}"));
                    pdf.Add(new Paragraph("\n")); // Espacio adicional

                    // Crear tabla para los items                    
                    //PdfpTable table = new Table(4); // 4 columnas: Producto, Cantidad, Precio Unitario, Subtotal
                    PdfPTable table = new PdfPTable(4);
                    table.AddCell("Producto");
                    table.AddCell("Cantidad");
                    table.AddCell("Precio Unitario");
                    table.AddCell("Subtotal");

                    // Agregar los items a la tabla
                    foreach (var item in OC.ListaItems)
                    {
                        table.AddCell(item.Producto);
                        table.AddCell(item.Cantidad);
                        table.AddCell(Convert.ToDecimal(item.PrecioUnitario).ToString("#,##0.00"));
                        table.AddCell(Convert.ToDecimal(item.Subtotal).ToString("#,##0.00"));
                    }

                    // Agregar tabla al documento
                    pdf.Add(table);

                    // Agregar el total final al final del documento
                    pdf.Add(new Paragraph($"\nTotal de la compra: ${Convert.ToDecimal(OC.Total).ToString("#,##0.00")}"));






                    pdf.Add(new Phrase(""));
                    /*using (StringReader sr = new StringReader(pagina)) 
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdf, sr);
                    }*/
                    pdf.Close();
                    stream.Close();
                }
            }                    
         }

        #endregion
    }
}