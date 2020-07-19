using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sorschia.SystemCore.Controllers;

namespace Sorschia
{
    public static class IMvcBuilderExtensions
    {
        public static IMvcBuilder AddSorschiaApi(this IMvcBuilder instance, IConfiguration configuration)
        {
            var assembly = typeof(UserController).Assembly;

            instance.Services.AddSorschiaApi(configuration);

            return instance
                .AddApplicationPart(assembly);
        }
    }
}
