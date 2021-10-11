using DataAccess.DataModels.Enums;
using System;

namespace BusinessLayer.Dtos
{
    public class VoteDto
    {
        public int Id { get; set; }
        public PostDto  Post{ get; set; }
        public VoteTypes VoteType { get; set; }   
        public UserDto User { get; set; }
        public DateTime CreationDate { get; set; }

        public int PostId { get; set; }

        public int UserId { get; set; }
    }
}
