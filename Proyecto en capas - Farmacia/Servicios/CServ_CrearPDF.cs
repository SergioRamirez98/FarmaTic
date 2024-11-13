using System;
using Modelo;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Servicios
{
    public static class CServ_CrearPDF 
    {

        #region Properties PDF
        public static System.Drawing.Image ImgFarmacia { get; set; }
        public static System.Drawing.Image ImgFarmatic { get; set; }
        public static string RutaArchivo { get; set; }
        public static string PDFhtml { get; set; }
        #endregion
        #region Properties OC
        public static int ID_Pedido { get; set; }
        public static int OC { get; set; }
        public static List <CM_OrdenDeCompraPorItemsPDF> ListadeItems = new List<CM_OrdenDeCompraPorItemsPDF> ();
        #endregion

        #region Properties Ventas
        public static int ID_Venta { get; set; }
        public static string NombreCliente { get; set; }
        public static string CategoriaCliente { get; set; }
        public static double Descuento { get; set; }
        public static string UsuarioVendedor { get; set; }
        public static double SubtotalAcumulado { get; set; }
        public static double DescuentoAcumulado { get; set; }
        public static DateTime Fecha { get; set; }
        public static List<CM_DatosVenta> ItemsVendidos = new List<CM_DatosVenta>();
        #endregion

        public static void GenerarPDF(int valor)
        {
            try
            {
                SaveFileDialog guardar = new SaveFileDialog();
                switch (valor)
                {
                    case 1:
                        guardar.FileName = "OC N° " + OC.ToString() + ".pdf";
                        RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Plantilla.html");
                        break;
                    case 2:
                        guardar.FileName = "Recibo de OC N° " + OC.ToString() + ".pdf";
                        RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Plantilla.html");
                        break;
                    case 3:
                        guardar.FileName = "Venta N° " + ID_Venta.ToString() + ".pdf";
                        RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "PlantillaParaVentas.html");
                        break;
                }
                PDFhtml = "";
                PDFhtml = File.ReadAllText(RutaArchivo.ToString());
                PDFhtml = CargarDatosPDF(PDFhtml, valor);

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 55, 75, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        iTextSharp.text.Image FarmaLogo = iTextSharp.text.Image.GetInstance(ImgFarmacia, System.Drawing.Imaging.ImageFormat.Png);
                        iTextSharp.text.Image FarmaTIClogo = iTextSharp.text.Image.GetInstance(ImgFarmatic, System.Drawing.Imaging.ImageFormat.Png);
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
        private static string CargarDatosPDF(string PDFhtml, int valor)
        {
            string FilaProductos = "";
            double TotalOC = 0;
            switch (valor)
            {
                case 1:
                    PDFhtml = PDFhtml.Replace("@OC", "Orden de Compra");
                    PDFhtml = PDFhtml.Replace("@NUMERO", OC.ToString());

                    PDFhtml = PDFhtml.Replace("@Proveedor", CM_DatosOCDefinitiva.NombreEmpresa);
                    PDFhtml = PDFhtml.Replace("@PC", ID_Pedido.ToString());
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


                    foreach (var producto in ListadeItems)
                    {
                        FilaProductos += "<tr>";
                        FilaProductos += "<td>" + producto.NombreComercial + "</td>";
                        FilaProductos += "<td>" + producto.Monodroga + "</td>";
                        FilaProductos += "<td>" + producto.Marca + "</td>";
                        FilaProductos += "<td>" + producto.Cantidad.ToString() + "</td>";
                        FilaProductos += "<td>" + producto.PrecioUnitario.ToString("#,##0.00") + "</td>";
                        FilaProductos += "<td>" + producto.Subtotal.ToString("#,##0.00") + "</td>";
                        FilaProductos += "</tr>";
                        TotalOC += producto.Subtotal;
                        
                    }

                    PDFhtml = PDFhtml.Replace("@Items", FilaProductos);
                    PDFhtml = PDFhtml.Replace("@TotOC", TotalOC.ToString("#,##0.00"));

                    PDFhtml = PDFhtml.Replace("@Usuario", CM_DatosOCDefinitiva.NombreApellido.ToString());
                    PDFhtml = PDFhtml.Replace("@AutoFecha", CM_DatosOCDefinitiva.Fecha.ToString());
                    CM_DatosOCDefinitiva.LimpiarDatos(true);
                    ID_Pedido = 0;
                    ListadeItems.Clear();
                    break;


                case 3:

                    if (string.IsNullOrEmpty(NombreCliente))
                    {
                        NombreCliente = "Cliente no registrado";
                        Descuento = 0;
                        CategoriaCliente = "Sin categoria, no aplica descuento";
                    }

                    PDFhtml = PDFhtml.Replace("@NUMERO", ID_Venta.ToString());
                    PDFhtml = PDFhtml.Replace("@NombreCliente", NombreCliente);
                    PDFhtml = PDFhtml.Replace("@DescuentoCliente", Descuento.ToString()+"%");
                    PDFhtml = PDFhtml.Replace("@Categoria", CategoriaCliente);



                    foreach (var producto in ItemsVendidos)
                    {
                        FilaProductos += "<tr>";
                        FilaProductos += "<td>" + producto.NombreProducto + "</td>";
                        FilaProductos += "<td>" + producto.Monodroga + "</td>";
                        FilaProductos += "<td>" + producto.Marca + "</td>";
                        FilaProductos += "<td>" + producto.Cantidad.ToString() + "</td>";
                        FilaProductos += "<td>" + producto.PrecUnit.ToString("#,##0.00") + "</td>";
                        FilaProductos += "<td>" + producto.Subtotal.ToString("#,##0.00") + "</td>";
                        FilaProductos += "</tr>";
                        TotalOC += producto.Subtotal;
                    }
                    DescuentoAcumulado =TotalOC*(Descuento/100);

                    PDFhtml = PDFhtml.Replace("@Items", FilaProductos);
                    PDFhtml = PDFhtml.Replace("@SubAcumulado", TotalOC.ToString("#,##0.00"));
                    PDFhtml = PDFhtml.Replace("@Desc","-"+ DescuentoAcumulado.ToString("#,##0.00"));
                    PDFhtml = PDFhtml.Replace("@Total", (TotalOC-DescuentoAcumulado).ToString("#,##0.00"));

                    PDFhtml = PDFhtml.Replace("@Usuario", UsuarioVendedor);
                    PDFhtml = PDFhtml.Replace("@AutoFecha", Fecha.ToString());
                    CM_DatosOCDefinitiva.LimpiarDatos(true);
                    ItemsVendidos.Clear();
                    ID_Venta = 0;
                    NombreCliente = null;
                    Descuento = 0;
                    CategoriaCliente = null;
                    break;
            }
            return PDFhtml;

        }
    }
            
}
