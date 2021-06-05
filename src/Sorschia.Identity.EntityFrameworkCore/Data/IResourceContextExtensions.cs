using Sorschia.Utilities;

namespace Sorschia.Identity.Data
{
    internal static class IResourceContextExtensions
    {
        private const string IdentityContext = "Sorschia.Identity.Data.IdentityContext";

        public static IResourceContext SetIdentityContext(this IResourceContext instance, IdentityContext context) => instance.Register(IdentityContext, context);

        public static IdentityContext GetIdentityContext(this IResourceContext instance) => instance.Request<IdentityContext>(IdentityContext);
    }
}
