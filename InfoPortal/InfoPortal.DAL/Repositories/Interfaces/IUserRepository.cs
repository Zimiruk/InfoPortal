using InfoPortal.Common.Models;
using System.Collections.Generic;

namespace InfoPortal.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        int Create(User User);

        List<User> GetAll();

        User Get(int id);

        void Update(User User);

        void Delete(int id);
    }
}
