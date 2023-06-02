﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FuncionesBuscar
{
    // Conexión a la base de datos
    private static SQLiteConnection connection = new SQLiteConnection("Data Source=pedidos.db;Version=3;");

    public static DataTable BuscarTallas(string nombreTalla)
    {
        string query = "SELECT * FROM Talla WHERE NombreTalla LIKE @NombreTalla";

        using (SQLiteConnection conn = new SQLiteConnection(connection))
        {
            conn.Open();

            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NombreTalla", "%" + nombreTalla + "%");

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dtTallas = new DataTable();
                    adapter.Fill(dtTallas);

                    return dtTallas;
                }
            }
        }
    }

    public static DataTable BuscarMolde(string nombreMolde)
    {
        string query = "SELECT * FROM Moldes WHERE NombreMoldes LIKE @NombreMoldes";

        using (SQLiteConnection conn = new SQLiteConnection(connection))
        {
            conn.Open();

            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NombreMoldes", "%" + nombreMolde + "%");

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dtMoldes = new DataTable();
                    adapter.Fill(dtMoldes);

                    return dtMoldes;
                }
            }
        }
    }

    public static DataTable BuscarTipoPago(string nombreTipoPago)
    {
        string query = "SELECT * FROM TipoPago WHERE NombrePago LIKE @NombreTipoPago";

        using (SQLiteConnection conn = new SQLiteConnection(connection))
        {
            conn.Open();

            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NombreTipoPago", "%" + nombreTipoPago + "%");

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dtTipoPago = new DataTable();
                    adapter.Fill(dtTipoPago);

                    return dtTipoPago;
                }
            }
        }
    }

    public static DataTable BuscarDistribucion(string nombreDistribucion)
    {
        string query = "SELECT * FROM Distribucion WHERE NombreDistribucio LIKE @nombreDistrubucion";

        using (SQLiteConnection conn = new SQLiteConnection(connection))
        {
            conn.Open();

            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombreDistribucion", "%" + nombreDistribucion + "%");

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dtDistribucio = new DataTable();
                    adapter.Fill(dtDistribucio);

                    return dtDistribucio;
                }
            }
        }
    }

}
