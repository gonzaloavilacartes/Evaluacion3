using System.Data.SQLite;
using System.IO;

namespace Trabajo3POO
{
    internal class DataBaseHelper
    {
        private const string dbFile = "pokemon.db";
        private const string connectionString = "Data Source=pokemon.db;Version=3;";

        public static void CrearBaseDatos()
        {
            if (!File.Exists(dbFile))
            {
                SQLiteConnection.CreateFile(dbFile);
                var con = new SQLiteConnection(connectionString);
                con.Open();

                string sql = @"
                CREATE TABLE Pokemon (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Altura INTEGER NOT NULL,
                    Peso REAL NOT NULL,
                    Experiencia INTEGER NOT NULL,
                    TipoPrincipal TEXT NOT NULL
                );";

                var cmd = new SQLiteCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
        }

        public static SQLiteConnection GetConnection()
        {
            var con = new SQLiteConnection(connectionString);
            con.Open();
            return con;
        }
    }
}
