namespace Stho.Auth.Apple.Models
{
    public class FetchAccessTokenParameters
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthorizationCode { get; set; }
        public string RedirectUri { get; set; }
    }
}