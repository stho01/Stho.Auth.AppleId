using Stho.Auth.Apple.Models;

namespace Stho.Auth.Apple
{
    public interface IAppleIdentityTokenReader
    {
        AppleIdentity Read(string identityToken);
    }
}