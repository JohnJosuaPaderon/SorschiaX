using Microsoft.Extensions.DependencyInjection;
using Sorschia.SystemBase.Security.CommandProviders;

namespace Sorschia.SystemBase
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection InternalAddCommandProviders(this IServiceCollection instance)
        {
            #region Application
            instance
                .InternalAddCommandProvider<DeleteApplicationCommandProvider>()
                .InternalAddCommandProvider<GetApplicationCommandProvider>()
                .InternalAddCommandProvider<GetApplicationListCommandProvider>()
                .InternalAddCommandProvider<RemoveApplicationFromPlatformCommandProvider>()
                .InternalAddCommandProvider<SaveApplicationCommandProvider>();
            #endregion

            #region ApplicationPlatform
            instance
                .InternalAddCommandProvider<DeleteApplicationPlatformCommandProvider>()
                .InternalAddCommandProvider<GetApplicationPlatformCommandProvider>()
                .InternalAddCommandProvider<SaveApplicationPlatformCommandProvider>();
            #endregion

            #region Module
            instance
                .InternalAddCommandProvider<DeleteModuleCommandProvider>()
                .InternalAddCommandProvider<GetModuleCommandProvider>()
                .InternalAddCommandProvider<RemoveModuleFromApplicationCommandProvider>()
                .InternalAddCommandProvider<SaveModuleCommandProvider>();
            #endregion

            #region Permission
            instance
                .InternalAddCommandProvider<DeletePermissionCommandProvider>()
                .InternalAddCommandProvider<GetPermissionCommandProvider>()
                .InternalAddCommandProvider<SavePermissionCommandProvider>();
            #endregion

            #region User
            instance
                .InternalAddCommandProvider<DeleteUserCommandProvider>()
                .InternalAddCommandProvider<GetUserCommandProvider>()
                .InternalAddCommandProvider<SaveUserCommandProvider>();
            #endregion

            #region UserApplication
            instance
                .InternalAddCommandProvider<DeleteUserApplicationCommandProvider>()
                .InternalAddCommandProvider<SaveUserApplicationCommandProvider>();
            #endregion

            #region UserModule
            instance
                .InternalAddCommandProvider<DeleteUserModuleCommandProvider>()
                .InternalAddCommandProvider<SaveUserModuleCommandProvider>();
            #endregion

            #region UserPermission
            instance
                .InternalAddCommandProvider<DeleteUserPermissionCommandProvider>()
                .InternalAddCommandProvider<SaveUserPermissionCommandProvider>();
            #endregion

            return instance;
        }
    }
}
