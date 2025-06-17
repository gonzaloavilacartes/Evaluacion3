using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Trabajo3POO
{
    internal class PokemonDAL
    {
        public static void InsertarPokemon(Pokemon p)
        {
            var con = DataBaseHelper.GetConnection();
            string sql = "INSERT INTO Pokemon (Nombre, Altura, Peso, Experiencia, TipoPrincipal) VALUES (@nombre, @altura, @peso, @exp, @tipo);";
            var cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@altura", p.Altura);
            cmd.Parameters.AddWithValue("@peso", p.Peso);
            cmd.Parameters.AddWithValue("@exp", p.Experiencia);
            cmd.Parameters.AddWithValue("@tipo", p.TipoPrincipal);
            cmd.ExecuteNonQuery();
        }
        public static List<Pokemon> ObtenerPokemones(string filtro = "")
        {
            var lista = new List<Pokemon>();
            var con = DataBaseHelper.GetConnection();

            string sql = "SELECT * FROM Pokemon";
            if (!string.IsNullOrWhiteSpace(filtro))
                sql += " WHERE Nombre LIKE @filtro OR TipoPrincipal LIKE @filtro";

            var cmd = new SQLiteCommand(sql, con);

            if (!string.IsNullOrWhiteSpace(filtro))
                cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Pokemon
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString(),
                    Altura = Convert.ToInt32(reader["Altura"]),
                    Peso = Convert.ToSingle(reader["Peso"]),
                    Experiencia = Convert.ToInt32(reader["Experiencia"]),
                    TipoPrincipal = reader["TipoPrincipal"].ToString()
                });
            }

            return lista;
        }

        public static void ActualizarPokemon(Pokemon p)
        {
            var con = DataBaseHelper.GetConnection();
            string sql = "UPDATE Pokemon SET Nombre=@nombre, Altura=@altura, Peso=@peso, Experiencia=@exp, TipoPrincipal=@tipo WHERE Id=@id";
            var cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@altura", p.Altura);
            cmd.Parameters.AddWithValue("@peso", p.Peso);
            cmd.Parameters.AddWithValue("@exp", p.Experiencia);
            cmd.Parameters.AddWithValue("@tipo", p.TipoPrincipal);
            cmd.Parameters.AddWithValue("@id", p.Id);
            cmd.ExecuteNonQuery();
        }

        public static void EliminarPokemon(int id)
        {
            var con = DataBaseHelper.GetConnection();
            string sql = "DELETE FROM Pokemon WHERE Id=@id";
            var cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
