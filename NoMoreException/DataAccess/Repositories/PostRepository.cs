using DataAccess.DataModels;
using DataAccess.DBContext;
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
            var factory = new DbContextFactory();
            string[] stringArray = new string[6];
            using (var context = factory.CreateDbContext(stringArray))
            {
                foreach (var query in context.Posts)
                {
                    if (query != null)
                        posts.Add(query);
                }
            }
            return posts;
        }
        public List<Post> GetPostByUserId(int userId)
        {
            List<Post> posts = new List<Post>();
            var factory = new DbContextFactory();
            string[] stringArray = new string[6];
            using (var context = factory.CreateDbContext(stringArray))
            {
                foreach (var query in context.Posts.Include(a => a.User).Where(x => x.User.Id == userId))
                {
                    if (query != null)
                        posts.Add(query);
                }
            }
            return posts;
        }
    }
}
