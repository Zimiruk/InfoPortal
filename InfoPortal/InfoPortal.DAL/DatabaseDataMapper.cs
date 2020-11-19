using InfoPortal.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfoPortal.DAL
{
    public static class DatabaseDataMapper
    {
        private static Dictionary<Type, Func<SqlDataReader, ITable>> mappers_dictionary = new Dictionary<Type, Func<SqlDataReader, ITable>>();

        static DatabaseDataMapper()
        {
            mappers_dictionary.Add(typeof(Article), ArticleMapper);
        }

        public static ITable Map<ITable>(SqlDataReader reader)
        {
            Type type = typeof(ITable);
            ITable result = (ITable)mappers_dictionary[type](reader);

            return result;
        }

        private static Article ArticleMapper(SqlDataReader reader)
        {
            Article article = new Article
            {
                Id = Convert.ToInt32(reader.GetValue(0)),
                Name = reader.GetValue(1).ToString(),
                Theme = reader.GetValue(2).ToString(),
                AddedOn = Convert.ToDateTime(reader.GetValue(3)),
                Language = reader.GetValue(4).ToString(),
                Picture = reader.GetValue(5).ToString(),
                Video = reader.GetValue(6).ToString(),
                Link = Convert.ToInt32(reader.GetValue(7))
            };
            return article;
        }
    }
}
