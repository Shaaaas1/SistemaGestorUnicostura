using System;
using System.Data.SQLite;
using UnicosturaAdminEnC;

public class FuncionesAgregar
{
    // Conexión a la base de datos
    private static SQLiteConnection connection = new SQLiteConnection("Data Source=pedidos.db;Version=3;");

    // Función para agregar un objeto Moldes a la base de datos
    public static void AgregarMolde(string nombre, int numero)
    {
        string query = "INSERT INTO Moldes (NombreMoldes, NumeroMoldes) VALUES (@nombre, @numero)";

        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        {
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@numero", numero);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    // Función para agregar un objeto Talla a la base de datos
    public static void AgregarTalla(string nombre)
    {
        string query = "INSERT INTO Talla (NombreTalla) VALUES (@nombre)";

        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        {
            command.Parameters.AddWithValue("@nombre", nombre);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    // Función para agregar un objeto Distribucion a la base de datos
    public static void AgregarDistribucion(string nombreDistribucion)
    {
        string query = "INSERT INTO Distribucion (NombreDistribucio) VALUES (@nombreDistribucion)";

        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        {
            command.Parameters.AddWithValue("@nombreDistribucion", nombreDistribucion);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    // Función para agregar un objeto TipoPago a la base de datos
    public static void AgregarTipoPago(string nombre)
    {
        string query = "INSERT INTO TipoPago (NombrePago) VALUES (@nombre)";

        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        {
            command.Parameters.AddWithValue("@nombre", nombre);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    // Función para agregar un objeto Estado a la base de datos
    public static void AgregarEstado(bool impreso, bool pagado, bool boleta, bool entregado)
    {
        string query = "INSERT INTO Estado (Impreso, Pagado, Boleta, Entregado) VALUES (@impreso, @pagado, @boleta, @entregado)";

        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        {
            command.Parameters.AddWithValue("@impreso", impreso);
            command.Parameters.AddWithValue("@pagado", pagado);
            command.Parameters.AddWithValue("@boleta", boleta);
            command.Parameters.AddWithValue("@entregado", entregado);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    // Función para agregar un objeto Repartidor a la base de datos
    public static void AgregarRepartidor(string nombre)
    {
        string query = "INSERT INTO Repartidor (NombreRepartidor) VALUES (@nombre)";

        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        {
            command.Parameters.AddWithValue("@nombre", nombre);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    // Función para agregar un objeto Cliente a la base de datos
    public static void AgregarCliente(string nombre, int celular, string direccion, string rut, string alias, string fuente)
    {
        string query = "INSERT INTO Cliente (NombreCliente, CelularCliente, Direccion, Rut, Alias, Fuente) VALUES (@nombre, @celular, @direccion, @rut, @alias, @fuente)";

        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        {
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@celular", celular);
            command.Parameters.AddWithValue("@direccion", direccion);
            command.Parameters.AddWithValue("@rut", rut);
            command.Parameters.AddWithValue("@alias", alias);
            command.Parameters.AddWithValue("@fuente", fuente);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    // Función para agregar un objeto PedidoMolde a la base de datos
    public static void AgregarPedidoMolde(int idEstado, int idRepartidor, int idDistribucion, int idPago, int totalMoldes, int valorPedido, int numBoletaImpresa, DateTime fecha)
    {
        string query = "INSERT INTO PedidoMolde (IdEstado, IdRepartidor, IdDistribucion, IdPago, TotalMoldes, ValorPedido, NumBoletaImpresa, Fecha) VALUES (@idEstado, @idRepartidor, @idDistribucion, @idPago, @totalMoldes, @valorPedido, @numBoletaImpresa, @fecha)";

        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        {
            command.Parameters.AddWithValue("@idEstado", idEstado);
            command.Parameters.AddWithValue("@idRepartidor", idRepartidor);
            command.Parameters.AddWithValue("@idDistribucion", idDistribucion);
            command.Parameters.AddWithValue("@idPago", idPago);
            command.Parameters.AddWithValue("@totalMoldes", totalMoldes);
            command.Parameters.AddWithValue("@valorPedido", valorPedido);
            command.Parameters.AddWithValue("@numBoletaImpresa", numBoletaImpresa);
            command.Parameters.AddWithValue("@fecha", fecha);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    // Función para agregar un objeto DetallePedidoMoldes a la base de datos
    public static void AgregarDetallePedidoMoldes(int idPedido, int idTalla, int codigoMolde, string tallaMolde, bool moldeEnStock, bool moldeFallido)
    {
        string query = "INSERT INTO DetallePedidoMoldes (IdPedido, IdTalla, CodigoMolde, TallaMolde, MoldeEnStock, MoldeFallido) VALUES (@idPedido, @idTalla, @codigoMolde, @tallaMolde, @moldeEnStock, @moldeFallido)";

        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        {
            command.Parameters.AddWithValue("@idPedido", idPedido);
            command.Parameters.AddWithValue("@idTalla", idTalla);
            command.Parameters.AddWithValue("@codigoMolde", codigoMolde);
            command.Parameters.AddWithValue("@tallaMolde", tallaMolde);
            command.Parameters.AddWithValue("@moldeEnStock", moldeEnStock);
            command.Parameters.AddWithValue("@moldeFallido", moldeFallido);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public static void PruebaCreacion()
    {
        // Crear las tablas en la base de datos
        CrearTablas();

        // Ejemplos de uso de las funciones de agregar objetos
        AgregarMolde("Molde 1", 1);
        AgregarTalla("Talla 1");
        AgregarDistribucion("Distribución 1");
        AgregarTipoPago("Pago 1");
        AgregarEstado(true, true, false, false);
        AgregarRepartidor("Repartidor 1");
        AgregarCliente("Cliente 1", 123456789, "Dirección 1", "RUT 1", "Alias 1", "Fuente 1");
        AgregarPedidoMolde(1, 1, 1, 1, 10, 100, 12345, DateTime.Now);
        AgregarDetallePedidoMoldes(1, 1, 1, "Talla M", true, false);
    }

    // Función para crear las tablas en la base de datos
    private static void CrearTablas()
    {
        string[] queries = {
            "CREATE TABLE IF NOT EXISTS Moldes (IdMoldes INTEGER PRIMARY KEY, NombreMoldes TEXT, NumeroMoldes INTEGER)",
            "CREATE TABLE IF NOT EXISTS Talla (IdTalla INTEGER PRIMARY KEY, NombreTalla TEXT)",
            "CREATE TABLE IF NOT EXISTS Distribucion (IdDistribucion INTEGER PRIMARY KEY, NombreDistribucion TEXT)",
            "CREATE TABLE IF NOT EXISTS TipoPago (IdPago INTEGER PRIMARY KEY, NombrePago TEXT)",
            "CREATE TABLE IF NOT EXISTS Estado (IdEstado INTEGER PRIMARY KEY, Impreso INTEGER, Pagado INTEGER, Boleta INTEGER, Entregado INTEGER)",
            "CREATE TABLE IF NOT EXISTS Repartidor (IdRepartidor INTEGER PRIMARY KEY, NombreRepartidor TEXT)",
            "CREATE TABLE IF NOT EXISTS Cliente (IdCliente INTEGER PRIMARY KEY, NombreCliente TEXT, CelularCliente INTEGER, Direccion TEXT, Rut TEXT, Alias TEXT, Fuente TEXT)",
            "CREATE TABLE IF NOT EXISTS PedidoMolde (IdPedido INTEGER PRIMARY KEY, IdEstado INTEGER, IdRepartidor INTEGER, IdDistribucion INTEGER, IdPago INTEGER, TotalMoldes INTEGER, ValorPedido INTEGER, NumBoletaImpresa INTEGER, Fecha TEXT)",
            "CREATE TABLE IF NOT EXISTS DetallePedidoMoldes (IdDetallePedido INTEGER PRIMARY KEY, IdPedido INTEGER, IdTalla INTEGER, CodigoMolde INTEGER, TallaMolde TEXT, MoldeEnStock INTEGER, MoldeFallido INTEGER)"
        };

        connection.Open();

        foreach (string query in queries)
        {
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        connection.Close();
    }
}

