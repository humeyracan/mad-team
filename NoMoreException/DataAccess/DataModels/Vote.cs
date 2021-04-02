using DataAccess.DataModels.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DataModels
{
    public record Vote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Post Post { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public VoteTypes VoteType { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
