using Xunit.Abstractions;

namespace NYourCodeAsCrimeScene.IntegrationTests
{
    public abstract class BaseTest
    {
        protected readonly ITestOutputHelper Output;

        protected BaseTest(ITestOutputHelper output)
        {
            Output = output;
        }
    }
}