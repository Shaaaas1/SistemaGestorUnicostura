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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using UnicosturaAdminEnC.Clases;

namespace UnicosturaAdminEnC
{
    public partial class AdministarPedidos : Form
    {
        public AdministarPedidos()
        {
            InitializeComponent();
            RellenarCbxCliente();
            RellenarCbxNumeroCliente();
            RellenarCbxAlias();
            RellenarCbxRut();
            RellenarRepartidor();
            RellenarTipoPago();
            RellenarDistribucion();
            tbx_NumeroBoleta.Text = "0";
            tbx_IdCliente.Text = "-1";
        }

        static string connectionString = "Data Source=pedidos.db;Version=3;";
        SQLiteConnection connection = new SQLiteConnection(connectionString);

        public void RellenarCbxCliente()
        {
            connection.Open();
            string query = "SELECT NombreCliente FROM Cliente";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cbx_NombreCliente.DataSource = dataTable;
            cbx_NombreCliente.DisplayMember = "NombreCliente";
            connection.Close();
        }

        public void RellenarCbxAlias()
        {
            connection.Open();
            string query = "SELECT Alias FROM Cliente";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cbx_Alias.DataSource = dataTable;
            cbx_Alias.DisplayMember = "Alias";
            connection.Close();
        }

        public void RellenarCbxNumeroCliente()
        {
            connection.Open();
            string query = "SELECT CelularCliente FROM Cliente";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cbx_CelularCliente.DataSource = dataTable;
            cbx_CelularCliente.DisplayMember = "CelularCliente";
            connection.Close();
        }

        public void RellenarCbxRut()
        {
            connection.Open();
            string query = "SELECT Rut FROM Cliente";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cbx_Rut.DataSource = dataTable;
            cbx_Rut.DisplayMember = "Rut";
            connection.Close();
        }

        public void RellenarRepartidor()
        {
            connection.Open();
            string query = "SELECT IdRepartidor, NombreRepartidor FROM Repartidor";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable repartidorTable = new DataTable();
            adapter.Fill(repartidorTable);
            cbx_IdRepartidor.DataSource = repartidorTable;
            cbx_IdRepartidor.DisplayMember = "NombreRepartidor";
            cbx_IdRepartidor.ValueMember = "IdRepartidor";
            connection.Close();
        }

        public void RellenarDistribucion()
        {
            connection.Open();
            string query = "SELECT IdDistribucion, NombreDistribucio FROM Distribucion";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable distribucionTable = new DataTable();
            adapter.Fill(distribucionTable);
            cbx_IdDistribucion.DataSource = distribucionTable;
            cbx_IdDistribucion.DisplayMember = "NombreDistribucio";
            cbx_IdDistribucion.ValueMember = "IdDistribucion";
            connection.Close();
        }

