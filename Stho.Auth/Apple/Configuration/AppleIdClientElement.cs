using System.Configuration;

namespace Stho.Auth.Apple.Configuration
{
    public class AppleIdClientElement : ConfigurationElement
    {
        private const string IdPropertyKey = "clientId";
        private const string KeyIdPropertyKey = "keyId";
        private const string IssuerPropertyKey = "issuer";
        private const string PrivateKeyPropertyKey = "privateKey";

        [ConfigurationProperty(IdPropertyKey, IsRequired = true, IsKey = true)]
        public string Id
        {
            get => this[IdPropertyKey] as string;
            set => this[IdPropertyKey] = value;
        }
        
        [ConfigurationProperty(KeyIdPropertyKey, IsRequired = true)]
        public string KeyId
        {
            get => this[KeyIdPropertyKey] as string;
            set => this[KeyIdPropertyKey] = value;
        }
        
        [ConfigurationProperty(IssuerPropertyKey, IsRequired = true)]
        public string Issuer
        {
            get => this[IssuerPropertyKey] as string;
            set => this[IssuerPropertyKey] = value;
        }
        
        [ConfigurationProperty(PrivateKeyPropertyKey, IsRequired = true)]
        public string PrivateKey
        {
            get => this[PrivateKeyPropertyKey] as string;
            set => this[PrivateKeyPropertyKey] = value;
        }
    }
}