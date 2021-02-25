using NYourCodeAsCrimeScene.SharedKernel;

namespace NYourCodeAsCrimeScene.Core.Entities
{
    public class GitFileEntry : BaseEntity
    {
        public GitCommit Commit { get; set; }
        public GitFile GitFile { get; set; }
        public int FileLength { get; set; }

        public GitFileEntry(GitCommit commit, GitFile gitFile, int fileLength):this()
        {
            Commit = commit;
            GitFile = gitFile;
            FileLength = fileLength;
        }

        private GitFileEntry()
        {
        }
    }
}