using System;
using System.Collections.Generic;

namespace BusinessLayer.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int? Score { get; set; }
        public string CommentText { get; set; }
        public PostDto Post { get; set; }
        public UserDto User { get; set; }
        public List<AttachmentDto> Attachments { get; set; }
    }
}
