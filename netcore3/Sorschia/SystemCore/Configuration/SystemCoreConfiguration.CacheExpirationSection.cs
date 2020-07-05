namespace Sorschia.SystemCore.Configuration
{
    public sealed partial class SystemCoreConfiguration
    {
        public sealed partial class CacheExpirationSection
        {
            private const long DEFAULT_DELETE = 10;
            private const long DEFAULT_GET = 2;
            private const long DEFAULT_SAVE = 5;
            private const long DEFAULT_SEARCH = 3;

            public ApplicationSection Application { get; set; } = new ApplicationSection();
            public ModuleSection Module { get; set; } = new ModuleSection();
            public PermissionSection Permission { get; set; } = new PermissionSection();
        }
    }
}
