namespace Sorschia.Api.Routing
{
    internal static class ControllerRoutes
    {
        private const string Base = "api";

        public static class Identity
        {
            private const string IdentityBase = Base + "/identity";
            public const string User = IdentityBase + "/user";
            public const string Role = IdentityBase + "/role";
            public const string Permission = IdentityBase + "/permission";
        }
    }
}
