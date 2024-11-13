using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicios
{
    public static class CServ_Limpiar
    {
        public static void LimpiarFormulario(Form formulario)
        {
            foreach (Control control in formulario.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = "";
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                }
                else if (control is RadioButton)
                {
                    ((RadioButton)control).Checked = false;
                }
                else if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                }
                else if (control is DateTimePicker)
                {
                    ((DateTimePicker)control).Value = DateTime.Today;
                }
                else if (control is DataGridView) 
                {
                    ((DataGridView)control).DataSource= null;
                }
            }
                
        }
        public static void LimpiarPanelBox(Panel panel) 
        {
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = "";
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                }
                else if (control is RadioButton)
                {
                    ((RadioButton)control).Checked = false;
                }
                else if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                }
                else if (control is DateTimePicker)
                {
                    ((DateTimePicker)control).Value = DateTime.Today;
                }
            }
        }
        public static void BloquearControles(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Enabled =false;

                }
                else if (control is ComboBox)
                {
                    ComboBox cmb = (ComboBox)control;
                    cmb.Enabled =false;
                }
                else if (control is RadioButton)
                {
                    ((RadioButton)control).Checked = false;
                }
                else if (control is CheckBox)
                {
                    CheckBox chb = (CheckBox)control;
                    chb.Enabled = false;
                }
                else if (control is DateTimePicker)
                {
                    DateTimePicker dtp= (DateTimePicker)control;
                    dtp.Enabled = false;
                }
            }
        }
    }
}
