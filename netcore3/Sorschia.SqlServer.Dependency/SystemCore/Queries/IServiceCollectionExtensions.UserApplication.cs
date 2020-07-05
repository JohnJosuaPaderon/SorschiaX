using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Queries
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddUserApplication(this IServiceCollection instance) => instance
            .AddSingleton<DeleteUserApplicationQuery>()
            .AddSingleton<SaveUserApplicationQuery>();
    }
}
