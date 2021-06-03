using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using Shared.BaseTypes;

namespace NoMoreException.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        public UserDto UserDto { get; private set; }

        public Task<UserDto> GetUser(UserDto user)
        {
            UserDto = Ioc.Resolve<IUserObject>().Authenticate(user.Username, user.Password);
            return Task.FromResult(UserDto);
        }

        public void CreateUser(UserDto user)
        {
            Ioc.Resolve<IUserObject>().CreateUser(user);
        }

        public void UpdateUser(UserDto user)
        {
            Ioc.Resolve<IUserObject>().UpdateUser(user);
        }

        public void RemoveUser(UserDto user)
        {
            Ioc.Resolve<IUserObject>().RemoveUser(user);
        }
        public void RemoveById(int id)
        {
            Ioc.Resolve<IUserObject>().RemoveById(id);
        }

        public List<UserDto> GetAll()
        {
            return Ioc.Resolve<IUserObject>().GetAll();
        }

        public Task<UserDto> Details(int id)
        {
            return Task.FromResult(Ioc.Resolve<IUserObject>().GetById(id));
        }
    }
}