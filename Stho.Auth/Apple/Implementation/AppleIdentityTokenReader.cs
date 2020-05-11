using System.IdentityModel.Tokens.Jwt;
using Stho.Auth.Apple.Models;

namespace Stho.Auth.Apple.Implementation
{
    public class AppleIdentityTokenReader : IAppleIdentityTokenReader
    {
        private readonly JwtSecurityTokenHandler _handler;

        public AppleIdentityTokenReader()
        {
            _handler = new JwtSecurityTokenHandler();
        }

        public AppleIdentity Read(string identityToken)
        {
            var securityToken = _handler.ReadJwtToken(identityToken);

            securityToken.Payload.TryGetValue("email", out var email);
            securityToken.Payload.TryGetValue("email_verified", out var emailVerified);

            return new AppleIdentity {
                Id = securityToken.Subject,
                Email = (email as string),
                EmailVerified = (emailVerified as string) == "true"
            };
        }
    }
}