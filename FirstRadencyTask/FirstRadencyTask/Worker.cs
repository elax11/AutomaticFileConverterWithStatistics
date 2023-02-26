using Microsoft.Extensions.Hosting;

namespace FirstRadencyTask
{
    public class Worker : BackgroundService
    {
        readonly IFileWatcher filewatcher;

        public Worker(IFileWatcher watcher)
        {
            filewatcher = watcher;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            filewatcher.StartWatching();

            while (!stoppingToken.IsCancellationRequested)
            {

            }
        }
    }
}
