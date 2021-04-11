using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Sorschia.Api.Configurations
{
    internal static class SwaggerGenConfiguration
    {
        public static void Configure(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Sorschia.Api", Version = "v1" });
            //options.SwaggerDoc("v2", new OpenApiInfo { Title = "Sorschia.Api", Version = "v2" });
        }
    }
}
