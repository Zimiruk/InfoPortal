using InfoPortal.Common.Models;
using System.Collections.Generic;

namespace InfoPortal.DAL.Repositories.Interfaces
{
    public interface IThemeRepository
    {
        int Create(Theme Theme);

        List<Theme> GetAll();

        void Update(Theme Theme);

        Report Delete(int id);
    }
}
