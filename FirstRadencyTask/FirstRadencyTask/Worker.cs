using Microsoft.Extensions.Hosting;

using FileProcessor;

namespace FirstRadencyTask
{
    public class Worker : BackgroundService
    {
        readonly IFileWatcher filewatcher;
        readonly ICreateMidnightFileMeta createMidnightFileMeta;

        public Worker(IFileWatcher watcher, ICreateMidnightFileMeta createMidnightFileMeta)
        {
            filewatcher = watcher;
            this.createMidnightFileMeta = createMidnightFileMeta;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            filewatcher.StartWatching();
            DateTime todayMidnight = DateTime.Today.AddDays(1).AddSeconds(-1);
            TimeSpan timeToMidnight = todayMidnight - DateTime.Now;
            int delay = (int)timeToMidnight.TotalMilliseconds;

            Timer timer = new Timer(createMidnightFileMeta.CreateFile, null, delay, 24 * 60 * 60 * 1000);
            Console.ReadLine();


            while (!stoppingToken.IsCancellationRequested)
            {

            }
        }
    }
}
