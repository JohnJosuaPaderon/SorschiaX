using Microsoft.Extensions.DependencyInjection;
using Sorschia.SystemBase.Security.Processes;

namespace Sorschia.SystemBase
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection InternalAddSecurityProcesses(this IServiceCollection instance)
        {
            #region Application
            instance
                .InternalAddProcess<IDeleteApplication, DeleteApplication>()
                .InternalAddProcess<IGetApplication, GetApplication>()
                .InternalAddProcess<IGetApplicationList, GetApplicationList>()
                .InternalAddProcess<ISaveApplication, SaveApplication>();
            #endregion

            #region ApplicationPlatform
            instance
                .InternalAddProcess<IDeleteApplicationPlatform, DeleteApplicationPlatform>()
                .InternalAddProcess<IGetApplicationPlatform, GetApplicationPlatform>()
                .InternalAddProcess<IGetApplicationPlatformList, GetApplicationPlatformList>()
                .InternalAddProcess<ISaveApplicationPlatform, SaveApplicationPlatform>();
            #endregion

            #region Module
            instance
                .InternalAddProcess<IDeleteModule, DeleteModule>()
                .InternalAddProcess<IGetModule, GetModule>()
                .InternalAddProcess<IGetModuleList, GetModuleList>()
                .InternalAddProcess<ISaveModule, SaveModule>();
            #endregion

            #region Permission
            instance
                .InternalAddProcess<IDeletePermission, DeletePermission>()
                .InternalAddProcess<IGetPermission, GetPermission>()
                .InternalAddProcess<ISavePermission, SavePermission>();
            #endregion

            #region User
            instance
                .InternalAddProcess<IDeleteUser, DeleteUser>()
                .InternalAddProcess<IGetUser, GetUser>()
                .InternalAddProcess<ISaveUser, SaveUser>();
            #endregion

            return instance;
        }
    }
}
