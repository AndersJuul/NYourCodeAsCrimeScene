using System;
using System.Threading.Tasks;
using GithubClient;
using NYourCodeAsCrimeScene.Core.Interfaces;

namespace NYourCodeAsCrimeScene.Core.Services
{
    public class UpdaterService : IUpdaterService
    {
        public async Task Update(string accessToken)
        {
            await Task.CompletedTask;

            var directory = await GithubClient.Github.getRepo("AndersJuul", "NYourCodeAsCrimeScene", accessToken);
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