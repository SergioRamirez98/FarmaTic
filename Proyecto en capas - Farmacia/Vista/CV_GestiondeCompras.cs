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
    public partial class CV_GestiondeCompras : Form
    {
        public CV_GestiondeCompras()
        {
            InitializeComponent();
        }
        private void CV_GestiondeCompras_Load(object sender, EventArgs e)
        {

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

        
    }
}
