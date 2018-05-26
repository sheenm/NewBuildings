using NewBuildings.Data.Abstract;
using System.Data.Common;
using System.Data.SqlClient;

namespace NewBuildings.Data
{
    public class MsSqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public MsSqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
