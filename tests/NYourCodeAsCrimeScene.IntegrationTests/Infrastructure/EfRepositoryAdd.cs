using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NYourCodeAsCrimeScene.IntegrationTests.Infrastructure
{
    public class GitClientGetCommits : BaseGitClientTestFixture
    {
        [Fact]
        public async Task ReturnsExpectedNumberOfCommits()
        {
            var gitClient = GetGitClient();

            var commitDtos = await gitClient.GetCommits(
                projectName: "NYourCodeAsCrimeScene",
                projectPath: @"C:\Projects\NYourCodeAsCrimeScene", 
                new[] {""});
            Assert.Equal(3, commitDtos.Count());
        }
    }
}