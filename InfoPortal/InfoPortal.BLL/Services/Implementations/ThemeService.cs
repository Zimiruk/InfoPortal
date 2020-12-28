using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.Common.Models;
using InfoPortal.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace InfoPortal.BLL.Services.Implementations
{
    public class ThemeService : IThemeService
    {
        private readonly IThemeRepository _themeRepository;

        public ThemeService(IThemeRepository ThemeRepository)
        {
            _themeRepository = ThemeRepository;
        }

        public int Create(Theme Theme)
        {
            return _themeRepository.Create(Theme);
        }

        public List<Theme> GetAll()
        {
            return _themeRepository.GetAll();
        }

        public void Update(Theme Theme)
        {
            _themeRepository.Update(Theme);
        }

        public Report Delete(int id)
        {
            return _themeRepository.Delete(id);
        }
    }
}