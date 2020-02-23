using Microsoft.Extensions.DependencyInjection;
using Sorschia.SystemBase.Security.FieldProviders;

namespace Sorschia.SystemBase
{
    partial class IServiceCollectionExtensions
    {
        public static IServiceCollection InternalAddFieldProviders(this IServiceCollection instance)
        {
            #region Application
            instance
                .InternalAddFieldProvider<GetApplicationFieldProvider>()
                .InternalAddFieldProvider<GetApplicationListFieldProvider>();
            #endregion

            #region ApplicationPlatform
            instance
                .InternalAddFieldProvider<GetApplicationPlatformFieldProvider>()
                .InternalAddFieldProvider<GetApplicationPlatformListFieldProvider>();
            #endregion

            #region Module
            instance
                .InternalAddFieldProvider<GetModuleFieldProvider>();
            #endregion

            #region Permission
            instance
                .InternalAddFieldProvider<GetPermissionFieldProvider>();
            #endregion

            #region User
            instance
                .InternalAddFieldProvider<GetUserFieldProvider>();
            #endregion

            return instance;
        }
    }
}
