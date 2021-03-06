using BusinessLayer.Dtos;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;
using Shared.BaseTypes;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NoMoreException.Services
{
    public class AuthUserService : AuthenticationStateProvider
    {
        private const string USER_SESSION_OBJECT_KEY = "user_local_obj";

        private ProtectedLocalStorage protectedSessionStore;
        private IHttpContextAccessor httpContextAccessor;

        public AuthUserService(ProtectedLocalStorage protectedSessionStore, IHttpContextAccessor httpContextAccessor) =>
            (this.protectedSessionStore, this.httpContextAccessor) = (protectedSessionStore, httpContextAccessor);

        public string IpAddress => httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? string.Empty;

        private UserDto User { get; set; }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // read a possible user session object from the storage.
            UserDto userSession = await GetUserSession();

            if (userSession != null)
                return await GenerateAuthenticationState(userSession);
            return await GenerateEmptyAuthenticationState();
        }

        public async Task LoginAsync(UserDto user)
        {
            UserDto authUser = Ioc.Resolve<IUserObject>().Authenticate(user.Username,user.Password);
            if (authUser == null)
                throw new System.Exception("login unsuccessful") ;
            // store the session information in the client's storage.
            await SetUserSession(authUser);

            // notify the authentication state provider.
            NotifyAuthenticationStateChanged(GenerateAuthenticationState(authUser));
        }

        public async Task LogoutAsync()
        {
            // delete the user's session object.
            await protectedSessionStore.DeleteAsync(USER_SESSION_OBJECT_KEY);

            // notify the authentication state provider.
            NotifyAuthenticationStateChanged(GenerateEmptyAuthenticationState());
        }

        public async Task<UserDto> GetUserSession()
        {
            if (User != null)
                return User;
            try
            {
                ProtectedBrowserStorageResult<string> localUserJsonres = await protectedSessionStore.GetAsync<string>(USER_SESSION_OBJECT_KEY);

                //string localUserJson = await protectedSessionStore.GetAsync<string>(USER_SESSION_OBJECT_KEY);

                // no active user session found!
                if (string.IsNullOrEmpty(localUserJsonres.Value))
                    return null;
                return RefreshUserSession(JsonConvert.DeserializeObject<UserDto>(localUserJsonres.Value));
            }
            catch
            {
                // user could have modified to local value, leading to an
                // invalid decrypted object. Hence, the user just did destory
                // his own session object. We need to clear it up.
                await LogoutAsync();
                return null;
            }

        }

        private async Task SetUserSession(UserDto user)
        {
            // buffer the current session into the user object,
            // in order to avoid fetching the user object from JS.
            RefreshUserSession(user);

            try
            {
                await protectedSessionStore.SetAsync(USER_SESSION_OBJECT_KEY, JsonConvert.SerializeObject(user));
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            
        }

        private UserDto RefreshUserSession(UserDto user) => User = user;

        private Task<AuthenticationState> GenerateAuthenticationState(UserDto user)
        {
            if (user != null)
            {
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.FullName.ToString()),
                new Claim(ClaimTypes.Role, user.UserType.ToString()),
                new Claim("Avatar", Convert.ToBase64String(user.ProfileImage))
            }, "apiauth_type");

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                return Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            return null;
        }

        private Task<AuthenticationState> GenerateEmptyAuthenticationState() => Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
    }
}
