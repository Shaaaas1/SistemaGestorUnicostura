using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
