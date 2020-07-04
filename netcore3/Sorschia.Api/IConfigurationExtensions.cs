using Microsoft.Extensions.Configuration;

namespace Sorschia
{
    internal static class IConfigurationExtensions
    {
        public static T GetSection<T>(this IConfiguration instance, string key)
        {
            return instance.GetSection(key).Get<T>();
        }

        public static bool AuthorizationEnabled(this IConfiguration instance)
        {
            return instance.GetValue<bool>("AuthorizationEnabled");
        }
    }
}
