using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace NYourCodeAsCrimeScene.IntegrationTests.Infrastructure
{
    public class GitClientGetCommits : BaseGitClientTestFixture
    {
        public GitClientGetCommits(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task ReturnsExpectedNumberOfCommits()
        {
            var gitClient = GetGitClient();

            var commitDtos = await gitClient.GetCommits(
                "NYourCodeAsCrimeScene",
                @"C:\Projects\NYourCodeAsCrimeScene",
                new[] {""});
            
            Output.WriteLine(JsonConvert.SerializeObject(commitDtos.OrderBy(x=>x.Date), Formatting.Indented));
            
            Assert.Equal(7, commitDtos.Count(x=>x.Date<new DateTime(2021,2,8)));
        }

    }
}