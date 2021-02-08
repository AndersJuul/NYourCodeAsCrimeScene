using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using NYourCodeAsCrimeScene.Infrastructure.Data;
using NYourCodeAsCrimeScene.Web;

namespace NYourCodeAsCrimeScene.IntegrationTests
{
    public class IntegrationTestBaseWithIoc
    {
        protected IServiceProvider CreateServiceProvider()
        {
            // Get service provider.
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("testsettings.json")
                .Build();
            var serviceCollection = new ServiceCollection();
            new Startup(configuration, null).ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Create a scope to obtain a reference to the database
            // context (AppDbContext).
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<AppDbContext>();

                // Ensure the database is created.
                db.Database.Migrate();

                try
                {
                    // Seed the database with test data.
                    SeedData.PopulateTestData(db);
                }
                catch (Exception ex)
                {
                }
            }

            return serviceProvider;
        }
    }
}