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
                .InternalAddProvider<GetPermissionFieldProvider>();
            #endregion

            #region User
            instance
                .InternalAddProvider<GetUserFieldProvider>();
            #endregion

            return instance;
        }
    }
}
