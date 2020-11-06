using InfoPortal.Common.Constants;
using InfoPortal.Common.Models;
using InfoPortal.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfoPortal.DAL.Repositories.Implementations
{
    public class ArticleRepository : IArticleRepository
    {   
        public SQLDataAccess Access { get; }

        public ArticleRepository(SQLDataAccess access)
        {
            Access = access;
        }

        /// TODO Fix that, additional class, exceptions, parsing
        public List<Article> GetAll()
        {
            List<Article> articles = new List<Article>();

            SqlConnection connection = Access.Connection;            

            using (connection)
            {
                connection.Open();
                string sqlExpression = SqlCommands.GetArticles;

                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) 
                    {      
                        while (reader.Read())
                        {
                            articles.Add(new Article
                            {
                                Id = Convert.ToInt32(reader.GetValue(0)),
                                Name = reader.GetValue(1).ToString(),
                                Theme = reader.GetValue(2).ToString(),
                                AddedOn = Convert.ToDateTime(reader.GetValue(3)),
                                Language = reader.GetValue(4).ToString(),
                                Picture = reader.GetValue(5).ToString(),
                                Video = reader.GetValue(6).ToString(),
                                Link = Convert.ToInt32(reader.GetValue(7))
                            });                            
                        }
                    }
                }
            }

            return articles;

        }
    }
}
