namespace Sorschia.SystemCore.Configuration
{
    partial class SystemCoreConfiguration
    {
        partial class CacheExpirationSection
        {
            public sealed class UserSection
            {
                public long? Delete { get; set; } = DEFAULT_DELETE;
                public long? Get { get; set; } = DEFAULT_GET;
                public long? Login { get; set; } = 2;
                public long? Save { get; set; } = DEFAULT_SAVE;
                public long? Search { get; set; } = DEFAULT_SEARCH;
                public long? ValidateUserApplication { get; set; } = 2;
                public long? ValidateUserModule { get; set; } = 2;
                public long? ValidateUserPermission { get; set; } = 2;
            }
        }
    }
}
