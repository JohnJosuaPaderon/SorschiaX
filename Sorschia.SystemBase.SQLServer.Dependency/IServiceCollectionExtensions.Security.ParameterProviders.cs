using Microsoft.Extensions.DependencyInjection;
using Sorschia.SystemBase.Security.ParameterProviders;

namespace Sorschia.SystemBase
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection InternalAddSecurityParameterProviders(this IServiceCollection instance)
        {
            #region Application
            instance
                .InternalAddProvider<DeleteApplicationParameterProvider>()
                .InternalAddProvider<GetApplicationParameterProvider>()
                .InternalAddProvider<GetApplicationListParameterProvider>()
                .InternalAddProvider<RemoveApplicationFromPlatformParameterProvider>()
                .InternalAddProvider<SaveApplicationParameterProvider>();
            #endregion

            #region ApplicationPlatform
            instance
                .InternalAddProvider<DeleteApplicationPlatformParameterProvider>()
                .InternalAddProvider<GetApplicationPlatformParameterProvider>()
                .InternalAddProvider<GetApplicationPlatformListParameterProvider>()
                .InternalAddProvider<SaveApplicationPlatformParameterProvider>();
            #endregion

            #region Module
            instance
                .InternalAddProvider<DeleteModuleParameterProvider>()
                .InternalAddProvider<GetModuleParameterProvider>()
                .InternalAddProvider<GetModuleListParameterProvider>()
                .InternalAddProvider<RemoveModuleFromApplicationParameterProvider>()
                .InternalAddProvider<SaveModuleParameterProvider>();
            #endregion

            #region Permission
            instance
                .InternalAddProvider<DeletePermissionParameterProvider>()
                .InternalAddProvider<GetPermissionParameterProvider>()
                .InternalAddProvider<GetPermissionListParameterProvider>()
                .InternalAddProvider<SavePermissionParameterProvider>();
            #endregion

            #region User
            instance
                .InternalAddProvider<DeleteUserParameterProvider>()
                .InternalAddProvider<GetUserParameterProvider>()
                .InternalAddProvider<SaveUserParameterProvider>();
            #endregion

            #region UserApplication
            instance
                .InternalAddProvider<DeleteUserApplicationParameterProvider>()
                .InternalAddProvider<SaveUserApplicationParameterProvider>();
            #endregion

            #region UserModule
            instance
                .InternalAddProvider<DeleteUserModuleParameterProvider>()
                .InternalAddProvider<SaveUserModuleParameterProvider>();
            #endregion

            #region UserPermission
            instance
                .InternalAddProvider<SaveUserPermissionParameterProvider>();
            #endregion

            return instance;
        }
    }
}
