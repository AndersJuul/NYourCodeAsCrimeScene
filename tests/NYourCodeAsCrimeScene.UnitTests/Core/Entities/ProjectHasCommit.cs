using System.Linq;
using Xunit;

namespace NYourCodeAsCrimeScene.UnitTests.Core.Entities
{
    public class ProjectHasCommit
    {
        [Fact]
        public void ReturnsTrueForExistingCommit()
        {
            var commit = new CommitBuilder()
                .WithDefaultValues()
                .Build();
            var project = new ProjectBuilder()
                .WithDefaultValues()
                .WithCommit(commit)
                .Build();

            Assert.True(project.HasCommit(commit.CommitId));
        }

        [Fact]
        public void ReturnsFalseForNonexistingCommit()
        {
            var commit = new CommitBuilder()
                .WithDefaultValues()
                .Build();
            var project = new ProjectBuilder()
                .WithDefaultValues()
                .Build();

            Assert.False(project.HasCommit(commit.CommitId));
        }
    }
}
