using System.Data;
using System.Data.SqlClient;

namespace InfoPortal.DAL
{
    public class SQLDataAccess : System.IDisposable
    {
        public SqlConnection Connection { get; }
        public virtual IDbConnection DbConnection { get; }

        public SQLDataAccess()
        {
        }

        public SQLDataAccess(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
            DbConnection = new SqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}
