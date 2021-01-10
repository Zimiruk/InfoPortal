using InfoPortal.Common.Models;
using System;
using System.Collections.Generic;

namespace InfoPortal.BLL.Services.Interfaces
{
    public interface IArticleService
    {
        int Create(Article article);

        List<Article> GetAll();

        Article Get(int id);

        void Update(Article article);

        void Delete(int id);

        public List<File> GetAllFilesByArticleId(int id);

        public List<Article> GetAllByName(string name);

        public List<Article> GetAllByThemeName(string name);

        public List<Article> GetAllByDate(DateTime date);
    }
}
