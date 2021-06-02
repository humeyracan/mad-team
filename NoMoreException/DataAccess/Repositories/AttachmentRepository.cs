using DataAccess.DataModels;
using DataAccess.DBContext;
using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class AttachmentRepository : Repository<Attachment>, IAttachmentRepository
    {
        public List<Attachment> GetByPostId(int postId)
        {
            List<Attachment> attachments = new List<Attachment>();
            var factory = new DbContextFactory();
            string[] stringArray = new string[6];
            using (var context = factory.CreateDbContext(stringArray))
            {
                foreach (var query in context.Attachments.Include(a => a.Post).Where(x => x.Post.Id == postId))
                {
                    if (query != null)
                        attachments.Add(query);
                }
            }
            return attachments;
        }

        public List<Attachment> GetByCommentId(int commentId)
        {
            List<Attachment> attachments = new List<Attachment>();
            var factory = new DbContextFactory();
            string[] stringArray = new string[6];
            using (var context = factory.CreateDbContext(stringArray))
            {
                foreach (var query in context.Attachments.Include(a => a.Comment).Where(x => x.Comment.Id == commentId))
                {
                    if (query != null)
                        attachments.Add(query);
                }
            }
            return attachments;
        }
    }
}
