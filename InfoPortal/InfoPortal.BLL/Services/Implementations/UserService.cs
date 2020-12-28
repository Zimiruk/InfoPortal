using InfoPortal.BLL.Services.Interfaces;
using InfoPortal.Common.Models;
using InfoPortal.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace InfoPortal.BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }

        public int Create(User User)
        {
            return _userRepository.Create(User);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User Get(int id)
        {
            return _userRepository.Get(id);
        }

        public void Update(User User)
        {
            _userRepository.Update(User);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}