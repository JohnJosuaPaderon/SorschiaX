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
                .FirstOrDefault(metadata => metadata is DomainRouteAttribute) as DomainRouteAttribute;

            return (domainRouteObj is DomainRouteAttribute domainRoute) ? domainRoute.Domain : null;
        }

        public static object GetRequestRouteValue(this HttpContext instance, string key) => instance?
            .Request?
            .RouteValues[key];

        public static string GetController(this HttpContext instance) => instance?
            .GetRequestRouteValue("controller")?
            .ToString();

        public static string GetAction(this HttpContext instance) => instance?
            .GetRequestRouteValue("action")?
            .ToString();
    }
}
