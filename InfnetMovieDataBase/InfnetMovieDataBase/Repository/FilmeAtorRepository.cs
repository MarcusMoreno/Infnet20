using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace InfnetMovieDataBase.Repository
{
    public interface IFilmeAtorRepository
    {
        void CreateOrUpdateFilmeAtor(string filmeId, string atorId);
    }

    public class FilmeAtorRepository : IFilmeAtorRepository
    {
        private readonly string connectionString;

        public FilmeAtorRepository(IConfiguration configuration)
        {
            this.connectionString = configuration["DataBase:connection"];
        }


        public void CreateOrUpdateFilmeAtor(string filmeId, string atorId)
        {
            using var connection = new SqlConnection(connectionString);

            var sp = "CreateOrUpdateFilmeAtor";
            var insert = new SqlCommand(sp, connection);
            insert.CommandType = CommandType.StoredProcedure;

            insert.Parameters.AddWithValue("@FilmeId", filmeId);
            insert.Parameters.AddWithValue("@AtorId", atorId);
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
