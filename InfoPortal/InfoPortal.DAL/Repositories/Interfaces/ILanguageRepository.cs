using InfoPortal.Common.Models;
using System.Collections.Generic;

namespace InfoPortal.DAL.Repositories.Interfaces
{
    public interface ILanguageRepository
    {
        int Create(Language Language);

        List<Language> GetAll();

        void Update(Language Language);

        Report Delete(int id);
    }
}
