using Prism.Ioc;
using Sorschia.Views;

namespace Sorschia
{
    public static class IContainerRegistryExtensions
    {
        public static IContainerRegistry AddSorschiaWpf(this IContainerRegistry instance)
        {
            return instance
                .AddNavigation<NotFound>(NavigationConstants.NotFound);
        }
    }
}
