using System.Configuration;

namespace Stho.Auth.Apple.Configuration
{
    public sealed class AppleSection : ConfigurationSection
    {
        [ConfigurationProperty("clientId", IsRequired = true, IsKey = true)]
        public string ClientId
        {
            get => this["clientId"] as string;
            set => this["clientId"] = value;
        }

        [ConfigurationProperty("redirectUri", IsRequired = true)]
        public string RedirectUri
        {
            get => this["redirectUri"] as string;
            set => this["redirectUri"] = value;
        }

        [ConfigurationProperty("keyId", IsRequired = true)]
        public string KeyId 
        {
            get => this["keyId"] as string;
            set => this["keyId"] = value;
        }
        
        [ConfigurationProperty("audience", IsRequired = true)]
        public string Audience 
        {
            get => this["audience"] as string;
            set => this["audience"] = value;
        }

        [ConfigurationProperty("issuer", IsRequired = true)]
        public string Issuer
        {
            get => this["issuer"] as string;
            set => this["issuer"] = value;
        }
        
        [ConfigurationProperty("expiresInMinutes", IsRequired = true)]
        public int ExpiresInMinutes
        {
            get => (this["issuer"] as int?) ?? 5;
            set => this["issuer"] = value;
        }
        
        [ConfigurationProperty("privateKey", IsRequired = true)]
        public string PrivateKey
        {
            get => (this["privateKey"] as string);
            set => this["privateKey"] = value;
        }
    }
}