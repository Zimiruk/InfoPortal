using InfoPortal.Common.Constants;
using InfoPortal.Common.Models;
using InfoPortal.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
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

        public int Create(Article article)
        {
            int id = 0;

            SqlConnection connection = Access.Connection;

            using (connection)
            {
                connection.Open();
                string sqlExpression = ArticleConstants.CreateArticle;

                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@name", SqlDbType.VarChar).Value = article.Name;
                    command.Parameters.Add("@theme", SqlDbType.VarChar).Value = article.Theme;
                    command.Parameters.Add("@addedOn", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@language", SqlDbType.VarChar).Value = article.Language;
                    command.Parameters.Add("@picture", SqlDbType.VarChar).Value = article.Picture;
                    command.Parameters.Add("@video", SqlDbType.VarChar).Value = article.Video;
                    command.Parameters.Add("@link", SqlDbType.Int).Value = article.Link;

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(returnValue);

                    command.ExecuteNonQuery();

                    id = (int)returnValue.Value;
                }
            }

            return id;
        }

        /// TODO Fix that, additional class, exceptions, parsing
        public List<Article> GetAll()
        {
            return DatabaseCommand.ExecuteListReader<Article>(ArticleConstants.GetArticles, Access.Connection);
        }

        /// TODO Parser, something with sql parameter
        public Article Get(int id)
        {
            SqlConnection connection = Access.Connection;

            Article article = null;

            using (connection)
            {
                connection.Open();
                string sqlExpression = ArticleConstants.GetArticle;

                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = new SqlParameter();

                    parameter.ParameterName = "@id";
                    parameter.SqlDbType = SqlDbType.Int;
                    parameter.Value = id;

                    command.Parameters.Add(parameter);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            article = new Article
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
                        }
                    }
                }
            }

            return article;
        }

        /// TODO Parser, something with sql parameter
        public void Update(Article article)
        {
            SqlConnection connection = Access.Connection;

            using (connection)
            {
                connection.Open();
                string sqlExpression = ArticleConstants.UpdateArticle;

                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = new SqlParameter();

                    command.Parameters.Add("@id", SqlDbType.Int).Value = article.Id;
                    command.Parameters.Add("@name", SqlDbType.VarChar).Value = article.Name;
                    command.Parameters.Add("@theme", SqlDbType.VarChar).Value = article.Theme;
                    command.Parameters.Add("@addedOn", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@language", SqlDbType.VarChar).Value = article.Language;
                    command.Parameters.Add("@picture", SqlDbType.VarChar).Value = article.Picture;
                    command.Parameters.Add("@video", SqlDbType.VarChar).Value = article.Video;
                    command.Parameters.Add("@link", SqlDbType.Int).Value = article.Link;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            SqlConnection connection = Access.Connection;

            using (connection)
            {
                connection.Open();
                string sqlExpression = ArticleConstants.DeleteArticle;

                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
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
}
