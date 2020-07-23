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
        string CriarGenero(Genero genero);
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

        public IEnumerable<Genero> ListarGenero()
        {
            var generos = new List<Genero>();

            using var connection = new SqlConnection(connectionString);
            var sp = "ListarGenero";
            var sqlCommand = new SqlCommand(sp, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                connection.Open();
                using var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
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
            return generos;
        }

        public string CriarGenero(Genero genero)
        {
            using var connection = new SqlConnection(connectionString);

            var sp = "CriarGenero";
            var insert = new SqlCommand(sp, connection);
            insert.CommandType = CommandType.StoredProcedure;

            insert.Parameters.AddWithValue("@Descricao", genero.Descricao);
            SqlParameter outputIdParam = new SqlParameter("@IdGenero", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            insert.Parameters.Add(outputIdParam);
            try
            {
                connection.Open();
                insert.ExecuteNonQuery();
                return insert.Parameters["@IdGenero"].Value.ToString();
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
            using var connection = new SqlConnection(connectionString);
            var sp = "GetGenero";
            var sqlCommand = new SqlCommand(sp, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id", id);
            try
            {
                Genero genero = null;
                connection.Open();
                using var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    if (genero == null)
                    {
                        genero = new Genero();
                        genero.Id = (int)reader["Id"];
                        genero.Descricao = reader["Descricao"].ToString();
                        genero.Filmes = new List<Filme>();
                    }
                    genero.Filmes.Add(new Filme()
                    {
                        Id = (int)reader["FilmeId"],
                        Titulo = reader["Titulo"].ToString(),
                        TituloOriginal = reader["TituloOriginal"].ToString()
                    });

                }
                return genero;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ExcluirGenero(int id)
        {
            throw new NotImplementedException();
        }
    }
}
