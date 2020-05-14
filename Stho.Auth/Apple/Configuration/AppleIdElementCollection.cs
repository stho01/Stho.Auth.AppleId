using System.Configuration;

namespace Stho.Auth.Apple.Configuration
{
    public class AppleIdElementCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;
        protected override string ElementName => "client";
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