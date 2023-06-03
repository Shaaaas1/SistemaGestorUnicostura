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

        }

        // Conexión a la base de datos
        private static SQLiteConnection connection = new SQLiteConnection("Data Source=pedidos.db;Version=3;");

        private System.Windows.Forms.ComboBox tbx_Fuente;

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            string nombreCliente = tbx_NombreCliente.Text;
            int numeroCliente = tbx_NumeroCliente.Text.Length;
            string direccion = tbx_Direccion.Text;
            string rut = tbx_Rut.Text;
            string alias = tbx_Alias.Text;
            string fuente = tbx_Fuente.SelectedItem.ToString();

            FuncionesAgregar.AgregarCliente(nombreCliente, numeroCliente, direccion, rut, alias, fuente );
            AdministrarClientes_Load(sender, e);
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string nombreCliente = tbx_NombreCliente.Text;

            DataTable dtCliente = FuncionesBuscar.BuscarCliente(nombreCliente);

            dataGridView1.DataSource = dtCliente;
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados en los campos de texto
            string nombreCliente = tbx_NombreCliente.Text;
            string numeroCliente = tbx_NumeroCliente.Text;
            string direccion = tbx_Direccion.Text;
            string rut = tbx_Rut.Text;
            string alias = tbx_Alias.Text;
            string fuente = tbx_Fuente.SelectedItem.ToString();

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
            FuncionesEliminar.EliminarCliente(nombreCliente);
            AdministrarClientes_Load(sender, e);
        }

        private void btn_EliminardeGrilla_Click(object sender, EventArgs e)
        {
            DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
            int rowIndex = selectedCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            string nombreCliente = Convert.ToString(selectedRow.Cells["NombreCliente"].Value);

            FuncionesEliminar.EliminarCliente(nombreCliente);
            AdministrarClientes_Load(sender, e);
        }

        private void AdministrarClientes_Load(object sender, EventArgs e)
        {
            // Obtener los datos de la tabla "Talla"
            List<Cliente> clientes = ObtenerClientes();

            // Enlazar los datos al DataGridView
            dataGridView1.DataSource = clientes;
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
                                CelularCliente = Convert.ToInt32(reader["CelularCliente"]),
                                Direccion = Convert.ToString(reader["Direccion"]),
                                Rut = Convert.ToString(reader["Rut"]),
                                Alias = Convert.ToString(reader["Alias"]),
                                Fuente = Convert.ToString(reader["Fuente"])
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
        }
    }
}
