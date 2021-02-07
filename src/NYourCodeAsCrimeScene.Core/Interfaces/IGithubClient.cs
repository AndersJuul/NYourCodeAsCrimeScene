using System.Threading.Tasks;
using NYourCodeAsCrimeScene.Core.Services;

namespace NYourCodeAsCrimeScene.Core.Interfaces
{
    public interface IGithubClient
    {
        Task<GitDirectory> GetRootDirectory(string owner, string name, string access_token, string[] fileExt);
    }
}