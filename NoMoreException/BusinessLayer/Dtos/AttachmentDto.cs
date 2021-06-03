using DataAccess.DataModels.Enums;

namespace BusinessLayer.Dtos
{
    public class AttachmentDto
    {
        public int Id { get; set; }
        //todo
        //public PostDto Post { get; set; }
        //public CommentDto Comment { get; set; }
        public AttachmentTypes AttachmentType { get; set; }
        public int AttachmentNr { get; set; }
        public byte[] Data { get; set; }
    }
}
