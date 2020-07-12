using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Queries
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddUser(this IServiceCollection instance) => instance
            .AddSingleton<DeleteUserQuery>()
            .AddSingleton<GetUserByCredentialsQuery>()
            .AddSingleton<GetUserQuery>()
            .AddSingleton<SaveUserQuery>()
            .AddSingleton<SearchUserQuery>()
            .AddSingleton<ValidateUserApplicationQuery>()
            .AddSingleton<ValidateUserModuleQuery>()
            .AddSingleton<ValidateUserPermissionQuery>();
    }
}
