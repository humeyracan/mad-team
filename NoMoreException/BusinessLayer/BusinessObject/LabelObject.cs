using AutoMapper;
using BaseTypes.Shared;
using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
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

            return new LabelDto {Id=result.Id,Text=result.Text };
        }
        public async Task UpdateLabel(LabelDto label)
        {
            var repository = FindService<ILabelRepository>();
            await repository.UpdateAsync(new Label { });
        }
        public Task CreateLabel(LabelDto label)
        {
            var repository = FindService<ILabelRepository>();
            return repository.AddAsync(new Label {});
        }
        public void RemoveById(int id)
        {
            var repository = FindService<ILabelRepository>();
            repository.RemoveById(id);
        }
        public void Remove(LabelDto label)
        {
            var repository = FindService<ILabelRepository>();
            repository.Remove(new Label { });
        }

    }
}
