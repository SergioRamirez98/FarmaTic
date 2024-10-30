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
using System.Windows.Forms;
using System.Text;
using Sesion;


namespace Vista.FormulariosMenu
{
    public partial class CV_GestionOrdenDeCompra : Form
    {
        CL_GestionOrdendeCompra OC = new CL_GestionOrdendeCompra();
        List<CL_GestionOrdendeCompra> ListaItems = new List<CL_GestionOrdendeCompra>();
        List<CM_Pedido> Pedido = new List<CM_Pedido>();
        List<CM_ObtenerPedidodeCompra> ListaPedidos = new List<CM_ObtenerPedidodeCompra>();
        List<CM_OrdenDeCompraPorItemsPDF> ItemsOCDef = new List<CM_OrdenDeCompraPorItemsPDF>();
        decimal TotalOC = 0;
        bool Confirmar = false;
        bool Descartar = false;
        bool Historial = false;
        bool Modificar = false;


        public CV_GestionOrdenDeCompra()
        {
            InitializeComponent();
        }

        private void CV_OrdenDeCompra_Load(object sender, EventArgs e)
        {
            cargarPermisos();
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
            if (Confirmar)
            {
                calculoTotalOC();
                try
                {
                    if (DTGV_Pedidos.SelectedRows.Count > 0 && TotalOC > 0)
                    {
                        pasarDatos();
                        int oc = OC.InsertarOrden();
                        pasarDatos(oc);
                        OC.InsertarOrdenPorItems();
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
            else CServ_MsjUsuario.MensajesDeError("No posee los permisos para realizar esta operación");
        }
        private void Btn_Descartar_Click(object sender, EventArgs e)
        {
            if (Descartar)
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
            else CServ_MsjUsuario.MensajesDeError("No posee los permisos para realizar esta operación");
        }
        private void Btn_Historial_Click(object sender, EventArgs e)
        {
            if (Historial)
            {
                mostrarHistorialPedidos();
                DTGV_Pedidos.Columns[5].Visible = true;
                DTGV_Pedidos.Size = new System.Drawing.Size(610, 228);
                Btn_Descartar.Enabled = false;
            }
            else CServ_MsjUsuario.MensajesDeError("No posee los permisos para realizar esta operación");
        }
        private void Btn_Refrescar_Click(object sender, EventArgs e)
        {
            CV_OrdenDeCompra_Load(sender, e);
        }
        private void DTGV_OC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Modificar)
            {
                DTGV_OC.Columns[7].ReadOnly = false;
                int Seleccion = DTGV_OC.CurrentRow.Index;
                bool Agregar = Convert.ToBoolean(DTGV_OC.Rows[Seleccion].Cells[7].Value);

                if (Agregar)
                {
                    DTGV_OC.Rows[Seleccion].Cells[7].Value = false;
                }
                else
                {
                    DTGV_OC.Rows[Seleccion].Cells[7].Value = true;
                }
            }
            calculoTotalOC();

        }
        private void Txb_Buscar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Txb_Buscar.Text) && Txb_Buscar.Text != "Buscar")
            {
                
                List<CM_ObtenerPedidodeCompra> Lista = new List<CM_ObtenerPedidodeCompra>();
                Lista = OC.BuscarFiltrado(ListaPedidos, Txb_Buscar.Text);
                DTGV_Pedidos.DataSource = Lista;
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
            DTGV_Pedidos.Size = new System.Drawing.Size(565, 228);//537
            Btn_Descartar.Enabled = false;
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
                        if (Modificar) DTGV_OC.Columns[7].ReadOnly = false;
                        else DTGV_OC.Columns[7].ReadOnly = true;
                        //   DTGV_OC.Columns[7].ReadOnly = false;
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
            OC.ListaItems = ListaItems;
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
            CServ_CrearPDF.ImgFarmacia = Properties.Resources.FarmaciaPasteur;
            CServ_CrearPDF.ImgFarmatic= Properties.Resources.farmaTic_logo;
            try
            {
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = "OC N° "+oc.ToString() + ".pdf";
                string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Plantilla.html");
                string PDFhtml = "";
                PDFhtml = File.ReadAllText(rutaArchivo.ToString());
                PDFhtml = cargarDatosPDF(PDFhtml,oc);

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 55, 75, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        iTextSharp.text.Image FarmaLogo = iTextSharp.text.Image.GetInstance(Properties.Resources.FarmaciaPasteur, System.Drawing.Imaging.ImageFormat.Png);
                        iTextSharp.text.Image FarmaTIClogo = iTextSharp.text.Image.GetInstance(Properties.Resources.farmaTic_logo, System.Drawing.Imaging.ImageFormat.Png);
                        FarmaLogo.ScaleToFit(80, 60);
                        FarmaLogo.Alignment = iTextSharp.text.Image.UNDERLYING;
                        FarmaLogo.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);

                        FarmaTIClogo.ScaleToFit(80, 60);
                        FarmaTIClogo.Alignment = iTextSharp.text.Image.UNDERLYING;
                        FarmaTIClogo.SetAbsolutePosition(PageSize.A4.Width - pdfDoc.RightMargin - 30, pdfDoc.Top - 60);

                        pdfDoc.Add(FarmaTIClogo);
                        pdfDoc.Add(FarmaLogo);

                        using (StringReader sr = new StringReader(PDFhtml))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }
                        pdfDoc.Close();
                        stream.Close();
                    }                    
                }
                Process.Start(guardar.FileName);
            }
            catch (Exception)
            {

                throw new Exception("La compra se ha realizado con éxito pero no se ha podido generar el PDF. Por favor, contáctes con el proveedor del sistema");
            }
        }
        private string cargarDatosPDF(string PDFhtml, int oc)
        {
            ItemsOCDef = OC.ObtenerItemsOC(oc);

            PDFhtml = PDFhtml.Replace("@OC", "Orden de Compra");
            PDFhtml = PDFhtml.Replace("@NUMERO", oc.ToString());

            PDFhtml = PDFhtml.Replace("@Proveedor", CM_DatosOCDefinitiva.NombreEmpresa);
            PDFhtml = PDFhtml.Replace("@Fecha", CM_DatosOCDefinitiva.Fecha.ToString("d"));
            PDFhtml = PDFhtml.Replace("@MatriculaProveedor", CM_DatosOCDefinitiva.MatriculaProveedor.ToString());
            PDFhtml = PDFhtml.Replace("@CUITProveedor", CM_DatosOCDefinitiva.CUITProveedor);
            PDFhtml = PDFhtml.Replace("@DireccionProv", CM_DatosOCDefinitiva.DireccionProv);
            PDFhtml = PDFhtml.Replace("@CorreoProv", CM_DatosOCDefinitiva.CorreoProv);
            PDFhtml = PDFhtml.Replace("@LocalidadProv", CM_DatosOCDefinitiva.LocalidadProv);
            PDFhtml = PDFhtml.Replace("@PartidoProv", CM_DatosOCDefinitiva.PartidoProv);
            PDFhtml = PDFhtml.Replace("@TelefonoProv", CM_DatosOCDefinitiva.TelefonoProv.ToString());

            PDFhtml = PDFhtml.Replace("@NombreEmpresa", CM_DatosOCDefinitiva.NombreEmpresa.ToString());
            PDFhtml = PDFhtml.Replace("@DireccionFarma", CM_DatosOCDefinitiva.DireccionFarma.ToString());
            PDFhtml = PDFhtml.Replace("@CUITEmpresa", CM_DatosOCDefinitiva.CUITEmpresa.ToString());
            PDFhtml = PDFhtml.Replace("@DireccionProv", CM_DatosOCDefinitiva.DireccionFarma.ToString());
            PDFhtml = PDFhtml.Replace("@DomicilioEntrega", CM_DatosOCDefinitiva.DomicilioEntrega.ToString());
            PDFhtml = PDFhtml.Replace("@Fe", CM_DatosOCDefinitiva.FechaInicioAct.ToString("d"));
            PDFhtml = PDFhtml.Replace("@PartidoFarma", CM_DatosOCDefinitiva.PartidoFarma.ToString());
            PDFhtml = PDFhtml.Replace("@LocalidadFarma", CM_DatosOCDefinitiva.LocalidadFarma.ToString());


            string FilaProductos = "";
            foreach (var producto in ItemsOCDef)
            {
                FilaProductos += "<tr>";
                FilaProductos += "<td>" + producto.NombreComercial + "</td>";
                FilaProductos += "<td>" + producto.Monodroga + "</td>";
                FilaProductos += "<td>" + producto.Marca + "</td>";
                FilaProductos += "<td>" + producto.Cantidad.ToString() + "</td>";
                FilaProductos += "<td>" + producto.PrecioUnitario.ToString("#,##0.00") + "</td>";
                FilaProductos += "<td>" + producto.Subtotal.ToString("#,##0.00") + "</td>";
                FilaProductos += "</tr>";
            }

            PDFhtml = PDFhtml.Replace("@Items", FilaProductos);
            PDFhtml = PDFhtml.Replace("@TotOC", TotalOC.ToString("#,##0.00"));

            PDFhtml = PDFhtml.Replace("@Usuario", CM_DatosOCDefinitiva.NombreApellido.ToString());
            PDFhtml = PDFhtml.Replace("@AutoFecha", CM_DatosOCDefinitiva.Fecha.ToString());
            CM_DatosOCDefinitiva.LimpiarDatos(true);

            return PDFhtml;
        }
        private void cargarPermisos()
        {
            foreach (var permiso in CSesion_SesionIniciada.Permisos)
            {
                switch (permiso.ID_Rol)
                {
                    case 1:
                        Confirmar = true;
                        Descartar = true;
                        Historial = true;
                        Modificar = true;
                        break;
                        
                    case 60:
                        Confirmar = true;
                        break;
                    case 58:
                        Descartar = true;
                        break;
                    case 59:
                        Historial = true;
                        break;
                    case 57:
                        Modificar = true;
                        break;
                }
            }
        }

        #endregion
    }
}