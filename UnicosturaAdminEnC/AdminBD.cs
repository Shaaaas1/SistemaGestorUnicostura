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

        private void Btn_AdminTallas_Click(object sender, EventArgs e)
        {
            if (administrarTallas == null)
            {
                administrarTallas = new AdministrarTallas();
                administrarTallas.FormClosed += (s, args) => administrarTallas = null; // Esto permite liberar la instancia cuando se cierra el formulario
            }
            administrarTallas.Show();
        }
    }
}
