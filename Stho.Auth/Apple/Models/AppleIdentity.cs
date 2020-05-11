namespace Stho.Auth.Apple.Models
{
    public class AppleIdentity
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool  EmailVerified { get; set; }
    }
}