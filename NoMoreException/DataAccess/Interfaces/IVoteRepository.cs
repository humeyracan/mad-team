using DataAccess.DataModels;
using DataAccess.DataModels.Enums;
using DataAccess.Interfaces;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IVoteRepository : IRepository<Vote>
    {
        public List<Vote> GetAll();
        public List<Vote> GetByPostId(int postId);
        public List<Vote> GetByUserId(int userId);
        public Vote GetVoteById(int voteId);
        public Vote getVote(int userId, int postId, VoteTypes voteType);
        public Vote getVote(int userId, int postId);
    }
}