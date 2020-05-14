namespace Stho.Auth.Apple
{
    public interface IAppleConfigurationProvider
    {
        IAppleIdConfiguration[] Get();
        IAppleIdConfiguration Get(string id);
    }
}