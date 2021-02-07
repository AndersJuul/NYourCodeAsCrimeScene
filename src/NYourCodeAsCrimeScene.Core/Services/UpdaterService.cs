using System;
using System.Threading.Tasks;
using NYourCodeAsCrimeScene.Core.Interfaces;

namespace NYourCodeAsCrimeScene.Core.Services
{
    public class UpdaterService : IUpdaterService
    {
        private readonly IGithubClient _githubClient;

        public UpdaterService(IGithubClient githubClient)
        {
            _githubClient = githubClient;
        }
        
        public async Task Update(string accessToken)
        {
            var directory = await _githubClient.GetRootDirectory("AndersJuul", "NYourCodeAsCrimeScene", accessToken, new []{"cs"});
            NewMethod(directory);
        }

        private static void NewMethod(Directory directory)
        {
            foreach (var directoryFile in directory.files)
            {
                Console.WriteLine(directoryFile.name);
            }

            foreach (var directorySubDir in directory.subDirs)
            {
                NewMethod(directorySubDir);
            }
        }
    }
}