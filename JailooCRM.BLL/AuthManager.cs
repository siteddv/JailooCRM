using JailooCRM.DAL;
using JailooCRM.DAL.Configs;
using JailooCRM.DAL.Request;
using JailooCRM.DAL.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JailooCRM.BLL
{
    public class AuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _options;
        

        public AuthManager(UserManager<User> userManager, IOptions<JwtSettings> options)
        {
            _userManager = userManager;
            _options = options.Value;

        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            if(!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new Exception("Password is not correct");
            }
            return new LoginResponse(200, "poxui", true);
            
            //TODO GetAccessToken
            //TODO GetRefreshToken
            //TODO return CreateResponse
            
        }
        //public async Task<(string, DateTime)> GetAccessToken(User user)
        //{
        //    //TODO return AccessToken dimalox
        //}
    }
}
