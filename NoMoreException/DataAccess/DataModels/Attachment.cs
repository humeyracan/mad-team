using DataAccess.DataModels.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.DataModels
{
    public record Attachment : Base
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Post Post { get; set; }

        [Required]
        public Comment Comment { get; set; }

        [Required]
        public AttachmentTypes AttachmentType { get; set; }

        [Required]
        [DefaultValue(0)]
        public int AttachmentNr { get; set; }

        public byte[] AttachmentData { get; set; }
    }
}
