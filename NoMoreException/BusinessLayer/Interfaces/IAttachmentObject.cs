using BusinessLayer.Dtos;
using DataAccess.DataModels;
using Shared.BaseTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IAttachmentObject : IBusinessObject
    {
        AttachmentDto GetById(int id);
        void Remove(AttachmentDto attachmentDto);
        void RemoveById(int id);
        List<AttachmentDto> GetAttachmentsByPostId(int postId);
        List<AttachmentDto> GetAttachmentsByCommentId(int commentId);
        Task UpdateAttachment(AttachmentDto attachmentDto);
        void CreateAttachment(AttachmentDto newAttachmentDto);
    }
}