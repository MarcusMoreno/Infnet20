using InfnetMovieDataBase.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace InfnetMovieDataBase.Repository
{
    public interface IGeneroRepository
    {
        IEnumerable<Genero> ListarGenero();
        IEnumerable<Filme> ListarFilme(int id);
       void CriarGenero(Genero genero);
       void AtualizarGenero(Genero genero);
       Genero DetalharGenero(int id);
       void ExcluirGenero(int id);
    }

    public class GeneroRepository : IGeneroRepository
    {
        private readonly string connectionString;

        public GeneroRepository(IConfiguration configuration)
        {
            this.connectionString = configuration["DataBase:connection"];
        }

        public IEnumerable<Filme> ListarFilme(int id)
        {
            var filmes = new List<Filme>();

            using var connection = new SqlConnection(connectionString);
            var sp = "ListarFilmesPorGenero";
            var sqlCommand = new SqlCommand(sp, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@GeneroId", id);

            try
            {
                connection.Open();
                using var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var filme = new Filme
                    {
                        Titulo = reader["Titulo"].ToString(),
                        TituloOriginal = reader["TituloOriginal"].ToString(),
                        Ano = Convert.ToInt32( reader["Ano"])                       
                    };

                    filmes.Add(filme);
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                connection.Close();
            }

            return filmes;
        }

        public IEnumerable<Genero> ListarGenero()
        {
            var generos = new List<Genero>();

            using var connection = new SqlConnection(connectionString); 
            var cmdText = "SELECT * FROM Genero";
            var select = new SqlCommand(cmdText, connection);
            try
            {
                connection.Open();
                using var reader = select.ExecuteReader(CommandBehavior.CloseConnection);
     
                while (reader.Read())
                {
                    var genero = new Genero();
                    genero.Id = (int)reader["Id"];
                    genero.Descricao = reader["Descricao"].ToString();
                    generos.Add(genero);
                }
            }
            catch (Exception e)
            {

            }
            finally
            {

            }

            return generos;
        }

        public void CriarGenero(Genero genero)
        {
            using var connection = new SqlConnection(connectionString);

            var sp = "CriarGenero";
            var insert = new SqlCommand(sp, connection);
            insert.CommandType = CommandType.StoredProcedure;

            insert.Parameters.AddWithValue("@Descricao", genero.Descricao);
            try
            {
                connection.Open();
                insert.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AtualizarGenero(Genero genero)
        {
            using var connection = new SqlConnection(connectionString);
            using var cmd = new SqlCommand("UPDATE Genero SET Descricao = @descricao WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@descricao", genero.Descricao);
            cmd.Parameters.AddWithValue("@id", genero.Id);

            try
            {
                connection.Open();
                using var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Genero DetalharGenero(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            string sql = "SELECT * FROM Genero WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Id", id);
            Genero genero = null;
            try
            {
                connection.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            genero = new Genero();
                            genero.Id = (int)reader["Id"];
                            genero.Descricao = reader["Descricao"].ToString();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return genero;

        }

        public void ExcluirGenero(int id)
        {
            throw new NotImplementedException();
        }
    }
}
