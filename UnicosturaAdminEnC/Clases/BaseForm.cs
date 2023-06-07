using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnicosturaAdminEnC.Clases
{
    public class BaseForm : Form
    {
        protected void SetFormStyle()
        {
            // Personalizar la apariencia de la ventana
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Desactivar la transparencia en el formulario
            this.TransparencyKey = Color.Empty;
        }

        protected void CustomizarBoton(Button boton, string texto, Color colorFondo, Color colorTexto)
        {
            boton.Text = texto;
            boton.BackColor = colorFondo;
            boton.ForeColor = colorTexto;
            boton.Font = new Font("Arial", 12, FontStyle.Bold);
            boton.FlatAppearance.MouseDownBackColor = colorFondo;
            boton.FlatAppearance.MouseOverBackColor = ControlPaint.Light(colorFondo);

            // Establecer el color y grosor del borde
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 3;
            boton.FlatAppearance.BorderColor = Color.FromArgb(220, 220, 220);
        }
    }
}
