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

            DataTable dtDistribucio = FuncionesBuscar.BuscarDistribucion(nombreDistribucion);

            dataGridView1.DataSource = dtDistribucio;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            FuncionesEliminar.EliminarDistribucion(nombre);
            AdministarDistribucion_Load(sender, e);
        }

        private void btn_EliminarDeGrilla_Click(object sender, EventArgs e)
        {
            DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
            int rowIndex = selectedCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            string nombreDistribucio = Convert.ToString(selectedRow.Cells["NombreDistribucio"].Value);

            FuncionesEliminar.EliminarDistribucion(nombreDistribucio);
            AdministarDistribucion_Load(sender, e);
        }

        private void AdministarDistribucion_Load(object sender, EventArgs e)
        {
            // Obtener los datos de la tabla "Talla"
            List<Distribucion> distribuciones = ObtenerDistribucion();

            // Enlazar los datos al DataGridView
            dataGridView1.DataSource = distribuciones;
        }

        // Método para obtener los datos de la tabla "Talla"
        private List<Distribucion> ObtenerDistribucion()
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

    }
}
