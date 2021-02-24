using System.Linq;
using Xunit;

namespace NYourCodeAsCrimeScene.UnitTests.Core.Entities
{
    public class ProjectAddCommit
    {
        [Fact]
        public void AddsCommit()
        {
            var commit = new CommitBuilder()
                .WithDefaultValues()
                .Build();
            var project = new ProjectBuilder()
                .WithDefaultValues()
                .Build();
            Assert.Equal(0, project.Commits.Count);
            project.AddCommit(commit);
            Assert.Equal(1,project.Commits.Count);
        }

    }
}
