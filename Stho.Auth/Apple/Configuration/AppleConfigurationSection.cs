using System.Configuration;

namespace Stho.Auth.Apple.Configuration
{
    public sealed class AppleSection : ConfigurationSection
    {
        private const string AppleIdCollectionPropertyKey = "appleId";
        
        [ConfigurationProperty(AppleIdCollectionPropertyKey)]
        public AppleIdElement AppleId => (AppleIdElement) base[AppleIdCollectionPropertyKey];
    }
}