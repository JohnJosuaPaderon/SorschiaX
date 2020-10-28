using Microsoft.Extensions.Configuration;

namespace Sorschia
{
    public static class IConfigurationExtensions
    {
        public static T GetSection<T>(this IConfiguration instance, string key)
        {
            return instance.GetSection(key).Get<T>();
        }

        public static bool AuthorizationEnabled(this IConfiguration instance)
        {
            return instance.GetValue<bool>("AuthorizationEnabled");
        }

        public static string UserPasswordPublicKeyPath(this IConfiguration instance)
        {
            return instance.GetValue<string>("Sorschia:SystemCore:UserPasswordPublicKeyPath");
        }

        public static string UserPasswordPrivateKeyPath(this IConfiguration instance)
        {
            return instance.GetValue<string>("Sorschia:SystemCore:UserPasswordPrivateKeyPath");
        }
    }
}
