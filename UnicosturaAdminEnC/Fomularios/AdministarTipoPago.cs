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
    public partial class AdministarTipoPago : Form
    {
        public AdministarTipoPago()
        {
            InitializeComponent();
        }

        // Conexión a la base de datos
        private static SQLiteConnection connection = new SQLiteConnection("Data Source=pedidos.db;Version=3;");

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            string nombreTipoPago = textBox1.Text;

            FuncionesAgregar.AgregarTipoPago(nombreTipoPago);
            AdministarTipoPago_Load(sender, e);
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            AdministarTipoPago_Load(sender, e);
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string nombreMolde = textBox1.Text;

            DataTable dtTipoPago = FuncionesBuscar.BuscarTipoPago(nombreMolde);

            dataGridView1.DataSource = dtTipoPago;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            string nombreTipoPago = textBox1.Text;
            FuncionesEliminar.EliminarTipoPago(nombreTipoPago);
            AdministarTipoPago_Load(sender, e);
        }

        private void btn_EliminarDeGrilla_Click(object sender, EventArgs e)
        {
            DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
            int rowIndex = selectedCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            string nombreTipoPago = Convert.ToString(selectedRow.Cells["NombrePago"].Value);

            FuncionesEliminar.EliminarTipoPago(nombreTipoPago);
            AdministarTipoPago_Load(sender, e);
        }

        private void AdministarTipoPago_Load(object sender, EventArgs e)
        {
            // Obtener los datos de la tabla "Talla"
            List<TipoPago> tipoPagos = ObtenerTipoPagos();

            // Enlazar los datos al DataGridView
            dataGridView1.DataSource = tipoPagos;
        }

        // Método para obtener los datos de la tabla "Talla"
        private List<TipoPago> ObtenerTipoPagos()
        {
            List<TipoPago> tipoPagos = new List<TipoPago>();

            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM TipoPago", conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear un objeto Moldes con los datos de cada fila
                            TipoPago tipoPago = new TipoPago
                            {
                                IdTipoPago = Convert.ToInt32(reader["IdPago"]),
                                NombrePago = Convert.ToString(reader["NombrePago"])
                            };

                            tipoPagos.Add(tipoPago);
                        }
                    }
                }

                conn.Close();
            }

            return tipoPagos;
        }
    }
}
