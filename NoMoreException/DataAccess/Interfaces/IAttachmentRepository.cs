using DataAccess.DataModels;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IAttachmentRepository : IRepository<Attachment>
    {
        public List<Attachment> GetByPostId(int postId);
        public List<Attachment> GetByCommentId(int commentId);
    }
}
