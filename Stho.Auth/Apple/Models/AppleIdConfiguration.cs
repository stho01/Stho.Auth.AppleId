namespace Stho.Auth.Apple.Models
{
    public class AppleIdConfiguration : IAppleIdConfiguration
    {
        public string RedirectUri { get; set; }
        public string ClientId { get; set; }
        public string KeyId { get; set; }
        public string PrivateKey { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ExpiresInMinutes { get; set; } = 5;
    }
}