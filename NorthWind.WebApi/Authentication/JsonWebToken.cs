namespace NorthWind.WebApi.Authentication
{
    public class JsonWebToken
    {
        public string Access_token { get; set; }
        public string Token_Type { get; set; } = "bearer";
        public int Expires_in { get; set; }
        public string Refresh_Token { get; set; }
    }
}
