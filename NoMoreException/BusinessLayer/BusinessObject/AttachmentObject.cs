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
    public class AttachmentObject : BaseBusinessObject, IAttachmentObject
    {
        public AttachmentDto GetById(int id)
        {
            var repository = FindService<IAttachmentRepository>();
            var result = repository.GetById(id);

            return MappingFactory.GetMapper().Map<AttachmentDto>(result);
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
            List<AttachmentDto> attachments = MappingFactory.MapList<Attachment, AttachmentDto>(result);

            foreach (var attachment in result)
            {
                attachments.Add(new AttachmentDto
                {
                    Id = attachment.Id,
                    //todo
                    //Post = new PostDto { Id = attachment.Post.Id, Title = attachment.Post.Title },
                    AttachmentNr = attachment.AttachmentNr,
                    AttachmentType = attachment.AttachmentType,
                    AttachmentData = attachment.AttachmentData
                });
            }
            return attachments;
        }

        public List<AttachmentDto> GetAttachmentsByCommentId(int commentId)
        {
            var repository = FindService<IAttachmentRepository>();
            var result = repository.GetByCommentId(commentId);
            List<AttachmentDto> attachments = MappingFactory.MapList<Attachment,AttachmentDto>(result);
            return attachments;
        }

        public void CreateAttachment(AttachmentDto newAttachmentDto)
        {
            var repository = FindService<IAttachmentRepository>();
            repository.AddAsync(MappingFactory.GetMapper().Map<Attachment>(newAttachmentDto));
        }

        public async Task UpdateAttachment(AttachmentDto attachmentDto)
        {
            var repository = FindService<IAttachmentRepository>();
            await repository.UpdateAsync(MappingFactory.GetMapper().Map<Attachment>(attachmentDto));
        }

        public void RemoveAttachment(AttachmentDto attachmentDto)
        {
            var repository = FindService<IAttachmentRepository>();
            repository.Remove(MappingFactory.GetMapper().Map<Attachment>(attachmentDto));
        }
    }
}
