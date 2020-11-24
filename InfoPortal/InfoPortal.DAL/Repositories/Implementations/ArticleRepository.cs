using InfoPortal.Common.Constants;
using InfoPortal.Common.Models;
using InfoPortal.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace InfoPortal.DAL.Repositories.Implementations
{
    /// TODO MayB add exception for wrong command input, or move commands to dictionary

    public class ArticleRepository : IArticleRepository
    {
        public SQLDataAccess Access { get; }

        public ArticleRepository(SQLDataAccess access)
        {
            Access = access;
        }

        public int Create(Article article)
        {
            return DatabaseCommand.ExecuteNonQueryWithId(article, ArticleConstants.CreateArticle, Access.Connection);
        }

        public List<Article> GetAll()
        {
            return DatabaseCommand.ExecuteListReader<Article>(ArticleConstants.GetArticles, Access.Connection);
        }

        public Article Get(int id)
        {
            return DatabaseCommand.ExecuteSingleReader<Article>(id, ArticleConstants.GetArticle, Access.Connection);
        }

        public void Update(Article article)
        {
            DatabaseCommand.ExecuteNonQuery(article, ArticleConstants.UpdateArticle, Access.Connection);         
        }

        public void Delete(int id)
        {
            DatabaseCommand.ExecuteNonQuery(id, ArticleConstants.DeleteArticle, Access.Connection);           
        }
    }
}
