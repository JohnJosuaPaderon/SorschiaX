using System.Reflection;

namespace Sorschia.Identity.Data.Configurations
{
    internal interface IConfigurationAssemblyProvider
    {
        public Assembly Assembly { get; }
    }
}
