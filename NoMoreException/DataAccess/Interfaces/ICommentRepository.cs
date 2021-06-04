using DataAccess.DataModels;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        public List<Comment> GetByPostId(int postId);
        public List<Comment> GetByUserId(int userId);
        public Comment GetByIdWithUserAndPost(int id);
    }
}
