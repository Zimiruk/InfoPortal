using InfoPortal.Common.Constants;
using InfoPortal.Common.Models;
using InfoPortal.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

            foreach (var file in article.Files)
            {
                file.ArticleId = id;
                CreateFile(file);
            }


            /// TODO Make sure to use it more then one time
            /// If not, figure out how to do otherwise

            foreach (var themeId in article.ThemesId)
            {

                List<CustomParameter> parameters = new List<CustomParameter>
                {
                    new CustomParameter
                    {
                        Parameter = "@ArticleId",
                        Value = id
                    },
                    new CustomParameter
                    {
                        Parameter = "@ThemeId",
                        Value = themeId
                    }
                };

                DatabaseCommand.ExecuteWithCustomParemeters(parameters, ArticleConstants.AddThemeToArticle, Access.Connection);
            }

            return id;
        }

        public List<Article> GetAll()
        {
            List<Article> articles = DatabaseCommand.ExecuteListReader<Article>(ArticleConstants.GetArticles, Access.Connection);
            foreach (var article in articles)
            {
                article.Themes = GetThemesByArticleId(article.Id);
                article.Language = GetLanguage(article.LanguageId);
            }

            return articles;

        }

        public Article Get(int id)
        {
            var article = DatabaseCommand.ExecuteSingleReader<Article>(id, ArticleConstants.GetArticle, Access.Connection);

            article.Themes = GetThemesByArticleId(id);
            article.Files = GetAllFilesByArticleId(id);
            article.Language = GetLanguage(article.LanguageId);

            return article;
        }

        public List<Theme> GetThemesByArticleId(int id)
        {
            return DatabaseCommand.ExecuteListReader<Theme>(id, ThemeConstants.GetThemesByArticleId, Access.Connection);
        }

        public Language GetLanguage(int id)
        {
            return DatabaseCommand.ExecuteSingleReader<Language>(id, LanguageConstants.GetLanguage, Access.Connection);
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

        public List<File> GetAllFilesByArticleId(int id)
        {
            return DatabaseCommand.ExecuteListReader<File>(id, FileConstants.GetFilesByArticleId, Access.Connection);
        }
    }
}
