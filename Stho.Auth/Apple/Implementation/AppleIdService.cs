using System;
using System.Collections.Specialized;
using Stho.Auth.Apple.Models;
using Stho.Auth.Utils;

namespace Stho.Auth.Apple.Implementation
{
    public class AppleIdService : IAppleIdService
    {
        private readonly IAppleClientSecretGenerator _appleClientSecretGenerator;
        private readonly IAppleIdClient _client;
        private readonly IAppleIdentityTokenReader _appleIdentityTokenReader;
        private readonly IAppleIdConfiguration _configuration;

        public AppleIdService(
            IAppleClientSecretGenerator appleClientSecretGenerator,
            IAppleIdClient client,
            IAppleIdentityTokenReader appleIdentityTokenReader,
            IAppleConfigurationProvider configurationProvider)
        {
            _appleClientSecretGenerator = appleClientSecretGenerator;
            _client = client;
            _appleIdentityTokenReader = appleIdentityTokenReader;
            _configuration = configurationProvider.Get();
        }

        /// <summary>Exchange authorization code with access token.</summary>
        /// <param name="authorizationCode"></param>
        public AppleAccessToken FetchAccessToken(string authorizationCode)
        {
            if (string.IsNullOrEmpty(authorizationCode))
                throw new ArgumentNullException(nameof(authorizationCode));

            var clientResponse = _client.FetchAccessToken(new FetchAccessTokenParameters {
                AuthorizationCode = authorizationCode,
                ClientId = _configuration.ClientId,
                RedirectUri = _configuration.RedirectUri,
                ClientSecret = _appleClientSecretGenerator.GenerateClientSecret(),
            });

            var identityToken = _appleIdentityTokenReader.Read(clientResponse.IdToken);

            return new AppleAccessToken(true) 
            {
                ClientResponse = clientResponse,
                Identity = identityToken
            };
        }

        public AppleSignInUri GetAppleSignInUri(AuthScope scope)
        {
            var random = new Random((int)DateTime.UtcNow.Ticks);
            var state = random.Next(10000, 99999).ToString("X");

            var uri = new Uri($"{_configuration.Audience}/auth/authorize", UriKind.Absolute);
            var query = new NameValueCollection {
                {"response_type", "code"},
                {"response_mode", "form_post"},
                {"client_id", _configuration.ClientId},
                {"redirect_uri", _configuration.RedirectUri},
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