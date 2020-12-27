using InfoPortal.Common.Constants;
using InfoPortal.Common.Models;
using InfoPortal.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace InfoPortal.DAL.Repositories.Implementations
{
    /// TODO MayB add exception for wrong command input, or move commands to dictionary

    public class LanguageRepository : ILanguageRepository
    {
        public SQLDataAccess Access { get; }

        public LanguageRepository(SQLDataAccess access)
        {
            Access = access;
        }

        public int Create(Language Language)
        {
            int id = DatabaseCommand.ExecuteNonQueryWithId(Language, LanguageConstants.CreateLanguage, Access.Connection);
            return id;
        }

        public List<Language> GetAll()
        {
            return DatabaseCommand.ExecuteListReader<Language>(LanguageConstants.GetLanguages, Access.Connection);
        }

        public void Update(Language Language)
        {
            DatabaseCommand.ExecuteNonQuery(Language, LanguageConstants.UpdateLanguage, Access.Connection);
        }

        /// TODO Result boolean value usage
        public Report Delete(int id)
        {
            var articles = DatabaseCommand.ExecuteListReader<Article>(id, ArticleConstants.GetArticlesByLanguageId, Access.Connection);

            if (articles.Count > 0)
            {
                return new Report
                {
                    Result = false,
                    Message = MessagesConstants.LanguageDeleteFalse
                };
            }

            else
            {
                DatabaseCommand.ExecuteNonQuery(id, LanguageConstants.DeleteLanguage, Access.Connection);

                return new Report
                {
                    Result = true,
                    Message = MessagesConstants.LanguageDeleteTrue
                };
            }
        }
    }
}
