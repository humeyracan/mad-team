using BusinessLayer.BusinessObject;
using BusinessLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMoreException.Controllers
{
    public class VoteController: ControllerBase
    {
        public VoteDto VoteDto { get; private set; }

        public void CreateVote(VoteDto vote)
        {
            Ioc.Resolve<IVoteObject>().CreateVote(vote);
        }
        public void UpdateVote(VoteDto vote)
        {
            Ioc.Resolve<IVoteObject>().UpdateVote(vote);
        }

        public List<VoteDto> GetAll()
        {
            return Ioc.Resolve<IVoteObject>().GetAll();
        }

        public Task<VoteDto> GetVotebyId(int id)
        {
            return Task.FromResult(Ioc.Resolve<IVoteObject>().GetById(id));
        }

        public List<VoteDto> GetVotesByPostId(int postId)
        {
            return Ioc.Resolve<IVoteObject>().GetVotesByPostId(postId);
        }

        public List<VoteDto> GetVotesByUserId(int userId)
        {
            return Ioc.Resolve<IVoteObject>().GetVotesByUserId(userId);
        }

        public void RemoveById(int voteid)
        {
            Ioc.Resolve<IVoteObject>().RemoveById(voteid);
        }


    }
}
