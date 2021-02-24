using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NYourCodeAsCrimeScene.Infrastructure.Data;
using Xunit;
using Xunit.Abstractions;

namespace NYourCodeAsCrimeScene.IntegrationTests.Infrastructure
{
    public class UpdaterServiceGetCommits : BaseUpdaterServiceTestFixture
    {
        public UpdaterServiceGetCommits(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task CreatesExpectedNumberOfProjects()
        {
            var gitClient = GetUpdaterService();

            await gitClient.Update(
                "NYourCodeAsCrimeScene",
                @"C:\Projects\NYourCodeAsCrimeScene");
            
            //Output.WriteLine(JsonConvert.SerializeObject(commitDtos.OrderBy(x=>x.Date), Formatting.Indented));
            
            Assert.Equal(1, base.CreateServiceProvider().GetRequiredService<AppDbContext>().Projects.Count());
        }

    }
}