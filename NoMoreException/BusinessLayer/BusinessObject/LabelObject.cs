using AutoMapper;
using BaseTypes.Shared;
using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using BusinessLayer.Mapping;
using DataAccess.DataModels;
using DataAccess.Interfaces;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessObject
{
    public class LabelObject:BaseBusinessObject,ILabelObject
    {
        public LabelDto GetById(int id)
        {
            var repository = FindService<ILabelRepository>();
            var result = repository.GetById(id);

            return MappingFactory.Map<Label,LabelDto>(result);
        }
        public async Task UpdateLabel(LabelDto labelDto)
        {
            var repository = FindService<ILabelRepository>();
            await repository.UpdateAsync(MappingFactory.Map<LabelDto, Label>(labelDto));
        }
        public void CreateLabel(LabelDto labelDto)
        {
            var repository = FindService<ILabelRepository>();
            repository.AddAsync(MappingFactory.Map<LabelDto, Label>(labelDto));
        }
        public void RemoveById(int id)
        {
            var repository = FindService<ILabelRepository>();
            repository.RemoveById(id);
        }
        public void RemoveLabel(LabelDto labelDto)
        {
            var repository = FindService<ILabelRepository>();
            repository.Remove(MappingFactory.Map<LabelDto,Label>(labelDto));
        }

    }
}
