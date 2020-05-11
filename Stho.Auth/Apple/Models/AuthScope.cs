using System;
using System.Collections.Generic;
using System.Linq;

namespace Stho.Auth.Apple.Models
{
    [Flags]
    public enum AuthScope
    {
        Name = 1,
        Email = 1 << 1,
    }

    public static class AuthScopeUtils
    {
        public static string GetScopeString(AuthScope scope)
        {
            var flags = GetFlags(scope);
            
            return string.Join(" ", flags.Select(x => x.ToString().ToLowerInvariant()));
        }
        
        public static IEnumerable<AuthScope> GetFlags(AuthScope scope)
        {
            return Enum.GetValues(typeof(AuthScope))
                .Cast<AuthScope>()
                .Where(value => (value & scope) == value);
        }
    }
}