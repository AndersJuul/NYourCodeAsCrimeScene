using System;
using System.Threading.Tasks;
using NYourCodeAsCrimeScene.Core.Interfaces;

namespace NYourCodeAsCrimeScene.Core.Services
{
    public class UpdaterService : IUpdaterService
    {
        public async Task Update()
        {
            await Task.CompletedTask;
        }
    }
}