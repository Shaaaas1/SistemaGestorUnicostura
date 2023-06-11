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
        static string connectionString = "Data Source=pedidos.db;Version=3;";
        private static SQLiteConnection connection = new SQLiteConnection(connectionString);
        public AdministarPedidos()
        {
            InitializeComponent();
            connection.Open();
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

        public void RellenarCbxCliente()
        {
            string query = "SELECT NombreCliente, IdCliente FROM Cliente";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cbx_NombreCliente.DataSource = dataTable;
            cbx_NombreCliente.DisplayMember = "NombreCliente";
            cbx_NombreCliente.ValueMember = "IdCliente";
        }

        public void RellenarCbxAlias()
        {
            string query = "SELECT Alias FROM Cliente";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cbx_Alias.DataSource = dataTable;
            cbx_Alias.DisplayMember = "Alias";
        }

        public void RellenarCbxNumeroCliente()
        {
            string query = "SELECT CelularCliente FROM Cliente";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cbx_CelularCliente.DataSource = dataTable;
            cbx_CelularCliente.DisplayMember = "CelularCliente";
        }

        public void RellenarCbxRut()
        {
            string query = "SELECT Rut FROM Cliente";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cbx_Rut.DataSource = dataTable;
            cbx_Rut.DisplayMember = "Rut";
        }

        public void RellenarRepartidor()
        {
            string query = "SELECT IdRepartidor, NombreRepartidor FROM Repartidor";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable repartidorTable = new DataTable();
            adapter.Fill(repartidorTable);
            cbx_IdRepartidor.DataSource = repartidorTable;
            cbx_IdRepartidor.DisplayMember = "NombreRepartidor";
            cbx_IdRepartidor.ValueMember = "IdRepartidor";
        }

        public void RellenarDistribucion()
        {
            string query = "SELECT IdDistribucion, NombreDistribucio FROM Distribucion";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable distribucionTable = new DataTable();
            adapter.Fill(distribucionTable);
            cbx_IdDistribucion.DataSource = distribucionTable;
            cbx_IdDistribucion.DisplayMember = "NombreDistribucio";
            cbx_IdDistribucion.ValueMember = "IdDistribucion";
        }

        public void RellenarTipoPago()
        {
            string query = "SELECT IdPago, NombrePago FROM TipoPago";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable tipoPagoTable = new DataTable();
            adapter.Fill(tipoPagoTable);
            cbx_IdPago.DataSource = tipoPagoTable;
            cbx_IdPago.DisplayMember = "NombrePago";
            cbx_IdPago.ValueMember = "IdPago";
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {

            if (tbx_IdCliente.Text == "0" && cbx_NombreCliente.Text == "")
            {
                // Mostrar mensaje de error
                MessageBox.Show("El pedido Debe de Tener algun Cliente. Asignele un nombre y un numero al Cliente",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

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
            if (idCliente != 0)
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
                    connection.Open();
                    string query = "SELECT * FROM Cliente WHERE Rut = @rut";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@rut", rutSeleccionado);

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
                    connection.Open();
                    string query = "SELECT * FROM Cliente WHERE NombreCliente = @nombreCliente";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreCliente", nombreClienteSeleccionado);
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

            string filtro = Convert.ToString(cbx_NombreCliente.SelectedValue);

            // Obtener los detalles de pedido filtrados
            List<PedidoMolde> filtrados = ObtenerFiltrados1(filtro);

            // Actualizar el origen de datos del DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filtrados;

            dataGridView1.Columns["IdPedido"].DisplayIndex = 0;
            dataGridView1.Columns["IdCliente"].DisplayIndex = 1;
            dataGridView1.Columns["IdDistribucion"].DisplayIndex = 2;
            dataGridView1.Columns["IdPago"].DisplayIndex = 3;
            dataGridView1.Columns["IdRepartidor"].DisplayIndex = 4;
            dataGridView1.Columns["TotalMoldes"].DisplayIndex = 5;
            dataGridView1.Columns["ValorPedido"].DisplayIndex = 6;
            dataGridView1.Columns["NumBoletaImpresa"].DisplayIndex = 7;
            dataGridView1.Columns["Fecha"].DisplayIndex = 8;
            dataGridView1.Columns["IdEstado"].DisplayIndex = 9;

            dataGridView1.Columns[0].HeaderText = "ID Pedido";
            dataGridView1.Columns[1].HeaderText = "Cliente";
            dataGridView1.Columns[2].HeaderText = "ID Estado";
            dataGridView1.Columns[3].HeaderText = "Repartidor";
            dataGridView1.Columns[4].HeaderText = "Distribucion";
            dataGridView1.Columns[5].HeaderText = "Tipo de Pago";
            dataGridView1.Columns[6].HeaderText = "Total de Moldes";
            dataGridView1.Columns[7].HeaderText = "Valor del Pedido";
            dataGridView1.Columns[8].HeaderText = "Numero de Boleta";
            dataGridView1.Columns[9].HeaderText = "Fecha";
        }

        private void cbx_Alias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string aliasSeleccionado = cbx_Alias.Text;

            if (!string.IsNullOrEmpty(aliasSeleccionado))
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Cliente WHERE Alias = @alias";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@alias", aliasSeleccionado);
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
                    connection.Open();
                    string query = "SELECT * FROM Cliente WHERE CelularCliente = @celularCliente";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@celularCliente", celularClienteSeleccionado);
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
            tbx_IdCliente.Text = "0";
            cbx_NombreCliente.SelectedIndex = -1;
            cbx_CelularCliente.Text = "0";
            cbx_Alias.SelectedIndex = -1;
            cbx_Rut.SelectedIndex = -1;
            tbx_Fuente.SelectedIndex = -1;
            tbx_Direccion.Text = string.Empty;

            tbx_IdCliente.Text = "0";
            cbx_NombreCliente.SelectedIndex = -1;
            cbx_CelularCliente.Text = "0";
            cbx_Alias.SelectedIndex = -1;
            cbx_Rut.SelectedIndex = -1;
            tbx_Fuente.SelectedIndex = -1;
            tbx_Direccion.Text = string.Empty;
        }

        public void AdministarPedidos_Load(object sender, EventArgs e)
        {
            LimpiarDatosCliente();
            // Obtener los datos de la tabla "PedidoMolde"
            List<PedidoMolde> pedidos = ObtenerPedidos();

            // Enlazar los datos al DataGridView
            dataGridView1.DataSource = pedidos;

            dataGridView1.Columns["IdPedido"].DisplayIndex = 0;
            dataGridView1.Columns["IdCliente"].DisplayIndex = 1;
            dataGridView1.Columns["IdDistribucion"].DisplayIndex = 2;
            dataGridView1.Columns["IdPago"].DisplayIndex = 3;
            dataGridView1.Columns["IdRepartidor"].DisplayIndex = 4;
            dataGridView1.Columns["TotalMoldes"].DisplayIndex = 5;
            dataGridView1.Columns["ValorPedido"].DisplayIndex = 6;
            dataGridView1.Columns["NumBoletaImpresa"].DisplayIndex = 7;
            dataGridView1.Columns["Fecha"].DisplayIndex = 8;
            dataGridView1.Columns["IdEstado"].DisplayIndex = 9;

            dataGridView1.Columns[0].HeaderText = "ID Pedido";
            dataGridView1.Columns[1].HeaderText = "Cliente";
            dataGridView1.Columns[2].HeaderText = "ID Estado";
            dataGridView1.Columns[3].HeaderText = "Repartidor";
            dataGridView1.Columns[4].HeaderText = "Distribucion";
            dataGridView1.Columns[5].HeaderText = "Tipo de Pago";
            dataGridView1.Columns[6].HeaderText = "Total de Moldes";
            dataGridView1.Columns[7].HeaderText = "Valor del Pedido";
            dataGridView1.Columns[8].HeaderText = "Numero de Boleta";
            dataGridView1.Columns[9].HeaderText = "Fecha";
        }

        // Método para obtener los datos de la tabla "PedidoMolde"
        private List<PedidoMolde> ObtenerPedidos()
        {
            List<PedidoMolde> pedidos = new List<PedidoMolde>();

            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {

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

            if (tbx_IdCliente.Text == "0")
            {
                // Mostrar mensaje de error
                MessageBox.Show("Debe de Tener Seleccionado a un Cliente para Buscar sus pedidos",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            DataTable dtCliente = FuncionesBuscar.BuscarPedido(idCliente);

            dataGridView1.DataSource = dtCliente;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {

            if (tbx_IdPedido.Text == "")
            {
                // Mostrar mensaje de error
                MessageBox.Show("Debe de Seleccionar a un pedido para Eliminarlo, haga doble click uno de los pedidos de la grilla",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            int idEstado = int.Parse(tbx_IdPedido.Text);

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar al pedido numero" + idEstado + "?",
                                     "Confirmar eliminación",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                FuncionesEliminar.EliminarPedido(idEstado);
                AdministarPedidos_Load(sender, e);
            }
            else
            {
                return;
            }

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

                }

                // Rellenar Datos Cliente

                // Consulta SQL para obtener el estado correspondiente al IdCliente
                string query2 = "SELECT * FROM Cliente WHERE IdCliente = @idCliente";

                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {

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

                }

                // Rellenar Datos Repartidor

                // Consulta SQL para obtener el estado correspondiente al IdRepartidor
                string query3 = "SELECT * FROM Repartidor WHERE IdRepartidor = @idRepartidor";

                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {

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

                }

                // Rellenar Datos Distribucion

                // Consulta SQL para obtener el estado correspondiente al IdRepartidor
                string query4 = "SELECT * FROM Distribucion WHERE IdDistribucion = @idDistribucion";

                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {

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

                }

                // Rellenar Datos TipoPago

                // Consulta SQL para obtener el estado correspondiente al IdRepartidor
                string query5 = "SELECT * FROM TipoPago WHERE IdPago = @idPago";

                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {

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
                }

            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {

            if (tbx_IdPedido.Text == "")
            {
                // Mostrar mensaje de error
                MessageBox.Show("El pedido Debe de estar Seleccionado para Modificarlo. Seleccione uno desde la Grilla",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            if (tbx_IdCliente.Text == "0")
            {
                // Mostrar mensaje de error
                MessageBox.Show("El pedido Debe de Tener algun Cliente. Asignele un nombre y un numero al Cliente",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

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
                AdministarPedidos_Load(sender, e);

            }
        }

        private void btn_EliminarDeGrilla_Click(object sender, EventArgs e)
        {
            DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
            int rowIndex = selectedCell.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            int idEstado = Convert.ToInt32(selectedRow.Cells["IdPedido"].Value);

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar al pedido numero" + idEstado + "?",
                         "Confirmar eliminación",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                FuncionesEliminar.EliminarPedido(idEstado);
                AdministarPedidos_Load(sender, e);
            }
            else
            {
                return;
            }
        }

        private AdministarDetallesPedido administarDetallesPedido;

        private void btn_AdminMoldesPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_IdPedido.Text))
            {
                // Mostrar mensaje de error
                MessageBox.Show("No tiene ningun pedido Seleccionado, Haga Doble Click en el Pedido en la Grilla que desea Administar.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Cancelar la ejecución de la función
            }

            int idPedido = int.Parse(tbx_IdPedido.Text);

            if (administarDetallesPedido == null)
            {
                administarDetallesPedido = new AdministarDetallesPedido(idPedido, this);
                administarDetallesPedido.FormClosed += (s, args) => administarDetallesPedido = null; // Esto permite liberar la instancia cuando se cierra el formulario
            }
            administarDetallesPedido.Show();
            this.Close();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["IdDistribucion"].Index)
            {
                int idDistribucion = Convert.ToInt32(e.Value);
                string nombreDistribucion = ObtenerNombreDistribucion(idDistribucion);
                e.Value = nombreDistribucion;
            }
            else if (e.ColumnIndex == dataGridView1.Columns["IdPago"].Index)
            {
                int idPago = Convert.ToInt32(e.Value);
                string nombrePago = ObtenerNombrePago(idPago);
                e.Value = nombrePago;
            }
            else if (e.ColumnIndex == dataGridView1.Columns["IdCliente"].Index)
            {
                int idCliente = Convert.ToInt32(e.Value);
                string nombreCliente = ObtenerNombreCliente(idCliente);
                e.Value = nombreCliente;
            }
            else if (e.ColumnIndex == dataGridView1.Columns["IdRepartidor"].Index)
            {
                int idRepartidor = Convert.ToInt32(e.Value);
                string nombreRepartidor = ObtenerNombreRepartidor(idRepartidor);
                e.Value = nombreRepartidor;
            }
        }

        private string ObtenerNombreDistribucion(int idDistribucion)
        {
            string nombreDistribucion = string.Empty;

            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT NombreDistribucio FROM Distribucion WHERE IdDistribucion = @IdDistribucion", conn))
                {
                    cmd.Parameters.AddWithValue("@IdDistribucion", idDistribucion);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nombreDistribucion = reader["NombreDistribucio"].ToString();
                        }
                    }
                }

            }

            return nombreDistribucion;
        }

        private string ObtenerNombrePago(int idPago)
        {
            string nombrePago = string.Empty;

            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT NombrePago FROM TipoPago WHERE IdPago = @IdPago", conn))
                {
                    cmd.Parameters.AddWithValue("@IdPago", idPago);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nombrePago = reader["NombrePago"].ToString();
                        }
                    }
                }

            }

            return nombrePago;
        }

        private string ObtenerNombreCliente(int idCliente)
        {
            string nombreBoleta = string.Empty;

            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT NombreCliente FROM Cliente WHERE IdCliente = @IdCliente", conn))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nombreBoleta = reader["NombreCliente"].ToString();
                        }
                    }
                }

            }

            return nombreBoleta;
        }

        private string ObtenerNombreRepartidor(int idRepartidor)
        {
            string nombreRepartidor = string.Empty;

            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT NombreRepartidor FROM Repartidor WHERE IdRepartidor = @IdRepartidor", conn))
                {
                    cmd.Parameters.AddWithValue("@IdRepartidor", idRepartidor);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nombreRepartidor = reader["NombreRepartidor"].ToString();
                        }
                    }
                }

            }

            return nombreRepartidor;
        }

        private void cbx_Rut_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar que solo se admitan números, guion y la letra 'K' (mayúscula o minúscula)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && !(char.ToUpper(e.KeyChar) == 'K') && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            // Convertir una 'k' minúscula ingresada a mayúscula
            if (char.ToLower(e.KeyChar) == 'k')
            {
                e.KeyChar = 'K';
            }

            // Verificar si el guion ya está presente en el texto
            bool guionPresente = cbx_Rut.Text.Contains("-");

            // Validar el máximo de 8 dígitos antes del guion
            if (!guionPresente && char.IsDigit(e.KeyChar) && cbx_Rut.Text.Length >= 8)
            {
                e.Handled = true;
                return;
            }

            // Validar el máximo de 1 dígito o letra después del guion
            if (guionPresente && cbx_Rut.Text.Substring(cbx_Rut.Text.IndexOf("-")).Length >= 2 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            // Agregar el número o letra ingresada
            if ((char.IsDigit(e.KeyChar) && !guionPresente) || char.ToUpper(e.KeyChar) == 'K')
            {
                cbx_Rut.Text += e.KeyChar;
                e.Handled = true; // Evitar que se ingrese el carácter directamente en el textbox
            }

            // Mover el cursor al final del texto
            cbx_Rut.SelectionStart = cbx_Rut.Text.Length;

            // Formatear el Rut según la estructura especificada
            if (e.KeyChar == '-')
            {
                FormatearRut();
                e.Handled = true; // Evitar que se ingrese el guion directamente en el textbox
            }
            else if (e.KeyChar == (char)Keys.Back) // Borrar
            {
                if (cbx_Rut.Text.EndsWith("-"))
                {
                    cbx_Rut.Text = cbx_Rut.Text.Replace(".", "");
                    cbx_Rut.Text = cbx_Rut.Text.Substring(0, cbx_Rut.Text.Length - 1);
                }
                else if (cbx_Rut.Text.Length > 0)
                {
                    cbx_Rut.Text = cbx_Rut.Text.Remove(cbx_Rut.Text.Length - 1);
                }

                // Mover el cursor al final del texto después de borrar
                cbx_Rut.SelectionStart = cbx_Rut.Text.Length;

                e.Handled = true; // Evitar que se ejecute el comportamiento predeterminado del retroceso
            }
        }

        private void FormatearRut()
        {
            string rut = cbx_Rut.Text.Replace(".", "").Replace("-", "");

            if (rut.Length == 7)
            {
                rut = $"{rut.Substring(0, 1)}.{rut.Substring(1, 3)}.{rut.Substring(4, 3)}-";
            }
            else if (rut.Length == 8)
            {
                rut = $"{rut.Substring(0, 2)}.{rut.Substring(2, 3)}.{rut.Substring(5, 3)}-";
            }

            cbx_Rut.Text = rut;

            // Mover el cursor al final del texto después de formatear
            cbx_Rut.SelectionStart = cbx_Rut.Text.Length;
        }

        private void AdministarPedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private List<PedidoMolde> ObtenerFiltrados1(string filtro1)
        {
            List<PedidoMolde> ListaBD = ObtenerPedidos();
            List<PedidoMolde> filtrados = new List<PedidoMolde>();

            if (int.TryParse(filtro1, out int idTalla))
            {
                foreach (PedidoMolde detalle in ListaBD)
                {
                    if (detalle.IdCliente == idTalla)
                    {
                        filtrados.Add(detalle);
                    }
                }
            }

            return filtrados;
        }

        private void cbx_IdDistribucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = Convert.ToString(cbx_IdDistribucion.SelectedValue);

            // Obtener los detalles de pedido filtrados
            List<PedidoMolde> filtrados = ObtenerFiltrados2(filtro);

            // Actualizar el origen de datos del DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filtrados;

            dataGridView1.Columns["IdPedido"].DisplayIndex = 0;
            dataGridView1.Columns["IdCliente"].DisplayIndex = 1;
            dataGridView1.Columns["IdDistribucion"].DisplayIndex = 2;
            dataGridView1.Columns["IdPago"].DisplayIndex = 3;
            dataGridView1.Columns["IdRepartidor"].DisplayIndex = 4;
            dataGridView1.Columns["TotalMoldes"].DisplayIndex = 5;
            dataGridView1.Columns["ValorPedido"].DisplayIndex = 6;
            dataGridView1.Columns["NumBoletaImpresa"].DisplayIndex = 7;
            dataGridView1.Columns["Fecha"].DisplayIndex = 8;
            dataGridView1.Columns["IdEstado"].DisplayIndex = 9;

            dataGridView1.Columns[0].HeaderText = "ID Pedido";
            dataGridView1.Columns[1].HeaderText = "Cliente";
            dataGridView1.Columns[2].HeaderText = "ID Estado";
            dataGridView1.Columns[3].HeaderText = "Repartidor";
            dataGridView1.Columns[4].HeaderText = "Distribucion";
            dataGridView1.Columns[5].HeaderText = "Tipo de Pago";
            dataGridView1.Columns[6].HeaderText = "Total de Moldes";
            dataGridView1.Columns[7].HeaderText = "Valor del Pedido";
            dataGridView1.Columns[8].HeaderText = "Numero de Boleta";
            dataGridView1.Columns[9].HeaderText = "Fecha";
        }

        private List<PedidoMolde> ObtenerFiltrados2(string filtro1)
        {
            List<PedidoMolde> ListaBD = ObtenerPedidos();
            List<PedidoMolde> filtrados = new List<PedidoMolde>();

            if (int.TryParse(filtro1, out int idTalla))
            {
                foreach (PedidoMolde detalle in ListaBD)
                {
                    if (detalle.IdDistribucion == idTalla)
                    {
                        filtrados.Add(detalle);
                    }
                }
            }

            return filtrados;
        }

        private void cbx_IdPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = Convert.ToString(cbx_IdPago.SelectedValue);

            // Obtener los detalles de pedido filtrados
            List<PedidoMolde> filtrados = ObtenerFiltrados3(filtro);

            // Actualizar el origen de datos del DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filtrados;

            dataGridView1.Columns["IdPedido"].DisplayIndex = 0;
            dataGridView1.Columns["IdCliente"].DisplayIndex = 1;
            dataGridView1.Columns["IdDistribucion"].DisplayIndex = 2;
            dataGridView1.Columns["IdPago"].DisplayIndex = 3;
            dataGridView1.Columns["IdRepartidor"].DisplayIndex = 4;
            dataGridView1.Columns["TotalMoldes"].DisplayIndex = 5;
            dataGridView1.Columns["ValorPedido"].DisplayIndex = 6;
            dataGridView1.Columns["NumBoletaImpresa"].DisplayIndex = 7;
            dataGridView1.Columns["Fecha"].DisplayIndex = 8;
            dataGridView1.Columns["IdEstado"].DisplayIndex = 9;

            dataGridView1.Columns[0].HeaderText = "ID Pedido";
            dataGridView1.Columns[1].HeaderText = "Cliente";
            dataGridView1.Columns[2].HeaderText = "ID Estado";
            dataGridView1.Columns[3].HeaderText = "Repartidor";
            dataGridView1.Columns[4].HeaderText = "Distribucion";
            dataGridView1.Columns[5].HeaderText = "Tipo de Pago";
            dataGridView1.Columns[6].HeaderText = "Total de Moldes";
            dataGridView1.Columns[7].HeaderText = "Valor del Pedido";
            dataGridView1.Columns[8].HeaderText = "Numero de Boleta";
            dataGridView1.Columns[9].HeaderText = "Fecha";
        }

        private List<PedidoMolde> ObtenerFiltrados3(string filtro1)
        {
            List<PedidoMolde> ListaBD = ObtenerPedidos();
            List<PedidoMolde> filtrados = new List<PedidoMolde>();

            if (int.TryParse(filtro1, out int idTalla))
            {
                foreach (PedidoMolde detalle in ListaBD)
                {
                    if (detalle.IdPago == idTalla)
                    {
                        filtrados.Add(detalle);
                    }
                }
            }

            return filtrados;
        }

        private void cbx_IdRepartidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = Convert.ToString(cbx_IdRepartidor.SelectedValue);

            // Obtener los detalles de pedido filtrados
            List<PedidoMolde> filtrados = ObtenerFiltrados4(filtro);

            // Actualizar el origen de datos del DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filtrados;

            dataGridView1.Columns["IdPedido"].DisplayIndex = 0;
            dataGridView1.Columns["IdCliente"].DisplayIndex = 1;
            dataGridView1.Columns["IdDistribucion"].DisplayIndex = 2;
            dataGridView1.Columns["IdPago"].DisplayIndex = 3;
            dataGridView1.Columns["IdRepartidor"].DisplayIndex = 4;
            dataGridView1.Columns["TotalMoldes"].DisplayIndex = 5;
            dataGridView1.Columns["ValorPedido"].DisplayIndex = 6;
            dataGridView1.Columns["NumBoletaImpresa"].DisplayIndex = 7;
            dataGridView1.Columns["Fecha"].DisplayIndex = 8;
            dataGridView1.Columns["IdEstado"].DisplayIndex = 9;

            dataGridView1.Columns[0].HeaderText = "ID Pedido";
            dataGridView1.Columns[1].HeaderText = "Cliente";
            dataGridView1.Columns[2].HeaderText = "ID Estado";
            dataGridView1.Columns[3].HeaderText = "Repartidor";
            dataGridView1.Columns[4].HeaderText = "Distribucion";
            dataGridView1.Columns[5].HeaderText = "Tipo de Pago";
            dataGridView1.Columns[6].HeaderText = "Total de Moldes";
            dataGridView1.Columns[7].HeaderText = "Valor del Pedido";
            dataGridView1.Columns[8].HeaderText = "Numero de Boleta";
            dataGridView1.Columns[9].HeaderText = "Fecha";
        }

        private List<PedidoMolde> ObtenerFiltrados4(string filtro1)
        {
            List<PedidoMolde> ListaBD = ObtenerPedidos();
            List<PedidoMolde> filtrados = new List<PedidoMolde>();

            if (int.TryParse(filtro1, out int idTalla))
            {
                foreach (PedidoMolde detalle in ListaBD)
                {
                    if (detalle.IdRepartidor == idTalla)
                    {
                        filtrados.Add(detalle);
                    }
                }
            }

            return filtrados;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime filtro = dateTimePicker1.Value.Date;

            // Obtener los detalles de pedido filtrados
            List<PedidoMolde> filtrados = ObtenerFiltrados5(filtro);

            // Actualizar el origen de datos del DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filtrados;

            dataGridView1.Columns["IdPedido"].DisplayIndex = 0;
            dataGridView1.Columns["IdCliente"].DisplayIndex = 1;
            dataGridView1.Columns["IdDistribucion"].DisplayIndex = 2;
            dataGridView1.Columns["IdPago"].DisplayIndex = 3;
            dataGridView1.Columns["IdRepartidor"].DisplayIndex = 4;
            dataGridView1.Columns["TotalMoldes"].DisplayIndex = 5;
            dataGridView1.Columns["ValorPedido"].DisplayIndex = 6;
            dataGridView1.Columns["NumBoletaImpresa"].DisplayIndex = 7;
            dataGridView1.Columns["Fecha"].DisplayIndex = 8;
            dataGridView1.Columns["IdEstado"].DisplayIndex = 9;

            dataGridView1.Columns[0].HeaderText = "ID Pedido";
            dataGridView1.Columns[1].HeaderText = "Cliente";
            dataGridView1.Columns[2].HeaderText = "ID Estado";
            dataGridView1.Columns[3].HeaderText = "Repartidor";
            dataGridView1.Columns[4].HeaderText = "Distribucion";
            dataGridView1.Columns[5].HeaderText = "Tipo de Pago";
            dataGridView1.Columns[6].HeaderText = "Total de Moldes";
            dataGridView1.Columns[7].HeaderText = "Valor del Pedido";
            dataGridView1.Columns[8].HeaderText = "Numero de Boleta";
            dataGridView1.Columns[9].HeaderText = "Fecha";
        }

        private List<PedidoMolde> ObtenerFiltrados5(DateTime filtro)
        {
            List<PedidoMolde> ListaBD = ObtenerPedidos();
            List<PedidoMolde> filtrados = new List<PedidoMolde>();

            foreach (PedidoMolde detalle in ListaBD)
            {
                if (detalle.Fecha.Date == filtro)
                {
                    filtrados.Add(detalle);
                }
            }

            return filtrados;
        }

    }
    
}
