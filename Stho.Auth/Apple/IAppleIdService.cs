using Stho.Auth.Apple.Models;

namespace Stho.Auth.Apple
{
    public interface IAppleIdService
    {
        AppleAccessToken FetchAccessToken(string clientId, string authorizationCode);
        AppleSignInUri GetAppleSignInUri(string clientId, AuthScope scope);
    }
}