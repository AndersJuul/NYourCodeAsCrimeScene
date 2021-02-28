using System;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NYourCodeAsCrimeScene.Infrastructure.Data;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace NYourCodeAsCrimeScene.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddJsonFile("testsettings.json", optional: true, reloadOnChange: true);
            var configurationRoot = configurationBuilder
                .Build();

            //configure logging first
            ConfigureLogging(configurationRoot,environment);
            
            var host = CreateHostBuilder(args,configurationRoot,configurationBuilder)
                .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    context.Database.Migrate();
                    //context.Database.EnsureCreated();
                    SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, IConfigurationRoot configurationRoot,
            IConfigurationBuilder configurationBuilder)
        {
            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .ConfigureAppConfiguration(_ => configurationBuilder.Build())
                        .UseSerilog();
                });
        }

        public static void ConfigureLogging(IConfigurationRoot configuration, string? environment)
        {
            var elasticsearchSinkOptions = ConfigureElasticSink(configuration);
            
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(elasticsearchSinkOptions)
                .Enrich.WithProperty("Environment", environment)
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        private static ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration)
        {
            var uriString = configuration["ElasticConfiguration:Uri"];
            var node = new Uri(uriString);
            return new ElasticsearchSinkOptions(node)
            {
                AutoRegisterTemplate = true,
                IndexFormat = $"logstash-{DateTime.UtcNow:yyyy.MM.dd}"
            };
        }
    }
}