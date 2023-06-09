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

namespace UnicosturaAdminEnC.Fomularios
{
    public partial class AdministarRepartidores : Form
    {
        public AdministarRepartidores()
        {
            InitializeComponent();
        }

        // Conexión a la base de datos
        private static SQLiteConnection connection = new SQLiteConnection("Data Source=pedidos.db;Version=3;");

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            string nombreRepartidor = textBox1.Text;

            if (string.IsNullOrEmpty(nombreRepartidor))
            {
                // Mostrar mensaje de error
                MessageBox.Show("El campo de Nombre no puede estar vacío.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            FuncionesAgregar.AgregarRepartidor(nombreRepartidor);
            AdministarRepartidor_Load(sender, e);
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string nombreRepartidor = textBox1.Text;

            if (string.IsNullOrEmpty(nombreRepartidor))
            {
                // Mostrar mensaje de error
                MessageBox.Show("El campo de Nombre no puede estar vacío.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            DataTable dtRepartidor = FuncionesBuscar.BuscarRepartidor(nombreRepartidor);

            dataGridView1.DataSource = dtRepartidor;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            string nombreRepartidor = textBox1.Text;

            if (string.IsNullOrEmpty(nombreRepartidor))
            {
                // Mostrar mensaje de error
                MessageBox.Show("El campo de Nombre no puede estar vacío.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar a " + nombreRepartidor + "?",
                                    "Confirmar eliminación",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                FuncionesEliminar.EliminarRepartidor(nombreRepartidor);
                AdministarRepartidor_Load(sender, e);
            }
            else
            {
                return;
            }

        }

        private void btn_EliminarDeGrilla_Click(object sender, EventArgs e)
        {
            DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
            int rowIndex = selectedCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            string nombreRepartidor = Convert.ToString(selectedRow.Cells["NombreRepartidor"].Value);

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar a " + nombreRepartidor + "?",
                                    "Confirmar eliminación",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                FuncionesEliminar.EliminarRepartidor(nombreRepartidor);
                AdministarRepartidor_Load(sender, e);
            }
            else
            {
                return;
            }

        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            AdministarRepartidor_Load(sender, e);
        }

        private void AdministarRepartidor_Load(object sender, EventArgs e)
        {
            // Obtener los datos de la tabla "Talla"
            List<Repartidor> repartidores = ObtenerRepartidores();

            // Enlazar los datos al DataGridView
            dataGridView1.DataSource = repartidores;
        }

        // Método para obtener los datos de la tabla "Talla"
        private List<Repartidor> ObtenerRepartidores()
        {
            List<Repartidor> repartidores = new List<Repartidor>();

            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Repartidor", conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear un objeto Moldes con los datos de cada fila
                            Repartidor repartidor = new Repartidor
                            {
                                IdRepartidor = Convert.ToInt32(reader["IdRepartidor"]),
                                NombreRepartidor = Convert.ToString(reader["NombreRepartidor"])
                            };

                            repartidores.Add(repartidor);
                        }
                    }
                }

                conn.Close();
            }

            return repartidores;
        }

        private void AdministarRepartidores_Load(object sender, EventArgs e)
        {
            AdministarRepartidor_Load(sender, e);
        }
    }
}
