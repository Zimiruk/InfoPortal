using InfoPortal.Common.Models;
using System.Collections.Generic;

namespace InfoPortal.BLL.Services.Interfaces
{
    public interface ILanguageService
    {
        int Create(Language Language);

        List<Language> GetAll();

        void Update(Language Language);

        Report Delete(int id);
    }
}
