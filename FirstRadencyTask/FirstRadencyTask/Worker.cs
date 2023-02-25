using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    public class Worker : BackgroundService
    {
        public readonly ifilewatcher _ifilewatcher;

        public Worker(ifilewatcher watcher)
        {
            _ifilewatcher = watcher;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ifilewatcher.StartWatching();

            while (!stoppingToken.IsCancellationRequested)
            {

            }
        }
    }
}
