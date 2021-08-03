using BusinessLayer.Dtos;
using Shared.BaseTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICommentObject : IBusinessObject
    {
        CommentDto GetById(int id);
        void RemoveComment(CommentDto commentDto);
        void RemoveById(int id);
        List<CommentDto> GetCommentsByPostId(int postId);
        List<CommentDto> GetCommentsByUserId(int userId);
        Task UpdateComment(CommentDto commentDto);
        void CreateComment(CommentDto commentDto);
    }
}