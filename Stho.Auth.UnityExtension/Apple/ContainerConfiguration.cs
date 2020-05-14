using Stho.Auth.Apple;
using Stho.Auth.Apple.Implementation;
using Unity;

namespace Stho.Auth.UnityExtension.Apple
{
    public static class ContainerConfiguration
    {
        public static void AddAppleIdService(this IUnityContainer container)
        {
            container.RegisterType<IAppleIdClient, AppleIdClient>();
            container.RegisterType<IAppleIdService, AppleIdService>();
            container.RegisterType<IAppleIdentityTokenReader, AppleIdentityTokenReader>();
            container.RegisterType<IAppleClientSecretGenerator, AppleSecretGenerator>();
            container.RegisterType<IAppleConfigurationProvider, AppleWebConfigurationProvider>();
            container.RegisterType<IAppleClientSecretGeneratorFactory, AppleSecretGeneratorFactory>();
        }
    }
}