using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Sorschia.Authorization
{
    public class ApiPermissionHandler : AuthorizationHandler<ApiPermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiPermissionRequirement requirement)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }

    public class RequestHeaderHandler : AuthorizationHandler<RequestHeaderRequirement>
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public RequestHeaderHandler(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RequestHeaderRequirement requirement)
        {
            var httpContext = _contextAccessor.HttpContext;
            httpContext.Request.Headers.ContainsKey(requirement.HeaderName);
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
