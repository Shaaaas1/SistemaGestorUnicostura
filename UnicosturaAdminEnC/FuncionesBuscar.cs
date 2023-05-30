using System;
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
}
