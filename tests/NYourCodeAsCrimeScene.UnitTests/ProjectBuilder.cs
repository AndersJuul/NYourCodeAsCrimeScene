using NYourCodeAsCrimeScene.Core.Entities;

namespace NYourCodeAsCrimeScene.UnitTests
{
    // Learn more about test builders:
    // https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
    public class ProjectBuilder
    {
        private Project _project = null;

        public ProjectBuilder Id(int id)
        {
            _project.Id = id;
            return this;
        }

        public ProjectBuilder WithDefaultValues()
        {
            _project = new Project("Hello", @"c:\world");

            return this;
        }

        public Project Build() => _project;

        public ProjectBuilder WithCommit(Commit commit)
        {
            var commits = _project.Commits;
            _project = new Project(_project.Name, _project.Path);
            
            foreach (var c in commits)
            {
                _project.AddCommit(c);
            }
            
            _project.AddCommit(commit);
            return this;
        }
    }
}
