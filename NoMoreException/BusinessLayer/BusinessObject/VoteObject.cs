using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BaseTypes.Shared;
using BusinessLayer.Dtos;
using DataAccess.DataModels;
using DataAccess.Repositories;

namespace BusinessLayer.BusinessObject
{
    public class VoteObject: BaseBusinessObject, IVoteObject
    {
        public List<VoteDto> GetAll()
        {
            List<VoteDto> votes = new List<VoteDto>();
            var repository = FindService<IVoteRepository>();
            var result = repository.GetAll();

            foreach (var vote in result)
            {
                votes.Add(new VoteDto
                {
                    Id = vote.Id,
                    Post = new PostDto
                    {
                        Id = vote.Post.Id,
                        Active = Convert.ToInt32(vote.Post.Active),
                        Title = vote.Post.Title,
                        Body = vote.Post.Body,
                        CreationDate = vote.Post.CreationDate,
                        AcceptedAnswerId = (int)vote.Post.AcceptedAnswerId,
                        AnswerCount = (int)vote.Post.AnswerCount,
                        PostType = (int)vote.Post.PostType,
                        ParentId = (int)vote.Post.ParentId,
                        Score = (int)vote.Post.Score,
                        CommentCount = (int)vote.Post.CommentCount,
                        ClosedDate = (DateTime)vote.Post.ClosedDate,
                        ViewCount = (int)vote.Post.ViewCount,
                        LastEditingDate = (DateTime)vote.Post.LastEditingDate
                    },
                    //User ile ilgili kısım eklenecek.
                    VoteType = (int)vote.VoteType,
                    CreationDate = vote.CreationDate
                });
            }
            return votes;
        }
        public VoteDto GetById(int voteId)
        {
            var repository = FindService<IVoteRepository>();
            var result = repository.GetVoteById(voteId);

            return new VoteDto
                {
                    Id = result.Id,
                    Post = new PostDto
                    {
                        Id = result.Post.Id,
                        Active = Convert.ToInt32(result.Post.Active),
                        Title = result.Post.Title,
                        Body = result.Post.Body,
                        CreationDate = result.Post.CreationDate,
                        AcceptedAnswerId = (int)result.Post.AcceptedAnswerId,
                        AnswerCount = (int)result.Post.AnswerCount,
                        PostType = (int)result.Post.PostType,
                        ParentId = (int)result.Post.ParentId,
                        Score = (int)result.Post.Score,
                        CommentCount = (int)result.Post.CommentCount,
                        ClosedDate = (DateTime)result.Post.ClosedDate,
                        ViewCount = (int)result.Post.ViewCount,
                        LastEditingDate = (DateTime)result.Post.LastEditingDate
                    },
                    //User ile ilgili kısım eklenecek.
                    VoteType = (int)result.VoteType,
                    CreationDate = result.CreationDate
                };
            
        }
        public List<VoteDto> GetVotesByPostId(int postId)
        {
            var repository = FindService<IVoteRepository>();
            var result = repository.GetByPostId(postId);
            List<VoteDto> votes = new List<VoteDto>();

            foreach (var _vote in result)
            {
                votes.Add(new VoteDto
                {
                    Id = _vote.Id,
                    Post = new PostDto
                    {
                        Id = _vote.Post.Id,
                        Active = Convert.ToInt32(_vote.Post.Active),
                        Title = _vote.Post.Title,
                        Body = _vote.Post.Body,
                        CreationDate = _vote.Post.CreationDate,
                        AcceptedAnswerId = (int)_vote.Post.AcceptedAnswerId,
                        AnswerCount = (int)_vote.Post.AnswerCount,
                        PostType = (int)_vote.Post.PostType,
                        ParentId = (int)_vote.Post.ParentId,
                        Score = (int)_vote.Post.Score,
                        CommentCount = (int)_vote.Post.CommentCount,
                        ClosedDate = (DateTime)_vote.Post.ClosedDate,
                        ViewCount = (int)_vote.Post.ViewCount,
                        LastEditingDate = (DateTime)_vote.Post.LastEditingDate
                    },
                    //User ile ilgili kısım eklenecek.
                    VoteType = (int) _vote.VoteType,
                    CreationDate = _vote.CreationDate
                });
            }
            return votes;
        }
        public List<VoteDto> GetVotesByUserId(int postId)
        {
            var repository = FindService<IVoteRepository>();
            var result = repository.GetByUserId(postId);
            List<VoteDto> votes = new List<VoteDto>();

            foreach (var _vote in result)
            {
                votes.Add(new VoteDto
                {
                    Id = _vote.Id,
                    //Post = new PostDto { Id = _vote.Post.Id,Active=Convert.ToInt32(_vote.Post.Active), Title = _vote.Post.Title, Body = _vote.Post.Body, 
                    //    CreationDate = _vote.Post.CreationDate, AcceptedAnswerId= (int)_vote.Post.AcceptedAnswerId, AnswerCount =(int) _vote.Post.AnswerCount,
                    //    PostType =(int) _vote.Post.PostType,ParentId =(int) _vote.Post.ParentId, Score =(int) _vote.Post.Score, CommentCount =(int) _vote.Post.CommentCount,
                    //    ClosedDate =(DateTime) _vote.Post.ClosedDate,ViewCount =(int) _vote.Post.ViewCount, LastEditingDate =(DateTime) _vote.Post.LastEditingDate
                    //},
                    //User ile ilgili kısım eklenecek.
                    VoteType = (int)_vote.VoteType,
                    CreationDate = _vote.CreationDate
                });
            }
            return votes;
        }
        public async Task UpdateVote(VoteDto votedto)
        {
            Vote vote = new Vote { };
            var repository = FindService<IVoteRepository>();
            await repository.UpdateAsync(vote);
        }
        public void CreateVote(VoteDto newVote)
        {
            Vote vote =new Vote {};
            var repository = FindService<IVoteRepository>();
            repository.AddAsync(vote);
        }
        public void Remove(VoteDto votedto)
        {
            Vote vote = new Vote { };
            var repository = FindService<IVoteRepository>();
            repository.Remove(vote);
        }
        public void RemoveById(int id)
        {
            var repository = FindService<IVoteRepository>();
            repository.RemoveById(id);
        }

    }
}
