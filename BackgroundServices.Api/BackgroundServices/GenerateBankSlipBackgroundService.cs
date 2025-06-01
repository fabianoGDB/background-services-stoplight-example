
using BackgroundServices.Api.Semaphores;
using BackgroundServices.Api.Services;

namespace BackgroundServices.Api.BackgroundServices
{
    public class GenerateBankSlipBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public GenerateBankSlipBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await ProcessBankSlip(stoppingToken);
            }

        }

        private async Task ProcessBankSlip(CancellationToken stoppingToken)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var _automaticBankSlipService = scope.ServiceProvider.GetRequiredService<IBankOperationsService>();

                await SemaphoresBackgroundServiceManagment.UseResourceAsync();
                await _automaticBankSlipService.GenerateBankSlipAsync();
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
