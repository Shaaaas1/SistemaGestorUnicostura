using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicosturaAdminEnC.Fomularios;

namespace UnicosturaAdminEnC
{
    public partial class AdminBD : Form
    {
        public AdminBD()
        {
            InitializeComponent();
        }

        private AdministrarTallas administrarTallas;
        private AdminNumeroMoldes adminNumeroMoldes;
        private AdministarTipoPago administarTipoPago;
        private AdministarDistribucion administarDistribucion;
        private AdministarRepartidores administarRepartidores;

        private void Btn_AdminTallas_Click(object sender, EventArgs e)
        {
            if (administrarTallas == null)
            {
                administrarTallas = new AdministrarTallas();
                administrarTallas.FormClosed += (s, args) => administrarTallas = null; // Esto permite liberar la instancia cuando se cierra el formulario
            }
            administrarTallas.Show();
        }

        private void btn_NumeroMoldes_Click(object sender, EventArgs e)
        {
            if (adminNumeroMoldes == null)
            {
                adminNumeroMoldes = new AdminNumeroMoldes();
                adminNumeroMoldes.FormClosed += (s, args) => adminNumeroMoldes = null; // Esto permite liberar la instancia cuando se cierra el formulario
            }
            adminNumeroMoldes.Show();
        }

        private void btn_TipoPago_Click(object sender, EventArgs e)
        {
            if (administarTipoPago == null)
            {
                administarTipoPago = new AdministarTipoPago();
                administarTipoPago.FormClosed += (s, args) => administarTipoPago = null; // Esto permite liberar la instancia cuando se cierra el formulario
            }
            administarTipoPago.Show();
        }

        private void btn_Distribucion_Click(object sender, EventArgs e)
        {
            if (administarDistribucion == null)
            {
                administarDistribucion = new AdministarDistribucion();
                administarDistribucion.FormClosed += (s, args) => administarDistribucion = null; // Esto permite liberar la instancia cuando se cierra el formulario
            }
            administarDistribucion.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (administarRepartidores == null)
            {
                administarRepartidores = new AdministarRepartidores();
                administarRepartidores.FormClosed += (s, args) => administarRepartidores = null; // Esto permite liberar la instancia cuando se cierra el formulario
            }
            administarRepartidores.Show();
        }

        private void AdminBD_Load(object sender, EventArgs e)
        {
            // Personalizar la apariencia de la ventana
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Desactivar la transparencia en el formulario
            this.TransparencyKey = Color.Empty;

            // Personalizar el estilo de los botones
            CustomizarBoton(Btn_AdminTallas, "Administrar Tallas", Color.FromArgb(52, 152, 219), Color.White, 14);
            CustomizarBoton(btn_NumeroMoldes, "Número de Moldes", Color.FromArgb(231, 76, 60), Color.White, 14);
            CustomizarBoton(btn_TipoPago, "Tipo de Pago", Color.FromArgb(46, 204, 113), Color.White, 14);
            CustomizarBoton(btn_Distribucion, "Distribución", Color.FromArgb(241, 196, 15), Color.Black, 14);
            CustomizarBoton(button1, "Repartidores", Color.FromArgb(155, 89, 182), Color.White, 14);
        }

        private void CustomizarBoton(Button boton, string texto, Color colorFondo, Color colorTexto, int tamanoFuente)
        {
            boton.Text = texto;
            boton.BackColor = colorFondo;
            boton.ForeColor = colorTexto;
            boton.Font = new Font("Arial", tamanoFuente, FontStyle.Bold);
            boton.FlatAppearance.MouseDownBackColor = colorFondo;
            boton.FlatAppearance.MouseOverBackColor = ControlPaint.Light(colorFondo);

            // Establecer el color y grosor del borde
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 3;
            boton.FlatAppearance.BorderColor = Color.FromArgb(220, 220, 220);
        }
    }
}
