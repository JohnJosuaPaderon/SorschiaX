using Microsoft.AspNetCore.Mvc;

namespace Sorschia.Routing
{
    public class DomainRouteAttribute : RouteAttribute
    {
        public string Domain { get; }

        public DomainRouteAttribute(string template, string domain = null) : base(template)
        {
            Domain = domain;
        }

        public DomainRouteAttribute(string template, SorschiaDomain domain = SorschiaDomain.None) : this(template, domain.ToString())
        {
        }
    }
}
