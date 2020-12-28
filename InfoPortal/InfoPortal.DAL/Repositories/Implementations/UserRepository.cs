using InfoPortal.Common.Constants;
using InfoPortal.Common.Models;
using InfoPortal.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace InfoPortal.DAL.Repositories.Implementations
{
    /// TODO MayB add exception for wrong command input, or move commands to dictionary

    public class UserRepository : IUserRepository
    {
        public SQLDataAccess Access { get; }

        public UserRepository(SQLDataAccess access)
        {
            Access = access;
        }

        public int Create(User User)
        {     
            return DatabaseCommand.ExecuteNonQueryWithId(User, UserConstants.CreateUser, Access.Connection);
        }

        public List<User> GetAll()
        {    
            return DatabaseCommand.ExecuteListReader<User>(UserConstants.GetUsers, Access.Connection);
        }

        public User Get(int id)
        {
            return DatabaseCommand.ExecuteSingleReader<User>(id, UserConstants.GetUser, Access.Connection);
       
        }       

        public void Update(User User)
        {
            DatabaseCommand.ExecuteNonQuery(User, UserConstants.UpdateUser, Access.Connection);
        }

        public void Delete(int id)
        {
            DatabaseCommand.ExecuteNonQuery(id, UserConstants.DeleteUser, Access.Connection);
        }
    }
}
