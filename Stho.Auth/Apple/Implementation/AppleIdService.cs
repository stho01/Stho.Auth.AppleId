using System;
using System.Collections.Specialized;
using Stho.Auth.Apple.Models;
using Stho.Auth.Utils;

namespace Stho.Auth.Apple.Implementation
{
    public class AppleIdService : IAppleIdService
    {
        private readonly IAppleClientSecretGeneratorFactory _appleClientSecretGeneratorFactory;
        private readonly IAppleIdClient _client;
        private readonly IAppleIdentityTokenReader _appleIdentityTokenReader;
        private readonly IAppleConfigurationProvider _configurationProvider;

        public AppleIdService(
            IAppleClientSecretGeneratorFactory appleClientSecretGeneratorFactory,
            IAppleIdClient client,
            IAppleIdentityTokenReader appleIdentityTokenReader,
            IAppleConfigurationProvider configurationProvider)
        {
            _appleClientSecretGeneratorFactory = appleClientSecretGeneratorFactory;
            _client = client;
            _appleIdentityTokenReader = appleIdentityTokenReader;
            _configurationProvider = configurationProvider;
        }

        /// <summary>Exchange authorization code with access token.</summary>
        /// <param name="authorizationCode"></param>
        public AppleAccessToken FetchAccessToken(string clientId, string authorizationCode)
        {
            if (string.IsNullOrEmpty(authorizationCode))
                throw new ArgumentNullException(nameof(authorizationCode));
            
            var configuration = _configurationProvider.Get(clientId);
            var clientSecretGenerator = _appleClientSecretGeneratorFactory.Create(configuration);
            
            var clientResponse = _client.FetchAccessToken(new FetchAccessTokenParameters {
                AuthorizationCode = authorizationCode,
                ClientId = configuration.ClientId,
                RedirectUri = configuration.RedirectUri,
                ClientSecret = clientSecretGenerator.Generate()
            });
            var identityToken = _appleIdentityTokenReader.Read(clientResponse.IdToken);

            return new AppleAccessToken(true) 
            {
                ClientResponse = clientResponse,
                Identity = identityToken
            };
        }

        public AppleSignInUri GetAppleSignInUri(string clientId, AuthScope scope)
        {
            var configuration = _configurationProvider.Get(clientId);
            return GetAppleSignInUri(configuration, scope);
        }
        
        public AppleSignInUri GetAppleSignInUri(IAppleIdConfiguration configuration, AuthScope scope)
        {
            var random = new Random((int)DateTime.UtcNow.Ticks);
            var state = random.Next(10000, 99999).ToString("X");

            var uri = new Uri($"{configuration.Audience}/auth/authorize", UriKind.Absolute);
            var query = new NameValueCollection {
                {"response_type", "code"},
                {"response_mode", "form_post"},
                {"client_id", configuration.ClientId},
                {"redirect_uri", configuration.RedirectUri},
                {"state", state},
                {"scope", "name email"}
            };
            var uriBuilder = new UriBuilder(uri) {
                Port = -1, 
                Query = query.ToUrlEncodedQueryString()
            };
            
            return new AppleSignInUri {
                Uri = uriBuilder.Uri,
                State = state
            };
        }
    }
}