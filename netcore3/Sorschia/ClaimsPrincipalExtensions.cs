using System;
using System.Security.Claims;

namespace Sorschia
{
    public static class ClaimsPrincipalExtensions
    {
        public delegate bool TryParse<T>(string input, out T output);

        private static bool TryGetClaimValue<T>(ClaimsPrincipal instance, string claimType, TryParse<T> tryParse, out T output)
        {
            output = default;

            if (
                instance != null && 
                instance.HasClaim(claim => string.Equals(claim.Type, claimType, StringComparison.CurrentCultureIgnoreCase)) &&
                tryParse(instance.FindFirst(claimType).Value, out output)
            )
                return true;

            return false;
        }

        public static bool TryGetClaimValueInt64(this ClaimsPrincipal instance, string claimType, out long output) => TryGetClaimValue(instance, claimType, long.TryParse, out output);
    }
}
