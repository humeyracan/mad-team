using DataAccess.DataModels;
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
            foreach (var query in Context.Votes.Include(a=> a.Post).Include(a=> a.User))
            {
                if (query != null)
                    votes.Add(query);
            }
            return votes;
        }

        public List<Vote> GetByPostId(int postId)
        {
            List<Vote> votes = new List<Vote>();
            foreach (var query in Context.Votes.Include(a => a.Post).Where(x => x.Post.Id == postId))
            {
                if (query != null)
                    votes.Add(query);
            }
            return votes;
        }

        public List<Vote> GetByUserId(int userId)
        {
            List<Vote> votes = new List<Vote>();
            foreach (var query in Context.Votes.Include(a => a.User).Where(x => x.User.Id == userId))
            {
                if (query != null)
                    votes.Add(query);
            }
            return votes;
        }

        public Vote GetVoteById(int voteid)
        {
            List<Vote> votes = new List<Vote>();
            var query = Context.Votes.Include(a => a.User).Include(a => a.Post).First(x => x.Id == voteid);
            if (query != null)
                return query;
            else
                return null;
        }
    }
}
