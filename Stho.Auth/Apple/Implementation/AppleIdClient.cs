using System;
using System.Collections.Specialized;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;
using Stho.Auth.Apple.Models;

namespace Stho.Auth.Apple.Implementation
{
    public class AppleIdClient : IAppleIdClient
    {
        private const string _appleIdUri = "https://appleid.apple.com/";

        public AppleAccessTokenResponse FetchAccessToken(FetchAccessTokenParameters parameters)
        {
            var client = CreateHttpClient();
            var request = CreateFormRequest("auth/token", new NameValueCollection {
                {"grant_type", "authorization_code"},
                {"code", parameters.AuthorizationCode},
                {"client_id", parameters.ClientId},
                {"client_secret", parameters.ClientSecret},
                {"redirect_uri", parameters.RedirectUri}
            });

            var response = client.Post(request);

            if (!response.IsSuccessful)
            {
                var error = new
                {
                    response.Content,
                    response.ErrorMessage,
                    response.StatusCode,
                    response.IsSuccessful,
                    request.Body,
                    request.Resource,
                    client.BaseUrl,
                };
                throw new Exception($"error: {JsonConvert.SerializeObject(error)}");
            }

            return JsonConvert.DeserializeObject<AppleAccessTokenResponse>(response.Content);
        }

        private RestClient CreateHttpClient() => new RestClient(_appleIdUri);
        private RestRequest CreateFormRequest(string path, NameValueCollection data = null)
        {
            var request = new RestRequest(path);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("User-Agent", "web");
            request.AddHeader("Accept", "application/Json");

            if (data != null)
                request.AddParameter("application/x-www-form-urlencoded", CreateFormDataFrom(data), ParameterType.RequestBody);

            return request;
        }
        private string CreateFormDataFrom(NameValueCollection collection)
        {
            return string.Join("&", collection.AllKeys.Select(k => $"{k}={collection[k]}"));
        }
    }
}