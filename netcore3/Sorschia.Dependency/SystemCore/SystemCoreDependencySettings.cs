using Sorschia.SystemCore.Configuration;
using System;

namespace Sorschia.SystemCore
{
    public sealed class SystemCoreDependencySettings
    {
        public RepositoryOption RepositoryOption { get; set; } = RepositoryOption.Cached;
        public bool UseDefaultUserPasswordCryptors { get; set; } = true;
        public bool UseDefaultConfiguration { get; set; } = true;
        public Action<SystemCoreConfiguration> Configure { get; set; }

        internal SystemCoreDependencySettings() { }
    }
}
