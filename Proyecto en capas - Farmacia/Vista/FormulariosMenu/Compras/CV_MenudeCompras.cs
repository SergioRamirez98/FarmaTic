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
using Vista.FormulariosMenu;

namespace Vista
{
    public partial class CV_MenudeCompras : Form
    {
        public CV_MenudeCompras()
        {
            InitializeComponent();
        }
        private void CV_GestiondeCompras_Load(object sender, EventArgs e)
        {
            cargarPermisos();
        }

        private void Btn_Catalogo_Click(object sender, EventArgs e)
        {
            CV_CatalogoProductos Catalogo = new CV_CatalogoProductos();
            Catalogo.Show();
        }
        private void Btn_PedidodeCompra_Click(object sender, EventArgs e)
        {
            CV_PedidodeCompra PC = new CV_PedidodeCompra();
            PC.Show();
        }
        private void Btn_OrdendeCompra_Click(object sender, EventArgs e)
        {
            CV_GestionOrdenDeCompra OC = new CV_GestionOrdenDeCompra();
            OC.Show();
        }
        private void Btn_Proveedores_Click(object sender, EventArgs e)
        {
            CV_GestionProveedores Proveedores = new CV_GestionProveedores();
            Proveedores.Show();
        }
        private void cargarPermisos()
        {
            Btn_Catalogo.Enabled = false;
            Btn_PedidodeCompra.Enabled = false;
            Btn_OrdendeCompra.Enabled = false;
            Btn_Proveedores.Enabled = false;
            foreach (var permiso in CSesion_SesionIniciada.Permisos)
            {
                switch (permiso.ID_Rol)
                {
                    case 1:
                        Btn_Catalogo.Enabled = true;
                        Btn_PedidodeCompra.Enabled = true;
                        Btn_OrdendeCompra.Enabled = true;
                        Btn_Proveedores.Enabled = true;
                        break;
                    case 42:
                        Btn_Proveedores.Enabled = true;
                        break;
                    case 46:
                        Btn_Catalogo.Enabled = true;
                        break;
                    case 51:
                        Btn_PedidodeCompra.Enabled = true;
                        break;
                    case 56:
                        Btn_OrdendeCompra.Enabled = true;
                        break;

                }
            }
        }

       
    }
}
