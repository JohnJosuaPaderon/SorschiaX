using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Processes
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddUser(this IServiceCollection instance) => instance
            .AddTransient<IDeleteUser, DeleteUser>()
            .AddTransient<IGetUser, GetUser>()
            .AddTransient<ILoginUser, LoginUser>()
            .AddTransient<ISaveUser, SaveUser>()
            .AddTransient<ISearchUser, SearchUser>()
            .AddTransient<IValidateUserApplication, ValidateUserApplication>()
            .AddTransient<IValidateUserModule, ValidateUserModule>()
            .AddTransient<IValidateUserPermission, ValidateUserPermission>();
    }
}
