using System;
using System.Collections.Generic;
using System.Linq;
using NYourCodeAsCrimeScene.SharedKernel;
using NYourCodeAsCrimeScene.SharedKernel.Interfaces;

namespace NYourCodeAsCrimeScene.Core.Entities
{
    public class Project : BaseEntity, IAggregateRoot
    {
        public Project(string name, string path):this()
        {
            Name = name;
            Path = path;
        }

        private Project()
        {
            Commits = new List<Commit>();
        }

        public string Name { get; set; }
        public string Path { get; set; }
        
        public List<Commit> Commits { get; set; }

        public bool HasCommit(string commitId)
        {
            return Commits.Any(x => x.CommitId == commitId);
        }

        public void AddCommit(Commit commit)
        {
            Commits.Add(commit);
        }
    }
}