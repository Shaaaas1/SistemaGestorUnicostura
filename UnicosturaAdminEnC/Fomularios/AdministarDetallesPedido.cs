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
    
    public partial class AdministarDetallesPedido : Form
    {
        public AdministarDetallesPedido(int idPedido)
        {
            InitializeComponent();
            tbx_IdPedido.Text = idPedido.ToString();
            RellenarCbxTallas();
        }

        private static SQLiteConnection connection = new SQLiteConnection("Data Source=pedidos.db;Version=3;");

        public void RellenarCbxTallas()
        {
            connection.Open();
            string query = "SELECT IdTalla, NombreTalla FROM Talla";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cbx_IdTalla.DataSource = dataTable;
            cbx_IdTalla.DisplayMember = "NombreTalla";
            cbx_IdTalla.ValueMember = "IdTalla";
            connection.Close();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            int IdPedido = int.Parse(tbx_IdPedido.Text);
            int IdTalla = Convert.ToInt32(cbx_IdTalla.SelectedValue);
            int CodigoMolde = int.Parse(tbx_CodigoMolde.Text);
            bool MoldeEnStock = chbx_MoldeEnStock.Checked;
            bool MoldeFallido = chbx_MoldeFallido.Checked;

            FuncionesAgregar.AgregarDetallePedidoMoldes(IdPedido, IdTalla, CodigoMolde, MoldeEnStock, MoldeFallido);
            AdministrarDetallePedidos_Load(sender, e);
        }

        private void AdministrarDetallePedidos_Load(object sender, EventArgs e)
        {
            // Obtener los datos de la tabla "DetallePedidoMoldes"
            List<DetallePedidoMoldes> detallesPedido = ObtenerDetallesPedido();

            // Enlazar los datos al DataGridView
            dataGridView1.DataSource = detallesPedido;
        }

        // Método para obtener los datos de la tabla "DetallePedidoMoldes"
        private List<DetallePedidoMoldes> ObtenerDetallesPedido()
        {
            List<DetallePedidoMoldes> detallesPedido = new List<DetallePedidoMoldes>();

            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM DetallePedidoMoldes WHERE IdPedido = @IdPedido", conn))
                {
                    int IdPedido = int.Parse(tbx_IdPedido.Text);

                    cmd.Parameters.AddWithValue("@IdPedido", IdPedido);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear un objeto DetallePedidoMolde con los datos de cada fila
                            DetallePedidoMoldes detallePedido = new DetallePedidoMoldes
                            {
                                IdDetallePedido = Convert.ToInt32(reader["IdDetallePedido"]),
                                IdPedido = Convert.ToInt32(reader["IdPedido"]),
                                IdTalla = Convert.ToInt32(reader["IdTalla"]),
                                CodigoMolde = Convert.ToInt32(reader["CodigoMolde"]),
                                MoldeEnStock = Convert.ToBoolean(reader["MoldeEnStock"]),
                                MoldeFallido = Convert.ToBoolean(reader["MoldeFallido"])
                            };

                            detallesPedido.Add(detallePedido);
                        }
                    }
                }

                conn.Close();
            }

            return detallesPedido;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            int CodigoMolde = int.Parse(tbx_CodigoMolde.Text);

            DataTable dtDetallePedido = FuncionesBuscar.BuscarDetallePedido(CodigoMolde);

            dataGridView1.DataSource = dtDetallePedido;
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados en los campos de texto
            int idDetallePedido = int.Parse(tbx_IdDetallePedido.Text);
            int idPedido = int.Parse(tbx_IdPedido.Text);
            int idTalla = Convert.ToInt32(cbx_IdTalla.SelectedValue);
            int codigoMolde = int.Parse(tbx_CodigoMolde.Text);
            bool moldeEnStock = chbx_MoldeEnStock.Checked;
            bool moldeFallido = chbx_MoldeFallido.Checked;

            // Crear la conexión a la base de datos
            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {
                conn.Open();

                // Crear el comando SQL para modificar el registro
                string sql = "UPDATE DetallePedidoMoldes SET IdPedido = @IdPedido, IdTalla = @IdTalla, CodigoMolde = @CodigoMolde, MoldeEnStock = @MoldeEnStock, MoldeFallido = @MoldeFallido WHERE IdDetallePedido = @IdDetallePedido";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    // Asignar los valores a los parámetros del comando
                    cmd.Parameters.AddWithValue("@IdPedido", idPedido);
                    cmd.Parameters.AddWithValue("@IdTalla", idTalla);
                    cmd.Parameters.AddWithValue("@CodigoMolde", codigoMolde);
                    cmd.Parameters.AddWithValue("@MoldeEnStock", moldeEnStock);
                    cmd.Parameters.AddWithValue("@MoldeFallido", moldeFallido);
                    cmd.Parameters.AddWithValue("@IdDetallePedido", idDetallePedido);

                    // Ejecutar el comando de modificación
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registro de Detalle Pedido modificado correctamente.");
                        // Aquí puedes realizar cualquier acción adicional después de la modificación exitosa.
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el registro de Detalle Pedido a modificar.");
                    }
                }

                conn.Close();
                AdministrarDetallePedidos_Load(sender, e);
            }
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            AdministrarDetallePedidos_Load(sender, e);
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            int idDetallePedido = int.Parse(tbx_IdDetallePedido.Text);
            FuncionesEliminar.EliminarDetallePedido(idDetallePedido);
            AdministrarDetallePedidos_Load(sender, e);
        }

        private void btn_EliminarDeGrilla_Click(object sender, EventArgs e)
        {
            DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
            int rowIndex = selectedCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            int idDetallePedido = Convert.ToInt32(selectedRow.Cells["IdDetallePedido"].Value);

            FuncionesEliminar.EliminarDetallePedido(idDetallePedido);

            AdministrarDetallePedidos_Load(sender, e);
        }

        private void AdministarDetallesPedido_Load(object sender, EventArgs e)
        {
            AdministrarDetallePedidos_Load(sender, e);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex >= 0)  // Verificar si se hizo clic en una fila válida
                {
                    // Obtener los valores de la fila seleccionada
                    DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];
                    string idDetallePedido = filaSeleccionada.Cells["IdDetallePedido"].Value.ToString();
                    string idPedido = filaSeleccionada.Cells["IdPedido"].Value.ToString();
                    string idTalla = filaSeleccionada.Cells["IdTalla"].Value.ToString();
                    string codigoMolde = filaSeleccionada.Cells["CodigoMolde"].Value.ToString();
                    string moldeEnStock = filaSeleccionada.Cells["MoldeEnStock"].Value.ToString();
                    string moldeFallido = filaSeleccionada.Cells["MoldeFallido"].Value.ToString();

                    // Rellenar los TextBoxes con los valores obtenidos
                    tbx_IdDetallePedido.Text = idDetallePedido;
                    tbx_IdPedido.Text = idPedido;
                    cbx_IdTalla.Text = idTalla;
                    tbx_CodigoMolde.Text = codigoMolde;
                    chbx_MoldeEnStock.Checked = bool.Parse(moldeEnStock);
                    chbx_MoldeFallido.Checked = bool.Parse(moldeFallido);

                    // Rellenar Booleanos de Estado

                    // Consulta SQL para obtener el estado correspondiente al IdEstado
                    string query = "SELECT * FROM Talla WHERE IdTalla = @idTalla";

                    using (SQLiteConnection conn = new SQLiteConnection(connection))
                    {
                        conn.Open();

                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@idTalla", idTalla);

                            using (SQLiteDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Obtener los valores de los campos del estado
                                    String talla = Convert.ToString(reader["NombreTalla"]);

                                    // Establecer los valores de los checkboxes
                                    cbx_IdTalla.Text = talla;
                                }
                            }
                        }

                        conn.Close();
                    }
                }
            }
        }
    }
}
