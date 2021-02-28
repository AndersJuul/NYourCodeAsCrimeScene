using System;
using System.Collections.Generic;
using NYourCodeAsCrimeScene.SharedKernel;

namespace NYourCodeAsCrimeScene.Core.Entities
{
    public class GitFile : BaseEntity
    {
        public GitFile(string name, int length, GitCommit gitCommit) : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name can't be empty or null.");
            Name = name;
            Length = length;
            GitCommit = gitCommit;
        }

        private GitFile()
        {
            GitFileEntries = new List<GitFileEntry>();
        }

        public List<GitFileEntry> GitFileEntries { get; private set; }

        public string Name { get; private set; }
        public int Length { get; private set; }
        public GitCommit GitCommit { get; set; }
        public int GitCommitId { get; set; }

        public void AddGitFileEntry(GitFileEntry gitFileEntry)
        {
            GitFileEntries.Add(gitFileEntry);
        }
    }
}