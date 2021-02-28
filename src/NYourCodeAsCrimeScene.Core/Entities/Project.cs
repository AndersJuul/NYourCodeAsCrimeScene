using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NYourCodeAsCrimeScene.SharedKernel;
using NYourCodeAsCrimeScene.SharedKernel.Interfaces;

namespace NYourCodeAsCrimeScene.Core.Entities
{
    public class Project : BaseEntity, IAggregateRoot
    {
        public Project(string name, string path) : this()
        {
            Name = name;
            Path = path;
        }

        private Project()
        {
            Commits = new List<GitCommit>();
        }

        public string Name { get; set; }
        public string Path { get; set; }

        public List<GitCommit> Commits { get; set; }

        public bool HasCommit(string commitId)
        {
            return Commits.Any(x => x.CommitId == commitId);
        }

        public void AddCommit(GitCommit gitCommit)
        {
            Commits.Add(gitCommit);
        }

        [CanBeNull]
        public GitCommit CommitById(string commitId)
        {
            return Commits.SingleOrDefault(x => x.CommitId == commitId);
        }
    }
}