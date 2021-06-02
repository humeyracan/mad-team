using System.ComponentModel.DataAnnotations;

namespace DataAccess.DataModels
{
    public record Label : Base
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Text { get; set; }
    }
}
