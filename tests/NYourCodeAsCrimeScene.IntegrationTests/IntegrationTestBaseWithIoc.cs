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
using Serilog;
using Xunit.Abstractions;

namespace NYourCodeAsCrimeScene.IntegrationTests
{
    public abstract class IntegrationTestBaseWithIoc : BaseTest
    {
        protected IntegrationTestBaseWithIoc(ITestOutputHelper output) : base(output)
        {
            var services = CreateServiceProvider();
            try
            {
                var context = services.GetRequiredService<AppDbContext>();
                context.Database.EnsureDeleted();
                context.Database.Migrate();
                SeedData.Initialize(services);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred seeding the DB.");
            }
        }

        protected IServiceProvider CreateServiceProvider()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddJsonFile("testsettings.json", optional: true, reloadOnChange: true);
            var configurationRoot = configurationBuilder
                .Build();

            Program.ConfigureLogging(configurationRoot,environment);

            Log.Logger = Log.ForContext("IsTest", true);
            
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
                        })
                        .UseSerilog();
                }).Build();

            var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            return services;
        }
    }
}