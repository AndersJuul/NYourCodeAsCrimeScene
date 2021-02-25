using System;
using NYourCodeAsCrimeScene.SharedKernel;

namespace NYourCodeAsCrimeScene.Core.Entities
{
    public class GitFile : BaseEntity
    {
        public GitFile(string name, int length)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name can't be empty or null.");
            Name = name;
            Length = length;
        }

        public string Name { get; set; }
        public int Length { get; set; }
        public GitCommit GitCommit { get; set; }
    }
}