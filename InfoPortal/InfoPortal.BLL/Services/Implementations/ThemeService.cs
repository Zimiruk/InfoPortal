using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.Common.Models;
using InfoPortal.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace InfoPortal.BLL.Services.Implementations
{
    public class ThemeService : IThemeService
    {
        private readonly IThemeRepository _ThemeRepository;

        public ThemeService(IThemeRepository ThemeRepository)
        {
            _ThemeRepository = ThemeRepository;
        }

        public int Create(Theme Theme)
        {
            return _ThemeRepository.Create(Theme);
        }

        public List<Theme> GetAll()
        {
            return _ThemeRepository.GetAll();
        }

        public void Update(Theme Theme)
        {
            _ThemeRepository.Update(Theme);
        }

        public void Delete(int id)
        {
            _ThemeRepository.Delete(id);
        }
    }
}