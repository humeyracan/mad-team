using DataAccess.DataModels;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public User Get(string username, string password);
        public List<User> GetAll();
        public User Authenticate(string username, string password);
    }
}
