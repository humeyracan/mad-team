using BusinessLayer.Dtos;
using Shared.BaseTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessObject
{
    public interface IVoteObject:IBusinessObject
    {
        public List<VoteDto> GetAll();
        public VoteDto GetById(int voteId);
        public List<VoteDto> GetVotesByPostId(int voteId);
        public List<VoteDto> GetVotesByUserId(int voteId);
        Task UpdateVote(VoteDto votedto);
        void CreateVote(VoteDto votedto);
        void Remove(VoteDto votedto);
        void RemoveById(int id);
    }
}