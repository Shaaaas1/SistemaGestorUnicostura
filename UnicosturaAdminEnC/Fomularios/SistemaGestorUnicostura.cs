using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
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
            this.Layout += FormInicio_Layout;
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

        private void SistemaGestorUnicostura_Load(object sender, EventArgs e)
        {
            FormInicio_Load(sender, e);
        }


        private void FormInicio_Load(object sender, EventArgs e)
        {
            // Personalizar la apariencia de la ventana
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Desactivar la transparencia en el formulario
            this.TransparencyKey = Color.Empty;

            // Personalizar el estilo de los botones
            CustomizarBoton(btn_AdminClientes, "Administrar Clientes", Color.FromArgb(52, 152, 219), Color.White);
            CustomizarBoton(btn_AdminPedidos, "Administrar Pedidos", Color.FromArgb(231, 76, 60), Color.White);
            CustomizarBoton(button1, "Administrar BD", Color.FromArgb(46, 204, 113), Color.White);
        }

        private void CustomizarBoton(Button boton, string texto, Color colorFondo, Color colorTexto)
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

        private void FormInicio_Layout(object sender, EventArgs e)
        {

            // Ajustar posición y tamaño de los botones
            btn_AdminClientes.Left = (this.Width - btn_AdminClientes.Width) / 2;
            btn_AdminClientes.Top = this.Height / 2 - btn_AdminClientes.Height - 10;

            btn_AdminPedidos.Left = (this.Width - btn_AdminPedidos.Width) / 2;
            btn_AdminPedidos.Top = this.Height / 2;

            button1.Left = (this.Width - button1.Width) / 2;
            button1.Top = this.Height / 2 + btn_AdminPedidos.Height + 10;
        }

    }
}
