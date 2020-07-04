using Microsoft.Extensions.DependencyInjection;
using Sorschia.SystemCore.Queries;

namespace Sorschia.SystemCore
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddQueries(this IServiceCollection instance) => instance
            .AddSingleton<DeleteApplicationQuery>()
            .AddSingleton<DeleteModuleQuery>()
            .AddSingleton<DeleteUserApplicationQuery>()
            .AddSingleton<DeleteUserModuleQuery>()
            .AddSingleton<GetApplicationQuery>()
            .AddSingleton<GetModuleQuery>()
            .AddSingleton<SaveApplicationQuery>()
            .AddSingleton<SaveModuleQuery>()
            .AddSingleton<SaveUserApplicationQuery>()
            .AddSingleton<SaveUserModuleQuery>()
            .AddSingleton<SearchApplicationQuery>()
            .AddSingleton<SearchModuleQuery>();
    }
}
