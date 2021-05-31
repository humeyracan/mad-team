using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using Shared.BaseTypes;
using System;
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
            return Task.FromResult(Ioc.Resolve<ILabelObject>().Get(1));
        }
    }
}
