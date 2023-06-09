using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicosturaAdminEnC.Clases;

namespace UnicosturaAdminEnC
{
    public partial class AdministarClientes : Form
    {
        public AdministarClientes()
        {
            InitializeComponent();
            tbx_NombreCliente.KeyPress += tbx_NombreCliente_KeyPress;
            tbx_NumeroCliente.KeyPress += tbx_NumeroCliente_KeyPress;
            tbx_Rut.KeyPress += tbx_Rut_KeyPress;
        }

        // Conexión a la base de datos
        private static SQLiteConnection connection = new SQLiteConnection("Data Source=pedidos.db;Version=3;");

        private System.Windows.Forms.ComboBox tbx_Fuente;

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            string nombreCliente = tbx_NombreCliente.Text;
            string direccion = tbx_Direccion.Text;
            string rut = tbx_Rut.Text;
            string alias = tbx_Alias.Text;

            if (string.IsNullOrEmpty(nombreCliente))
            {
                // Mostrar mensaje de error
                MessageBox.Show("El campo de Nombre no puede estar vacío.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            string numeroClienteStr = tbx_NumeroCliente.Text;

            if (numeroClienteStr.Length != 9)
            {
                // Mostrar mensaje de error
                MessageBox.Show("El campo de Contacto no puede estar vacío o tener menos de 9 Digitos.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            int numeroCliente = int.Parse(tbx_NumeroCliente.Text);

            if (tbx_Fuente.Text == "")
            {
                MessageBox.Show("El campo de Fuente no puede estar vacío.\nSe debe seleccionar una de las opciones proporcionadas.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fuente = tbx_Fuente.SelectedItem.ToString();

            FuncionesAgregar.AgregarCliente(nombreCliente, numeroCliente, direccion, rut, alias, fuente);
            AdministrarClientes_Load(sender, e);
            MessageBox.Show("Se Agrego al Cliente correctamente.");
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string nombreCliente = tbx_NombreCliente.Text;

            if (string.IsNullOrEmpty(nombreCliente))
            {
                // Mostrar mensaje de error
                MessageBox.Show("El campo de Nombre no puede estar vacío.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            DataTable dtCliente = FuncionesBuscar.BuscarCliente(nombreCliente);

            dataGridView1.DataSource = dtCliente;
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados en los campos de texto
            string nombreCliente = tbx_NombreCliente.Text;
            string direccion = tbx_Direccion.Text;
            string rut = tbx_Rut.Text;
            string alias = tbx_Alias.Text;

            if (string.IsNullOrEmpty(nombreCliente))
            {
                // Mostrar mensaje de error
                MessageBox.Show("El campo de Nombre no puede estar vacío.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            string numeroClienteStr = tbx_NumeroCliente.Text;

            if (numeroClienteStr.Length != 9)
            {
                // Mostrar mensaje de error
                MessageBox.Show("El campo de Contacto no puede estar vacío o tener menos de 9 Digitos.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            int numeroCliente = int.Parse(tbx_NumeroCliente.Text);

            if (tbx_Fuente.Text == "")
            {
                MessageBox.Show("El campo de Fuente no puede estar vacío.\nSe debe seleccionar una de las opciones proporcionadas.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fuente = tbx_Fuente.SelectedItem.ToString();

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas Modificar a " + nombreCliente + "?",
                              "Confirmar Modificacion",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                return;
            }

            // Crear la conexión a la base de datos
            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {
                conn.Open();

                // Crear el comando SQL para modificar el registro
                string sql = "UPDATE Cliente SET CelularCliente = @CelularCliente, Direccion = @Direccion, Rut = @Rut, Alias = @Alias, Fuente = @Fuente WHERE NombreCliente = @NombreCliente";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    // Asignar los valores a los parámetros del comando
                    cmd.Parameters.AddWithValue("@CelularCliente", numeroCliente);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@Rut", rut);
                    cmd.Parameters.AddWithValue("@Alias", alias);
                    cmd.Parameters.AddWithValue("@Fuente", fuente);
                    cmd.Parameters.AddWithValue("@NombreCliente", nombreCliente);

                    // Ejecutar el comando de modificación
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registro de Cliente modificado correctamente.");
                        // Aquí puedes realizar cualquier acción adicional después de la modificación exitosa.
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el registro de Cliente a modificar.");
                    }
                }

                conn.Close();
                AdministrarClientes_Load(sender, e);
            }
        }


        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            string nombreCliente = tbx_NombreCliente.Text;

            if (string.IsNullOrEmpty(nombreCliente))
            {
                // Mostrar mensaje de error
                MessageBox.Show("El campo de Nombre no puede estar vacío.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar a " + nombreCliente + "?",
                              "Confirmar eliminación",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                FuncionesEliminar.EliminarCliente(nombreCliente);
                AdministrarClientes_Load(sender, e);
            }
            else
            {
                return;
            }
        }

        private void btn_EliminardeGrilla_Click(object sender, EventArgs e)
        {
            DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
            int rowIndex = selectedCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            string nombreCliente = Convert.ToString(selectedRow.Cells["NombreCliente"].Value);

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar a " + nombreCliente + "?",
                              "Confirmar eliminación",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                FuncionesEliminar.EliminarCliente(nombreCliente);
                AdministrarClientes_Load(sender, e);
            }
            else
            {
                return;
            }
        }

        private void AdministrarClientes_Load(object sender, EventArgs e)
        {
            // Obtener los datos de la tabla "Talla"
            List<Cliente> clientes = ObtenerClientes();

            // Enlazar los datos al DataGridView
            dataGridView1.DataSource = clientes;

            dataGridView1.Columns["IdCliente"].DisplayIndex = 0;
            dataGridView1.Columns["NombreCliente"].DisplayIndex = 1;
            dataGridView1.Columns["Alias"].DisplayIndex = 2;
            dataGridView1.Columns["Fuente"].DisplayIndex = 3;
            dataGridView1.Columns["CelularCliente"].DisplayIndex = 4;
            dataGridView1.Columns["Rut"].DisplayIndex = 5;
            dataGridView1.Columns["Direccion"].DisplayIndex = 6;

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Contacto";
        }

        // Método para obtener los datos de la tabla "Talla"
        private List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Cliente", conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear un objeto Moldes con los datos de cada fila
                            Cliente cliente = new Cliente
                            {
                                IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                NombreCliente = Convert.ToString(reader["NombreCliente"]),
                                Alias = Convert.ToString(reader["Alias"]),
                                Fuente = Convert.ToString(reader["Fuente"]),
                                CelularCliente = Convert.ToInt32(reader["CelularCliente"]),
                                Rut = Convert.ToString(reader["Rut"]),
                                Direccion = Convert.ToString(reader["Direccion"])
                            };

                            clientes.Add(cliente);
                        }
                    }
                }

                conn.Close();
            }

            return clientes;
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            AdministrarClientes_Load(sender, e);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // Verificar si se hizo clic en una fila válida
            {
                // Obtener los valores de la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];
                string IdCliente = filaSeleccionada.Cells["IdCliente"].Value.ToString();
                string nombreCliente = filaSeleccionada.Cells["NombreCliente"].Value.ToString();
                string numeroCliente = filaSeleccionada.Cells["CelularCliente"].Value.ToString();
                string direccion = filaSeleccionada.Cells["Direccion"].Value.ToString();
                string rut = filaSeleccionada.Cells["Rut"].Value.ToString();
                string alias = filaSeleccionada.Cells["Alias"].Value.ToString();
                string fuente = filaSeleccionada.Cells["Fuente"].Value.ToString();

                // Rellenar los TextBoxes con los valores obtenidos
                tbx_IdCliente.Text = IdCliente;
                tbx_NombreCliente.Text = nombreCliente;
                tbx_NumeroCliente.Text = numeroCliente;
                tbx_Direccion.Text = direccion;
                tbx_Rut.Text = rut;
                tbx_Alias.Text = alias;
                tbx_Fuente.SelectedItem = fuente;
            }
        }

        private void AdministarClientes_Load(object sender, EventArgs e)
        {
            AdministrarClientes_Load(sender, e);

            // Personalizar la apariencia de la ventana
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Desactivar la transparencia en el formulario
            this.TransparencyKey = Color.Empty;

            // Personalizar el estilo de los botones
            CustomizarBoton(btn_Agregar, "Agregar", Color.FromArgb(192, 192, 192), Color.Black, 12);
            CustomizarBoton(btn_Buscar, "Buscar", Color.FromArgb(192, 192, 192), Color.Black, 12);
            CustomizarBoton(btn_Modificar, "Modificar", Color.FromArgb(192, 192, 192), Color.Black, 12);
            CustomizarBoton(btn_Eliminar, "Eliminar", Color.FromArgb(192, 192, 192), Color.Black, 12);
            CustomizarBoton(btn_EliminardeGrilla, "Eliminar de Grilla", Color.FromArgb(192, 192, 192), Color.Black, 12);
            CustomizarBoton(btn_Actualizar, "Actualizar", Color.FromArgb(192, 192, 192), Color.Black, 12);
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

        private void CustomizarLabel(Label label, string texto, Color colorTexto, int tamanoFuente)
        {
            label.Text = texto;
            label.Font = new Font("Arial", tamanoFuente, FontStyle.Bold);
            label.ForeColor = colorTexto;
        }

        // Validaciones de los Campos

        private void tbx_NombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar que solo se admitan letras
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbx_NumeroCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir borrar caracteres si se presiona la tecla "Backspace"
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            // Validar que solo se admitan números y un máximo de 9 dígitos
            if (!char.IsDigit(e.KeyChar) || tbx_NumeroCliente.Text.Length >= 9)
            {
                e.Handled = true;
            }
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Evitar la entrada de texto en el ComboBox
            e.Handled = true;
        }

        private void tbx_Rut_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar que solo se admitan números, guion y la letra 'K' (mayúscula o minúscula)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && !(char.ToUpper(e.KeyChar) == 'K') && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            // Convertir una 'k' minúscula ingresada a mayúscula
            if (char.ToLower(e.KeyChar) == 'k')
            {
                e.KeyChar = 'K';
            }

            // Verificar si el guion ya está presente en el texto
            bool guionPresente = tbx_Rut.Text.Contains("-");

            // Validar el máximo de 8 dígitos antes del guion
            if (!guionPresente && char.IsDigit(e.KeyChar) && tbx_Rut.Text.Length >= 8)
            {
                e.Handled = true;
                return;
            }

            // Validar el máximo de 1 dígito o letra después del guion
            if (guionPresente && tbx_Rut.Text.Substring(tbx_Rut.Text.IndexOf("-")).Length >= 2 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            // Agregar el número o letra ingresada
            if ((char.IsDigit(e.KeyChar) && !guionPresente) || char.ToUpper(e.KeyChar) == 'K')
            {
                tbx_Rut.Text += e.KeyChar;
                e.Handled = true; // Evitar que se ingrese el carácter directamente en el textbox
            }

            // Mover el cursor al final del texto
            tbx_Rut.SelectionStart = tbx_Rut.Text.Length;

            // Formatear el Rut según la estructura especificada
            if (e.KeyChar == '-')
            {
                FormatearRut();
                e.Handled = true; // Evitar que se ingrese el guion directamente en el textbox
            }
            else if (e.KeyChar == (char)Keys.Back) // Borrar
            {
                if (tbx_Rut.Text.EndsWith("-"))
                {
                    tbx_Rut.Text = tbx_Rut.Text.Replace(".", "");
                    tbx_Rut.Text = tbx_Rut.Text.Substring(0, tbx_Rut.Text.Length - 1);
                }
                else if (tbx_Rut.Text.Length > 0)
                {
                    tbx_Rut.Text = tbx_Rut.Text.Remove(tbx_Rut.Text.Length - 1);
                }

                // Mover el cursor al final del texto después de borrar
                tbx_Rut.SelectionStart = tbx_Rut.Text.Length;

                e.Handled = true; // Evitar que se ejecute el comportamiento predeterminado del retroceso
            }
        }

        private void FormatearRut()
        {
            string rut = tbx_Rut.Text.Replace(".", "").Replace("-", "");

            if (rut.Length == 7)
            {
                rut = $"{rut.Substring(0, 1)}.{rut.Substring(1, 3)}.{rut.Substring(4, 3)}-";
            }
            else if (rut.Length == 8)
            {
                rut = $"{rut.Substring(0, 2)}.{rut.Substring(2, 3)}.{rut.Substring(5, 3)}-";
            }

            tbx_Rut.Text = rut;

            // Mover el cursor al final del texto después de formatear
            tbx_Rut.SelectionStart = tbx_Rut.Text.Length;
        }

        private void tbx_Direccion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
