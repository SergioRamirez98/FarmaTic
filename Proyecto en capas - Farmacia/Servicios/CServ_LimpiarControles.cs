using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicios
{
    public static class CServ_LimpiarControles
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
                // Añadir más casos según los tipos de controles que tengas (CheckBox, RadioButton, etc.)
            }
            }
        

    }
}
