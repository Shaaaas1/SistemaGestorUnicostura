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
            string query = "SELECT NombreRepartidor FROM Repartidor";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable repartidorTable = new DataTable();
            adapter.Fill(repartidorTable);
            cbx_IdRepartidor.DataSource = repartidorTable;
            cbx_IdRepartidor.DisplayMember = "NombreRepartidor";
            connection.Close();
        }

        public void RellenarDistribucion()
        {
            connection.Open();
            string query = "SELECT NombreDistribucio FROM Distribucion";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable distribucionTable = new DataTable();
            adapter.Fill(distribucionTable);
            cbx_IdDistribucion.DataSource = distribucionTable;
            cbx_IdDistribucion.DisplayMember = "NombreDistribucio";
            connection.Close();
        }

        public void RellenarTipoPago()
        {
            connection.Open();
            string query = "SELECT NombrePago FROM TipoPago";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable tipoPagoTable = new DataTable();
            adapter.Fill(tipoPagoTable);
            cbx_IdPago.DataSource = tipoPagoTable;
            cbx_IdPago.DisplayMember = "NombrePago";
            connection.Close();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            
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
                cbx_Rut.Text = string.Empty;
                cbx_NombreCliente.Text = string.Empty;
                cbx_Alias.Text = string.Empty;
                tbx_Fuente.Text = string.Empty;
                tbx_Direccion.Text = string.Empty;
            }
        }

        private void btn_LimpiarCliente_Click(object sender, EventArgs e)
        {
            tbx_IdCliente.Text = "";
            cbx_NombreCliente.SelectedIndex = -1;
            cbx_CelularCliente.SelectedIndex = -1;
            cbx_Alias.SelectedIndex = -1;
            cbx_Rut.SelectedIndex = -1;
            tbx_Fuente.SelectedIndex = -1;
            tbx_Direccion.Text = string.Empty;
        }
    }
}
