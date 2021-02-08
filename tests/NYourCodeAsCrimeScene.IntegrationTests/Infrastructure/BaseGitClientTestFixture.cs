using Microsoft.Extensions.DependencyInjection;
using NYourCodeAsCrimeScene.Core.Interfaces;

namespace NYourCodeAsCrimeScene.IntegrationTests.Infrastructure
{
    public abstract class BaseGitClientTestFixture : IntegrationTestBaseWithIoc
    {
        protected IGitClient GetGitClient()
        {
            var serviceProvider = CreateServiceProvider();
            return serviceProvider.GetRequiredService<IGitClient>();
        }
    }
}