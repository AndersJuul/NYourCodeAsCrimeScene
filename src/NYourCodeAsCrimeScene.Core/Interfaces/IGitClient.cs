using System.Collections.Generic;
using System.Threading.Tasks;
using NYourCodeAsCrimeScene.Core.Services;

namespace NYourCodeAsCrimeScene.Core.Interfaces
{
    public interface IGitClient
    {
        Task<IEnumerable<CommitDto>> GetCommits(string projectName, string projectPath, string[] fileExt);
        Task<IEnumerable<FileDto>> GetFiles(string projectPath, string commitId);
        Task<string[]> GetFileContent(string projectPath, string commitId, string fileDtoName);
    }
}