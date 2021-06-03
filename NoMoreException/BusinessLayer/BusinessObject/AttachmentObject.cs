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

            return MappingFactory.Map<Attachment,AttachmentDto>(result);
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
            repository.AddAsync(MappingFactory.Map<AttachmentDto,Attachment>(newAttachmentDto));
        }

        public async Task UpdateAttachment(AttachmentDto attachmentDto)
        {
            var repository = FindService<IAttachmentRepository>();
            await repository.UpdateAsync(MappingFactory.Map<AttachmentDto, Attachment>(attachmentDto));
        }

        public void RemoveAttachment(AttachmentDto attachmentDto)
        {
            var repository = FindService<IAttachmentRepository>();
            repository.Remove(MappingFactory.Map<AttachmentDto, Attachment>(attachmentDto));
        }
    }
}
