using JailooCRM.DAL;
using JailooCRM.DAL.Configs;
using JailooCRM.DAL.Request;
using JailooCRM.DAL.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JailooCRM.BLL
{
    public class AuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;


        public AuthManager(UserManager<User> userManager, IOptions<JwtSettings> options)
        {
            _userManager = userManager;
            _jwtSettings = options.Value;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            if (!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new Exception("Password is not correct");
            }
            return new LoginResponse(200, "poxui", true);


            //TODO GetAccessToken

            (string acccessToken, DateTime expireAccess) = GetAccessToken(user);

            //TODO GetRefreshToken


            //TODO return CreateResponse

            return new LoginResponse(200, null, true)
            {
                AccessToken = acccessToken,
                AccessTokenExpiredDate = expireAccess,
            };
        }

        public (string, DateTime) GetAccessToken(User user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            DateTime expireDate = DateTime.Now.AddMinutes(_jwtSettings.AccessTokenLifeTimeInMinutes);

            var token = new JwtSecurityToken(_jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: expireDate,
                signingCredentials: credentials);


            return (new JwtSecurityTokenHandler().WriteToken(token), expireDate);
        }
    }
}
