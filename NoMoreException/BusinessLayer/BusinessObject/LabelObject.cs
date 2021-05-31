using BaseTypes.Shared;
using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessObject
{
    public class LabelObject:BaseBusinessObject,ILabelObject
    {
        public LabelDto Get(int id)
        {
            var repository = FindService<ILabelRepository>();
            var result = repository.Get(id);

            return new LabelDto {Id=result.Id,Text=result.Text };
        }
    }
}
