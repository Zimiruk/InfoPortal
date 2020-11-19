using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfoPortal.DAL
{
    public static class DatabaseCommand
    {
        public static List<ITable> ExecuteListReader<ITable>(string sqlExpression, SqlConnection sqlConnection)
        {
            List<ITable> data = new List<ITable>();

            using (SqlCommand command = new SqlCommand(sqlExpression, sqlConnection))
            {
                sqlConnection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ITable value = DatabaseDataMapper.Map<ITable>(reader);
                        data.Add(value);
                    }
                }
            }

            return data;
        }
    }
}
