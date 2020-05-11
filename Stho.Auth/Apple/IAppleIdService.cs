using Stho.Auth.Apple.Models;

namespace Stho.Auth.Apple
{
    public interface IAppleIdService
    {
        AppleAccessToken FetchAccessToken(string authorizationCode);
        AppleSignInUri GetAppleSignInUri(AuthScope scope);
    }
}