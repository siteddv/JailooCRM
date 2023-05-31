using Microsoft.AspNetCore.Identity;

namespace JailooCRM.DAL
{
    public class User : IdentityUser<int>
    {
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
