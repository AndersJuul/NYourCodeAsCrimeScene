using MediatR;
using Moq;
using NYourCodeAsCrimeScene.Core.Interfaces;
using NYourCodeAsCrimeScene.Infrastructure;

namespace NYourCodeAsCrimeScene.IntegrationTests.Infrastructure
{
    public abstract class BaseGitClientTestFixture
    {
        protected IGitClient GetGitClient()
        {
            var mockMediator = new Mock<IMediator>();
            return new GitClient(mockMediator.Object);
        }
    }
}