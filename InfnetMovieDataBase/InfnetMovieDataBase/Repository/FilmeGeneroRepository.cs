using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InfnetMovieDataBase.Repository
{
    public interface IFilmeGeneroRepository
    {
        void CreateOrUpdateFilmeGenero(string filmeId, string generoId);
    }

    public class FilmeGeneroRepository : IFilmeGeneroRepository
    {
        private readonly string connectionString;

        public FilmeGeneroRepository(IConfiguration configuration)
        {
            this.connectionString = configuration["DataBase:connection"];
        }

        //Criar filmes
        public void CreateOrUpdateFilmeGenero(string filmeId, string generoId)
        {
            using var connection = new SqlConnection(connectionString);

            //Usando Stored Procedure:
            var sp = "CreateOrUpdateFilmeGenero";
            var insert = new SqlCommand(sp, connection);
            insert.CommandType = CommandType.StoredProcedure;

            insert.Parameters.AddWithValue("@FilmeId", filmeId);
            insert.Parameters.AddWithValue("@GeneroId", generoId);
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
    }
}
