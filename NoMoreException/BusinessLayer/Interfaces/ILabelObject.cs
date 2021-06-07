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

        LabelDto GetById(int id);
        void RemoveLabel(LabelDto label);
        void RemoveById(int id);
        Task UpdateLabel(LabelDto label);
        void CreateLabel(LabelDto label);
    }
}
