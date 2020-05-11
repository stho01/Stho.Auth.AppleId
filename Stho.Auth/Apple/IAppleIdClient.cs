using Stho.Auth.Apple.Models;

namespace Stho.Auth.Apple
{
    public interface IAppleIdClient
    {
        AppleAccessTokenResponse FetchAccessToken(FetchAccessTokenParameters parameters);
    }
}