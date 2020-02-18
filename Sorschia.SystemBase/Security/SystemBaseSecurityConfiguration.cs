namespace Sorschia.SystemBase.Security
{
    public class SystemBaseSecurityConfiguration
    {
        public sealed class CacheExpirationSection
        {
            #region SystemApplication
            public long? DeleteApplication { get; set; } = 60;
            public long? GetApplication { get; set; } = 3;
            public long? SaveApplication { get; set; } = 5;
            #endregion

            #region SystemModule
            public long? DeleteModule { get; set; } = 60;
            public long? GetModule { get; set; } = 3;
            public long? SaveModule { get; set; } = 5;
            #endregion

            #region SystemPermission
            public long? DeletePermission { get; set; } = 60;
            public long? GetPermission { get; set; } = 3;
            public long? SavePermission { get; set; } = 5;
            #endregion

            #region SystemUser
            public long? DeleteUser { get; set; } = 60;
            public long? GetUser { get; set; } = 3;
            public long? SaveUser { get; set; } = 5;
            #endregion
        }

        public CacheExpirationSection CacheExpiration { get; set; } = new CacheExpirationSection();
    }
}
