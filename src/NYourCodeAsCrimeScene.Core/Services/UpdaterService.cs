using System;
using System.Threading.Tasks;
using MediatR;
using NYourCodeAsCrimeScene.Core.Interfaces;

namespace NYourCodeAsCrimeScene.Core.Services
{
    public class UpdaterService : IUpdaterService
    {
        private readonly IGitClient _gitClient;

        public UpdaterService(IGitClient gitClient)
        {
            _gitClient = gitClient;
        }
        
        public async Task Update(string projectName, string projectPath)
        {
            var commits = await _gitClient
                .GetCommits(projectName, projectPath, new []{"cs"});
        }
    }
}