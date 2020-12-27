using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.Common.Models;
using InfoPortal.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace InfoPortal.BLL.Services.Implementations
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _LanguageRepository;

        public LanguageService(ILanguageRepository LanguageRepository)
        {
            _LanguageRepository = LanguageRepository;
        }

        public int Create(Language Language)
        {
            return _LanguageRepository.Create(Language);
        }

        public List<Language> GetAll()
        {
            return _LanguageRepository.GetAll();
        }

        public void Update(Language Language)
        {
            _LanguageRepository.Update(Language);
        }

        public Report Delete(int id)
        {
            return _LanguageRepository.Delete(id);
        }
    }
}