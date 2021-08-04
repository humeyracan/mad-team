using BusinessLayer.Dtos;
using DataAccess.DataModels;
using Shared.BaseTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUserObject : IBusinessObject
    {
        public UserDto Get(string username);
        public List<UserDto> GetAll();
        public UserDto GetById(int id);
        public UserDto Authenticate(String username, String password);
        void RemoveUser(UserDto userDto);
        void RemoveById(int id);
        Task UpdateUser(UserDto userDto);
        void CreateUser(UserDto newUserDto);
    }
}
