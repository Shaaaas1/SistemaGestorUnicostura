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
        private AdministarClientes administarClientes;
        private AdministarPedidos administarPedidos;

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

        private void btn_AdminClientes_Click(object sender, EventArgs e)
        {
            if (administarClientes == null)
            {
                administarClientes = new AdministarClientes();
                administarClientes.FormClosed += (s, args) => administarClientes = null; // Esto permite liberar la instancia cuando se cierra el formulario
            }
            administarClientes.Show();
        }

        private void btn_AdminPedidos_Click(object sender, EventArgs e)
        {
            if (administarPedidos == null)
            {
                administarPedidos = new AdministarPedidos();
                administarPedidos.FormClosed += (s, args) => administarPedidos = null; // Esto permite liberar la instancia cuando se cierra el formulario
            }
            administarPedidos.Show();
        }
    }
}
