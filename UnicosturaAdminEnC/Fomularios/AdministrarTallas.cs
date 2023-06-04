using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace UnicosturaAdminEnC
{
    public partial class AdministrarTallas : Form
    {
        public AdministrarTallas()
        {
            InitializeComponent();
        }

        // Conexión a la base de datos
        private static SQLiteConnection connection = new SQLiteConnection("Data Source=pedidos.db;Version=3;");

        private void btn_AgregarTalla_Click(object sender, EventArgs e)
        {
            string nombreTalla = textBox1.Text;

            FuncionesAgregar.AgregarTalla(nombreTalla);
            AdministrarTallas_Load(sender, e);
            textBox1.Text = "";
        }

        private void AdministrarTallas_Load(object sender, EventArgs e)
        {
            // Obtener los datos de la tabla "Talla"
            List<Talla> tallas = ObtenerTallas();

            // Enlazar los datos al DataGridView
            dataGridView1.DataSource = tallas;
        }

        // Método para obtener los datos de la tabla "Talla"
        private List<Talla> ObtenerTallas()
        {
            List<Talla> tallas = new List<Talla>();

            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Talla", conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear un objeto Talla con los datos de cada fila
                            Talla talla = new Talla
                            {
                                IdTalla = Convert.ToInt32(reader["IdTalla"]),
                                NombreTalla = Convert.ToString(reader["NombreTalla"])
                            };

                            tallas.Add(talla);
                        }
                    }
                }

                conn.Close();
            }

            return tallas;
        }

        private void btn_BuscarTalla_Click(object sender, EventArgs e)
        {
            string nombreTalla = textBox1.Text;

            DataTable dtTallas = FuncionesBuscar.BuscarTallas(nombreTalla);

            dataGridView1.DataSource = dtTallas;
        }

        private void btn_ActualizarGrid_Click(object sender, EventArgs e)
        {
            AdministrarTallas_Load(sender, e);
        }

        private void btn_EliminarTalla_Click(object sender, EventArgs e)
        
        {

                string nombreTalla = textBox1.Text;
                FuncionesEliminar.EliminarTalla(nombreTalla);
                AdministrarTallas_Load(sender, e);

        }

        private void Btn_EliminardeGrilla_Click(object sender, EventArgs e)
        {
            DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
            int rowIndex = selectedCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            string nombreTalla = Convert.ToString(selectedRow.Cells["NombreTalla"].Value);

            FuncionesEliminar.EliminarTalla(nombreTalla);
            AdministrarTallas_Load(sender, e);
        }

    }
}
