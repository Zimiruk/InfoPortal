using InfoPortal.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace InfoPortal.DAL
{
    public static class DatabaseDataMapper
    {
        private static Dictionary<Type, Func<SqlDataReader, ITable>> mappersDictionary = new Dictionary<Type, Func<SqlDataReader, ITable>>();
        private static Dictionary<Type, SqlDbType> sqlTypes = new Dictionary<Type, SqlDbType>();

        static DatabaseDataMapper()
        {
            mappersDictionary.Add(typeof(Article), ArticleMapper);
            mappersDictionary.Add(typeof(File), FileMapper);
            mappersDictionary.Add(typeof(Theme), ThemeMapper);
            mappersDictionary.Add(typeof(Language), LanguageMapper);
            mappersDictionary.Add(typeof(User), UserMapper);
            mappersDictionary.Add(typeof(Role), RoleMapper);


            sqlTypes.Add(typeof(string), SqlDbType.VarChar);
            sqlTypes.Add(typeof(int), SqlDbType.Int);
            sqlTypes.Add(typeof(DateTime), SqlDbType.DateTime);
            sqlTypes.Add(typeof(byte[]), SqlDbType.VarBinary);
        }

        public static SqlDbType GetSqlType(Type type)
        {
            return sqlTypes[type];
        }

        public static ITable Map<ITable>(SqlDataReader reader)
        {
            Type type = typeof(ITable);
            ITable result = (ITable)mappersDictionary[type](reader);

            return result;
        }

        private static Article ArticleMapper(SqlDataReader reader)
        {
            var article = new Article
            {
                Id = Convert.ToInt32(reader.GetValue(0)),
                Name = reader.GetValue(1).ToString(),
                /*ThemeId = reader.GetValue(2) == DBNull.Value ? 0 : Convert.ToInt32(reader.GetValue(2)), 
                AddedOn = Convert.ToDateTime(reader.GetValue(3)),
                Language = reader.GetValue(4).ToString(),
                Link = Convert.ToInt32(reader.GetValue(5))*/


                AddedOn = Convert.ToDateTime(reader.GetValue(2)),
                LanguageId = Convert.ToInt32(reader.GetValue(3)),
                Image = (byte[])reader.GetValue(4),
                Video = (byte[])reader.GetValue(5),
                Text = reader.GetValue(6).ToString()         
            };

            return article;
        }

        private static File FileMapper(SqlDataReader reader)
        {
            var file = new File
            {
                Id = Convert.ToInt32(reader.GetValue(0)),
                ArticleId = Convert.ToInt32(reader.GetValue(1)),
                Content = (byte[])reader.GetValue(2),
                Type = reader.GetValue(3).ToString()   
            };

            return file;
        }

        private static Theme ThemeMapper(SqlDataReader reader)
        {
            var theme = new Theme
            {
                Id = Convert.ToInt32(reader.GetValue(0)),
                Name = reader.GetValue(1).ToString()
            };

            return theme;
        }

        private static Language LanguageMapper(SqlDataReader reader)
        {
            var Language = new Language
            {
                Id = Convert.ToInt32(reader.GetValue(0)),
                Name = reader.GetValue(1).ToString()
            };

            return Language;
        }

        private static User UserMapper(SqlDataReader reader)
        {
            var User = new User
            {
                Id = Convert.ToInt32(reader.GetValue(0)),
                Login = reader.GetValue(1).ToString(),
                Email = reader.GetValue(2).ToString(),
                Password = reader.GetValue(3).ToString(),
                RoleId = Convert.ToInt32(reader.GetValue(4)),
            };

            return User;
        }

        private static Role RoleMapper(SqlDataReader reader)
        {
            var Role = new Role
            {
                Id = Convert.ToInt32(reader.GetValue(0)),
                Name = reader.GetValue(1).ToString()
            };

            return Role;
        }

    }
}
