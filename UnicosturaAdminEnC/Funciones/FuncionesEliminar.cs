using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FuncionesEliminar
{
    // Conexión a la base de datos
    private static SQLiteConnection connection = new SQLiteConnection("Data Source=pedidos.db;Version=3;");

    public static void EliminarTalla(string nombreTalla)
    {
        using (SQLiteConnection conn = new SQLiteConnection("Data Source=pedidos.db;Version=3;"))
        {
            conn.Open();

            string query = "DELETE FROM Talla WHERE NombreTalla = @nombreTalla";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombreTalla", nombreTalla);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }

    public static void EliminarMolde(string nombreMoldes)
    {
        using (SQLiteConnection conn = new SQLiteConnection("Data Source=pedidos.db;Version=3;"))
        {
            conn.Open();

            string query = "DELETE FROM Moldes WHERE NombreMoldes = @nombreMoldes";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombreMoldes", nombreMoldes);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }

    public static void EliminarTipoPago(string nombreTipoPago)
    {
        using (SQLiteConnection conn = new SQLiteConnection("Data Source=pedidos.db;Version=3;"))
        {
            conn.Open();

            string query = "DELETE FROM TipoPago WHERE NombrePago = @nombreTipoPago";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombreTipoPago", nombreTipoPago);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }

    public static void EliminarDistribucion(string nombreDistribucion)
    {
        using (SQLiteConnection conn = new SQLiteConnection("Data Source=pedidos.db;Version=3;"))
        {
            conn.Open();

            string query = "DELETE FROM Distribucion WHERE NombreDistribucio = @nombreDistribucion";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombreDistribucion", nombreDistribucion);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }

    public static void EliminarRepartidor(string nombreRepartidor)
    {
        using (SQLiteConnection conn = new SQLiteConnection("Data Source=pedidos.db;Version=3;"))
        {
            conn.Open();

            string query = "DELETE FROM Repartidor WHERE NombreRepartidor = @nombreRepartidor";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombreRepartidor", nombreRepartidor);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }

    public static void EliminarCliente(string nombreCliente)
    {
        using (SQLiteConnection conn = new SQLiteConnection(connection))
        {
            conn.Open();

            string query = "DELETE FROM Cliente WHERE NombreCliente = @nombreCliente";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombreCliente", nombreCliente);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }

    public static void EliminarPedido(int idPedido)
    {
        using (SQLiteConnection conn = new SQLiteConnection(connection))
        {
            conn.Open();

            // Eliminar el PedidoMolde
            string deletePedidoQuery = "DELETE FROM PedidoMolde WHERE IdPedido = @idPedido";
            using (SQLiteCommand deletePedidoCmd = new SQLiteCommand(deletePedidoQuery, conn))
            {
                deletePedidoCmd.Parameters.AddWithValue("@idPedido", idPedido);
                deletePedidoCmd.ExecuteNonQuery();
            }

            // Eliminar el Estado asociado al Pedido eliminado
            string deleteEstadoQuery = "DELETE FROM Estado WHERE IdEstado = @idEstado";
            using (SQLiteCommand deleteEstadoCmd = new SQLiteCommand(deleteEstadoQuery, conn))
            {
                // Obtener el IdEstado del Pedido eliminado
                string getIdEstadoQuery = "SELECT IdEstado FROM PedidoMolde WHERE IdPedido = @idPedido";
                using (SQLiteCommand getIdEstadoCmd = new SQLiteCommand(getIdEstadoQuery, conn))
                {
                    getIdEstadoCmd.Parameters.AddWithValue("@idPedido", idPedido);
                    int idEstado = Convert.ToInt32(getIdEstadoCmd.ExecuteScalar());

                    deleteEstadoCmd.Parameters.AddWithValue("@idEstado", idEstado);
                    deleteEstadoCmd.ExecuteNonQuery();
                }
            }

            conn.Close();
        }

    }

    public static void EliminarDetallePedido(int idDetallePedido)
    {
        using (SQLiteConnection conn = new SQLiteConnection(connection))
        {
            conn.Open();

            string query = "DELETE FROM DetallePedidoMoldes WHERE IdDetallePedido = @idDetallePedido";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idDetallePedido", idDetallePedido);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }

}
