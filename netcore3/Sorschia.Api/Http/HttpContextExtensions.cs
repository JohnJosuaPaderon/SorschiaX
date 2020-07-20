using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Sorschia.Routing;
using System.Linq;

namespace Sorschia.Http
{
    public static class HttpContextExtensions
    {
        public static string GetDomain(this HttpContext instance)
        {
            var domainRouteObj = instance?
                .GetEndpoint()?
                .Metadata?
                .GetMetadata<ControllerActionDescriptor>()?
                .EndpointMetadata?
                .FirstOrDefault(metadata => metadata is DomainRouteAttribute);

            return (domainRouteObj is DomainRouteAttribute domainRoute) ? domainRoute.Domain : null; 
        }

        public static string GetController(this HttpContext instance) => instance?
            .Request?
            .RouteValues["controller"]?
            .ToString();

        public static string GetAction(this HttpContext instance) => instance?
            .Request?
            .RouteValues["action"]?
            .ToString();
    }
}