        public void RellenarTipoPago()
        {
            connection.Open();
            string query = "SELECT IdPago, NombrePago FROM TipoPago";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable tipoPagoTable = new DataTable();
            adapter.Fill(tipoPagoTable);
            cbx_IdPago.DataSource = tipoPagoTable;
            cbx_IdPago.DisplayMember = "NombrePago";
            cbx_IdPago.ValueMember = "IdPago";
            connection.Close();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            // Variables del Cliente
            int idCliente = int.Parse(tbx_IdCliente.Text);
            string nombreCliente = cbx_NombreCliente.Text;
            string direccion = tbx_Direccion.Text;
            string alias = cbx_Alias.Text;
            int celularCliente = int.Parse(cbx_CelularCliente.Text);
            string fuente = tbx_Fuente.Text;
            string rut = cbx_Rut.Text;

            // Variables de Estado
            bool impreso = Chbx_Impreso.Checked;
            bool pagado = Chbx_Pagado.Checked;
            bool boleta = Chbx_Boleta.Checked;
            bool entregado = Chbx_Entregado.Checked;

            // Variables de PedidoMolde
            int idRepartidor = Convert.ToInt32(cbx_IdRepartidor.SelectedValue);
            int idDistribucion = Convert.ToInt32(cbx_IdDistribucion.SelectedValue);
            int idPago = Convert.ToInt32(cbx_IdPago.SelectedValue);
            int totalMoldes = 0;
            int valorPedido = 0;
            int numeroBoleta = int.Parse(tbx_NumeroBoleta.Text);
            DateTime fecha = dateTimePicker1.Value;

            // Verificar si el cliente ya existe en la base de datos por su IdCliente
            if (idCliente != -1)
            {

                int idEstado = FuncionesAgregar.AgregarEstado(impreso, pagado, boleta, entregado);

                FuncionesAgregar.AgregarPedidoMolde(idCliente, idEstado, idRepartidor, idDistribucion, idPago, totalMoldes, valorPedido, numeroBoleta, fecha);

            }
            else
            {
                int idNuevoCliente = FuncionesAgregar.AgregarCliente2(nombreCliente, celularCliente, direccion, rut, alias, fuente);

                int idEstado = FuncionesAgregar.AgregarEstado(impreso, pagado, boleta, entregado);

                FuncionesAgregar.AgregarPedidoMolde(idNuevoCliente, idEstado, idRepartidor, idDistribucion, idPago, totalMoldes, valorPedido, numeroBoleta, fecha);
            }
            AdministarPedidos_Load(sender, e);
        }

        private void cbx_Rut_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rutSeleccionado = cbx_Rut.Text;

            if (!string.IsNullOrEmpty(rutSeleccionado))
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string query = "SELECT * FROM Cliente WHERE Rut = @rut";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@rut", rutSeleccionado);
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string IdCliente = reader["IdCliente"].ToString();
                                string nombreCliente = reader["NombreCliente"].ToString();
                                string alias = reader["Alias"].ToString();
                                string celular = reader["CelularCliente"].ToString();
                                string fuente = reader["Fuente"].ToString();
                                string direccion = reader["Direccion"].ToString();

