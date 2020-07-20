using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Sorschia.Http;
using System.Threading.Tasks;

namespace Sorschia
{
    internal sealed class AuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationPolicyProvider(IOptions<AuthorizationOptions> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            var policy = await base.GetPolicyAsync(policyName);

            if (policy is null && !string.IsNullOrWhiteSpace(policyName))
            {
                if (policyName == ApiPermissionAuthorizeAttribute.POLICY_NAME)
                {
                    var httpContext = _httpContextAccessor.HttpContext;

                    policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser()
                        .AddRequirements(new ApiPermissionRequirement(httpContext.GetDomain(), httpContext.GetController(), httpContext.GetAction()))
                        .Build();
                }
            }

            return policy;
        }
    }
}
