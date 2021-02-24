using NYourCodeAsCrimeScene.SharedKernel;

namespace NYourCodeAsCrimeScene.Core.Entities
{
    public class GitFile:BaseEntity
    {
        public string Name { get; set; }

        public GitFile(string name)
        {
            Name = name;
        }

        public GitCommit GitCommit { get; set; }
    }
}