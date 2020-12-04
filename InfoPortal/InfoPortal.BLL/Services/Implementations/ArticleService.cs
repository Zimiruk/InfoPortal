using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.Common.Models;
using InfoPortal.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace InfoPortal.BLL.Services.Implementations
{
    public class ArticleService : IArticleService
    {
        private IArticleRepository _articleRepository;
        private IFileRepository _fileRepository;

        public int Create(Article article)
        {
            int id = _articleRepository.Create(article);

            foreach (File file in article.Files)
            {
                file.ArticleId = id;
                _fileRepository.Add(file);
            }

            return id;
        }

        public ArticleService(IArticleRepository articleRepository, IFileRepository fileRepository)
        {
            _articleRepository = articleRepository;
            _fileRepository = fileRepository;
        }

        public List<Article> GetAll()
        {
            return _articleRepository.GetAll();
        }

        public Article Get(int id)
        {
            var article = _articleRepository.Get(id);
            article.Files = _fileRepository.GetAllByArticleId(id);

            return article;
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