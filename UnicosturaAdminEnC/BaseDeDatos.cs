using System;
using System.Data.SQLite;

public class BaseDeDatos
{
    public static void BaseDatos()
    {
        // Conectar a la base de datos (se creará si no existe)
        using (SQLiteConnection conn = new SQLiteConnection("Data Source=pedidos.db;Version=3;"))
        {
            conn.Open();

            // Crear tabla Moldes
            using (SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Moldes (IdMoldes INTEGER PRIMARY KEY, NombreMoldes TEXT, NumeroMoldes INTEGER)", conn))
            {
                cmd.ExecuteNonQuery();
            }

            // Crear tabla Talla
            using (SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Talla (IdTalla INTEGER PRIMARY KEY, NombreTalla TEXT)", conn))
            {
                cmd.ExecuteNonQuery();
            }

            // Crear tabla Distribucion
            using (SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Distribucion (IdDistribucion INTEGER PRIMARY KEY, NombreDistribucio TEXT)", conn))
            {
                cmd.ExecuteNonQuery();
            }

            // Crear tabla TipoPago
            using (SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS TipoPago (IdPago INTEGER PRIMARY KEY, NombrePago TEXT)", conn))
            {
                cmd.ExecuteNonQuery();
            }

            // Crear tabla Estado
            using (SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Estado (IdEstado INTEGER PRIMARY KEY, Impreso INTEGER, Pagado INTEGER, Boleta INTEGER, Entregado INTEGER)", conn))
            {
                cmd.ExecuteNonQuery();
            }

            // Crear tabla Repartidor
            using (SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Repartidor (IdRepartidor INTEGER PRIMARY KEY, NombreRepartidor TEXT)", conn))
            {
                cmd.ExecuteNonQuery();
            }

            // Crear tabla Cliente
            using (SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Cliente (IdCliente INTEGER PRIMARY KEY, NombreCliente TEXT, CelularCliente INTEGER, Direccion TEXT, Rut TEXT, Alias TEXT, Fuente TEXT)", conn))
            {
                cmd.ExecuteNonQuery();
            }

            // Crear tabla PedidoMolde
            using (SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS PedidoMolde (IdPedido INTEGER PRIMARY KEY, IdEstado INTEGER, IdRepartidor INTEGER, IdDistribucion INTEGER, IdPago INTEGER, TotalMoldes INTEGER, ValorPedido INTEGER, NumBoletaImpresa INTEGER, Fecha TEXT, FOREIGN KEY (IdEstado) REFERENCES Estado(IdEstado), FOREIGN KEY (IdRepartidor) REFERENCES Repartidor(IdRepartidor), FOREIGN KEY (IdDistribucion) REFERENCES Distribucion(IdDistribucion), FOREIGN KEY (IdPago) REFERENCES TipoPago(IdPago))", conn))
            {
                cmd.ExecuteNonQuery();
            }

            // Crear tabla DetallePedidoMoldes
            using (SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS DetallePedidoMoldes (IdDetallePedido INTEGER PRIMARY KEY, IdPedido INTEGER, IdTalla INTEGER, CodigoMolde INTEGER, TallaMoldel TEXT, MoldeEnStock INTEGER, MoldeFallido INTEGER, FOREIGN KEY (IdPedido) REFERENCES PedidoMolde(IdPedido), FOREIGN KEY (IdTalla) REFERENCES Talla(IdTalla))", conn))
            {
                cmd.ExecuteNonQuery();
            }

            // Cerrar la conexión
            conn.Close();
        }
    }
}
