using BaseTypes.Shared;
using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using DataAccess.DataModels;
using DataAccess.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessObject
{
    public class AttachmentObject : BaseBusinessObject, IAttachmentObject
    {
        public AttachmentDto GetById(int id)
        {
            var repository = FindService<IAttachmentRepository>();
            var result = repository.GetById(id);

            return new AttachmentDto
            {
                Id = result.Id,
                AttachmentNr = result.AttachmentNr,
                AttachmentType = result.AttachmentType,
                Data = result.AttachmentData
            };
        }

        public void Remove(Attachment Attachment)
        {
            var repository = FindService<IAttachmentRepository>();
            repository.Remove(Attachment);
        }

        public void RemoveById(int id)
        {
            var repository = FindService<IAttachmentRepository>();
            repository.RemoveById(id);
        }

        public List<AttachmentDto> GetAttachmentsByPostId(int postId)
        {
            var repository = FindService<IAttachmentRepository>();
            var result = repository.GetByPostId(postId);
            List<AttachmentDto> attachments = new List<AttachmentDto>();

            foreach (var attachment in result)
            {
                attachments.Add(new AttachmentDto
                {
                    Id = attachment.Id,
                    //todo
                    //Post = new PostDto { Id = attachment.Post.Id, Title = attachment.Post.Title },
                    AttachmentNr = attachment.AttachmentNr,
                    AttachmentType = attachment.AttachmentType,
                    Data = attachment.AttachmentData
                });
            }
            return attachments;
        }

        public List<AttachmentDto> GetAttachmentsByCommentId(int commentId)
        {
            var repository = FindService<IAttachmentRepository>();
            var result = repository.GetByCommentId(commentId);
            List<AttachmentDto> attachments = new List<AttachmentDto>();

            foreach (var attachment in result)
            {
                attachments.Add(new AttachmentDto
                {
                    Id = attachment.Id,
                    //todo
                    //Comment = new CommentDto { Id = attachment.Comment.Id, },
                    AttachmentNr = attachment.AttachmentNr,
                    AttachmentType = attachment.AttachmentType,
                    Data = attachment.AttachmentData
                });
            }
            return attachments;
        }
        public async Task UpdateAttachment(Attachment Attachment)
        {
            var repository = FindService<IAttachmentRepository>();
            await repository.UpdateAsync(Attachment);
        }
        public void CreateAttachment(Attachment newAttachment)
        {
            var repository = FindService<IAttachmentRepository>();
            repository.AddAsync(newAttachment);
        }
    }
}
