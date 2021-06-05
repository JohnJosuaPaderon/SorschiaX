using Sorschia.Utilities;

namespace Sorschia.Auditing
{
    public static class IResourceContextExtensions
    {
        private const string CurrentFootprint = "Sorschia.Auditing.Footprint|Current";
        
        public static IResourceContext SetCurrentFootprint(this IResourceContext instance, Footprint footprint) => instance.Register(CurrentFootprint, footprint);

        public static Footprint GetCurrentFootprint(this IResourceContext instance) => instance.Request<Footprint>(CurrentFootprint);
    }
}
