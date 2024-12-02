using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Servicios
{
    public static class CServ_ConfBotones
    {
        public static void ConfiguracionDeBotones(Form formulario)
        {
            foreach (Control control in formulario.Controls)
            {
                if (control is Button) 
                {
                    Button btn = (Button)control;
                    btn.BackColor = Color.FromArgb(220, 230, 240);
                    btn.ForeColor = Color.FromArgb(0, 0, 0);
                    btn.FlatAppearance.BorderColor= Color.FromArgb(220, 230, 240);
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 80, 190);
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 190);
                    btn.FlatStyle= FlatStyle.Flat; 
                    btn.Font = new Font("Segoe UI", 8);

                }
                if (control is Panel panel)
                {
                    foreach (Control panelControl in panel.Controls)
                    {
                        if (panelControl is Button)
                        {
                            Button btn = (Button)panelControl;
                            btn.BackColor = Color.FromArgb(220, 230, 240);
                            btn.ForeColor = Color.FromArgb(0, 0, 0);
                            btn.FlatAppearance.BorderColor = Color.FromArgb(220, 230, 240);
                            btn.FlatAppearance.BorderSize = 0;
                            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 80, 190);
                            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 190);
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.Font = new Font("Segoe UI", 8);
                        }

                    }
                }

            }
        }
    }
}
