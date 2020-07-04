namespace Sorschia.SystemCore.Configuration
{
    public sealed partial class SystemCoreConfiguration
    {
        public CacheExpirationSection CacheExpiration { get; set; } = new CacheExpirationSection();
    }
}
