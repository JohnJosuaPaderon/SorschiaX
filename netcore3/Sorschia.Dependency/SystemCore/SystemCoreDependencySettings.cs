using Sorschia.SystemCore.Configuration;
using System;

namespace Sorschia.SystemCore
{
    public sealed class SystemCoreDependencySettings
    {
        public RepositoryOption RepositoryOption { get; set; } = RepositoryOption.Cached;
        public UserPasswordCryptoKeySource UserPasswordCryptoKeySource { get; set; } = UserPasswordCryptoKeySource.None;
        public bool UseDefaultUserPasswordCryptors { get; set; } = true;
        public bool UseDefaultConfiguration { get; set; } = true;
        public string UserPasswordPublicKeyFilePath { get; set; }
        public string UserPasswordPrivateKeyFilePath { get; set; }
        public Action<SystemCoreConfiguration> ConfigureConfiguration { get; set; }

        internal SystemCoreDependencySettings() { }
    }
}
