using BusinessLayer.Dtos;
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
        public LabelDto Get(int id);
        public void Remove(int id);
    }
}
