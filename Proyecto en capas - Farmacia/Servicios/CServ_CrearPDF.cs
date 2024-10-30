using System;
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
        #region Properties 
        public static System.Drawing.Image ImgFarmacia { get; set; }
        public static System.Drawing.Image ImgFarmatic { get; set; }
        #endregion
        public static void GenerarPDF(int oc)
        {
            try
            {
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = "OC N° " + oc.ToString() + ".pdf";
                string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Plantilla.html");
                string PDFhtml = "";
                PDFhtml = File.ReadAllText(rutaArchivo.ToString());
               // PDFhtml = CargarDatosPDF(PDFhtml, oc);

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
        }/*
        public static string CargarDatosPDF(string PDFhtml, int oc)
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
*/    }
            
}
