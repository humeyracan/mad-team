using DataAccess.DataModels;
using DataAccess.Interfaces;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IPostRepository: IRepository<Post>
    {
        public List<Post> GetAll();
        public List<Post> GetPostByUserId(int userId);
    }
}