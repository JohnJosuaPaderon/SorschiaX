namespace Sorschia.Security
{
    public sealed class SecurityDependencySettings
    {
        public bool UseCryptoHash { get; set; } = true;

        internal SecurityDependencySettings() { }
    }
}
