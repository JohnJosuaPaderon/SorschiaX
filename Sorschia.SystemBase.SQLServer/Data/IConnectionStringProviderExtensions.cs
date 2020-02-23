using Sorschia.Data;

namespace Sorschia.SystemBase.Data
{
    internal static class IConnectionStringProviderExtensions
    {
        public static string GetDefault(this IConnectionStringProvider instance)
        {
            return instance["sorschia_systembase"];
        }
    }
}
