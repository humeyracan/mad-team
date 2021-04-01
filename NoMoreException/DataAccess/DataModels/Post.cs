using DataAccess.DataModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModels
{
    public record Post
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public PostType PostType { get; set; }

        public int ParentId { get; set; }

        public int AcceptedAnswerId { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [DefaultValue(0)]
        public int Score { get; set; }

        public int ViewCount { get; set; }

        [Required]
        public string Body { get; set; }
        
        [Required]
        public User User { get; set; }

        public DateTime LastEditingDate { get; set; }

        [DefaultValue(0)]
        public int AnswerCount { get; set; }

        [DefaultValue(0)]
        public int CommentCount { get; set; }

        public DateTime ClosedDate { get; set; }

    }
}
