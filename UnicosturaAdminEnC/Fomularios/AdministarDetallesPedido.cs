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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace UnicosturaAdminEnC
{
    
    public partial class AdministarDetallesPedido : Form
    {
        private AdministarPedidos administarPedidos;

        private static SQLiteConnection connection;
        public AdministarDetallesPedido(int idPedido, AdministarPedidos administarPedidos)
        {
            InitializeComponent();
            connection = new SQLiteConnection("Data Source=pedidos.db;Version=3;");
            connection.Open();
            tbx_IdPedido.Text = idPedido.ToString();
            RellenarCbxTallas();
            this.administarPedidos = administarPedidos;
        }

        

        public void RellenarCbxTallas()
        {
            string query = "SELECT IdTalla, NombreTalla FROM Talla";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cbx_IdTalla.DataSource = dataTable;
            cbx_IdTalla.DisplayMember = "NombreTalla";
            cbx_IdTalla.ValueMember = "IdTalla";
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            int IdPedido = int.Parse(tbx_IdPedido.Text);
            int IdTalla = Convert.ToInt32(cbx_IdTalla.SelectedValue);
            bool MoldeEnStock = chbx_MoldeEnStock.Checked;
            bool MoldeFallido = chbx_MoldeFallido.Checked;
            bool PrecioVariable = chbx_PrecioVariable.Checked;
            bool PrecioEspecial = chbx_PrecioEspecial.Checked;

            if (string.IsNullOrEmpty(tbx_CodigoMolde.Text))
            {
                // Mostrar mensaje de error
                MessageBox.Show("El campo de Codigo Molde no puede estar vacío.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            int CodigoMolde = int.Parse(tbx_CodigoMolde.Text);


            FuncionesAgregar.AgregarDetallePedidoMoldes(IdPedido, IdTalla, CodigoMolde, MoldeEnStock, MoldeFallido, PrecioVariable, PrecioEspecial);

            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {


                int PrecioNormalDeTabla = 0;
                int PrecioVariableDeTabla = 0;
                int PrecioEspecialDeTabla = 0;
                int TotalMoldesDeTabla = 0;
                int ValorPedidoDeTabla = 0;
                int ImprimirDeTabla = 0;
                int StockDeTabla = 0;
                int FallidoDeTabla = 0;


                using (SQLiteCommand cmd = new SQLiteCommand("SELECT NumeroMoldes FROM Moldes WHERE NombreMoldes = 'PrecioNormal'", conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        PrecioNormalDeTabla = Convert.ToInt32(result);
                    }
                    
                }

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT NumeroMoldes FROM Moldes WHERE NombreMoldes = 'PrecioVariable'", conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        PrecioVariableDeTabla = Convert.ToInt32(result);
                    }
                }

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT NumeroMoldes FROM Moldes WHERE NombreMoldes = 'PrecioEspecial'", conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        PrecioEspecialDeTabla = Convert.ToInt32(result);
                    }
                }

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT TotalMoldes FROM PedidoMolde WHERE IdPedido = @IdPedido", conn))
                {
                    cmd.Parameters.AddWithValue("@IdPedido", IdPedido);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        TotalMoldesDeTabla = Convert.ToInt32(result);
                        
                    }
                }

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT ValorPedido FROM PedidoMolde WHERE IdPedido = @IdPedido", conn))
                {
                    cmd.Parameters.AddWithValue("@IdPedido", IdPedido);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        ValorPedidoDeTabla = Convert.ToInt32(result);
                        
                    }
                }

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT NumeroMoldes FROM Moldes WHERE NombreMoldes = 'Imprimir'", conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        ImprimirDeTabla = Convert.ToInt32(result);
                    }
                }

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT NumeroMoldes FROM Moldes WHERE NombreMoldes = 'Stock'", conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        StockDeTabla = Convert.ToInt32(result);
                    }
                }

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT NumeroMoldes FROM Moldes WHERE NombreMoldes = 'Fallido'", conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        FallidoDeTabla = Convert.ToInt32(result);
                        
                    }
                }

                int NuevoStock = 0;
                int NuevoFallido = 0;

                int NuevoValorPedido = 0;
                int NuevoTotalMoldes = TotalMoldesDeTabla + 1;

                if (MoldeEnStock == true)
                {
                    NuevoStock = StockDeTabla + 1;

                    // Crear el comando SQL para modificar el PedidoMolde
                    string sql = "UPDATE Moldes SET NumeroMoldes = @NuevoStock WHERE NombreMoldes = 'Stock'";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        // Asignar los valores a los parámetros del comando
                        cmd.Parameters.AddWithValue("@NuevoStock", NuevoStock);

                        // Ejecutar el comando de modificación
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }

                if (MoldeFallido == true)
                {
                    NuevoFallido = FallidoDeTabla + 1;

                    // Crear el comando SQL para modificar el PedidoMolde
                    string sql = "UPDATE Moldes SET NumeroMoldes = @NuevoFallido WHERE NombreMoldes = 'Fallido'";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        // Asignar los valores a los parámetros del comando
                        cmd.Parameters.AddWithValue("@NuevoFallido", NuevoFallido);

                        // Ejecutar el comando de modificación
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }


                if (PrecioVariable == false && PrecioEspecial == false)
                {
                    NuevoValorPedido = PrecioNormalDeTabla + ValorPedidoDeTabla;
                }

                if (PrecioVariable == true )
                {
                    NuevoValorPedido = PrecioVariableDeTabla + ValorPedidoDeTabla;
                }

                if ( PrecioEspecial == true)
                {
                    NuevoValorPedido = PrecioEspecialDeTabla + ValorPedidoDeTabla;
                }


                // Crear el comando SQL para modificar el PedidoMolde
                string sql2 = "UPDATE PedidoMolde SET totalMoldes = @totalMoldes WHERE IdPedido = @IdPedido";
                using (SQLiteCommand cmd = new SQLiteCommand(sql2, conn))
                {
                    // Asignar los valores a los parámetros del comando
                    cmd.Parameters.AddWithValue("@totalMoldes", NuevoTotalMoldes);
                    cmd.Parameters.AddWithValue("@IdPedido", IdPedido);

                    // Ejecutar el comando de modificación
                    int rowsAffected = cmd.ExecuteNonQuery();
                }

                if (MoldeFallido == false)
                {
                    string sql = "UPDATE PedidoMolde SET valorPedido = @valorPedido WHERE IdPedido = @IdPedido";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        // Asignar los valores a los parámetros del comando
                        cmd.Parameters.AddWithValue("@valorPedido", NuevoValorPedido);
                        cmd.Parameters.AddWithValue("@IdPedido", IdPedido);

                        // Ejecutar el comando de modificación
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }

                if (MoldeEnStock == false)
                {
                    int NuevoImprimir = ImprimirDeTabla - 1;

                    string sql = "UPDATE Moldes SET NumeroMoldes = @NuevoImprimir WHERE NombreMoldes = 'Imprimir'";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        // Asignar los valores a los parámetros del comando
                        cmd.Parameters.AddWithValue("@NuevoImprimir", NuevoImprimir);

                        // Ejecutar el comando de modificación
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }


            }

             AdministrarDetallePedidos_Load(sender, e);
             administarPedidos.AdministarPedidos_Load(sender, e);
        }

        private void AdministrarDetallePedidos_Load(object sender, EventArgs e)
        {

            // Obtener los datos de la tabla "DetallePedidoMoldes"
            List<DetallePedidoMoldes> detallesPedido = ObtenerDetallesPedido();

            // Enlazar los datos al DataGridView
            dataGridView1.DataSource = detallesPedido;

            dataGridView1.Columns["IdDetallePedido"].DisplayIndex = 0;
            dataGridView1.Columns["IdPedido"].DisplayIndex = 1;
            dataGridView1.Columns["CodigoMolde"].DisplayIndex = 2;
            dataGridView1.Columns["IdTalla"].DisplayIndex = 3;
            dataGridView1.Columns["MoldeEnStock"].DisplayIndex = 4;
            dataGridView1.Columns["MoldeFallido"].DisplayIndex = 5;
            dataGridView1.Columns["PrecioVariable"].DisplayIndex = 6;
            dataGridView1.Columns["PrecioEspecial"].DisplayIndex = 7;

            dataGridView1.Columns[0].HeaderText = "ID Detalle";
            dataGridView1.Columns[1].HeaderText = "ID Pedido";
            dataGridView1.Columns[2].HeaderText = "Talla";
            dataGridView1.Columns[3].HeaderText = "Codigo";
            dataGridView1.Columns[4].HeaderText = "Molde En Stock";
            dataGridView1.Columns[5].HeaderText = "Molde Fallido";
            dataGridView1.Columns[6].HeaderText = "Precio Variable";
            dataGridView1.Columns[7].HeaderText = "Precio Especial";


        }

        // Método para obtener los datos de la tabla "DetallePedidoMoldes"
        private List<DetallePedidoMoldes> ObtenerDetallesPedido()
        {
            List<DetallePedidoMoldes> detallesPedido = new List<DetallePedidoMoldes>();

            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {

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
                                MoldeFallido = Convert.ToBoolean(reader["MoldeFallido"]),
                                PrecioVariable = Convert.ToBoolean(reader["PrecioVariable"]),
                                PrecioEspecial = Convert.ToBoolean(reader["PrecioEspecial"])
                            };

                            detallesPedido.Add(detallePedido);

                        }
                    }
                }
            }

            return detallesPedido;
        }

        private List<DetallePedidoMoldes> ObtenerDetallesPedido2()
        {
            List<DetallePedidoMoldes> detallesPedido = new List<DetallePedidoMoldes>();

            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {

                string query = "SELECT * FROM DetallePedidoMoldes WHERE IdPedido = @IdPedido";

                SQLiteCommand command = new SQLiteCommand(query, conn);

                int IdPedido = int.Parse(tbx_IdPedido.Text);

                command.Parameters.AddWithValue("@IdPedido", IdPedido);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DetallePedidoMoldes detalle = new DetallePedidoMoldes();
                        detalle.IdDetallePedido = Convert.ToInt32(reader["IdDetallePedido"]);
                        detalle.IdPedido = Convert.ToInt32(reader["IdPedido"]);
                        detalle.CodigoMolde = Convert.ToInt32(reader["CodigoMolde"]);
                        detalle.IdTalla = Convert.ToInt32(reader["IdTalla"]);
                        detalle.MoldeEnStock = Convert.ToBoolean(reader["MoldeEnStock"]);
                        detalle.MoldeFallido = Convert.ToBoolean(reader["MoldeFallido"]);
                        detalle.PrecioVariable = Convert.ToBoolean(reader["PrecioVariable"]);
                        detalle.PrecioEspecial = Convert.ToBoolean(reader["PrecioEspecial"]);

                        detallesPedido.Add(detalle);
                    }
                }

            }

            return detallesPedido;
        }


        private void btn_Buscar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tbx_CodigoMolde.Text))
            {
                // Mostrar mensaje de error
                MessageBox.Show("El campo de Codigo Molde no puede estar vacío.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            int CodigoMolde = int.Parse(tbx_CodigoMolde.Text);

            DataTable dtDetallePedido = FuncionesBuscar.BuscarDetallePedido(CodigoMolde);

            dataGridView1.DataSource = dtDetallePedido;
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {

        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            AdministrarDetallePedidos_Load(sender, e);
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_IdDetallePedido.Text))
            {
                // Mostrar mensaje de error
                MessageBox.Show("Debe de Seleccionar un Pedido antes de Eliminar, Desde la Grilla Haga Doble Click en el Molde que desea Eliminar primero.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            int IdDetallePedido = int.Parse(tbx_IdDetallePedido.Text);
            int IdPedido = int.Parse(tbx_IdPedido.Text);
            bool MoldeEnStock = chbx_MoldeEnStock.Checked;
            bool MoldeFallido = chbx_MoldeFallido.Checked;
            bool PrecioVariable = chbx_PrecioVariable.Checked;
            bool PrecioEspecial = chbx_PrecioEspecial.Checked;

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar al Molde numero" + IdDetallePedido + "?",
                         "Confirmar eliminación",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {


                    int PrecioNormalDeTabla = 0;
                    int PrecioVariableDeTabla = 0;
                    int PrecioEspecialDeTabla = 0;
                    int TotalMoldesDeTabla = 0;
                    int ValorPedidoDeTabla = 0;
                    int ImprimirDeTabla = 0;
                    int StockDeTabla = 0;
                    int FallidoDeTabla = 0;


                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT NumeroMoldes FROM Moldes WHERE NombreMoldes = 'PrecioNormal'", conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            PrecioNormalDeTabla = Convert.ToInt32(result);
                        }

                    }

                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT NumeroMoldes FROM Moldes WHERE NombreMoldes = 'PrecioVariable'", conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            PrecioVariableDeTabla = Convert.ToInt32(result);
                        }
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT NumeroMoldes FROM Moldes WHERE NombreMoldes = 'PrecioEspecial'", conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            PrecioEspecialDeTabla = Convert.ToInt32(result);
                        }
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT TotalMoldes FROM PedidoMolde WHERE IdPedido = @IdPedido", conn))
                    {
                        cmd.Parameters.AddWithValue("@IdPedido", IdPedido);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            TotalMoldesDeTabla = Convert.ToInt32(result);

                        }
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT ValorPedido FROM PedidoMolde WHERE IdPedido = @IdPedido", conn))
                    {
                        cmd.Parameters.AddWithValue("@IdPedido", IdPedido);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            ValorPedidoDeTabla = Convert.ToInt32(result);

                        }
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT NumeroMoldes FROM Moldes WHERE NombreMoldes = 'Imprimir'", conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            ImprimirDeTabla = Convert.ToInt32(result);
                        }
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT NumeroMoldes FROM Moldes WHERE NombreMoldes = 'Stock'", conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            StockDeTabla = Convert.ToInt32(result);
                        }
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT NumeroMoldes FROM Moldes WHERE NombreMoldes = 'Fallido'", conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            FallidoDeTabla = Convert.ToInt32(result);

                        }
                    }

                    int NuevoStock = 0;
                    int NuevoFallido = 0;

                    int NuevoValorPedido = 0;
                    int NuevoTotalMoldes = TotalMoldesDeTabla - 1;

                    if (MoldeEnStock == true)
                    {
                        NuevoStock = StockDeTabla - 1;

                        // Crear el comando SQL para modificar el PedidoMolde
                        string sql = "UPDATE Moldes SET NumeroMoldes = @NuevoStock WHERE NombreMoldes = 'Stock'";
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                        {
                            // Asignar los valores a los parámetros del comando
                            cmd.Parameters.AddWithValue("@NuevoStock", NuevoStock);

                            // Ejecutar el comando de modificación
                            int rowsAffected = cmd.ExecuteNonQuery();
                        }
                    }

                    if (MoldeFallido == true)
                    {
                        NuevoFallido = FallidoDeTabla - 1;

                        // Crear el comando SQL para modificar el PedidoMolde
                        string sql = "UPDATE Moldes SET NumeroMoldes = @NuevoFallido WHERE NombreMoldes = 'Fallido'";
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                        {
                            // Asignar los valores a los parámetros del comando
                            cmd.Parameters.AddWithValue("@NuevoFallido", NuevoFallido);

                            // Ejecutar el comando de modificación
                            int rowsAffected = cmd.ExecuteNonQuery();
                        }
                    }


                    if (PrecioVariable == false && PrecioEspecial == false)
                    {
                        NuevoValorPedido = ValorPedidoDeTabla - PrecioNormalDeTabla;
                    }

                    if (PrecioVariable == true)
                    {
                        NuevoValorPedido = ValorPedidoDeTabla - PrecioVariableDeTabla;
                    }

                    if (PrecioEspecial == true)
                    {
                        NuevoValorPedido = ValorPedidoDeTabla - PrecioEspecialDeTabla;
                    }


                    // Crear el comando SQL para modificar el PedidoMolde
                    string sql2 = "UPDATE PedidoMolde SET totalMoldes = @totalMoldes WHERE IdPedido = @IdPedido";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql2, conn))
                    {
                        // Asignar los valores a los parámetros del comando
                        cmd.Parameters.AddWithValue("@totalMoldes", NuevoTotalMoldes);
                        cmd.Parameters.AddWithValue("@IdPedido", IdPedido);

                        // Ejecutar el comando de modificación
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }

                    if (MoldeFallido == false)
                    {
                        string sql = "UPDATE PedidoMolde SET valorPedido = @valorPedido WHERE IdPedido = @IdPedido";
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                        {
                            // Asignar los valores a los parámetros del comando
                            cmd.Parameters.AddWithValue("@valorPedido", NuevoValorPedido);
                            cmd.Parameters.AddWithValue("@IdPedido", IdPedido);

                            // Ejecutar el comando de modificación
                            int rowsAffected = cmd.ExecuteNonQuery();
                        }
                    }

                    if (MoldeEnStock == false)
                    {
                        int NuevoImprimir = ImprimirDeTabla + 1;

                        string sql = "UPDATE Moldes SET NumeroMoldes = @NuevoImprimir WHERE NombreMoldes = 'Imprimir'";
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                        {
                            // Asignar los valores a los parámetros del comando
                            cmd.Parameters.AddWithValue("@NuevoImprimir", NuevoImprimir);

                            // Ejecutar el comando de modificación
                            int rowsAffected = cmd.ExecuteNonQuery();
                        }
                    }


                }

                int idDetallePedido = int.Parse(tbx_IdDetallePedido.Text);
                FuncionesEliminar.EliminarDetallePedido(idDetallePedido);
                AdministrarDetallePedidos_Load(sender, e);
                administarPedidos.AdministarPedidos_Load(sender, e);

            }
            else
            {
                return;
            }

        }

        private void btn_EliminarDeGrilla_Click(object sender, EventArgs e)
        {
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

                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbx_IdDetallePedido_Click(object sender, EventArgs e)
        {

        }

        private void tbx_IdPedido_Click(object sender, EventArgs e)
        {

        }

        private void chbx_MoldeEnStock_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_MoldeEnStock.Checked)
            {
                chbx_MoldeFallido.Enabled = false; // Desactiva el checkBox2 si checkBox1 está marcado
            }
            else
            {
                chbx_MoldeFallido.Enabled = true; // Habilita el checkBox2 si checkBox1 no está marcado
            }
        }

        private void chbx_MoldeFallido_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_MoldeFallido.Checked)
            {
                chbx_MoldeEnStock.Enabled = false; // Desactiva el checkBox2 si checkBox1 está marcado
                chbx_PrecioVariable.Enabled = false;
                chbx_PrecioEspecial.Enabled = false;
            }
            else
            {
                chbx_MoldeEnStock.Enabled = true; // Habilita el checkBox2 si checkBox1 no está marcado
                chbx_PrecioVariable.Enabled = true;
                chbx_PrecioEspecial.Enabled = true;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["IdTalla"].Index && e.Value != null)
            {
                int idTalla = (int)e.Value;
                string nombreTalla = ObtenerNombreTalla(idTalla); // Reemplaza "ObtenerNombreTalla" con tu método para obtener el nombre de la talla según el Id

                e.Value = nombreTalla;
            }
        }

        private string ObtenerNombreTalla(int idTalla)
        {
            string nombreTalla = string.Empty;

            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT NombreTalla FROM Talla WHERE IdTalla = @IdTalla", conn))
                {
                    cmd.Parameters.AddWithValue("@IdTalla", idTalla);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nombreTalla = reader["NombreTalla"].ToString();
                        }
                    }
                }

            }

            return nombreTalla;
        }

        private void chbx_PrecioVariable_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_PrecioVariable.Checked)
            {
                chbx_MoldeFallido.Enabled = false; // Desactiva el checkBox2 si checkBox1 está marcado
                chbx_PrecioEspecial.Enabled = false;
            }
            else
            {
                chbx_PrecioEspecial.Enabled = true; // Activa el checkBox2 si checkBox1 está marcado

                if(!chbx_MoldeEnStock.Checked)
                {
                    chbx_MoldeFallido.Enabled = true;
                }
                
            }
        }

        private void chbx_PrecioEspecial_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_PrecioEspecial.Checked)
            {
                chbx_MoldeFallido.Enabled = false; // Desactiva el checkBox2 si checkBox1 está marcado
                chbx_PrecioVariable.Enabled = false;
            }
            else
            {
                chbx_PrecioVariable.Enabled = true;

                if (!chbx_MoldeEnStock.Checked)
                {
                    chbx_MoldeFallido.Enabled = true;
                }
            }
        }

        private void tbx_CodigoMolde_TextChanged(object sender, EventArgs e)
        {
            string filtro1 = tbx_CodigoMolde.Text;

            // Obtener los detalles de pedido filtrados
            List<DetallePedidoMoldes> filtrados = ObtenerFiltrados(filtro1);

            // Actualizar el origen de datos del DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filtrados;

            dataGridView1.Columns["IdDetallePedido"].DisplayIndex = 0;
            dataGridView1.Columns["IdPedido"].DisplayIndex = 1;
            dataGridView1.Columns["CodigoMolde"].DisplayIndex = 2;
            dataGridView1.Columns["IdTalla"].DisplayIndex = 3;
            dataGridView1.Columns["MoldeEnStock"].DisplayIndex = 4;
            dataGridView1.Columns["MoldeFallido"].DisplayIndex = 5;
            dataGridView1.Columns["PrecioVariable"].DisplayIndex = 6;
            dataGridView1.Columns["PrecioEspecial"].DisplayIndex = 7;

            dataGridView1.Columns[0].HeaderText = "ID Detalle";
            dataGridView1.Columns[1].HeaderText = "ID Pedido";
            dataGridView1.Columns[2].HeaderText = "Talla";
            dataGridView1.Columns[3].HeaderText = "Codigo";
            dataGridView1.Columns[4].HeaderText = "Molde En Stock";
            dataGridView1.Columns[5].HeaderText = "Molde Fallido";
            dataGridView1.Columns[6].HeaderText = "Precio Variable";
            dataGridView1.Columns[7].HeaderText = "Precio Especial";
        }

        private List<DetallePedidoMoldes> ObtenerFiltrados(string filtro1)
        {
            List<DetallePedidoMoldes> ListaBD = ObtenerDetallesPedido();
            List<DetallePedidoMoldes> filtrados = new List<DetallePedidoMoldes>();

            foreach (DetallePedidoMoldes detalle in ListaBD)
            {
                if (detalle.CodigoMolde.ToString().StartsWith(filtro1))
                {
                    filtrados.Add(detalle);
                }
            }

            return filtrados;
        }

        private void cbx_IdTalla_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = Convert.ToString(cbx_IdTalla.SelectedValue);

            // Obtener los detalles de pedido filtrados
            List<DetallePedidoMoldes> filtrados = ObtenerFiltrados2(filtro);

            // Actualizar el origen de datos del DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filtrados;

            dataGridView1.Columns["IdDetallePedido"].DisplayIndex = 0;
            dataGridView1.Columns["IdPedido"].DisplayIndex = 1;
            dataGridView1.Columns["CodigoMolde"].DisplayIndex = 2;
            dataGridView1.Columns["IdTalla"].DisplayIndex = 3;
            dataGridView1.Columns["MoldeEnStock"].DisplayIndex = 4;
            dataGridView1.Columns["MoldeFallido"].DisplayIndex = 5;
            dataGridView1.Columns["PrecioVariable"].DisplayIndex = 6;
            dataGridView1.Columns["PrecioEspecial"].DisplayIndex = 7;

            dataGridView1.Columns[0].HeaderText = "ID Detalle";
            dataGridView1.Columns[1].HeaderText = "ID Pedido";
            dataGridView1.Columns[2].HeaderText = "Talla";
            dataGridView1.Columns[3].HeaderText = "Codigo";
            dataGridView1.Columns[4].HeaderText = "Molde En Stock";
            dataGridView1.Columns[5].HeaderText = "Molde Fallido";
            dataGridView1.Columns[6].HeaderText = "Precio Variable";
            dataGridView1.Columns[7].HeaderText = "Precio Especial";
        }

        private List<DetallePedidoMoldes> ObtenerFiltrados2(string filtro1)
        {
            List<DetallePedidoMoldes> ListaBD = ObtenerDetallesPedido2();
            List<DetallePedidoMoldes> filtrados = new List<DetallePedidoMoldes>();

            if (int.TryParse(filtro1, out int idTalla))
            {
                foreach (DetallePedidoMoldes detalle in ListaBD)
                {
                    if (detalle.IdTalla == idTalla)
                    {
                        filtrados.Add(detalle);
                    }
                }
            }

            return filtrados;
        }

        private void AdministarDetallesPedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private AdministarPedidos administarPedidos1;
        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            

            if (administarPedidos1 == null)
            {
                administarPedidos1 = new AdministarPedidos();
                administarPedidos1.FormClosed += (s, args) => administarPedidos1 = null; // Esto permite liberar la instancia cuando se cierra el formulario
            }
            administarPedidos1.Show();
            this.Close();
        }


    }
}
