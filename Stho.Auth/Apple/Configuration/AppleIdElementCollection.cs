using System.Configuration;

namespace Stho.Auth.Apple.Configuration
{
    public class AppleIdElementCollection : ConfigurationElementCollection
    {
        private const string RedirectUriPropertyKey = "redirectUri";
        private const string AudiencePropertyKey = "audience";
        private const string ExpiresInMinutesPropertyKey = "expiresInMinutes";
        
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
        
        protected override ConfigurationElement CreateNewElement() => new AppleIdClientElement();
        protected override object GetElementKey(ConfigurationElement element) => ((AppleIdClientElement)element).Id;

        public void Add(AppleIdClientElement client) => BaseAdd(client);
        public void Remove(AppleIdClientElement client) => BaseRemove(client);
        public void Clear() => BaseClear();
        
        public AppleIdClientElement this[int index]
        {
            get => BaseGet(index) as AppleIdClientElement;
            set
            {
                if (this[index] != null)
                    BaseRemove(index);
                
                BaseAdd(index, value);
            }
        }
    }
}