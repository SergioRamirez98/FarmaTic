using System;
using Logica;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicios;
using Vista.FormulariosMenu.Ventas;

namespace Vista
{
    public partial class CV_ConsultaVentas : Form
    {
        CL_ConsultaVentas Ventas = new CL_ConsultaVentas();
        int ID_Venta = 0;
        public CV_ConsultaVentas()
        {
            InitializeComponent();
        }
        private void CV_ConsultaVentas_Load(object sender, EventArgs e)
        {
            configurarDTGV();
            //cargarDTGV();
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                capturarDatos();
                cargarDTGV();
            }
            catch (Exception ex)
            {
                CServ_MsjUsuario.MensajesDeError(ex.Message);
            }
        }

        private void Btn_Ver_Click(object sender, EventArgs e)
        {
            if (DTGV_BusqVentas.SelectedRows.Count>0)
            {
                int Seleccion = DTGV_BusqVentas.CurrentRow.Index;
                seleccionarItem(Seleccion);

                CV_VisualizadorVentas VisualizadordeVentas = new CV_VisualizadorVentas(ID_Venta);
                VisualizadordeVentas.Show();
            }
        }

       

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (DTGV_BusqVentas.SelectedRows.Count > 0)
            {
               bool confirmacion= CServ_MsjUsuario.Preguntar("¿Esta seguro de eliminar el registro? Podría ser una gran pérdida para la empresa.");
                if (confirmacion)
                {
                    int Seleccion = DTGV_BusqVentas.CurrentRow.Index;
                    seleccionarItem(Seleccion);
                    Ventas.EliminarVenta(ID_Venta);
                    DTGV_BusqVentas.DataSource = null;
                    CServ_MsjUsuario.Exito("La venta ha sido eliminada exitosamente");
                }
            }
            else
            {
                CServ_MsjUsuario.MensajesDeError("No ha seleccionado ninguna Venta");
            }
        }
        #region Metodos
        private void configurarDTGV()
        {
            DTGV_BusqVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_BusqVentas.MultiSelect = false;
            DTGV_BusqVentas.AllowUserToAddRows = false;
            DTGV_BusqVentas.AllowUserToResizeColumns = false;
            DTGV_BusqVentas.AllowUserToResizeRows = false;
            DTGV_BusqVentas.ReadOnly = true;
            DTGV_BusqVentas.RowHeadersVisible = false;
            DTGV_BusqVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void capturarDatos() 
        {
            Ventas.Cliente = Txb_Cliente.Text;
            Ventas.PrecioDesde = Txb_PrecDesde.Text;
            Ventas.PrecioHasta = Txb_PrecHasta.Text;
            Ventas.FechaDesde = Dtp_FeDesde.Value.ToString("yyyy-MM-dd 00:00:00");
            Ventas.FechaHasta = Dtp_FeHasta.Value.ToString("yyyy-MM-dd 00:00:00");
            
        }

        private void cargarDTGV() 
        {
            DTGV_BusqVentas.DataSource = null;
            DTGV_BusqVentas.DataSource = Ventas.ConsultarVenta();
            DTGV_BusqVentas.Columns[0].HeaderText = "ID Venta";
            DTGV_BusqVentas.Columns[1].HeaderText = "Usuario vendedor";
            DTGV_BusqVentas.Columns[2].HeaderText = "Cliente";
            DTGV_BusqVentas.Columns[3].HeaderText = "Fecha de venta";
            DTGV_BusqVentas.Columns[4].HeaderText = "Monto";
            DTGV_BusqVentas.Columns[4].DefaultCellStyle.Format = "#,##0.00";
            DTGV_BusqVentas.ClearSelection();
        }
        private void seleccionarItem(int seleccion)
        {
            ID_Venta = Convert.ToInt32(DTGV_BusqVentas.Rows[seleccion].Cells[0].Value);
        }
        #endregion        
    }
}
