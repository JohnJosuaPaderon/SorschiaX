namespace Sorschia.Security
{
    public sealed class SecurityDependencySettings
    {
        public bool UseAesCrypto { get; set; } = true;
        public bool UseCryptoHash { get; set; } = true;

        internal SecurityDependencySettings() { }
    }
}
