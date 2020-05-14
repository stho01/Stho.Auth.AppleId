using System.Configuration;

namespace Stho.Auth.Apple.Configuration
{
    public class AppleIdElement : ConfigurationElement
    {
        private const string RedirectUriPropertyKey = "redirectUri";
        private const string AudiencePropertyKey = "audience";
        private const string ExpiresInMinutesPropertyKey = "expiresInMinutes";
        private const string ClientTagName = "client";
        
        [ConfigurationProperty(RedirectUriPropertyKey)]
        public string RedirectUri
        {
            get => this[RedirectUriPropertyKey] as string;
            set => this[RedirectUriPropertyKey] = value;
        }

        [ConfigurationProperty(AudiencePropertyKey)]
        public string Audience
        {
            get => this[AudiencePropertyKey] as string;
            set => this[AudiencePropertyKey] = value;
        }
        
        [ConfigurationProperty(ExpiresInMinutesPropertyKey)]
        public int ExpiresInMinutes
        {
            get => (this[ExpiresInMinutesPropertyKey] as int?) ?? 0;
            set => this[ExpiresInMinutesPropertyKey] = value;
        }
        
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public AppleIdElementCollection Clients => base[""] as AppleIdElementCollection;
    }
}