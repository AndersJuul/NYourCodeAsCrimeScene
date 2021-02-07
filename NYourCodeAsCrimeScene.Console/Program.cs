using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NYourCodeAsCrimeScene.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.)
            {
                var services = scope.ServiceProvider;

                logger.Info("Egis.Service Program Main");
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    //                    context.Database.Migrate();
                    context.Database.EnsureCreated();
                    SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
                finally
                {
                    logger.s
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .ConfigureAppConfiguration((hosting, config) => { config.AddEnvironmentVariables(); })
                        .ConfigureLogging((hostingContext, logging) =>
                        {
                            logging.ClearProviders();
                            logging.AddConsole();
                        })
                        .UseNLog()
                        .UseStartup<Startup>();
                });
        }
    }
}