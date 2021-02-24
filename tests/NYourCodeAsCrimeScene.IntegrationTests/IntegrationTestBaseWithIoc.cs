using System;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NYourCodeAsCrimeScene.Infrastructure.Data;
using NYourCodeAsCrimeScene.Web;
using Xunit.Abstractions;

namespace NYourCodeAsCrimeScene.IntegrationTests
{
    public abstract class IntegrationTestBaseWithIoc : BaseTest
    {
        protected IntegrationTestBaseWithIoc(ITestOutputHelper output) : base(output)
        {
        }

        protected IServiceProvider CreateServiceProvider()
        {
            var host = Host.CreateDefaultBuilder(new string[] { })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .ConfigureAppConfiguration((hosting, config) =>
                        {
                            config.AddEnvironmentVariables();
                            config.AddJsonFile("testsettings.json");
                        })
                        .UseStartup<Startup>()
                        .ConfigureLogging(logging =>
                        {
                            logging.ClearProviders();
                            logging.AddConsole();
                        });
                }).Build();

            var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
                SeedData.Initialize(services);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred seeding the DB.");
            }

            return services;
        }
    }
}