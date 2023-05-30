namespace JailooCRM.DAL.DTOs
{
    public class TokenModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
