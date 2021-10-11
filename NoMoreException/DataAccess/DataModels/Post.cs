using DataAccess.DataModels.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.DataModels
{
    public record Post:Base
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [DefaultValue(0)]
        public bool Active { get; set; }

        [Required]
        [DefaultValue(PostTypes.Question)]
        public PostTypes PostType { get; set; }

        [DefaultValue(0)]
        public int? ParentId { get; set; }

        [DefaultValue(0)]
        public int? AcceptedAnswerId { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [DefaultValue(0)]
        public int? Score { get; set; }

        [DefaultValue(0)]
        public int? ViewCount { get; set; }

        [Required]
        public string Body { get; set; }
        
        [Required]
        public User User { get; set; }

        public DateTime? LastEditingDate { get; set; }

        [DefaultValue(0)]
        public int? AnswerCount { get; set; }

        [DefaultValue(0)]
        public int? CommentCount { get; set; }

        public DateTime? ClosedDate { get; set; }
        
        //public string Label { get; set; }
    }
}
