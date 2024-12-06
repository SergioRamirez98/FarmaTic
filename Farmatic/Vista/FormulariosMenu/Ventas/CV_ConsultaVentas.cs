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
using Sesion;

namespace Vista
{
    public partial class CV_ConsultaVentas : Form
    {
        CL_ConsultaVentas ConsultaVentas = new CL_ConsultaVentas();
        int ID_Venta = 0;
        bool Eliminar = false;
        bool Visualizar = false;
        public CV_ConsultaVentas()
        {
            InitializeComponent();
        }
        private void CV_ConsultaVentas_Load(object sender, EventArgs e)
        {
            configurarDTGV();
            cargarPermisos();
            CServ_ConfControles.ConfiguraciondeControles(this);
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
            if (Visualizar)
            {
                if (DTGV_BusqVentas.SelectedRows.Count > 0)
                {
                    int Seleccion = DTGV_BusqVentas.CurrentRow.Index;
                    seleccionarItem(Seleccion);

                   /* CV_VisualizadorVentas VisualizadordeVentas = new CV_VisualizadorVentas(ID_Venta);
                    VisualizadordeVentas.Show();*/
                    cargarDTGVConsulta();
                }
            }
            else CServ_MsjUsuario.MensajesDeError("No posee permisos para realizar esta operación");
        }              
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (Visualizar)
            {
                if (DTGV_BusqVentas.SelectedRows.Count > 0)
                {
                    bool confirmacion = CServ_MsjUsuario.Preguntar("¿Esta seguro de eliminar el registro? Podría ser una gran pérdida para la empresa.");
                    if (confirmacion)
                    {
                        int Seleccion = DTGV_BusqVentas.CurrentRow.Index;
                        seleccionarItem(Seleccion);
                        ConsultaVentas.EliminarVenta(ID_Venta);
                        DTGV_BusqVentas.DataSource = null;
                        CServ_MsjUsuario.Exito("La venta ha sido eliminada exitosamente");
                    }
                }
                else
                {
                    CServ_MsjUsuario.MensajesDeError("No ha seleccionado ninguna Venta");
                }
            }
            else CServ_MsjUsuario.MensajesDeError("No posee permisos para realizar esta operación");
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


            DTGV_VisualizadorVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTGV_VisualizadorVentas.MultiSelect = false;
            DTGV_VisualizadorVentas.AllowUserToAddRows = false;
            DTGV_VisualizadorVentas.AllowUserToResizeColumns = false;
            DTGV_VisualizadorVentas.AllowUserToResizeRows = false;
            DTGV_VisualizadorVentas.ReadOnly = true;
            DTGV_VisualizadorVentas.RowHeadersVisible = false;
            DTGV_VisualizadorVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }
        private void capturarDatos() 
        {
            ConsultaVentas.Cliente = Txb_Cliente.Text;
            ConsultaVentas.PrecioDesde = Txb_PrecDesde.Text;
            ConsultaVentas.PrecioHasta = Txb_PrecHasta.Text;
            ConsultaVentas.FechaDesde = Dtp_FeDesde.Value.ToString("yyyy-MM-dd 00:00:00");
            ConsultaVentas.FechaHasta = Dtp_FeHasta.Value.ToString("yyyy-MM-dd 00:00:00");
            
        }
        private void cargarDTGV() 
        {
            DTGV_BusqVentas.DataSource = null;
            DTGV_BusqVentas.DataSource = ConsultaVentas.ConsultarVenta();
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

        private void cargarDTGVConsulta()
        {
            DTGV_VisualizadorVentas.DataSource = ConsultaVentas.VerVentaItems(ID_Venta);
            DTGV_VisualizadorVentas.Columns[0].HeaderText = "ID Venta";
            DTGV_VisualizadorVentas.Columns[1].HeaderText = "Usuario vendedor";
            DTGV_VisualizadorVentas.Columns[2].HeaderText = "Cliente";
            DTGV_VisualizadorVentas.Columns[3].HeaderText = "Nombre del Producto";
            DTGV_VisualizadorVentas.Columns[4].HeaderText = "Precio unitario";
            DTGV_VisualizadorVentas.Columns[5].HeaderText = "Cantidad";
            DTGV_VisualizadorVentas.Columns[6].HeaderText = "Descuento aplicado al cliente";
            DTGV_VisualizadorVentas.Columns[7].HeaderText = "Valor con descuento";
            DTGV_VisualizadorVentas.Columns[8].HeaderText = "Fecha de venta";
            DTGV_VisualizadorVentas.Columns[4].DefaultCellStyle.Format = "#,##0.00";
            DTGV_VisualizadorVentas.Columns[7].DefaultCellStyle.Format = "#,##0.00";
            DTGV_VisualizadorVentas.ClearSelection();
        }
        private void cargarPermisos()
        {
            foreach (var permiso in CSesion_SesionIniciada.Permisos)
            {
                switch (permiso.ID_Rol)
                {
                    case 1:
                        Eliminar = true;
                        Visualizar = true;
                        break;

                    case 40:
                        Eliminar = true;
                        break;
                        
                    case 41:
                        Visualizar = true;
                        break;

                }
            }
        }

        #endregion        
    }
}
