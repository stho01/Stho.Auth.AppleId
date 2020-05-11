using System.Configuration;
using Stho.Auth.Apple.Configuration;
using Stho.Auth.Apple.Models;

namespace Stho.Auth.Apple.Implementation
{
    public class AppleWebConfigurationProvider : IAppleConfigurationProvider
    {
        public IAppleIdConfiguration Get()
        {
            var configSection = ConfigurationManager.GetSection("apple") as AppleSection;
            if (configSection == null)
                throw new ConfigurationErrorsException("Apple section not configured");

            return new AppleIdConfiguration
            {
                Audience = configSection.Audience,
                Issuer = configSection.Issuer,
                ClientId = configSection.ClientId,
                KeyId = configSection.KeyId,
                PrivateKey = configSection.PrivateKey,
                RedirectUri = configSection.RedirectUri,
                ExpiresInMinutes = configSection.ExpiresInMinutes
            };
        }
    }
}