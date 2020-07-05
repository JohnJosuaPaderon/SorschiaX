using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Queries
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddUserModule(this IServiceCollection instance) => instance
            .AddSingleton<DeleteUserModuleQuery>()
            .AddSingleton<SaveUserModuleQuery>();
    }
}
