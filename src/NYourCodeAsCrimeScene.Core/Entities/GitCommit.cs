using System;
using System.Collections.Generic;
using NYourCodeAsCrimeScene.SharedKernel;
using NYourCodeAsCrimeScene.SharedKernel.Interfaces;

namespace NYourCodeAsCrimeScene.Core.Entities
{
    public class GitCommit : BaseEntity, IAggregateRoot
    {
        public GitCommit(string commitId, in DateTime date, Project? project) : this()
        {
            if (commitId.Contains(" "))
                throw new ArgumentException("CommitId can't contain a space.");
            CommitId = commitId;
            Date = date;
        }

        private GitCommit()
        {
            GitFiles = new List<GitFile>();
        }

        public string CommitId { get; private set; }
        public DateTime Date { get; private set; }

        public Project Project { get; private set; }
        public List<GitFile> GitFiles { get; private set; }
        public int ProjectId { get; private set; }

        public void AddFile(GitFile gitFile)
        {
            GitFiles.Add(gitFile);
        }

        public void AddGitFileEntry(GitFileEntry gitFileEntry)
        {
            throw new NotImplementedException();
        }
    }
}