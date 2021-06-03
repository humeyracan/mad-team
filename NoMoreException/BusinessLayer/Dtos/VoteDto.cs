using System;

namespace BusinessLayer.Dtos
{
    public class VoteDto
    {
        public int Id { get; set; }
        public PostDto  Post{ get; set; }
        public int VoteType { get; set; }   
        public UserDto User { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
