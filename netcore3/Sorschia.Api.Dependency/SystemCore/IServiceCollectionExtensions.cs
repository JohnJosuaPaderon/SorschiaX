using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore
{
    internal static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSystemCore(this IServiceCollection instance) => instance
            .AddSingleton<IAccessTokenGenerator, AccessTokenGenerator>()
            .AddSingleton<IRefreshTokenGenerator, RefreshTokenGenerator>()
            .AddTransient<ISessionIdProvider, SessionIdProvider>();
    }
}
