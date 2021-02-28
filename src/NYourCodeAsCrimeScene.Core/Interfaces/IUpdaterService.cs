using System.Threading.Tasks;

namespace NYourCodeAsCrimeScene.Core.Interfaces
{
    public interface IUpdaterService
    {
        Task Update(string projectName, string projectPath, int maxCommitsToInclude);
    }
}