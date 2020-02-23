using Microsoft.Extensions.DependencyInjection;
using Sorschia.SystemBase.Security.ParameterProviders;

namespace Sorschia.SystemBase
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection InternalAddParameterProviders(this IServiceCollection instance)
        {
            #region Application
            instance
                .InternalAddParameterProvider<DeleteApplicationParameterProvider>()
                .InternalAddParameterProvider<GetApplicationParameterProvider>()
                .InternalAddParameterProvider<GetApplicationListParameterProvider>()
                .InternalAddParameterProvider<RemoveApplicationFromPlatformParameterProvider>()
                .InternalAddParameterProvider<SaveApplicationParameterProvider>();
            #endregion

            #region ApplicationPlatform
            instance
                .InternalAddParameterProvider<DeleteApplicationPlatformParameterProvider>()
                .InternalAddParameterProvider<GetApplicationPlatformParameterProvider>()
                .InternalAddParameterProvider<SaveApplicationPlatformParameterProvider>();
            #endregion

            #region Module
            instance
                .InternalAddParameterProvider<DeleteModuleParameterProvider>()
                .InternalAddParameterProvider<GetModuleParameterProvider>()
                .InternalAddParameterProvider<RemoveModuleFromApplicationParameterProvider>()
                .InternalAddParameterProvider<SaveModuleParameterProvider>();
            #endregion

            #region Permission
            instance
                .InternalAddParameterProvider<DeletePermissionParameterProvider>()
                .InternalAddParameterProvider<GetPermissionParameterProvider>()
                .InternalAddParameterProvider<SavePermissionParameterProvider>();
            #endregion

            #region User
            instance
                .InternalAddParameterProvider<DeleteUserParameterProvider>()
                .InternalAddParameterProvider<GetUserParameterProvider>()
                .InternalAddParameterProvider<SaveUserParameterProvider>();
            #endregion

            #region UserApplication
            instance
                .InternalAddParameterProvider<DeleteUserApplicationParameterProvider>()
                .InternalAddParameterProvider<SaveUserApplicationParameterProvider>();
            #endregion

            #region UserModule
            instance
                .InternalAddParameterProvider<DeleteUserModuleParameterProvider>()
                .InternalAddParameterProvider<SaveUserModuleParameterProvider>();
            #endregion

            #region UserPermission
            instance
                .InternalAddParameterProvider<SaveUserPermissionParameterProvider>();
            #endregion

            return instance;
        }
    }
}
