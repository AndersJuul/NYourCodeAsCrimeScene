using Microsoft.Extensions.DependencyInjection;
using NYourCodeAsCrimeScene.Core.Interfaces;
using Xunit.Abstractions;

namespace NYourCodeAsCrimeScene.IntegrationTests.Infrastructure
{
    public abstract class BaseUpdaterServiceTestFixture : IntegrationTestBaseWithIoc
    {
        protected BaseUpdaterServiceTestFixture(ITestOutputHelper output) : base(output)
        {
        }

        protected IUpdaterService GetUpdaterService()
        {
            var serviceProvider = CreateServiceProvider();
            return serviceProvider.GetRequiredService<IUpdaterService>();
        }
    }
}