                                tbx_IdCliente.Text = IdCliente;
                                cbx_NombreCliente.Text = nombreCliente;
                                cbx_Alias.Text = alias;
                                cbx_CelularCliente.Text = celular;
                                tbx_Fuente.Text = fuente;
                                tbx_Direccion.Text = direccion;
                            }
                        }
                    }
                }
            }
            else
            {
                tbx_IdCliente.Text = "-1";
                cbx_NombreCliente.Text = string.Empty;
                cbx_Alias.Text = string.Empty;
                cbx_CelularCliente.Text = string.Empty;
                tbx_Fuente.Text = string.Empty;
                tbx_Direccion.Text = string.Empty;
            }
        }

        private void cbx_NombreCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreClienteSeleccionado = cbx_NombreCliente.Text;

            if (!string.IsNullOrEmpty(nombreClienteSeleccionado))
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string query = "SELECT * FROM Cliente WHERE NombreCliente = @nombreCliente";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreCliente", nombreClienteSeleccionado);
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string IdCliente = reader["IdCliente"].ToString();
                                string rut = reader["Rut"].ToString();
                                string alias = reader["Alias"].ToString();
                                string celular = reader["CelularCliente"].ToString();
                                string fuente = reader["Fuente"].ToString();
                                string direccion = reader["Direccion"].ToString();

                                tbx_IdCliente.Text = IdCliente;
                                cbx_Rut.Text = rut;
                                cbx_Alias.Text = alias;
                                cbx_CelularCliente.Text = celular;
                                tbx_Fuente.Text = fuente;
                                tbx_Direccion.Text = direccion;
                            }
                        }
                    }
                }
            }
            else
            {
                tbx_IdCliente.Text = "-1";
                cbx_Rut.Text = string.Empty;
                cbx_Alias.Text = string.Empty;
                cbx_CelularCliente.Text = string.Empty;
                tbx_Fuente.Text = string.Empty;
                tbx_Direccion.Text = string.Empty;
            }
        }

        private void cbx_Alias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string aliasSeleccionado = cbx_Alias.Text;

            if (!string.IsNullOrEmpty(aliasSeleccionado))
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string query = "SELECT * FROM Cliente WHERE Alias = @alias";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@alias", aliasSeleccionado);
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string IdCliente = reader["IdCliente"].ToString();
                                string rut = reader["Rut"].ToString();
                                string nombreCliente = reader["NombreCliente"].ToString();
                                string celular = reader["CelularCliente"].ToString();
                                string fuente = reader["Fuente"].ToString();
                                string direccion = reader["Direccion"].ToString();

                                tbx_IdCliente.Text = IdCliente;
                                cbx_Rut.Text = rut;
                                cbx_NombreCliente.Text = nombreCliente;
                                cbx_CelularCliente.Text = celular;
                                tbx_Fuente.Text = fuente;
                                tbx_Direccion.Text = direccion;
                            }
                        }
                    }
                }
            }
            else
            {
                tbx_IdCliente.Text = "-1";
                cbx_Rut.Text = string.Empty;
                cbx_NombreCliente.Text = string.Empty;
                cbx_CelularCliente.Text = string.Empty;
                tbx_Fuente.Text = string.Empty;
                tbx_Direccion.Text = string.Empty;
            }
        }

        private void cbx_CelularCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string celularClienteSeleccionado = cbx_CelularCliente.Text;

            if (!string.IsNullOrEmpty(celularClienteSeleccionado))
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string query = "SELECT * FROM Cliente WHERE CelularCliente = @celularCliente";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@celularCliente", celularClienteSeleccionado);
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string IdCliente = reader["IdCliente"].ToString();
                                string rut = reader["Rut"].ToString();
                                string nombreCliente = reader["NombreCliente"].ToString();
                                string alias = reader["Alias"].ToString();
                                string fuente = reader["Fuente"].ToString();
                                string direccion = reader["Direccion"].ToString();

                                tbx_IdCliente.Text = IdCliente;
                                cbx_Rut.Text = rut;
                                cbx_NombreCliente.Text = nombreCliente;
                                cbx_Alias.Text = alias;
                                tbx_Fuente.Text = fuente;
                                tbx_Direccion.Text = direccion;
                            }
                        }
                    }
                }
            }
            else
            {
                tbx_IdCliente.Text = "-1";
                cbx_Rut.Text = string.Empty;
                cbx_NombreCliente.Text = string.Empty;
                cbx_Alias.Text = string.Empty;
                tbx_Fuente.Text = string.Empty;
                tbx_Direccion.Text = string.Empty;
            }
        }

        private void btn_LimpiarCliente_Click(object sender, EventArgs e)
        {
            LimpiarDatosCliente();
        }

        public void LimpiarDatosCliente()
        {
            tbx_IdCliente.Text = "-1";
            cbx_NombreCliente.SelectedIndex = -1;
            cbx_CelularCliente.SelectedIndex = -1;
            cbx_Alias.SelectedIndex = -1;
            cbx_Rut.SelectedIndex = -1;
            tbx_Fuente.SelectedIndex = -1;
            tbx_Direccion.Text = string.Empty;
        }

        private void AdministarPedidos_Load(object sender, EventArgs e)
        {
            // Obtener los datos de la tabla "PedidoMolde"
            List<PedidoMolde> pedidos = ObtenerPedidos();

            // Enlazar los datos al DataGridView
            dataGridView1.DataSource = pedidos;
        }

        // Método para obtener los datos de la tabla "PedidoMolde"
        private List<PedidoMolde> ObtenerPedidos()
        {
            List<PedidoMolde> pedidos = new List<PedidoMolde>();

            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM PedidoMolde", conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear un objeto PedidoMolde con los datos de cada fila
                            PedidoMolde pedido = new PedidoMolde
                            {
                                IdPedido = Convert.ToInt32(reader["IdPedido"]),
                                IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                IdEstado = Convert.ToInt32(reader["IdEstado"]),
                                IdRepartidor = Convert.ToInt32(reader["IdRepartidor"]),
                                IdDistribucion = Convert.ToInt32(reader["IdDistribucion"]),
                                IdPago = Convert.ToInt32(reader["IdPago"]),
                                TotalMoldes = Convert.ToInt32(reader["TotalMoldes"]),
                                ValorPedido = Convert.ToInt32(reader["ValorPedido"]),
                                NumBoletaImpresa = Convert.ToInt32(reader["NumBoletaImpresa"]),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                // Agregar aquí los demás atributos de la tabla PedidoMolde
                            };

                            pedidos.Add(pedido);
                        }
                    }
                }

                conn.Close();
            }

            return pedidos;
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            AdministarPedidos_Load(sender, e);
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            int idCliente = int.Parse(tbx_IdCliente.Text);

            DataTable dtCliente = FuncionesBuscar.BuscarPedido(idCliente);

            dataGridView1.DataSource = dtCliente;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            int idEstado = int.Parse(tbx_IdEstados.Text);
            FuncionesEliminar.EliminarPedido(idEstado);
            AdministarPedidos_Load(sender, e);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // Verificar si se hizo clic en una fila válida
            {
                // Obtener los valores de la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];
                int idPedido = Convert.ToInt32(filaSeleccionada.Cells["IdPedido"].Value);
                int idCliente = Convert.ToInt32(filaSeleccionada.Cells["IdCliente"].Value);
                int idEstado = Convert.ToInt32(filaSeleccionada.Cells["IdEstado"].Value);
                int idRepartidor = Convert.ToInt32(filaSeleccionada.Cells["IdRepartidor"].Value);
                int idDistribucion = Convert.ToInt32(filaSeleccionada.Cells["IdDistribucion"].Value);
                int idPago = Convert.ToInt32(filaSeleccionada.Cells["IdPago"].Value);
                int totalMoldes = Convert.ToInt32(filaSeleccionada.Cells["TotalMoldes"].Value);
                int valorPedido = Convert.ToInt32(filaSeleccionada.Cells["ValorPedido"].Value);
                int numBoletaImpresa = Convert.ToInt32(filaSeleccionada.Cells["NumBoletaImpresa"].Value);
                DateTime fecha = Convert.ToDateTime(filaSeleccionada.Cells["Fecha"].Value);

                // Rellenar los TextBoxes con los valores obtenidos
                tbx_IdPedido.Text = idPedido.ToString();
                tbx_IdCliente.Text = idCliente.ToString();
                tbx_IdEstados.Text = idEstado.ToString();
                cbx_IdRepartidor.Text = idRepartidor.ToString();
                cbx_IdDistribucion.Text = idDistribucion.ToString();
                cbx_IdPago.Text = idPago.ToString();
                tbx_TotalMoldes.Text = totalMoldes.ToString();
                tbx_ValorPedido.Text = valorPedido.ToString();
                tbx_NumeroBoleta.Text = numBoletaImpresa.ToString();
                dateTimePicker1.Value = fecha;

                // Rellenar Booleanos de Estado

                // Consulta SQL para obtener el estado correspondiente al IdEstado
                string query = "SELECT * FROM Estado WHERE IdEstado = @idEstado";

                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idEstado", idEstado);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Obtener los valores de los campos del estado
                                bool impreso = Convert.ToBoolean(reader["Impreso"]);
                                bool pagado = Convert.ToBoolean(reader["Pagado"]);
                                bool boleta = Convert.ToBoolean(reader["Boleta"]);
                                bool entregado = Convert.ToBoolean(reader["Entregado"]);

                                // Establecer los valores de los checkboxes
                                Chbx_Impreso.Checked = impreso;
                                Chbx_Pagado.Checked = pagado;
                                Chbx_Boleta.Checked = boleta;
                                Chbx_Entregado.Checked = entregado;
                            }
                        }
                    }

                    conn.Close();
                }

                // Rellenar Datos Cliente

                // Consulta SQL para obtener el estado correspondiente al IdCliente
                string query2 = "SELECT * FROM Cliente WHERE IdCliente = @idCliente";

                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(query2, conn))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", idCliente);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Obtener los valores de los campos del estado
                                string NombreCliente = Convert.ToString(reader["NombreCliente"]);
                                int CelularCliente = Convert.ToInt32(reader["CelularCliente"]);
                                string Direccion = Convert.ToString(reader["Direccion"]);
                                string Rut = Convert.ToString(reader["Rut"]);
                                string Alias = Convert.ToString(reader["Alias"]);
                                string Fuente = Convert.ToString(reader["Fuente"]);

                                // Establecer los valores
                                cbx_NombreCliente.Text = NombreCliente;
                                cbx_CelularCliente.Text = CelularCliente.ToString();
                                tbx_Direccion.Text = Direccion;
                                cbx_Rut.Text = Rut;
                                cbx_Alias.Text = Alias;
                                tbx_Fuente.Text = Fuente;
                            }
                        }
                    }

                    conn.Close();
                }

                // Rellenar Datos Repartidor

                // Consulta SQL para obtener el estado correspondiente al IdRepartidor
                string query3 = "SELECT * FROM Repartidor WHERE IdRepartidor = @idRepartidor";

                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(query3, conn))
                    {
                        cmd.Parameters.AddWithValue("@idRepartidor", idRepartidor);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Obtener los valores de los campos del estado
                                string NombreRepartidor = Convert.ToString(reader["NombreRepartidor"]);

                                // Establecer los valores
                                cbx_IdRepartidor.Text = NombreRepartidor;
                            }
                        }
                    }

                    conn.Close();
                }

                // Rellenar Datos Distribucion

                // Consulta SQL para obtener el estado correspondiente al IdRepartidor
                string query4 = "SELECT * FROM Distribucion WHERE IdDistribucion = @idDistribucion";

                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(query4, conn))
                    {
                        cmd.Parameters.AddWithValue("@idDistribucion", idDistribucion);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Obtener los valores de los campos del estado
                                string NombreDistribucion = Convert.ToString(reader["NombreDistribucio"]);

                                // Establecer los valores
                                cbx_IdDistribucion.Text = NombreDistribucion;
                            }
                        }
                    }

                    conn.Close();
                }

                // Rellenar Datos TipoPago

                // Consulta SQL para obtener el estado correspondiente al IdRepartidor
                string query5 = "SELECT * FROM TipoPago WHERE IdPago = @idPago";

                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(query5, conn))
                    {
                        cmd.Parameters.AddWithValue("@idPago", idPago);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Obtener los valores de los campos del estado
                                string NombrePago = Convert.ToString(reader["NombrePago"]);

                                // Establecer los valores
                                cbx_IdPago.Text = NombrePago;
                            }
                        }
                    }

                    conn.Close();
                }

            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            // Variables del Cliente
            int idCliente = int.Parse(tbx_IdCliente.Text);
            string nombreCliente = cbx_NombreCliente.Text;
            string direccion = tbx_Direccion.Text;
            string alias = cbx_Alias.Text;
            int celularCliente = int.Parse(cbx_CelularCliente.Text);
            string fuente = tbx_Fuente.Text;
            string rut = cbx_Rut.Text;

            // Variables de Estado
            int idEstado = int.Parse(tbx_IdEstados.Text);
            bool impreso = Chbx_Impreso.Checked;
            bool pagado = Chbx_Pagado.Checked;
            bool boleta = Chbx_Boleta.Checked;
            bool entregado = Chbx_Entregado.Checked;

            // Variables de PedidoMolde
            int idPedido = Convert.ToInt32(tbx_IdPedido.Text);
            int idRepartidor = Convert.ToInt32(cbx_IdRepartidor.SelectedValue);
            int idDistribucion = Convert.ToInt32(cbx_IdDistribucion.SelectedValue);
            int idPago = Convert.ToInt32(cbx_IdPago.SelectedValue);
            int totalMoldes = 0;
            int valorPedido = 0;
            int numeroBoleta = int.Parse(tbx_NumeroBoleta.Text);
            DateTime fecha = dateTimePicker1.Value;

            // Crear la conexión a la base de datos
            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {
                conn.Open();

                // Crear el comando SQL para modificar el Cliente
                string sql = "UPDATE Cliente SET CelularCliente = @CelularCliente, Direccion = @Direccion, Rut = @Rut, Alias = @Alias, Fuente = @Fuente WHERE NombreCliente = @NombreCliente";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    // Asignar los valores a los parámetros del comando
                    cmd.Parameters.AddWithValue("@CelularCliente", celularCliente);
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

                // Crear el comando SQL para modificar el PedidoMolde
                string sql2 = "UPDATE PedidoMolde SET IdCliente = @idCliente, IdRepartidor = @idRepartidor, IdDistribucion = @idDistribucion, IdPago = @idPago, TotalMoldes = @totalMoldes, ValorPedido = @valorPedido, NumBoletaImpresa = @numBoletaImpresa, Fecha = @fecha WHERE IdPedido = @idPedido";
                using (SQLiteCommand cmd = new SQLiteCommand(sql2, conn))
                {
                    // Asignar los valores a los parámetros del comando
                    cmd.Parameters.AddWithValue("@idPedido", idPedido);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.Parameters.AddWithValue("@idRepartidor", idRepartidor);
                    cmd.Parameters.AddWithValue("@idDistribucion", idDistribucion);
                    cmd.Parameters.AddWithValue("@idPago", idPago);
                    cmd.Parameters.AddWithValue("@totalMoldes", totalMoldes);
                    cmd.Parameters.AddWithValue("@valorPedido", valorPedido);
                    cmd.Parameters.AddWithValue("@numBoletaImpresa", numeroBoleta);
                    cmd.Parameters.AddWithValue("@fecha", fecha);

                    // Ejecutar el comando de modificación
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registro de Pedido modificado correctamente.");
                        // Aquí puedes realizar cualquier acción adicional después de la modificación exitosa.
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el registro de Pedido a modificar.");
                    }

                    
                }

                // Crear el comando SQL para modificar el Estado del Pedido
                string sql3 = "UPDATE Estado SET Impreso = @impreso, Pagado = @pagado, Boleta = @boleta, Entregado = @entregado WHERE IdEstado = @idEstado";
                using (SQLiteCommand cmd3 = new SQLiteCommand(sql3, conn))
                {
                    // Asignar los valores a los parámetros del comando
                    cmd3.Parameters.AddWithValue("@idEstado", idEstado);
                    cmd3.Parameters.AddWithValue("@impreso", impreso);
                    cmd3.Parameters.AddWithValue("@pagado", pagado);
                    cmd3.Parameters.AddWithValue("@boleta", boleta);
                    cmd3.Parameters.AddWithValue("@entregado", entregado);

                    // Ejecutar el comando de modificación
                    int rowsAffected3 = cmd3.ExecuteNonQuery();

                    if (rowsAffected3 > 0)
                    {
                        MessageBox.Show("Registro de Estado del pedido modificado correctamente.");
                        // Aquí puedes realizar cualquier acción adicional después de la modificación exitosa.
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el registro de Estado a modificar.");
                    }

                }

                conn.Close();
                AdministarPedidos_Load(sender, e);

            }
        }

        private void btn_EliminarDeGrilla_Click(object sender, EventArgs e)
        {
            DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
            int rowIndex = selectedCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            int idEstado = Convert.ToInt32(selectedRow.Cells["IdEstado"].Value);

            FuncionesEliminar.EliminarPedido(idEstado);

            AdministarPedidos_Load(sender, e);
        }

        private AdministarDetallesPedido administarDetallesPedido;

        private void btn_AdminMoldesPedido_Click(object sender, EventArgs e)
        {
            int idPedido = int.Parse(tbx_IdPedido.Text);

            if (administarDetallesPedido == null)
            {
                administarDetallesPedido = new AdministarDetallesPedido(idPedido);
                administarDetallesPedido.FormClosed += (s, args) => administarDetallesPedido = null; // Esto permite liberar la instancia cuando se cierra el formulario
            }
            administarDetallesPedido.Show();
        }
    }
}
