using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dtos
{
    public class VoteDto
    {
        public int Id { get; set; }
        public PostDto  Post{ get; set; }
        public int VoteType { get; set; }
        //public UserDto User { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
