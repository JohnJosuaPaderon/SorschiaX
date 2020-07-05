using Microsoft.Extensions.DependencyInjection;
using Sorschia.SystemCore.Queries;

namespace Sorschia.SystemCore
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddQueries(this IServiceCollection instance) => instance
            .AddSingleton<DeleteApplicationQuery>()
            .AddSingleton<DeleteModuleQuery>()
            .AddSingleton<DeletePermissionQuery>()
            .AddSingleton<DeleteUserApplicationQuery>()
            .AddSingleton<DeleteUserModuleQuery>()
            .AddSingleton<DeleteUserPermissionQuery>()
            .AddSingleton<GetApiPermissionQuery>()
            .AddSingleton<GetApplicationQuery>()
            .AddSingleton<GetModuleQuery>()
            .AddSingleton<GetPermissionQuery>()
            .AddSingleton<SaveApiPermissionQuery>()
            .AddSingleton<SaveApplicationQuery>()
            .AddSingleton<SaveModuleQuery>()
            .AddSingleton<SavePermissionQuery>()
            .AddSingleton<SaveUserApplicationQuery>()
            .AddSingleton<SaveUserModuleQuery>()
            .AddSingleton<SaveUserPermissionQuery>()
            .AddSingleton<SearchApplicationQuery>()
            .AddSingleton<SearchModuleQuery>()
            .AddSingleton<SearchPermissionQuery>();
    }
}
