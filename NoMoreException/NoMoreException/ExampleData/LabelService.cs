using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using Shared.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMoreException.ExampleData
{
    public class LabelService
    {
        public Task<LabelDto> GetLabelAsync()
        {
            return Task.FromResult(Ioc.Resolve<ILabelObject>().GetById(1));
        }
        public Task AddLabelAsync(LabelDto label)
        {
            return Task.FromResult(Ioc.Resolve<ILabelObject>().CreateLabel(label));
        }
    }
}
