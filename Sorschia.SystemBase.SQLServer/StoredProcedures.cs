namespace Sorschia.SystemBase
{
    internal static class StoredProcedures
    {
        public static class Security
        {
            #region Application
            public const string DeleteApplication = "Security.DeleteApplication";
            public const string GetApplication = "Security.GetApplication";
            public const string GetApplicationList = "Security.GetApplicationList";
            public const string RemoveApplicationFromPlatform = "Security.RemoveApplicationFromPlatform";
            public const string SaveApplication = "Security.SaveApplication";
            #endregion

            #region ApplicationPlatform
            public const string DeleteApplicationPlatform = "Security.DeleteApplicationPlatform";
            public const string GetApplicationPlatform = "Security.GetApplicationPlatform";
            public const string GetApplicationPlatformList = "Security.GetApplicationPlatformList";
            public const string SaveApplicationPlatform = "Security.SaveApplicationPlatform";
            #endregion

            #region Module
            public const string DeleteModule = "Security.DeleteModule";
            public const string GetModule = "Security.GetModule";
            public const string GetModuleList = "Security.GetModuleList";
            public const string RemoveModuleFromApplication = "Security.RemoveModuleFromApplication";
            public const string SaveModule = "Security.SaveModule";
            #endregion

            #region Permission
            public const string DeletePermission = "Security.DeleteApplication";
            public const string GetPermission = "Security.GetPermission";
            public const string GetPermissionList = "Security.GetPermissionList";
            public const string SavePermission = "Security.SavePermission";
            #endregion

            #region User
            public const string DeleteUser = "Security.DeleteUser";
            public const string GetUser = "Security.GetUser";
            public const string GetUserList = "Security.GetUserList";
            public const string SaveUser = "Security.SaveUser";
            #endregion

            #region UserApplication
            public const string DeleteUserApplication = "Security.DeleteUserApplication";
            public const string GetUserApplicationList = "Security.GetUserApplicationList";
            public const string SaveUserApplication = "Security.SaveUserApplication";
            #endregion

            #region UserModule
            public const string DeleteUserModule = "Security.DeleteUserModule";
            public const string GetUserModuleList = "Security.GetUserModuleList";
            public const string SaveUserModule = "Security.SaveuserModule";
            #endregion

            #region UserPermission
            public const string DeleteUserPermission = "Security.DeleteUserPermission";
            public const string SaveUserPermission = "Security.SaveUserPermission";
            #endregion
        }
    }
}
