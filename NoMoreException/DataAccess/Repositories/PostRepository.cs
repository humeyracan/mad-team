using DataAccess.DataModels;
using DataAccess.DataModels.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using System.Linq;

namespace DataAccess.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
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

        public Post GetPostById(int postId)
        {
            return Context.Posts.Include(a => a.User).FirstOrDefault(x => x.Id == postId);
        }

        public List<Post> GetAllActiveQuestions()
        {
            List<Post> posts = new List<Post>();
            foreach (var query in Context.Posts.Include(p => p.User).Where(p => p.Active == false && p.PostType == PostTypes.Question && p.ParentId == 0))
            {//active olayini ters kurguladik sanirim
                if (query != null)
                    posts.Add(query);
            }
            return posts;
        }
        public List<Post> GetByParentId(int parentId)
        {
            //Post post = GetById(parentId);
            //OrderBy(a => post.AcceptedAnswerId == a.Id ? a).

            List <Post> posts = new List<Post>();
            foreach (var query in Context.Posts.Include(a => a.User).Where(a => a.Active == false &&
            a.PostType == PostTypes.Answer && a.ParentId == parentId).OrderByDescending(p => p.Score).ThenBy(p => p.CreationDate))
            {
                if (query != null)
                    posts.Add(query);
            }
            return posts;
        }
    }
}
