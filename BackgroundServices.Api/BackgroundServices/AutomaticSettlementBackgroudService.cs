using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackgroundServices.Api.Semaphores;
using BackgroundServices.Api.Services;

namespace BackgroundServices.Api.BackgroundServices
{
    public class AutomaticSettlementBackgroudService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public AutomaticSettlementBackgroudService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await ProcessAutomaticSettlement(stoppingToken);
            }

        }

        private async Task ProcessAutomaticSettlement(CancellationToken stoppingToken)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var _automaticSettlementService = scope.ServiceProvider.GetRequiredService<IBankOperationsService>();

                await SemaphoresBackgroundServiceManagment.UseResourceAsync();
                await _automaticSettlementService.ExecuteAutomaticSettlementAsync();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                SemaphoresBackgroundServiceManagment.ReleaseResource();
                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }
    }
}