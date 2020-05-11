namespace Stho.Auth.Apple.Models
{
    public class AppleAccessToken
    {
        public AppleAccessToken(bool valid)
        {
            IsTokenValid = valid;
        }

        public AppleIdentity Identity { get; set; }
        public AppleAccessTokenResponse ClientResponse { get; set; }
        public bool IsTokenValid { get; }
    }
}