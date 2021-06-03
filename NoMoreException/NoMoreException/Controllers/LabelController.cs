using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public Task AddLabelAsync(LabelDto label)
        {
            return Task.FromResult(Ioc.Resolve<ILabelObject>().CreateLabel(label));
        }
    }
}
