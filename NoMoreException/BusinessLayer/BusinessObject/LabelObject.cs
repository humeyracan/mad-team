using AutoMapper;
using BaseTypes.Shared;
using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using DataAccess.Interfaces;

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

        public void Remove(int id)
        {
            //var repository = FindService<ILabelRepository>();
            //repository.RemoveById(id);
        }
    }
}
