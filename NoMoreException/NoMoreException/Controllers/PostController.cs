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
    public class PostController: ControllerBase
    {
        public PostDto PostDto { get; private set; }

        public void CreateVote(PostDto post)
        {
            Ioc.Resolve<IPostObject>().CreatePost(post);
        }
        public void UpdateScore(PostDto post)
        {
            Ioc.Resolve<IPostObject>().UpdatePost(post);
        }

        public List<PostDto> GetAll()
        {
            return Ioc.Resolve<IPostObject>().GetAll();
        }

        public PostDto GetPostById(int id)
        {
            return Ioc.Resolve<IPostObject>().GetPostById(id);
        }

        public void RemoveById(int postId)
        {
            Ioc.Resolve<IPostObject>().RemoveById(postId);
        }
        public List<PostDto> GetAllActiveQuestions()
        {
            return Ioc.Resolve<IPostObject>().GetAllActiveQuestions();
        }
        public List<PostDto> GetByParentId(int parentid)
        {
            return Ioc.Resolve<IPostObject>().GetByParentId(parentid);
        }
    }
}
