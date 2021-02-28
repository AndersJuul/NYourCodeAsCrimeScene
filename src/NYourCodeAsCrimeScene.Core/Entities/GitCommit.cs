using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using NYourCodeAsCrimeScene.SharedKernel;
using NYourCodeAsCrimeScene.SharedKernel.Interfaces;

namespace NYourCodeAsCrimeScene.Core.Entities
{
    public class GitCommit : BaseEntity, IAggregateRoot
    {
        public GitCommit(string commitId, in DateTime date, Project project) : this()
        {
            if (commitId.Contains(" "))
                throw new ArgumentException("CommitId can't contain a space.");
            CommitId = commitId;
            Date = date;
            Project = project;
        }

        private GitCommit()
        {
            GitFiles = new List<GitFile>();
        }

        public List<GitFile> GitFiles { get; set; }

        public string CommitId { get; set; }
        public DateTime Date { get; set; }

        public Project Project { get; }

        public int ProjectId { get; private set; }

        public void AddFile(GitFile gitFile)
        {
            GitFiles.Add(gitFile);
        }
    }
}