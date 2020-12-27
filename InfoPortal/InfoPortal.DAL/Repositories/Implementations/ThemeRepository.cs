using InfoPortal.Common.Constants;
using InfoPortal.Common.Models;
using InfoPortal.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace InfoPortal.DAL.Repositories.Implementations
{
    /// TODO MayB add exception for wrong command input, or move commands to dictionary

    public class ThemeRepository : IThemeRepository
    {
        public SQLDataAccess Access { get; }

        public ThemeRepository(SQLDataAccess access)
        {
            Access = access;
        }

        public int Create(Theme Theme)
        {
            int id = DatabaseCommand.ExecuteNonQueryWithId(Theme, ThemeConstants.CreateTheme, Access.Connection);
            return id;
        }

        public List<Theme> GetAll()
        {
            return DatabaseCommand.ExecuteListReader<Theme>(ThemeConstants.GetThemes, Access.Connection);
        }

        public void Update(Theme Theme)
        {
            DatabaseCommand.ExecuteNonQuery(Theme, ThemeConstants.UpdateTheme, Access.Connection);
        }

        /// TODO Result boolean value usage
        public Report Delete(int id)
        {       
            var articles = DatabaseCommand.ExecuteListReader<Article>(id, ArticleConstants.GetArticlesByThemeId, Access.Connection);

            if (articles.Count > 0)
            {
                return new Report { 
                    Result = false, 
                    Message = MessagesConstants.ThemeDeleteFalse 
                };
            }

            else
            {
                DatabaseCommand.ExecuteNonQuery(id, ThemeConstants.DeleteTheme, Access.Connection);

                return new Report
                {
                    Result = true,
                    Message = MessagesConstants.ThemeDeleteTrue
                };
            }
        }
    }
}
