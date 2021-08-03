using DataAccess.DataModels;
using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public List<Comment> GetByPostId(int postId)
        {
            List<Comment> comments = new List<Comment>();
            foreach (var query in Context.Comments.Include(a => a.Post).Where(x => x.Post.Id == postId))
            {
                if (query != null)
                    comments.Add(query);
            }
            return comments;
        }

        public List<Comment> GetByUserId(int userId)
        {
            List<Comment> comments = new List<Comment>();
            foreach (var query in Context.Comments.Include(a => a.User).Where(x => x.User.Id == userId))
            {
                if (query != null)
                    comments.Add(query);
            }
            return comments;
        }

        public Comment GetByIdWithUserAndPost(int id)
        {
            var query = Context.Comments.Include(x => x.Post).Include(x => x.User).FirstOrDefault(x => x.Id == id);
            return new Comment
            {
                Id = query.Id,
                CreationDate = query.CreationDate,
                Score = query.Score,
                CommentText = query.CommentText,
                Post = query.Post,
                User = query.User
            };
        }
    }
}
