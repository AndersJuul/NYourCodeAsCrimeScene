using NYourCodeAsCrimeScene.SharedKernel;

namespace NYourCodeAsCrimeScene.Core.Entities
{
    public class GitFileEntry : BaseEntity
    {
        public GitFile GitFile { get; set; }
        public int FileLength { get; set; }

        public GitFileEntry(GitFile gitFile, int fileLength) : this()
        {
            GitFile = gitFile;
            FileLength = fileLength;
        }

        private GitFileEntry()
        {
        }
    }
}