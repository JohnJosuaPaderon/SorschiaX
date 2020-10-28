using Microsoft.Extensions.DependencyInjection;
using Sorschia.Security;
using System;

namespace Sorschia.UtilityApp
{
    class Program
    {
        static void Main()
        {
            var services = new ServiceCollection();
            services
                .AddSorschia()
                .AddSorschiaBouncyCastle();
            var provider = services.BuildServiceProvider();
            var generator = provider.GetService<IRsaCryptoKeyGenerator>();
            var pair = generator.Generate();
            Console.WriteLine(pair);
        }
    }
}
