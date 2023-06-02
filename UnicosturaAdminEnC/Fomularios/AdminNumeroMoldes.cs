using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicosturaAdminEnC.Clases;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UnicosturaAdminEnC
{
    public partial class AdminNumeroMoldes : Form
    {
        public AdminNumeroMoldes()
        {
            InitializeComponent();
        }

        // Conexión a la base de datos
        private static SQLiteConnection connection = new SQLiteConnection("Data Source=pedidos.db;Version=3;");

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            string nombreMolde = tbx_NombreMolde.Text;
            int NumeroMoldes = tbx_NumeroMoldes.Text.Length;

            FuncionesAgregar.AgregarMolde(nombreMolde, NumeroMoldes);
            AdministrarMoldes_Load(sender, e);
        }

        private void AdministrarMoldes_Load(object sender, EventArgs e)
        {
            // Obtener los datos de la tabla "Talla"
            List<Moldes> moldes = ObtenerMoldes();

            // Enlazar los datos al DataGridView
            dataGridView1.DataSource = moldes;
        }

        // Método para obtener los datos de la tabla "Talla"
        private List<Moldes> ObtenerMoldes()
        {
            List<Moldes> moldes = new List<Moldes>();

            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Moldes", conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear un objeto Moldes con los datos de cada fila
                            Moldes molde = new Moldes
                            {
                                IdMoldes = Convert.ToInt32(reader["IdMoldes"]),
                                NombreMoldes = Convert.ToString(reader["NombreMoldes"]),
                                NumeroMoldes = Convert.ToInt32(reader["NumeroMoldes"])
                            };

                            moldes.Add(molde);
                        }
                    }
                }

                conn.Close();
            }

            return moldes;
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            AdministrarMoldes_Load(sender, e);
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string nombreMolde = tbx_NombreMolde.Text;

            DataTable dtMoldes = FuncionesBuscar.BuscarMolde(nombreMolde);

            dataGridView1.DataSource = dtMoldes;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            string nombreMolde = tbx_NombreMolde.Text;
            FuncionesEliminar.EliminarMolde(nombreMolde);
            AdministrarMoldes_Load(sender, e);
        }

        private void btn_EliminarDeGrilla_Click(object sender, EventArgs e)
        {
            DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
            int rowIndex = selectedCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            string nombreMolde = Convert.ToString(selectedRow.Cells["NombreMoldes"].Value);

            FuncionesEliminar.EliminarMolde(nombreMolde);
            AdministrarMoldes_Load(sender, e);
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados en los campos de texto
            string nombreMolde = tbx_NombreMolde.Text;
            int numeroMolde = int.Parse(tbx_NumeroMoldes.Text);

            // Crear la conexión a la base de datos
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=pedidos.db;Version=3;"))
            {
                conn.Open();

                // Crear el comando SQL para modificar el registro
                string sql = "UPDATE Moldes SET NumeroMoldes = @NumeroMoldes WHERE NombreMoldes = @NombreMoldes";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    // Asignar los valores a los parámetros del comando
                    cmd.Parameters.AddWithValue("@NumeroMoldes", numeroMolde);
                    cmd.Parameters.AddWithValue("@NombreMoldes", nombreMolde);

                    // Ejecutar el comando de modificación
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registro de Molde modificado correctamente.");
                        // Aquí puedes realizar cualquier acción adicional después de la modificación exitosa.
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el registro de Molde a modificar.");
                    }
                }

                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // Verificar si se hizo clic en una fila válida
            {
                // Obtener los valores de la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];
                string nombreMolde = filaSeleccionada.Cells["NombreMoldes"].Value.ToString();
                int numeroMolde = Convert.ToInt32(filaSeleccionada.Cells["NumeroMoldes"].Value);

                // Rellenar los TextBoxes con los valores obtenidos
                tbx_NombreMolde.Text = nombreMolde;
                tbx_NumeroMoldes.Text = numeroMolde.ToString();
            }
        }

        private void AdminNumeroMoldes_Load(object sender, EventArgs e)
        {
            AdministrarMoldes_Load(sender, e);
        }
    }
}
