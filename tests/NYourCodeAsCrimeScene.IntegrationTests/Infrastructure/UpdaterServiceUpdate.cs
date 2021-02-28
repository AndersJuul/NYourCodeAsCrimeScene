using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NYourCodeAsCrimeScene.Core.Specifications;
using NYourCodeAsCrimeScene.SharedKernel.Interfaces;
using Xunit;
using Xunit.Abstractions;

namespace NYourCodeAsCrimeScene.IntegrationTests.Infrastructure
{
    public class UpdaterServiceUpdate : BaseUpdaterServiceTestFixture
    {
        public UpdaterServiceUpdate(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task CreatesExpectedNumberOfProjects()
        {
            var updaterService = GetUpdaterService();

            await updaterService.Update(
                "NYourCodeAsCrimeScene",
                @"C:\Projects\NYourCodeAsCrimeScene", 2);

            // Assert
            var repository = CreateServiceProvider().GetRequiredService<IRepository>();
            var projects = (await repository.ListAsync(new AllProjects())).ToArray();
            Output.WriteLine(JsonConvert.SerializeObject(projects, Formatting.Indented,
                new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore}));
            Assert.Single(projects);
        }
    }
}