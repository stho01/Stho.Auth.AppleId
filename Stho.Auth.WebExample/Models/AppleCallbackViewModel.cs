using System;
using Stho.Auth.Apple.Models;

namespace Stho.Auth.WebExample.Models
{
    public class AppleCallbackViewModel
    {
        public AppleAccessToken AccessToken { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }

        public AppleCallbackViewModel(AppleAccessToken accessToken)
        {
            AccessToken = accessToken;
        }

        public AppleCallbackViewModel(Exception ex)
        {
            ErrorMessage = ex.Message;
            StackTrace = ex.StackTrace;
        }
    }
}