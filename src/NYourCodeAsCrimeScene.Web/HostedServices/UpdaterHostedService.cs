using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using NYourCodeAsCrimeScene.Core.Interfaces;
using NYourCodeAsCrimeScene.Core.Services;

namespace NYourCodeAsCrimeScene.Web.HostedServices
{
    public class UpdaterHostedService: IHostedService, IDisposable
    {
        private readonly IUpdaterService _updaterService;

        public UpdaterHostedService(IUpdaterService updaterService)
        {
            _updaterService = updaterService;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _updaterService.Update();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}