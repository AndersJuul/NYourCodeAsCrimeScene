using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NYourCodeAsCrimeScene.Infrastructure.Data;
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
            var gitClient = GetUpdaterService();

            await gitClient.Update(
                "NYourCodeAsCrimeScene",
                @"C:\Projects\NYourCodeAsCrimeScene");

            Assert.Equal(1, CreateServiceProvider().GetRequiredService<AppDbContext>().Projects.Count());
        }
    }
}