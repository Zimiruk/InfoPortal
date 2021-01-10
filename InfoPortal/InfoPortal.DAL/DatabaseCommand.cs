﻿using InfoPortal.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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

                sqlConnection.Close();
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

                sqlConnection.Close();
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

                sqlConnection.Close();
            }

            return entities;
        }

        public static List<ITable> ExecuteListReader<ITable>(string name, string sqlExpression, SqlConnection sqlConnection)
        {
            List<ITable> entities = new List<ITable>();

            using (SqlCommand command = new SqlCommand(sqlExpression, sqlConnection))
            {
                sqlConnection.Open();

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@searchString", SqlDbType.VarChar).Value = name;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ITable value = DatabaseDataMapper.Map<ITable>(reader);
                        entities.Add(value);
                    }
                }

                sqlConnection.Close();
            }

            return entities;
        }

        public static List<ITable> ExecuteListReader<ITable>(DateTime date, string sqlExpression, SqlConnection sqlConnection)
        {
            List<ITable> entities = new List<ITable>();

            using (SqlCommand command = new SqlCommand(sqlExpression, sqlConnection))
            {
                sqlConnection.Open();

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@searchDate", SqlDbType.DateTime).Value = date;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ITable value = DatabaseDataMapper.Map<ITable>(reader);
                        entities.Add(value);
                    }
                }

                sqlConnection.Close();
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
                        case "Role":
                        // case "Theme":
                        case "Language":
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
                    if (propertyInfo.PropertyType.GetInterfaces().Contains(typeof(ITable)))
                    {
                        continue;
                    }

                    if (propertyInfo.PropertyType.IsGenericType)
                    {
                        continue;
                    }

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

        public static void ExecuteWithCustomParemeters(List<CustomParameter> parameters, string sqlExpression, SqlConnection sqlConnection)
        {
            using (SqlCommand command = new SqlCommand(sqlExpression, sqlConnection))
            {
                sqlConnection.Open();
                command.CommandType = CommandType.StoredProcedure;

                foreach(var param in parameters)
                {

                    SqlParameter parameter = new SqlParameter();

                    parameter.ParameterName = param.Parameter;
                    parameter.SqlDbType = SqlDbType.Int;
                    parameter.Value = param.Value;

                    command.Parameters.Add(parameter);
                }

                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

  

        public static ITable ExecuteWithCustomParemeters<ITable>(List<CustomParameter> parameters, string sqlExpression, SqlConnection sqlConnection)
        {
            ITable entity = default;


            using (SqlCommand command = new SqlCommand(sqlExpression, sqlConnection))
            {
                sqlConnection.Open();
                command.CommandType = CommandType.StoredProcedure;

                foreach (var param in parameters)
                {

                    SqlParameter parameter = new SqlParameter();

                    parameter.ParameterName = param.Parameter;
                    parameter.SqlDbType = SqlDbType.VarChar;
                    parameter.Value = param.Value;

                    command.Parameters.Add(parameter);
                }
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        entity = DatabaseDataMapper.Map<ITable>(reader);
                    }
                }

                sqlConnection.Close();
            }

            return entity;
        }

        /*This method creating only for testing*/
        public static IList<User> ExecuteList(string sqlExpression, IDbConnection sqlConnection)
        {
            List<ITable> entities = new List<ITable>();

            using (IDbCommand command = sqlConnection.CreateCommand())
            {
                command.CommandText = sqlExpression;
                sqlConnection.Open();

                using (IDataReader reader = command.ExecuteReader())
                {
                    IList<User> rows = new List<User>();
                    while (reader.Read())
                    {
                        rows.Add(new User
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Email = reader.GetString(reader.GetOrdinal("Email"))
                        });
                    }
                    return rows;
                }
            }
        }
    }
}
