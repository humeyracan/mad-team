using BaseTypes.Shared;
using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
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

            return new UserDto
            {
                Id = result.Id,
                Username = result.Username,
                FullName = result.FullName,
                UserType = result.UserType,
                Email = result.Email,
                Password = result.Password,
                RegistryDate = result.RegistryDate,
                Active = result.Active,
                ProfileImage = result.ProfileImage
            };
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
            return new UserDto { Username = result.Username, Password = result.Password };
        }

        public List<UserDto> GetAll()
        {
            List<UserDto> users = new List<UserDto>();
            var repository = FindService<IUserRepository>();
            var result = repository.GetAll();

            foreach (var user in result)
            {
                users.Add(new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    FullName = user.FullName,
                    UserType = user.UserType,
                    Email = user.Email,
                    Password = user.Password,
                    RegistryDate = user.RegistryDate,
                    Active = user.Active,
                    ProfileImage = user.ProfileImage
                });
            }
            return users;
        }

        public UserDto Authenticate(String username, String password)
        {
            var repository = FindService<IUserRepository>();
            var result = repository.Authenticate(username, password);

            if (result == null)
                return null;

            return new UserDto { Username = result.Username, Password = result.Password };
        }

        public void CreateUser(UserDto newUserDto)
        {
            //todo: UserDto'yu User modeline cevirme isi mapper'la yapilacak.
            var repository = FindService<IUserRepository>();
            repository.AddAsync(new User { });
        }

        public async Task UpdateUser(UserDto userDto)
        {
            //todo: UserDto'yu User modeline cevirme isi mapper'la yapilacak.
            var repository = FindService<IUserRepository>();
            await repository.UpdateAsync(new User { });
        }

        public void RemoveUser(UserDto userDto)
        {
            //todo: UserDto'yu User modeline cevirme isi mapper'la yapilacak.
            var repository = FindService<IUserRepository>();
            repository.Remove(new User { });
        }
    }
}
