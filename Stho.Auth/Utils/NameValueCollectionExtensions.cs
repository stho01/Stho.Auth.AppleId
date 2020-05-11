using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Stho.Auth.Utils
{
    internal static class NameValueCollectionExtensions
    {
        internal static string ToUrlEncodedQueryString(this NameValueCollection collection)
        {
            return string.Join("&", collection.AllKeys.Select(x => $"{x}={HttpUtility.UrlEncode(collection[x])}"));
        }

        internal static string ToQueryString(this NameValueCollection collection)
        {
            return string.Join("&", collection.AllKeys.Select(x => $"{x}={collection[x]}"));
        }
    }
}