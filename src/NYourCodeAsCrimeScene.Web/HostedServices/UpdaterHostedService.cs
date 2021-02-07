using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NYourCodeAsCrimeScene.Core.Interfaces;
using NYourCodeAsCrimeScene.Web.Options;

namespace NYourCodeAsCrimeScene.Web.HostedServices
{
    public class UpdaterHostedService: IHostedService, IDisposable
    {
        private readonly IUpdaterService _updaterService;
        private readonly GithubConnectionOptions _options;

        public UpdaterHostedService(IUpdaterService updaterService, IOptions<GithubConnectionOptions> options)
        {
            _updaterService = updaterService;
            _options = options.Value;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _updaterService.Update(projectName:"NYourCodeAsCrimeScene",
                projectPath: @"C:\Projects\NYourCodeAsCrimeScene");
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