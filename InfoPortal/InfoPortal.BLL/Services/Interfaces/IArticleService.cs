using InfoPortal.Common.Models;
using System.Collections.Generic;

namespace InfoPortal.BLL.Services.Interfaces
{
    public interface IArticleService
    {
        int Create(Article article);

        List<Article> GetAll();

        Article Get(int id);

        void Update(Article article);
    }
}
