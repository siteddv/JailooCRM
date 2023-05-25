using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JailooCRM.DAL.Response
{
    public class LoginResponse : Response
    {
        public string Username { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }

        public DateTime AccessTokenExpiredDate { get; set; }

        public DateTime RefreshTokenExpiredDate { get; set; }
        
        public LoginResponse(int statusCode, string message, bool isSuccess) : base(statusCode, message, isSuccess)
        {

        }
    }
}
