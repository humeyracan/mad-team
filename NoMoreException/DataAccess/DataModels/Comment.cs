using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;

namespace DataAccess.DataModels
{
    public record Comment : Base
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [DefaultValue(0)]
        public int? Score { get; set; }

        [Required]
        public string CommentText { get; set; }

        [Required]
        public Post Post { get; set; }

        [Required]
        public User User { get; set; }
    }
}
