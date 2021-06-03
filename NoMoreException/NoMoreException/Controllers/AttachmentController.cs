using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using Shared.BaseTypes;

namespace NoMoreException.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AttachmentController : ControllerBase
    {
        public AttachmentDto AttachmentDto { get; private set; }

        public Task<AttachmentDto> GetAttachment(int id)
        {
            AttachmentDto = Ioc.Resolve<IAttachmentObject>().GetById(id);
            return Task.FromResult(AttachmentDto);
        }

        public void CreateAttachment(AttachmentDto attachmentDto)
        {
            Ioc.Resolve<IAttachmentObject>().CreateAttachment(attachmentDto);
        }

        public void UpdateAttachment(AttachmentDto attachmentDto)
        {
            Ioc.Resolve<IAttachmentObject>().UpdateAttachment(attachmentDto);
        }

        public void RemoveAttachment(AttachmentDto attachmentDto)
        {
            Ioc.Resolve<IAttachmentObject>().RemoveAttachment(attachmentDto);
        }

        public void RemoveById(int id)
        {
            Ioc.Resolve<IAttachmentObject>().RemoveById(id);
        }

        public List<AttachmentDto> GetAttachmentsByPostId(int postId)
        {
            return Ioc.Resolve<IAttachmentObject>().GetAttachmentsByPostId(postId);
        }

        public List<AttachmentDto> GetAttachmentsByCommentId(int commentId)
        {
            return Ioc.Resolve<IAttachmentObject>().GetAttachmentsByCommentId(commentId);
        }

        public Task<AttachmentDto> Details(int id)
        {
            return Task.FromResult(Ioc.Resolve<IAttachmentObject>().GetById(id));
        }
    }
}