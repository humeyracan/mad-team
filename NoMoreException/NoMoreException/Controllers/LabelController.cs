using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseTypes;
using System.Threading.Tasks;

namespace NoMoreException.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class LabelController : ControllerBase
    {
        public Task<LabelDto> GetLabelAsync(int id)
        {
            return Task.FromResult(Ioc.Resolve<ILabelObject>().GetById(id));
        }
        public void AddLabelAsync(LabelDto labelDto)
        {
          Ioc.Resolve<ILabelObject>().CreateLabel(labelDto);

        }
        public void UpdateAttachment(LabelDto labelDto)
        {
            Ioc.Resolve<ILabelObject>().UpdateLabel(labelDto);
        }

        public void RemoveAttachment(LabelDto labelDto)
        {
            Ioc.Resolve<ILabelObject>().RemoveLabel(labelDto);
        }

        public void RemoveById(int id)
        {
            Ioc.Resolve<ILabelObject>().RemoveById(id);
        }
    }
}
