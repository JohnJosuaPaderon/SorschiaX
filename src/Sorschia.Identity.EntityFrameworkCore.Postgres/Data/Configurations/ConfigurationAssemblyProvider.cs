using System.Reflection;

namespace Sorschia.Identity.Data.Configurations
{
    internal sealed class ConfigurationAssemblyProvider : IConfigurationAssemblyProvider
    {
        public Assembly Assembly { get; } = typeof(ConfigurationAssemblyProvider).Assembly;
    }
}
