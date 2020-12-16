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
            int id = DatabaseCommand.ExecuteNonQueryWithId(article, ArticleConstants.CreateArticle, Access.Connection);           

            foreach(var file in article.Files)
            {
                file.ArticleId = id;
                CreateFile(file);
            }

            return id;
        }

        public List<Article> GetAll()
        {
            return DatabaseCommand.ExecuteListReader<Article>(ArticleConstants.GetArticles, Access.Connection);
        }
      
        public Article Get(int id)
        {          
           var article = DatabaseCommand.ExecuteSingleReader<Article>(id, ArticleConstants.GetArticle, Access.Connection);

           article.Theme = GetTheme(article.ThemeId); 
           article.Files = GetAllByArticleId(id);

           return article;
        }

        public Theme GetTheme(int id)
        {
            return DatabaseCommand.ExecuteSingleReader<Theme>(id, ThemeConstants.GetTheme, Access.Connection);          
        }

        public void Update(Article article)
        {
            DatabaseCommand.ExecuteNonQuery(article, ArticleConstants.UpdateArticle, Access.Connection);         
        }

        public void Delete(int id)
        {
            DatabaseCommand.ExecuteNonQuery(id, ArticleConstants.DeleteArticle, Access.Connection);           
        }

        public void CreateFile(File file)
        {
            DatabaseCommand.ExecuteNonQueryWithId(file, FileConstants.AddFile, Access.Connection);
        }

        public List<File> GetAllByArticleId(int id)
        {
            return DatabaseCommand.ExecuteListReader<File>(id, FileConstants.GetFilesByArticleId, Access.Connection);
        }
    }
}
