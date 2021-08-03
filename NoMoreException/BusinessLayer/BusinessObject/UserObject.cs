using BaseTypes.Shared;
using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using BusinessLayer.Mapping;
using DataAccess.DataModels;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessObject
{
    public class UserObject : BaseBusinessObject, IUserObject
    {
        public UserDto GetById(int id)
        {
            var repository = FindService<IUserRepository>();
            var result = repository.GetById(id);

            return MappingFactory.Map<User, UserDto>(result);
        }

        public void RemoveById(int id)
        {
            var repository = FindService<IUserRepository>();
            repository.RemoveById(id);
        }

        public UserDto Get(String username, String password)
        {
            var repository = FindService<IUserRepository>();
            var result = repository.Get(username, password);
            return MappingFactory.Map<User, UserDto>(result);
        }

        public List<UserDto> GetAll()
        {
            var repository = FindService<IUserRepository>();
            var result = repository.GetAll();
            return MappingFactory.MapList<User, UserDto>(result);
        }

        public UserDto Authenticate(String username, String password)
        {
            var repository = FindService<IUserRepository>();
            var result = repository.Authenticate(username, password);

            if (result == null)
                return null;

            return MappingFactory.Map<User, UserDto>(result);
        }

        public void CreateUser(UserDto newUserDto)
        {
            var repository = FindService<IUserRepository>();
            repository.AddAsync(MappingFactory.Map<UserDto, User> (newUserDto));
        }

        public async Task UpdateUser(UserDto userDto)
        {
            var repository = FindService<IUserRepository>();
            await repository.UpdateAsync(MappingFactory.Map<UserDto, User>(userDto));
        }

        public void RemoveUser(UserDto userDto)
        {
            var repository = FindService<IUserRepository>();
            repository.Remove(MappingFactory.Map<UserDto, User>(userDto));
        }
    }
}
