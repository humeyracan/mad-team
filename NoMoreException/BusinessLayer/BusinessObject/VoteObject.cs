using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BaseTypes.Shared;
using BusinessLayer.Dtos;
using BusinessLayer.Mapping;
using DataAccess.DataModels;
using DataAccess.DataModels.Enums;
using DataAccess.Repositories;

namespace BusinessLayer.BusinessObject
{
    public class VoteObject: BaseBusinessObject, IVoteObject
    {
        public List<VoteDto> GetAll()
        {
            var repository = FindService<IVoteRepository>();
            var result = repository.GetAll();

            return MappingFactory.MapList<Vote, VoteDto>(result);
            
        }
        public VoteDto GetById(int voteId)
        {
            var repository = FindService<IVoteRepository>();
            var result = repository.GetVoteById(voteId);

            return MappingFactory.Map<Vote, VoteDto>(result);
        }
        public VoteDto getVote(int userId, int postId, VoteTypes voteType)
        {
            var repository = FindService<IVoteRepository>();
            var result = repository.getVote(userId, postId, voteType);
            return MappingFactory.Map<Vote, VoteDto>(result);
        }
        public VoteDto getVote(int userId, int postId)
        {
            var repository = FindService<IVoteRepository>();
            var result = repository.getVote(userId, postId);
            return MappingFactory.Map<Vote, VoteDto>(result);
        }

        public List<VoteDto> GetVotesByPostId(int postId)
        {
            var repository = FindService<IVoteRepository>();
            var result = repository.GetByPostId(postId);
          
            return MappingFactory.MapList<Vote, VoteDto>(result);
           
        }
        public List<VoteDto> GetVotesByUserId(int postId)
        {
            var repository = FindService<IVoteRepository>();
            var result = repository.GetByUserId(postId);

            return MappingFactory.MapList<Vote, VoteDto>(result);
        }
        public async Task UpdateVote(VoteDto votedto)
        {
            var repository = FindService<IVoteRepository>();
            await repository.UpdateAsync(MappingFactory.Map<VoteDto, Vote>(votedto));
        }
        public void CreateVote(VoteDto newVote)
        {
            var repository = FindService<IVoteRepository>();
            repository.AddAsync(MappingFactory.Map<VoteDto, Vote>(newVote));
        }
        public void Remove(VoteDto votedto)
        {
            var repository = FindService<IVoteRepository>();
            repository.Remove(MappingFactory.Map<VoteDto, Vote>(votedto));
        }
        public void RemoveById(int id)
        {
            var repository = FindService<IVoteRepository>();
            repository.RemoveById(id);
        }

    }
}
