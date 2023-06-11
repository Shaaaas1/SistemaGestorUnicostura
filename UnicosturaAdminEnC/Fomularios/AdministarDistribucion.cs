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
    public partial class AdministarDistribucion : Form
    {
        public AdministarDistribucion()
        {
            InitializeComponent();
        }

        // Conexión a la base de datos
        private static SQLiteConnection connection = new SQLiteConnection("Data Source=pedidos.db;Version=3;");

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            string nombreDistribucion = textBox1.Text;

            if (string.IsNullOrEmpty(nombreDistribucion))
            {
                // Mostrar mensaje de error
                MessageBox.Show("El campo de Nombre no puede estar vacío.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            FuncionesAgregar.AgregarDistribucion(nombreDistribucion);
            AdministarDistribucion_Load(sender, e);
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            AdministarDistribucion_Load(sender, e);
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string nombreDistribucion = textBox1.Text;

            if (string.IsNullOrEmpty(nombreDistribucion))
            {
                // Mostrar mensaje de error
                MessageBox.Show("El campo de Nombre no puede estar vacío.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            DataTable dtDistribucio = FuncionesBuscar.BuscarDistribucion(nombreDistribucion);

            dataGridView1.DataSource = dtDistribucio;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;

            if (string.IsNullOrEmpty(nombre))
            {
                // Mostrar mensaje de error
                MessageBox.Show("El campo de Nombre no puede estar vacío.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar a " + nombre + "?",
                  "Confirmar eliminación",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                FuncionesEliminar.EliminarDistribucion(nombre);
                AdministarDistribucion_Load(sender, e);
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
            string nombreDistribucio = Convert.ToString(selectedRow.Cells["NombreDistribucio"].Value);

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar a " + nombreDistribucio + "?",
                  "Confirmar eliminación",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                FuncionesEliminar.EliminarDistribucion(nombreDistribucio);
                AdministarDistribucion_Load(sender, e);
            }
            else
            {
                return;
            }

        }

        private void AdministarDistribucion_Load(object sender, EventArgs e)
        {
            // Obtener los datos de la tabla "Talla"
            List<Distribucion> distribuciones = ObtenerDistribucion();

            // Enlazar los datos al DataGridView
            dataGridView1.DataSource = distribuciones;
        }

        // Método para obtener los datos de la tabla "Talla"
        public List<Distribucion> ObtenerDistribucion()
        {
            List<Distribucion> distribuciones = new List<Distribucion>();

            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Distribucion", conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear un objeto Moldes con los datos de cada fila
                             Distribucion distribucion = new Distribucion
                            {
                                IdDistribucion = Convert.ToInt32(reader["IdDistribucion"]),
                                NombreDistribucio = Convert.ToString(reader["NombreDistribucio"])
                            };

                            distribuciones.Add(distribucion);
                        }
                    }
                }

                conn.Close();
            }

            return distribuciones;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox1.Text;

            // Obtener las distribuciones filtradas
            List<Distribucion> distribucionesFiltradas = ObtenerDistribucionesFiltradas(filtro);

            // Actualizar el origen de datos del DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = distribucionesFiltradas;
        }

        private List<Distribucion> ObtenerDistribucionesFiltradas(string filtro)
        {
            List<Distribucion>  distrbuciones = ObtenerDistribucion();
            List<Distribucion> distribucionesFiltradas = new List<Distribucion>();

            foreach (Distribucion distribucion in distrbuciones)
            {
                if (distribucion.NombreDistribucio.Contains(filtro))
                {
                    distribucionesFiltradas.Add(distribucion);
                }
            }

            return distribucionesFiltradas;
        }
    }
}
