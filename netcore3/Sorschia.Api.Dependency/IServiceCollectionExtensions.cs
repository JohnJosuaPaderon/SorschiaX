using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Sorschia.Data;
using Sorschia.SystemCore;
using System;
using System.Threading.Tasks;

namespace Sorschia
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSorschiaApi(this IServiceCollection instance, IConfiguration configuration) => instance
            .InternalAddAuthentication(configuration)
            .AddAuthorization()
            .AddTransient<IAuthorizationHandler, ApiPermissionHandler>()
            .AddTransient<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>()
            .AddHttpContextAccessor()
            .AddData()
            .AddSystemCore();

        private static IServiceCollection InternalAddAuthentication(this IServiceCollection instance, IConfiguration configuration)
        {
            var accessTokenConfiguration = configuration.GetSection<AccessTokenConfiguration>(ApiConstants.AccessTokenConfigurationKey);

            instance
                .AddSingleton(accessTokenConfiguration)
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = accessTokenConfiguration.GetIssuerSigningKey(),
                        ValidIssuer = accessTokenConfiguration.Issuer,
                        ValidAudience = accessTokenConfiguration.Audience,
                        ValidateIssuerSigningKey = accessTokenConfiguration.ValidateIssuerSigningKey,
                        ValidateIssuer = accessTokenConfiguration.ValidateIssuer,
                        ValidateAudience = accessTokenConfiguration.ValidateAudience,
                        ValidateLifetime = accessTokenConfiguration.ValidateLifetime,
                        ClockSkew = TimeSpan.Zero
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception is SecurityTokenExpiredException)
                                context.Response.Headers.Add(ApiConstants.TokenExpiredHeader, "true");

                            return Task.CompletedTask;
                        }
                    };
                });

            return instance;
        }
    }
}
