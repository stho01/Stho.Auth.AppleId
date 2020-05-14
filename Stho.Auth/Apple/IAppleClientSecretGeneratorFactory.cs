﻿namespace Stho.Auth.Apple
{
    public interface IAppleClientSecretGeneratorFactory
    {
        IAppleClientSecretGenerator Create(IAppleIdConfiguration configuration);
    }
}
