using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using Shared.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMoreException.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<LabelDto> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Ioc.Resolve<ILabelObject>().GetById(1));
        }

        //public Task<List<AttachmentDto>> GetAttachments()
        //{
        //    return Task.FromResult(Ioc.Resolve<IAttachmentObject>().GetAttachmentsByPostId(2));
        //}

        //public Task<AttachmentDto> GetAttachment()
        //{
        //    return Task.FromResult(Ioc.Resolve<IAttachmentObject>().GetById(4));
        //}

        public void DeleteAttachment(int id)
        {
            Ioc.Resolve<IAttachmentObject>().RemoveById(id);
        }

        public void deleteLabel()
        {
           // Ioc.Resolve<ILabelObject>().Remove(1);
        }
    }
}
