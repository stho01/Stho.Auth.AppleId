using System;

namespace Stho.Auth.Apple.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AppleSignInUri
    {
        public string State { get; set; }
        public Uri Uri { get; set; }
        /// <summary>The Configuration that is used for this apple sign in</summary>
        public IAppleIdConfiguration Configuration { get; set; }

        public override string ToString()
        {
            return Uri.ToString();
        }
    }
}