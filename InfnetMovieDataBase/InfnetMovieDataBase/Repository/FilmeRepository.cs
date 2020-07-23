using InfnetMovieDataBase.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace InfnetMovieDataBase.Repository
{
    public  interface IFilmeRepository
    {
        IEnumerable<Filme> ListarFilmes();
        string CriarFilme(Filme filme);
       void AtualizarFilme(Filme filme);
        Filme DetalharFilme(int id);
        void ExcluirFilme(int id);
    }

    public class FilmeRepository : IFilmeRepository
    {
        private readonly string connectionString;

        public FilmeRepository(IConfiguration configuration)
        {
            this.connectionString = configuration["DataBase:connection"];
        }
    
        public IEnumerable<Filme> ListarFilmes()
        {
            var filmes = new List<Filme>();

            using var connection = new SqlConnection(connectionString);
            var sp = "ListarFilme";
            var sqlCommand = new SqlCommand(sp, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
               
                connection.Open();
                using var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    //Enquanto for possível ler de reader significa que ainda temos Filmes armazenados no banco
                    var filme = new Filme();
                    filme.Id = (int)reader["Id"]; 
                    filme.Titulo = reader["Titulo"].ToString();
                    filme.TituloOriginal = reader["TituloOriginal"].ToString();
                    filmes.Add(filme);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
          
            return filmes;
        }

        //Criar filmes
        public string CriarFilme(Filme filme)
        {
            using var connection = new SqlConnection(connectionString);

            //Usando Stored Procedure:
            var sp = "CriarFilme";
            var insert = new SqlCommand(sp, connection);
            insert.CommandType = CommandType.StoredProcedure;
            
            insert.Parameters.AddWithValue("@Titulo", filme.Titulo);
            insert.Parameters.AddWithValue("@TituloOriginal", filme.TituloOriginal);
            SqlParameter outputIdParam = new SqlParameter("@IDFilme", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            insert.Parameters.Add(outputIdParam);
            try
            {

                connection.Open();
                insert.ExecuteNonQuery();
                return insert.Parameters["@IDFilme"].Value.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AtualizarFilme(Filme filme)
        {
            using var connection = new SqlConnection(connectionString);
            using var cmd = new SqlCommand("UPDATE Filme SET Titulo = @titulo, TituloOriginal = @tituloOriginal WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@titulo", filme.Titulo);
            cmd.Parameters.AddWithValue("@tituloOriginal", filme.TituloOriginal);
            cmd.Parameters.AddWithValue("@id", filme.Id);
            
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

        public Filme DetalharFilme(int id)
        {
            using var connection = new SqlConnection(connectionString);
            var sp = "GetFilme";
            var sqlCommand = new SqlCommand(sp, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id", id);

            try
            {
                connection.Open();
                using var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var filme = new Filme();
                    filme.Id = (int)reader["Id"];
                    filme.Titulo = reader["Titulo"].ToString();
                    filme.TituloOriginal = reader["TituloOriginal"].ToString();

                    filme.Atores = new List<Ator>();
                    filme.Atores.Add(new Ator()
                    {
                        Id = (int)reader["AtorId"],
                        Nome = reader["Nome"].ToString(),
                        Sobrenome = reader["Sobrenome"].ToString()
                    });
                    return filme;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return null;
        }

        public void ExcluirFilme(int id)
        {
            using var connection = new SqlConnection(connectionString); // Dá close e dispose
            using var cmd = new SqlCommand("DELETE  FROM Filme WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                //Abrir a conexão
                connection.Open();
                using var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                // A conexão está aberta; O comando SQL foi executado
                reader.Read();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

            }

        }
    }
}
