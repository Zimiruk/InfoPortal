using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.Common.Models;
using InfoPortal.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace InfoPortal.BLL.Services.Implementations
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageService(ILanguageRepository LanguageRepository)
        {
            _languageRepository = LanguageRepository;
        }

        public int Create(Language Language)
        {
            return _languageRepository.Create(Language);
        }

        public List<Language> GetAll()
        {
            return _languageRepository.GetAll();
        }

        public void Update(Language Language)
        {
            _languageRepository.Update(Language);
        }

        public Report Delete(int id)
        {
            return _languageRepository.Delete(id);
        }
    }
}