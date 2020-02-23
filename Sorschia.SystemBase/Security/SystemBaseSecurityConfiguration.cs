namespace Sorschia.SystemBase.Security
{
    public class SystemBaseSecurityConfiguration
    {
        public sealed class CacheExpirationSection
        {
            #region Application
            public long? DeleteApplication { get; set; } = 60;
            public long? GetApplication { get; set; } = 3;
            public long? GetApplicationList { get; set; } = 3;
            public long? SaveApplication { get; set; } = 10;
            #endregion

            #region ApplicationPlatform
            public long? DeleteApplicationPlatform { get; set; } = 60;
            public long? GetApplicationPlatform { get; set; } = 3;
            public long? GetApplicationPlatformList { get; set; } = 3;
            public long? SaveApplicationPlatform { get; set; } = 10;
            #endregion

            #region Module
            public long? DeleteModule { get; set; } = 60;
            public long? GetModule { get; set; } = 3;
            public long? GetModuleList { get; set; } = 3;
            public long? SaveModule { get; set; } = 10;
            #endregion

            #region Permission
            public long? DeletePermission { get; set; } = 60;
            public long? GetPermission { get; set; } = 3;
            public long? GetPermissionList { get; set; } = 3;
            public long? SavePermission { get; set; } = 10;
            #endregion

            #region User
            public long? DeleteUser { get; set; } = 60;
            public long? GetUser { get; set; } = 3;
            public long? GetUserList { get; set; } = 3;
            public long? SaveUser { get; set; } = 10;
            #endregion
        }

        public CacheExpirationSection CacheExpiration { get; set; } = new CacheExpirationSection();
    }
}
