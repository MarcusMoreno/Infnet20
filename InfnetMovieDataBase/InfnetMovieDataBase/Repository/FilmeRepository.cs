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
        IEnumerable<Pessoa> ListarElenco(int id);
        void CriarFilme(Filme filme);
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
            // Onde vamos armazenar o resultado da consulta?
            var filmes = new List<Filme>();

            using var connection = new SqlConnection(connectionString); // Dá close e dispose
            // Agora, a conexão existe.
            // O que queremos acessar do banco?
            var cmdText = "SELECT * FROM Filme";
            // Vincular esse comando a uma conexão:
            var select = new SqlCommand(cmdText, connection);
            try
            {
                //Abrir a conexão
                connection.Open();
                using var reader = select.ExecuteReader(CommandBehavior.CloseConnection);
                // A conexão está aberta; O comando SQL foi executado
                while (reader.Read())
                {
                    //Enquanto for possível ler de reader significa que ainda temos Filmes armazenados no banco
                    var filme = new Filme();
                    filme.Id = (int)reader["Id"]; 
                    filme.Titulo = reader["Titulo"].ToString();
                    filme.TituloOriginal = reader["TituloOriginal"].ToString();
                    filme.Ano = (int)reader["Ano"];
                    filmes.Add(filme);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

            }

            return filmes;
        }

        //Listar elenco do filme
        public IEnumerable<Pessoa> ListarElenco(int id)
        {
            var elenco = new List<Pessoa>();

            using var connection = new SqlConnection(connectionString);
            var sp = "ListarAtoresPorFilme";
            //Vinculando o que desejamos executar (a stored procedure)
            //à conexão na qual desejamos executá-la (connection)
            var sqlCommand = new SqlCommand(sp, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@FilmeId", id);

            try
            {
                connection.Open();
                using var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var pessoa = new Pessoa
                    {
                        Nome = reader["Nome"].ToString(),
                        Sobrenome = reader["Sobrenome"].ToString()
                    };

                    elenco.Add(pessoa);
                }
            } catch (Exception e)
            {

            }
            finally
            {
                connection.Close();
            }

            return elenco;
        }

        //Criar filmes
        public void CriarFilme(Filme filme)
        {
            using var connection = new SqlConnection(connectionString);

            //Usando puramente ADO.NET:
            /*var cmdText = "INSERT INTO Filme (Titulo, TituloOriginal, Ano) VALUES (@Titulo, @TituloOriginal, @Ano)";
            var insert = new SqlCommand(cmdText, connection);
            insert.CommandType = CommandType.Text;*/

            //Usando Stored Procedure:
            var sp = "CriarFilme";
            var insert = new SqlCommand(sp, connection);
            insert.CommandType = CommandType.StoredProcedure;
            
            //Configurar os parâmetros @Titulo, @TituloOriginal e @Ano:
            insert.Parameters.AddWithValue("@Titulo", filme.Titulo);
            insert.Parameters.AddWithValue("@TituloOriginal", filme.TituloOriginal);
            insert.Parameters.AddWithValue("@Ano", filme.Ano);
            try
            {
                connection.Open();
                insert.ExecuteNonQuery();
            } catch (Exception e)
            {
                throw e; 
            }
        }

        public void AtualizarFilme(Filme filme)
        {
            using var connection = new SqlConnection(connectionString);
            using var cmd = new SqlCommand("UPDATE Filme SET Titulo = @titulo, TituloOriginal = @tituloOriginal, Ano = @ano WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@titulo", filme.Titulo);
            cmd.Parameters.AddWithValue("@tituloOriginal", filme.TituloOriginal);
            cmd.Parameters.AddWithValue("@ano", filme.Ano);
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
            var filme = new Filme();

            using var connection = new SqlConnection(connectionString); // Dá close e dispose
                                                                        // Agora, a conexão existe.
                                                                        // O que queremos acessar do banco?
            using var cmd = new SqlCommand("SELECT * FROM Filme WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                //Abrir a conexão
                connection.Open();
                using var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                // A conexão está aberta; O comando SQL foi executado
                reader.Read();
                filme.Id = (int)reader["Id"];
                filme.Titulo = reader["Titulo"].ToString();
                filme.TituloOriginal = reader["TituloOriginal"].ToString();
                filme.Ano = (int)reader["Ano"];
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

            }

            return filme;
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
