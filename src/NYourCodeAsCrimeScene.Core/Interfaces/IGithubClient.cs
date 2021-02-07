using System.Threading.Tasks;

namespace NYourCodeAsCrimeScene.Core.Services
{
    public interface IGithubClient
    {
        Task<Directory> GetRootDirectory(string owner, string name, string access_token, string[] fileExt);
    }
}