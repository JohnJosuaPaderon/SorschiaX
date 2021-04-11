using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Sorschia.Api.Configurations
{
    internal static class ApiVersioningConfiguration
    {
        public static void Configure(ApiVersioningOptions options)
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
        }
    }
}
