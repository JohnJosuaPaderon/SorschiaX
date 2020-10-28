using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sorschia.Security;

namespace Sorschia.SystemCore.UserPassword.CryptoKeyInstallerApp
{
    class Program
    {
        static void Main()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var publicKeyFilePath = configuration.GetValue<string>("UserPasswordCryptoKeyPath:Public");
            var privateKeyFilePath = configuration.GetValue<string>("UserPasswordCryptoKeyPath:Private");

            var services = new ServiceCollection()
                .AddSorschia(settings =>
                {
                    settings.SystemCore.UserPasswordCryptoKeySource = UserPasswordCryptoKeySource.File;
                    settings.SystemCore.UserPasswordPrivateKeyFilePath = privateKeyFilePath;
                    settings.SystemCore.UserPasswordPublicKeyFilePath = publicKeyFilePath;
                })
                .AddSorschiaBouncyCastle()
                .AddSingleton(configuration)
                .BuildServiceProvider();

            var keyPair = services.GetService<IRsaCryptoKeyGenerator>().Generate();
            var privateKeyWriter = services.GetService<IUserPasswordPrivateKeyWriter>();
            var publicKeyWriter = services.GetService<IUserPasswordPublicKeyWriter>();
            privateKeyWriter.WriteString(keyPair.PrivateKeyString);
            publicKeyWriter.WriteString(keyPair.PublicKeyString);
        }
    }
}
