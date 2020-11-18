using Microsoft.AspNetCore.Authorization;

namespace Sorschia.Authorization
{
    public static class AuthorizationPolicyBuilderExtensions
    {
        public static AuthorizationPolicyBuilder RequireRequestHeader(this AuthorizationPolicyBuilder instance, string headerName) => instance?
            .AddRequirements(new RequestHeaderRequirement(headerName));
    }
}
