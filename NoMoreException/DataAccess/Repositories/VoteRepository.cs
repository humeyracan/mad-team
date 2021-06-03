using DataAccess.DataModels;
using DataAccess.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class VoteRepository: Repository<Vote>, IVoteRepository
    {
        public List<Vote> GetAll()
        {
            List<Vote> votes = new List<Vote>();
            var factory = new DbContextFactory();
            string[] stringArray = new string[6];
            using (var context = factory.CreateDbContext(stringArray))
            {
                foreach (var query in context.Votes.Include(a=> a.Post).Include(a=> a.User))
                {
                    if (query != null)
                        votes.Add(query);
                }
            }
            return votes;
        }

        public List<Vote> GetByPostId(int postId)
        {
            List<Vote> votes = new List<Vote>();
            var factory = new DbContextFactory();
            string[] stringArray = new string[6];
            using (var context = factory.CreateDbContext(stringArray))
            {
                foreach (var query in context.Votes.Include(a => a.Post).Where(x => x.Post.Id == postId))
                {
                    if (query != null)
                        votes.Add(query);
                }
            }
            return votes;
        }

        public List<Vote> GetByUserId(int userId)
        {
            List<Vote> votes = new List<Vote>();
            var factory = new DbContextFactory();
            string[] stringArray = new string[6];
            using (var context = factory.CreateDbContext(stringArray))
            {
                foreach (var query in context.Votes.Include(a => a.User).Where(x => x.User.Id == userId))
                {
                    if (query != null)
                        votes.Add(query);
                }
            }
            return votes;
        }

        public Vote GetVoteById(int voteid)
        {
            List<Vote> votes = new List<Vote>();
            var factory = new DbContextFactory();
            string[] stringArray = new string[6];
            using (var context = factory.CreateDbContext(stringArray))
            {
                var query = context.Votes.Include(a => a.User).Include(a => a.Post).First(x => x.Id == voteid);
                if (query != null)
                    return query;
                else
                    return null;
            }
        }


    }
}
