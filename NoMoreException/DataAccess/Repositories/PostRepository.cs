using DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using System.Linq;

namespace DataAccess.Repositories
{
    public class PostRepository: Repository<Post>, IPostRepository
    {
        public List<Post> GetAll()
        {
            List<Post> posts = new List<Post>();
            foreach (var query in Context.Posts)
            {
                if (query != null)
                    posts.Add(query);
            }
            return posts;
        }
        public List<Post> GetPostByUserId(int userId)
        {
            List<Post> posts = new List<Post>();
            foreach (var query in Context.Posts.Include(a => a.User).Where(x => x.User.Id == userId))
            {
                if (query != null)
                    posts.Add(query);
            }
            return posts;
        }
    }
}
