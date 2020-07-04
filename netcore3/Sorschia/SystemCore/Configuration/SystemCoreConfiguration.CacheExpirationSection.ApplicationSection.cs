namespace Sorschia.SystemCore.Configuration
{
    public sealed partial class SystemCoreConfiguration
    {
        public sealed partial class CacheExpirationSection
        {
            public sealed class ApplicationSection
            {
                public long? Delete { get; set; } = DEFAULT_DELETE;
                public long? Get { get; set; } = DEFAULT_GET;
                public long? Save { get; set; } = DEFAULT_SAVE;
                public long? Search { get; set; } = DEFAULT_SEARCH;
            }
        }
    }
}
