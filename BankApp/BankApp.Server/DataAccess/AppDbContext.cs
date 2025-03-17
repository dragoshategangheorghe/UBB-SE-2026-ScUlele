using Microsoft.Data.SqlClient;
using System.Data;

namespace BankApp.Server.DataAccess
{
    public class AppDbContext : IDbContext
    {
        private readonly string _connectionString;
        private SqlConnection? _connection;
        private SqlTransaction? _currentTransaction;
        public AppDbContext(string connectionString)
        {
            // TODO: implement app db context logic
            ;
        }

        public SqlConnection GetConnection()
        {
            // TODO: load connection
            return default !;
        }

        public SqlTransaction BeginTransaction()
        {
            // TODO: implement begin transaction logic
            return default !;
        }

        public void CommitTransaction()
        {
            // TODO: implement commit transaction logic
            ;
        }

        public void RollbackTransaction()
        {
            // TODO: implement rollback transaction logic
            ;
        }

        public SqlTransaction? GetCurrentTransaction()
        {
            // TODO: load current transaction
            return default !;
        }

        private void AddParameters(SqlCommand cmd, object[] parameters)
        {
            // TODO: implement add parameters logic
            ;
        }

        public IDataReader ExecuteQuery(string sqlStatement, object[] parameters)
        {
            // TODO: implement execute query logic
            return default !;
        }

        public int ExecuteNonQuery(string sqlStatement, object[] parameters)
        {
            // TODO: implement execute non query logic
            return default !;
        }

        public void Dispose()
        {
            // TODO: implement dispose logic
            ;
        }
    }
}