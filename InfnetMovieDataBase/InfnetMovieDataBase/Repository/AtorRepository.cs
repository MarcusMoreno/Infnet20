using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InfnetMovieDataBase.Domain;
using Microsoft.Extensions.Configuration;

namespace InfnetMovieDataBase.Repository
{
    public interface IAtorRepository
    {
        IEnumerable<Ator> ListarAtores();
        string CriarAtor(Ator ator);
        void AtualizarAtor(Ator ator);
        Ator DetalharAtor(int id);
        void ExcluirAtor(int id);
    }

    public class AtorRepository : IAtorRepository
    {
        private readonly string connectionString;

        public AtorRepository(IConfiguration configuration)
        {
            this.connectionString = configuration["DataBase:connection"];
        }
        

        public string CriarAtor(Ator ator)
        {
            using var connection = new SqlConnection(connectionString);

            //Usando Stored Procedure:
            var sp = "CriarAtor";
            var insert = new SqlCommand(sp, connection);
            insert.CommandType = CommandType.StoredProcedure;

            insert.Parameters.AddWithValue("@Nome", ator.Nome);
            insert.Parameters.AddWithValue("@Sobrenome", ator.Sobrenome);
            SqlParameter outputIdParam = new SqlParameter("@IdAtor", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            insert.Parameters.Add(outputIdParam);
            try
            {
                connection.Open();
                insert.ExecuteNonQuery();
                return insert.Parameters["@IdAtor"].Value.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Atualizar
        public void AtualizarAtor(Ator ator)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            string cmdText = "UPDATE Ator SET Nome=@Nome, Sobrenome=@Sobrenome WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@Id", ator.Id);
            cmd.Parameters.AddWithValue("@Nome", ator.Nome);
            cmd.Parameters.AddWithValue("@Sobrenome", ator.Sobrenome);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        //Detalhar
        public Ator DetalharAtor(int id)
        {
            using var connection = new SqlConnection(connectionString);
            var sp = "GetAtor";
            var sqlCommand = new SqlCommand(sp, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id", id);

            try
            {
                Ator ator = null;
                connection.Open();
                using var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);           
                while (reader.Read())
                {
                    if (ator == null)
                    {
                        ator = new Ator();
                        ator.Id = (int)reader["Id"];
                        ator.Nome = reader["Nome"].ToString();
                        ator.Sobrenome = reader["Sobrenome"].ToString();
                        ator.Filmes = new List<Filme>();
                    }
                    if (!string.IsNullOrEmpty(reader["FilmeId"].ToString()))
                    {
                        ator.Filmes.Add(new Filme()
                        {
                            Id = (int)reader["FilmeId"],
                            Titulo = reader["Titulo"].ToString(),
                            TituloOriginal = reader["TituloOriginal"].ToString()
                        });
                    }
                }
                return ator;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ExcluirAtor(int id)
        {
            using var connection = new SqlConnection(connectionString);
            var sp = "DeleteAtor";
            var sqlCommand = new SqlCommand(sp, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id", id);

            try
            {
                connection.Open();
                using var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                reader.Read();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Ator> ListarAtores()
        {
            var elenco = new List<Ator>();

            using var connection = new SqlConnection(connectionString);
            var sp = "ListarAtor";
            var sqlCommand = new SqlCommand(sp, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
       
            try
            {
                connection.Open();
                using var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var ator = new Ator
                    {
                        Id = (int)reader["Id"],
                        Nome = reader["Nome"].ToString(),
                        Sobrenome = reader["Sobrenome"].ToString()
                    };

                    elenco.Add(ator);
                }
            }
            catch (Exception e)
            {

            }
      
            return elenco;
        }
    }

}
