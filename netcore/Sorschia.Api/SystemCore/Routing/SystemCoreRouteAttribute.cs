using Sorschia.Routing;

namespace Sorschia.SystemCore.Routing
{
    public class SystemCoreRouteAttribute : DomainRouteAttribute
    {
        public SystemCoreRouteAttribute(string template) : base(template, SorschiaDomain.SystemCore)
        {
        }
    }
}
