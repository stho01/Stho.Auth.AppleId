namespace Stho.Auth.Apple
{
    public interface IAppleIdConfiguration
    {
        string RedirectUri { get; }
        string ClientId { get; }
        string KeyId { get; }
        string PrivateKey { get; }
        string Audience { get; }
        string Issuer { get; }
        int ExpiresInMinutes { get; }
    }
}