using System;
using NYourCodeAsCrimeScene.SharedKernel;

namespace NYourCodeAsCrimeScene.Core.Entities
{
    public class GitFile:BaseEntity
    {
        public string Name { get; set; }

        public GitFile(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name can't be empty or null.");
            Name = name;
        }

        public GitCommit GitCommit { get; set; }
    }
}