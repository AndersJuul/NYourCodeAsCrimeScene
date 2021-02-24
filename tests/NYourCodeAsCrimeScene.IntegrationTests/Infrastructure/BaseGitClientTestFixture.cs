using Microsoft.Extensions.DependencyInjection;
using NYourCodeAsCrimeScene.Core.Interfaces;
using Xunit.Abstractions;

namespace NYourCodeAsCrimeScene.IntegrationTests.Infrastructure
{
    public abstract class BaseGitClientTestFixture : IntegrationTestBaseWithIoc
    {
        protected BaseGitClientTestFixture(ITestOutputHelper output) : base(output)
        {
        }

        protected IGitClient GetGitClient()
        {
            var serviceProvider = CreateServiceProvider();
            return serviceProvider.GetRequiredService<IGitClient>();
        }
    }
}