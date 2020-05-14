using System.Configuration;

namespace Stho.Auth.Apple.Configuration
{
    public sealed class AppleSection : ConfigurationSection
    {
        private const string AppleIdCollectionPropertyKey = "appleId";
        
        [ConfigurationProperty(AppleIdCollectionPropertyKey, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(AppleIdElementCollection), AddItemName = "Add", RemoveItemName = "Remove", ClearItemsName = "Clear")]
        public AppleIdElementCollection AppleId => this[AppleIdCollectionPropertyKey] as AppleIdElementCollection;
    }
}