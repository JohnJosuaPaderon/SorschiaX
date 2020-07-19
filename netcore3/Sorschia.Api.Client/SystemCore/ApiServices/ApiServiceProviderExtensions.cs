using Sorschia.ApiServices;

namespace Sorschia.SystemCore.ApiServices
{
    internal static class ApiServiceProviderExtensions
    {
        public static IApplicationApiService Application(this ApiServiceProvider instance) => instance.GetApiService<IApplicationApiService>(ControllerRoutes.SystemCore.Application);

        public static IModuleApiService Module(this ApiServiceProvider instance) => instance.GetApiService<IModuleApiService>(ControllerRoutes.SystemCore.Module);

        public static IPermissionApiService Permission(this ApiServiceProvider instance) => instance.GetApiService<IPermissionApiService>(ControllerRoutes.SystemCore.Permission);

        public static IPermissionGroupApiService PermissionGroup(this ApiServiceProvider instance) => instance.GetApiService<IPermissionGroupApiService>(ControllerRoutes.SystemCore.PermissionGroup);

        public static IPlatformApiService Platform(this ApiServiceProvider instance) => instance.GetApiService<IPlatformApiService>(ControllerRoutes.SystemCore.Platform);

        public static IUserApiService User(this ApiServiceProvider instance) => instance.GetApiService<IUserApiService>(ControllerRoutes.SystemCore.User);
    }
}
