using Sorschia.Security;
using Sorschia.Utilities;

namespace Sorschia
{
    public sealed class DependencySettings
    {
        public SecurityDependencySettings Security { get; } = new SecurityDependencySettings();
        public UtilitiesDependencySettings Utilities { get; } = new UtilitiesDependencySettings();

        internal DependencySettings() { }
    }
}
