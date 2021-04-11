namespace Sorschia.Api.Routing
{
    internal static class ControllerRoutes
    {
        public const string ControllerRouteBase = "api/";
        public const string VersionedControllerRouteBase = ControllerRouteBase + "v{version:apiVersion}/";
        public const string IdentityControllerRoute = ControllerRouteBase + "identity/[controller]";
        public const string IdentityVersionedControllerRoute = VersionedControllerRouteBase + "identity/[controller]";
    }
}
