namespace Sorschia.SystemCore
{
    public sealed class SystemCoreDependencySettings
    {
        public RepositoryOption RepositoryOption { get; set; } = RepositoryOption.Cached;

        internal SystemCoreDependencySettings() { }
    }
}
