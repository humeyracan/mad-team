using DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Active { get; set; }
        public int PostType { get; set; }
        public int ParentId { get; set; }
        public int AcceptedAnswerId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public int ViewCount { get; set; }
        public string Body { get; set; }
        public User User { get; set; }
        public DateTime LastEditingDate { get; set; }
        public int AnswerCount { get; set; }
        public int CommentCount { get; set; }
        public DateTime ClosedDate { get; set; }
    }
}
