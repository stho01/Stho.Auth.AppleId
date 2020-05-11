using System;

namespace Stho.Auth.Apple.Models
{
    public class AppleSignInUri
    {
        public string State { get; set; }
        public Uri Uri { get; set; }

        public override string ToString()
        {
            return Uri.ToString();
        }
    }
}