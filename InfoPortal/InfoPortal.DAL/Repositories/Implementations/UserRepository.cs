using InfoPortal.Common.Constants;
using InfoPortal.Common.Models;
using InfoPortal.DAL.Repositories.Interfaces;
using System.Collections.Generic;

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
            var users = DatabaseCommand.ExecuteListReader<User>(UserConstants.GetUsers, Access.Connection);

            foreach (var user in users)
            {
                user.Role = DatabaseCommand.ExecuteSingleReader<Role>(user.Id, UserConstants.GetRole, Access.Connection);
            }

            return users;
        }

        /* This method created only for testing */
        public IList<User> GetAllTest()
        {
            var users = DatabaseCommand.ExecuteList(UserConstants.GetUsers, Access.DbConnection);

            return users;
        }

        public User Get(int id)
        {
            var user = DatabaseCommand.ExecuteSingleReader<User>(id, UserConstants.GetUser, Access.Connection);
            user.Role = DatabaseCommand.ExecuteSingleReader<Role>(id, UserConstants.GetRole, Access.Connection);

            return user;
        }

        public void Update(User User)
        {
            DatabaseCommand.ExecuteNonQuery(User, UserConstants.UpdateUser, Access.Connection);
        }

        public void Delete(int id)
        {
            DatabaseCommand.ExecuteNonQuery(id, UserConstants.DeleteUser, Access.Connection);
        }

        public List<Role> GetRoles()
        {
            return DatabaseCommand.ExecuteListReader<Role>(UserConstants.GetRoles, Access.Connection);
        }

        public User CheckUser(string email, string password)
        {
            List<CustomParameter> parameters = new List<CustomParameter>
                {
                    new CustomParameter
                    {
                        Parameter = "@Email",
                        Value = email
                    },
                    new CustomParameter
                    {
                        Parameter = "@Password",
                        Value = password
                    }
                };

            var user =  DatabaseCommand.ExecuteWithCustomParemeters<User>(parameters, UserConstants.CheckUser, Access.Connection);

            if(user != null)
            {
                user.Role = DatabaseCommand.ExecuteSingleReader<Role>(user.Id, UserConstants.GetRole, Access.Connection);
            }

            return user;
        }
    }
}

