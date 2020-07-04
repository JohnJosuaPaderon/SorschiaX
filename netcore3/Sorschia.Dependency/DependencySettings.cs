using Sorschia.Security;
using Sorschia.SystemCore;
using Sorschia.Utilities;

namespace Sorschia
{
    public sealed class DependencySettings
    {
        public SecurityDependencySettings Security { get; } = new SecurityDependencySettings();
        public SystemCoreDependencySettings SystemCore { get; } = new SystemCoreDependencySettings();
        public UtilitiesDependencySettings Utilities { get; } = new UtilitiesDependencySettings();

        internal DependencySettings() { }
    }
}
