using BusinessLayer.Dtos;
using DataAccess.DataModels.Enums;
using Shared.BaseTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessObject
{
    public interface IVoteObject:IBusinessObject
    {
        public List<VoteDto> GetAll();
        public VoteDto GetById(int voteId);

        public VoteDto getVote(int userId, int postId, VoteTypes voteType);
        public VoteDto getVote(int userId, int postId);
        public List<VoteDto> GetVotesByPostId(int voteId);
        public List<VoteDto> GetVotesByUserId(int voteId);
        Task UpdateVote(VoteDto votedto);
        void CreateVote(VoteDto votedto);
        void Remove(VoteDto votedto);
        void RemoveById(int id);
    }
}