namespace BackgroundServices.Api.Semaphores
{
    public class SemaphoresBackgroundServiceManagment
    {
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public static async Task UseResourceAsync()
        {
            await _semaphore.WaitAsync();
        }

        public static void ReleaseResource()
        {
            _semaphore.Release();
        }

    }
}
