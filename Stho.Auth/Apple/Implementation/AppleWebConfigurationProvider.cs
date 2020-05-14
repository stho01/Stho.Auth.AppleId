using System.Configuration;
using System.Linq;
using Stho.Auth.Apple.Configuration;
using Stho.Auth.Apple.Models;

namespace Stho.Auth.Apple.Implementation
{
    public class AppleWebConfigurationProvider : IAppleConfigurationProvider
    {
        private readonly IAppleIdConfiguration[] _configs;

        public AppleWebConfigurationProvider()
        {
            _configs = ReadFromConfigSection();
        }
        
        public IAppleIdConfiguration[] Get() => _configs;

        public IAppleIdConfiguration Get(string id)
        {
            var config = _configs.SingleOrDefault(x => x.ClientId == id);
            if (config == null)
                throw new ConfigurationErrorsException($"Apple config {id} was not found.");
            
            return config;
        }

        private static IAppleIdConfiguration[] ReadFromConfigSection()
        {
            var configSection = ConfigurationManager.GetSection("apple") as AppleSection;
            if (configSection == null)
                throw new ConfigurationErrorsException("Apple section not configured");

            var clients = configSection.AppleId.Clients;
            var configs = new IAppleIdConfiguration[clients.Count];
            for (var i = 0; i < clients.Count; i++)
            {
                var config = clients[i];
                configs[i] = new AppleIdConfiguration
                {
                    Audience = configSection.AppleId.Audience,
                    RedirectUri = configSection.AppleId.RedirectUri,
                    ExpiresInMinutes = configSection.AppleId.ExpiresInMinutes,
                    Issuer = config.Issuer,
                    ClientId = config.Id,
                    KeyId = config.KeyId,
                    PrivateKey = config.PrivateKey,
                };
            }

            return configs;
        }
    }
}