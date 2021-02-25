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
            GitFiles = new List<GitFile>();
        }

        public string Name { get; set; }
        public string Path { get; set; }

        public List<GitCommit> Commits { get; set; }
        public List<GitFile> GitFiles { get; set; }

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

        public void AddFileEntry(GitCommit commit, GitFile gitFile, int fileLength)
        {
            var commitById = CommitById(commit.CommitId);
            if (commitById == null)
            {
                Commits.Add(commit);
                commitById = commit;
            }

            var gitFileById = GitFiles.SingleOrDefault(x => x.Name == gitFile.Name);
            if (gitFileById == null)
            {
                GitFiles.Add(gitFile);
                gitFileById = gitFile;
            }

            var gitFileEntry = new GitFileEntry(commitById, gitFileById, fileLength);
            commit.AddGitFileEntry(gitFileEntry);
            gitFileById.AddGitFileEntry(gitFileEntry);
        }
    }
}