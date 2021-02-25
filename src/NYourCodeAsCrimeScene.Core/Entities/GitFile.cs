using System;
using System.Collections.Generic;
using NYourCodeAsCrimeScene.SharedKernel;

namespace NYourCodeAsCrimeScene.Core.Entities
{
    public class GitFile : BaseEntity
    {
        public GitFile(string name, int length):this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name can't be empty or null.");
            Name = name;
            Length = length;
        }

        private GitFile()
        {
            GitFileEntries = new List<GitFileEntry>();
        }

        public List<GitFileEntry> GitFileEntries { get; set; }

        public string Name { get; set; }
        public int Length { get; set; }
        public GitCommit GitCommit { get; set; }
        public int GitCommitId { get; set; }

        public void AddGitFileEntry(GitFileEntry gitFileEntry)
        {
            GitFileEntries.Add(gitFileEntry);
        }
    }
}