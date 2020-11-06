using System.Data.SqlClient;

namespace InfoPortal.DAL
{
    public class SQLDataAccess : System.IDisposable
    {
        public SqlConnection Connection { get; }

        public SQLDataAccess(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}
