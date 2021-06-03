using BusinessLayer.Dtos;
using DataAccess.DataModels;
using Shared.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ILabelObject:IBusinessObject
    {
        //public LabelDto Get(int id);
        //public void Remove(int id);

        LabelDto GetById(int id);
        void Remove(LabelDto label);
        void RemoveById(int id);
        //List<LabelDto> GetAttachmentsByPostId(int postId);
        //List<LabelDto> GetAttachmentsByCommentId(int commentId);
        Task UpdateLabel(LabelDto label);
        Task CreateLabel(LabelDto label);
    }
}
