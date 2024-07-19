using Servicios;
using Sesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class CV_Menu : Form
    {
        public CV_Menu()
        {
            InitializeComponent();
        }
        private void CV_Menu_Load(object sender, EventArgs e)
        {
            if (CSesion_SesionIniciada.Es_Usuario==true)
            {
                string Familia = CSesion_SesionIniciada.Familia;                
                switch (Familia)
                {
                    case "Administrador": Btn_GestionInventario.Enabled = true;
                        Btn_GestionVentas.Enabled = false;
                        break;
                    case "Administración":
                        Btn_GestionUsuarios.Enabled=false;
                        break;
                    case "Ventas": Btn_GestionUsuarios.Enabled = false; 
                        Btn_GestionVentas.Enabled=true;
                        Btn_GestionInventario.Enabled=true;
                        break;
                    case "Control de Stock": Btn_GestionUsuarios.Enabled = false;
                        Btn_GestionVentas.Enabled = false;
                        Btn_GestionInventario.Enabled = true;
                        break;
                }               

            }
        }

        private void Btn_GestionUsuarios_Click(object sender, EventArgs e)
        {
            CV_Registrar agregarPersona = new CV_Registrar();
            agregarPersona.Show();         
        }

    }
}
