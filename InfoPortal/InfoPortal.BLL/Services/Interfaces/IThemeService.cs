using InfoPortal.Common.Models;
using System.Collections.Generic;

namespace InfoPortal.BLL.Services.Interfaces
{
    public interface IThemeService
    {
        int Create(Theme theme);

        List<Theme> GetAll();

        void Update(Theme Theme);

        void Delete(int id);
    }
}
