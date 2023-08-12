using Microsoft.Data.SqlClient;
using System.Data;

namespace LearnDapper.Database
{
    public class DapperDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;
        public DapperDBContext(IConfiguration configuration) 
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("connection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(connectionString);
      
    }
}
