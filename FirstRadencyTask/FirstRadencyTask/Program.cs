using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using FileProcessor;

namespace FirstRadencyTask
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Worker>();
                    services.AddSingleton<IFileWatcher, FileWatcher>();
                    services.AddSingleton<IConfiguration, Configuration>();
                    services.AddTransient<IFileTypeChecker, FileTypeChecker>();
                    services.AddScoped<IProcessIncomingFileStrategy, ProcessIncomingFileStrategy>();
                })
                .Build();

            await host.RunAsync();
        }
    }
}
