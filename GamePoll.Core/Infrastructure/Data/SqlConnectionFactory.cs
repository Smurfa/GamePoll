using System.Data;
using System.Data.SqlClient;

namespace GamePoll.Core.Infrastructure.Data
{
    internal class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connection;

        public SqlConnectionFactory(string connection)
        {
            _connection = connection;
        }

        public IDbConnection Create()
        {
            return new SqlConnection(_connection);
        }
    }
}
