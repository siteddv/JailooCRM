using JailooCRM.DAL;
using JailooCRM.DAL.Configs;
using JailooCRM.DAL.DTOs;
using JailooCRM.DAL.Request;
using JailooCRM.DAL.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
            // return new LoginResponse(200, "poxui", true);


            //TODO GetAccessToken

            (string acccessToken, DateTime expireAccess) = GetAccessToken(user);


            //TODO GetRefreshToken
            string refreshToken = GenerateRefreshToken();

            //TODO return CreateResponse

            return new LoginResponse(200, null, true)
            {
                RefreshToken = refreshToken,
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

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public async Task<LoginResponse> CreateOrUpdateToken(TokenModel tokenModel)
        {
            if (tokenModel == null)
            {
                throw new UnauthorizedAccessException("Invalid client request");
            }

            string accessToken = tokenModel.AccessToken;
            string refreshToken = tokenModel.RefreshToken;


            var principal = GetPrincipalFromExpiredToken(accessToken);
            if (principal == null)
            {
                throw new UnauthorizedAccessException("Invalid access token or refresh token");
            }

            string username = principal.Identity.Name;

            var user = await _userManager.FindByNameAsync(username);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                throw new UnauthorizedAccessException("Invalid access token or refresh token");
            }

            (string acccessToken, DateTime expireAccess) = GetAccessToken(user);
            var newRefreshToken = GenerateRefreshToken();


            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return (new LoginResponse(200, null, false)
            {
                AccessToken = acccessToken,
                RefreshToken = newRefreshToken,
                AccessTokenExpiredDate = expireAccess,
                RefreshTokenExpiredDate = DateTime.UtcNow.AddDays(1),
            }) ;
        }


        private  ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;

        }

    }
}
