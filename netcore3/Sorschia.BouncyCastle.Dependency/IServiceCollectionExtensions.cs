using Microsoft.Extensions.DependencyInjection;
using Sorschia.Security;

namespace Sorschia
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSorschiaBouncyCastle(this IServiceCollection instance) => instance
            .AddSingleton<IRsaCrypto, RsaCrypto>()
            .AddSingleton<IRsaCryptoKeyGenerator, RsaCryptoKeyGenerator>()
            .AddSingleton<PemStringConverter>();
    }
}
