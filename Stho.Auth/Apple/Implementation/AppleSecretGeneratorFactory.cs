namespace Stho.Auth.Apple.Implementation
{
    public class AppleSecretGeneratorFactory : IAppleClientSecretGeneratorFactory
    {
        public IAppleClientSecretGenerator Create(IAppleIdConfiguration configuration)
        {            
            return new AppleSecretGenerator(configuration);
        }
    }
}