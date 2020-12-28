using InfoPortal.Common.Models;
using System.Collections.Generic;

namespace InfoPortal.BLL.Services.Interfaces
{
    public interface IUserService
    {
        int Create(User User);

        List<User> GetAll();

        User Get(int id);

        void Update(User User);

        void Delete(int id);
    }
}
