using Microsoft.AspNetCore.Authorization;
using Sorschia.Http;

namespace Sorschia.Authorization
{
    public class RequestHeaderAuthorizeAttribute : AuthorizeAttribute
    {
        public RequestHeaderAuthorizeAttribute(string headerName) : base(GetPolicyFromHeaderName(headerName))
        {
        }

        private static string GetPolicyFromHeaderName(string headerName)
        {
            return headerName switch
            {
                RequestHeaders.AllowGetGlobalPublicCryptoKey => Policies.AllowGetGlobalPublicCryptoKey,
                RequestHeaders.AllowUserLogin => Policies.AllowUserLogin,
                RequestHeaders.AllowRefreshAccessToken => Policies.AllowRefreshAccessToken,
                _ => throw new SorschiaException($"Header '{headerName}' is unsupported and cannot be mapped to an authorization policy"),
            };
        }
    }
}
