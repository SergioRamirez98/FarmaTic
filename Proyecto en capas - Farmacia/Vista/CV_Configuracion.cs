using Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class CV_Configuracion : Form
    {
        public CV_Configuracion()
        {
            InitializeComponent();
        }

        private void Chb_MinCaracteres_CheckedChanged(object sender, EventArgs e)
        {
            CSistema_MinimoCaracteres.Caracteres = true;
        }
    }
}
