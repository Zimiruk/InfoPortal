using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.Common.Models;
using InfoPortal.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace InfoPortal.BLL.Services.Implementations
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public int Create(Article article)
        {
           return _articleRepository.Create(article);
        } 

        public List<Article> GetAll()
        {
            return _articleRepository.GetAll();
        }

        public Article Get(int id)
        {
            return _articleRepository.Get(id);    
        }

        public void Update(Article article)
        {
            _articleRepository.Update(article);
        }

        public void Delete(int id)
        {
            _articleRepository.Delete(id);
        }
    }
}