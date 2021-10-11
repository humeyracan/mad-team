using BaseTypes.Shared;
using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using BusinessLayer.Mapping;
using DataAccess.DataModels;
using DataAccess.DataModels.Enums;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
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

        public UserDto Get(String username)
        {
            var repository = FindService<IUserRepository>();
            var result = repository.Get(username);
            return MappingFactory.Map<User, UserDto>(result);
        }

        public List<UserDto> GetAll()
        {
            var repository = FindService<IUserRepository>();
            var result = repository.GetAll();
            return MappingFactory.MapList<User, UserDto>(result);
        }
        public UserDto CheckActiveDirectoryForLogin(String username,String password)
        {
            bool loginResult = false;
            UserDto user = null;
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, Domain.GetComputerDomain().ToString()))
                {
                    //Kullanıcı ve Şifre bilgilerini doğrulamasını yapar. Doğruysa login olunmuştur.
                    loginResult = pc.ValidateCredentials(username, password);
                    if (loginResult)
                    {
                        UserPrincipal tempUserPrincipal = new UserPrincipal(pc);
                        tempUserPrincipal.SamAccountName = username;

                        // Search for user
                        PrincipalSearcher searchUser = new PrincipalSearcher();
                        searchUser.QueryFilter = tempUserPrincipal;

                        UserPrincipal foundUser = (UserPrincipal)searchUser.FindOne();
                        if (foundUser != null)
                            user = new UserDto
                            {
                                Active = true,
                                Username = username,
                                RegistryDate = DateTime.Now.ToLocalTime(),
                                UserType = UserTypes.User,
                                FullName = foundUser.Name,
                                Email = foundUser.EmailAddress
                            };
                    }
                }
            }
            catch (ActiveDirectoryObjectNotFoundException e)
            {
                loginResult = false;
            }
            return user;
        }
        public UserDto Authenticate(String username, String password)
        {
            var result = Get(username);
            try
            {
                var checkUser = CheckActiveDirectoryForLogin(username, password);
                
                if (checkUser != null && result == null)
                {
                    CreateUser(checkUser);
                    result = Get(username);
                }
                else if (checkUser == null)
                    result = null;

                if (result == null)
                    return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

            return result;
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
