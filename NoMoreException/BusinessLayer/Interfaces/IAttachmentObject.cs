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
        void Remove(Attachment Attachment);
        void RemoveById(int id);
        List<AttachmentDto> GetAttachmentsByPostId(int postId);
        List<AttachmentDto> GetAttachmentsByCommentId(int commentId);
        Task UpdateAttachment(Attachment Attachment);
        void CreateAttachment(Attachment newAttachment);
    }
}