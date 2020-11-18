using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Sorschia.Http;
using System.Threading.Tasks;

namespace Sorschia.Authorization
{
    public class AuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthorizationPolicyProvider(IOptions<AuthorizationOptions> options, IHttpContextAccessor contextAccessor) : base(options)
        {
            _contextAccessor = contextAccessor;
        }

        public override async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            var policy = await base.GetPolicyAsync(policyName);

            if (policy is null)
            {
                return policyName switch
                {
                    Policies.ApiPermisssion => new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                            .RequireAuthenticatedUser()
                            .AddRequirements(ApiPermissionRequirement.FromContext(_contextAccessor.HttpContext))
                            .Build(),
                    Policies.AllowGetGlobalPublicCryptoKey => new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                            .RequireRequestHeader(RequestHeaders.AllowGetGlobalPublicCryptoKey)
                            .Build(),
                    Policies.AllowUserLogin => new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                            .RequireRequestHeader(RequestHeaders.AllowUserLogin)
                            .Build(),
                    Policies.AllowRefreshAccessToken => new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                            .RequireRequestHeader(RequestHeaders.AllowRefreshAccessToken)
                            .Build(),
                    _ => null
                };
            }

            return policy;
        }
    }
}
