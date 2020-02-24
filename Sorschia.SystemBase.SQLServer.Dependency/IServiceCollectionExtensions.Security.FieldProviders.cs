using Microsoft.Extensions.DependencyInjection;
using Sorschia.SystemBase.Security.FieldProviders;

namespace Sorschia.SystemBase
{
    partial class IServiceCollectionExtensions
    {
        public static IServiceCollection InternalAddSecurityFieldProviders(this IServiceCollection instance)
        {
            #region Application
            instance
                .InternalAddProvider<GetApplicationFieldProvider>()
                .InternalAddProvider<GetApplicationListFieldProvider>();
            #endregion

            #region ApplicationPlatform
            instance
                .InternalAddProvider<GetApplicationPlatformFieldProvider>()
                .InternalAddProvider<GetApplicationPlatformListFieldProvider>();
            #endregion

            #region Module
            instance
                .InternalAddProvider<GetModuleFieldProvider>()
                .InternalAddProvider<GetModuleListFieldProvider>();
            #endregion

            #region Permission
            instance
                .InternalAddProvider<GetPermissionFieldProvider>()
                .InternalAddProvider<GetPermissionListFieldProvider>();
            #endregion

            #region User
            instance
                .InternalAddProvider<GetUserFieldProvider>()
                .InternalAddProvider<GetUserListFieldProvider>();
            #endregion

            #region UserApplication
            instance
                .InternalAddProvider<GetUserApplicationListFieldProvider>();
            #endregion

            #region UserModule
            instance
                .InternalAddProvider<GetUserModuleListFieldProvider>();
            #endregion

            #region UserPermission
            instance
                .InternalAddProvider<GetUserPermissionListFieldProvider>();
            #endregion

            return instance;
        }
    }
}
