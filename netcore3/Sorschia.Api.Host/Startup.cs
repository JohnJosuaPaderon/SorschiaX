using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sorschia.Caching;
using Sorschia.SystemCore;
using System;

namespace Sorschia
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSorschia(settings =>
                {
                    settings.SystemCore.UserPasswordCryptoKeySource = UserPasswordCryptoKeySource.File;
                    settings.SystemCore.UserPasswordPrivateKeyFilePath = Configuration.GetValue<string>("UserPasswordCryptoKeyPath:Private");
                    settings.SystemCore.UserPasswordPublicKeyFilePath = Configuration.GetValue<string>("UserPasswordCryptoKeyPath:Public");
                })
                .AddSorschiaBouncyCastle()
                .AddSorschiaCaching()
                .AddSorschiaSqlServer();

            services.AddControllers()
                .AddSorschiaApi(Configuration)
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseExceptionHandler("/error");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
