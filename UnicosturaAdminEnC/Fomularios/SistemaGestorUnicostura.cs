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
    public partial class SistemaGestorUnicostura : Form
    {
        public SistemaGestorUnicostura()
        {
            InitializeComponent();
            BaseDeDatos.BaseDatos();
        }

        private AdminBD adminBD;

        private void Btn_AdministrarBaseDeDatos(object sender, EventArgs e)
        {
            if (adminBD == null)
            {
                adminBD = new AdminBD();
                adminBD.FormClosed += (s, args) => adminBD = null; // Esto permite liberar la instancia cuando se cierra el formulario
            }
            adminBD.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
