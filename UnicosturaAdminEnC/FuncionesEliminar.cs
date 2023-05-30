﻿using System;
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

}
