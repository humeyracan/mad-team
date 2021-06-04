using BaseTypes.Shared;
using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using BusinessLayer.Mapping;
using DataAccess.DataModels;
using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessObject
{
    public class CommentObject : BaseBusinessObject, ICommentObject
    {
        public CommentDto GetById(int id)
        {
            var repository = FindService<ICommentRepository>();
            var result = repository.GetByIdWithUserAndPost(id);

            return MappingFactory.Map<Comment, CommentDto>(result);
        }

        public List<CommentDto> GetCommentsByPostId(int postId)
        {
            var repository = FindService<ICommentRepository>();
            var result = repository.GetByPostId(postId);
            List<CommentDto> comments = MappingFactory.MapList<Comment, CommentDto>(result);
            return comments;
        }

        public List<CommentDto> GetCommentsByUserId(int userId)
        {
            var repository = FindService<ICommentRepository>();
            var result = repository.GetByUserId(userId);
            List<CommentDto> comments = MappingFactory.MapList<Comment, CommentDto>(result);
            return comments;
        }
        public async Task UpdateComment(CommentDto commentDto)
        {
            var repository = FindService<ICommentRepository>();
            await repository.UpdateAsync(MappingFactory.Map<CommentDto, Comment>(commentDto));
        }
        public void CreateComment(CommentDto commentDto)
        {
            var repository = FindService<ICommentRepository>();
            repository.AddAsync(MappingFactory.Map<CommentDto, Comment>(commentDto));
        }
        public void RemoveComment(CommentDto commentDto)
        {
            var repository = FindService<ICommentRepository>();
            repository.Remove(MappingFactory.Map<CommentDto, Comment>(commentDto));
        }
        public void RemoveById(int id)
        {
            var repository = FindService<ICommentRepository>();
            repository.RemoveById(id);
        }
    }
}
