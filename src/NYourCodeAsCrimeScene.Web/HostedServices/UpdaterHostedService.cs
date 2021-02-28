using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NYourCodeAsCrimeScene.Core.Interfaces;

namespace NYourCodeAsCrimeScene.Web.HostedServices
{
    public class UpdaterHostedService: IHostedService, IDisposable
    {
        private readonly ILogger<UpdaterHostedService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;

        public UpdaterHostedService(ILogger<UpdaterHostedService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(30));
        }

        private async void DoWork(object state)
        {
            try
            {
                _logger.LogInformation("Timed Hosted Service is working. Count.");

                var serviceScope = _serviceProvider.CreateScope();
                var updaterService = serviceScope.ServiceProvider.GetRequiredService<IUpdaterService>();
                await updaterService.Update(projectName: "NYourCodeAsCrimeScene",
                    projectPath: @"C:\Projects\NYourCodeAsCrimeScene", 1);
            }
            catch (Exception e)
            {
                _logger.LogError(e,"During DoWork");
            }
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}