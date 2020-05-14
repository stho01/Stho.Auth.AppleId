using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Stho.Auth.Apple.Implementation
{
    public class AppleSecretGenerator : IAppleClientSecretGenerator
    {
        private readonly IAppleIdConfiguration _configuration;
        private readonly JwtSecurityTokenHandler _handler;
        
        public AppleSecretGenerator(IAppleIdConfiguration configuration)
        {
            _configuration = configuration;
            _handler = new JwtSecurityTokenHandler();
        }
        
        public string Generate()
        {
            var securityToken = CreateSecurityToken();

            return _handler.WriteToken(securityToken);
        }
        
        public JwtSecurityToken CreateSecurityToken()
        {
            var utcNow = DateTime.UtcNow;

            return _handler.CreateJwtSecurityToken(
                issuer             : _configuration.Issuer,
                audience           : _configuration.Audience,
                subject            : GetClaimsIdentity(),
                expires            : utcNow.AddMinutes(_configuration.ExpiresInMinutes),
                issuedAt           : utcNow,
                notBefore          : utcNow,
                signingCredentials : GetSigningCredentials()
            );
        }

        private ClaimsIdentity GetClaimsIdentity()
        {
            var claims = new List<Claim> {
                new Claim("sub", _configuration.ClientId)
            };

            return new ClaimsIdentity(claims);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var pkBytes = Convert.FromBase64String(_configuration.PrivateKey);
            var cngKey = CngKey.Import(pkBytes, CngKeyBlobFormat.Pkcs8PrivateBlob);
            var key = new ECDsaSecurityKey(new ECDsaCng(cngKey));

            return new SigningCredentials(key, SecurityAlgorithms.EcdsaSha256) {
                Key = {KeyId = _configuration.KeyId}
            };
        }
    }
}