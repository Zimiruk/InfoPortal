using InfoPortal.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace InfoPortal.DAL
{
    public static class DatabaseCommand
    {
        public static ITable ExecuteSingleReader<ITable>(int id, string sqlExpression, SqlConnection sqlConnection)
        {
            ITable entity = default;

            using (SqlCommand command = new SqlCommand(sqlExpression, sqlConnection))
            {
                sqlConnection.Open();

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        entity = DatabaseDataMapper.Map<ITable>(reader);
                    }
                }
            }

            return entity;
        }

        public static List<ITable> ExecuteListReader<ITable>(string sqlExpression, SqlConnection sqlConnection)
        {
            List<ITable> entities = new List<ITable>();

            using (SqlCommand command = new SqlCommand(sqlExpression, sqlConnection))
            {
                sqlConnection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ITable value = DatabaseDataMapper.Map<ITable>(reader);
                        entities.Add(value);
                    }
                }
            }

            return entities;
        }

        public static List<ITable> ExecuteListReader<ITable>(int id, string sqlExpression, SqlConnection sqlConnection)
        {
            List<ITable> entities = new List<ITable>();

            using (SqlCommand command = new SqlCommand(sqlExpression, sqlConnection))
            {
                sqlConnection.Open();

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ITable value = DatabaseDataMapper.Map<ITable>(reader);
                        entities.Add(value);
                    }
                }
            }

            return entities;
        }

        public static int ExecuteNonQueryWithId(ITable entity, string sqlExpression, SqlConnection sqlConnection)
        {
            int id = 0;

            using (SqlCommand command = new SqlCommand(sqlExpression, sqlConnection))
            {
                sqlConnection.Open();

                command.CommandType = CommandType.StoredProcedure;

                foreach (var propertyInfo in entity.GetType().GetProperties())
                {
                    if(propertyInfo.PropertyType.IsGenericType)
                    {
                        continue;
                    }

                    switch (propertyInfo.Name)
                    {
                        case "Id":
                            continue;

                        case "AddedOn":
                            command.Parameters
                                .Add("@AddedOn",
                                DatabaseDataMapper.GetSqlType(propertyInfo.PropertyType))
                                .Value = DateTime.Now;
                            break;

                        default:
                            var value = entity.GetType().
                                GetProperty(propertyInfo.Name).
                                GetValue(entity, null);

                            command.Parameters.
                                Add("@" + propertyInfo.Name,
                                DatabaseDataMapper.GetSqlType(propertyInfo.PropertyType)).
                                Value = value;
                            break;
                    }
                }

                SqlParameter returnValue = new SqlParameter();
                returnValue.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(returnValue);

                command.ExecuteNonQuery();

                id = (int)returnValue.Value;

                sqlConnection.Close();
            }

            return id;
        }

        public static void ExecuteNonQuery(ITable entity, string sqlExpression, SqlConnection sqlConnection)
        {
            using (SqlCommand command = new SqlCommand(sqlExpression, sqlConnection))
            {
                sqlConnection.Open();

                command.CommandType = CommandType.StoredProcedure;

                foreach (var propertyInfo in entity.GetType().GetProperties())
                {
                    if (propertyInfo.Name == "AddedOn")
                    {
                        command.Parameters
                            .Add("@AddedOn",DatabaseDataMapper.GetSqlType(propertyInfo.PropertyType))
                            .Value = DateTime.Now;
                    }

                    else
                    {
                        var value = entity.GetType().
                              GetProperty(propertyInfo.Name).
                              GetValue(entity, null);

                        command.Parameters.
                            Add("@" + propertyInfo.Name,
                            DatabaseDataMapper.GetSqlType(propertyInfo.PropertyType)).
                            Value = value;
                    }
                }

                SqlParameter returnValue = new SqlParameter();
                returnValue.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(returnValue);

                command.ExecuteNonQuery();
            }
        }


        public static void ExecuteNonQuery(int id, string sqlExpression, SqlConnection sqlConnection)
        {
            using (SqlCommand command = new SqlCommand(sqlExpression, sqlConnection))
            {
                sqlConnection.Open();
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter();

                parameter.ParameterName = "@id";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Value = id;

                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
        }
    }
}
