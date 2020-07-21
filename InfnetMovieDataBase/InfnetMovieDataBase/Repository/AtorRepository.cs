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
        IEnumerable<Filme> ListarFilme(int id);
    }

    public class AtorRepository : IAtorRepository
    {
        private readonly string connectionString;

        public AtorRepository(IConfiguration configuration)
        {
            this.connectionString = configuration["DataBase:connection"];
        }
        //Listar
        public IEnumerable<Ator> ListarAtores()
        {
        //1. Onde vamos armazenar o resultado da consulta?
            var usuarios = new List<Ator>();

            //2. Estabelecer uma conexão com o banco
            using var connection = new SqlConnection(connectionString);

            //A conexão existe

            //O que queremos acessar no banco?
            var cmdText = "SELECT * FROM Ator";
            //Vincular esse comando a uma conexão:
            var select = new SqlCommand(cmdText, connection);


            try
            {
                connection.Open();
                using (var reader = select.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    //A conexão está aberta; O comando SQL foi executado
                    while (reader.Read())
                    {
                        /*Enquanto for possível ler de reader, 
                        significa que temos um novo Pessoa armazenado no banco*/
                        var usuario = new Ator();
                        usuario.Id = (int)reader["Id"];
                        usuario.Nome = reader["Nome"].ToString();
                        usuario.Sobrenome = reader["Sobrenome"].ToString();
                    
                        usuarios.Add(usuario);
                    }
                }
            }
            finally
            {
                connection.Close();
            }



            return usuarios;
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
            using SqlConnection connection = new SqlConnection(connectionString);
            string sql = "SELECT Id, Nome, Sobrenome FROM Ator WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Id", id);
            Ator ator = null;
            try
            {
                connection.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            ator = new Ator();
                            ator.Id = (int)reader["Id"];
                            ator.Nome = reader["Nome"].ToString();
                            ator.Sobrenome = reader["Sobrenome"].ToString();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return ator;

        }

        //Excluir
        public void ExcluirAtor(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            string cmdText = "DELETE Ator WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@Id", id);
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

        //Listar filmes do ator
        public IEnumerable<Filme> ListarFilme(int id)
        {
            var elenco = new List<Filme>();

            using var connection = new SqlConnection(connectionString);
            var sp = "ListarFilmesPorAtor";
            var sqlCommand = new SqlCommand(sp, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@AtorId", id);

            try
            {
                connection.Open();
                using var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var filme = new Filme
                    {
                        Titulo = reader["Titulo"].ToString(),
                        TituloOriginal = reader["TituloOriginal"].ToString()                   
                    };

                    elenco.Add(filme);
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                connection.Close();
            }

            return elenco;
        }
    }

}
