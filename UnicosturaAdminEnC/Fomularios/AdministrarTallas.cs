﻿using System;
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
        private List<Talla> tallas;
        private List<Talla> tallasFiltradas;
        public AdministrarTallas()
        {
            InitializeComponent();

        }

        // Conexión a la base de datos
        private static SQLiteConnection connection = new SQLiteConnection("Data Source=pedidos.db;Version=3;");

        private void btn_AgregarTalla_Click(object sender, EventArgs e)
        {
            string nombreTalla = textBox1.Text;

            if (string.IsNullOrEmpty(nombreTalla))
            {
                // Mostrar mensaje de error
                MessageBox.Show("El campo de Nombre no puede estar vacío.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            FuncionesAgregar.AgregarTalla(nombreTalla);
            AdministrarTallas_Load(sender, e);
            textBox1.Text = "";
        }

        private void AdministrarTallas_Load(object sender, EventArgs e)
        {
            // Obtener los datos de la tabla "Talla"
            tallas = ObtenerTallas();

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

            if (string.IsNullOrEmpty(nombreTalla))
            {
                // Mostrar mensaje de error
                MessageBox.Show("El campo de Nombre no puede estar vacío.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

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

            if (string.IsNullOrEmpty(nombreTalla))
            {
                // Mostrar mensaje de error
                MessageBox.Show("El campo de Nombre no puede estar vacío.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar a " + nombreTalla + "?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                FuncionesEliminar.EliminarTalla(nombreTalla);
                AdministrarTallas_Load(sender, e);
            }
            else
            {
                return;
            }



        }

        private void Btn_EliminardeGrilla_Click(object sender, EventArgs e)
        {
            DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
            int rowIndex = selectedCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            string nombreTalla = Convert.ToString(selectedRow.Cells["NombreTalla"].Value);

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar a " + nombreTalla + "?",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                FuncionesEliminar.EliminarTalla(nombreTalla);
                AdministrarTallas_Load(sender, e);
            }
            else
            {
                return;
            }
        }

        public void CustomizarBoton(Button boton, string texto, Color colorFondo, Color colorTexto, int tamanoFuente)
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

        public void CustomizarLabel(Label label, string texto, Color colorTexto, int tamanoFuente)
        {
            label.Text = texto;
            label.Font = new Font("Arial", tamanoFuente, FontStyle.Bold);
            label.ForeColor = colorTexto;
        }

        private List<Talla> ObtenerTallasFiltradas(string filtro)
        {
            List<Talla> tallasFiltradas = new List<Talla>();

            foreach (Talla talla in tallas)
            {
                if (talla.NombreTalla.Contains(filtro))
                {
                    tallasFiltradas.Add(talla);
                }
            }

            return tallasFiltradas;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox1.Text;

            // Obtener las tallas filtradas
            List<Talla> tallasFiltradas = ObtenerTallasFiltradas(filtro);

            // Actualizar el origen de datos del DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tallasFiltradas;
        }
    }
}
