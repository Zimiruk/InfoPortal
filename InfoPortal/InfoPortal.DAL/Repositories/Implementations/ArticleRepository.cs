using InfoPortal.Common.Constants;
using InfoPortal.Common.Models;
using InfoPortal.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace InfoPortal.DAL.Repositories.Implementations
{
    /// TODO MayB add exception for wrong command input, or move commands to dictionary

    public class ArticleRepository : IArticleRepository
    {
        FileRepository fileRepository;

        public SQLDataAccess Access { get; }

        public ArticleRepository(SQLDataAccess access)
        {
            Access = access;
            fileRepository = new FileRepository(Access);
        }

        public int Create(Article article)
        {
            int id = DatabaseCommand.ExecuteNonQueryWithId(article, ArticleConstants.CreateArticle, Access.Connection);           

            foreach(var file in article.Files)
            {
                file.ArticleId = id;
                fileRepository.Create(file);
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
           article.Files = fileRepository.GetAllByArticleId(id);

           return article;
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
