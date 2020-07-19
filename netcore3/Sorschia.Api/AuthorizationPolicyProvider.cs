using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Sorschia
{
    internal sealed class AuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        private const string ROUTEDATA_CONTROLLER = "controller";
        private const string ROUTEDATA_ACTION = "action";

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
                    var controller = Convert.ToString(httpContext.Request.RouteValues[ROUTEDATA_CONTROLLER]);
                    var action = Convert.ToString(httpContext.Request.RouteValues[ROUTEDATA_ACTION]);

                    policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                        //.RequireAuthenticatedUser()
                        .AddRequirements(new ApiPermissionRequirement(controller, action))
                        .Build();
                }
            }

            return policy;
        }
    }
}
