using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using Shared.BaseTypes;

namespace NoMoreException.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CommentController : ControllerBase
    {
        public CommentDto CommentDto { get; private set; }

        public Task<CommentDto> GetComment(int id)
        { 
            CommentDto = Ioc.Resolve<ICommentObject>().GetById(id);
            return Task.FromResult(CommentDto);
        }

        public void CreateComment(CommentDto commentDto)
        {
            Ioc.Resolve<ICommentObject>().CreateComment(commentDto);
        }

        public void UpdateComment(CommentDto commentDto)
        {
            Ioc.Resolve<ICommentObject>().UpdateComment(commentDto);
        }

        public void RemoveComment(CommentDto commentDto)
        {
            Ioc.Resolve<ICommentObject>().RemoveComment(commentDto);
        }

        public void RemoveById(int id)
        {
            Ioc.Resolve<ICommentObject>().RemoveById(id);
        }

        public List<CommentDto> GetCommentsByPostId(int postId)
        {
            return Ioc.Resolve<ICommentObject>().GetCommentsByPostId(postId);
        }

        public List<CommentDto> GetCommentsByUserId(int userId)
        {
            return Ioc.Resolve<ICommentObject>().GetCommentsByUserId(userId);
        }

        public Task<CommentDto> Details(int id)
        {
            return Task.FromResult(Ioc.Resolve<ICommentObject>().GetById(id));
        }
    }
}
