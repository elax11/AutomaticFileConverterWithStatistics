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
                    services.AddSingleton<IMetaLog>(new MetaLog(new List<string>()));
                    services.AddTransient<IFileTypeChecker, FileTypeChecker>();
                    services.AddTransient<IFileReaderProvider, FileReaderProvider>();
                    services.AddTransient<ITxtFileReader, TxtFileReader>();
                    services.AddTransient<ICsvFileReader, CsvFileReader>();
                    services.AddTransient<IParser, Parser >();
                    services.AddTransient<IValidator, Validator >();
                    services.AddTransient<ITransformer, Transformer >();
                    services.AddTransient<IFileWriter, FileWriter >();
                    services.AddScoped<IProcessIncomingFileStrategy, ProcessIncomingFileStrategy>();
                })
                .Build();

            await host.RunAsync();
        }
    }
}
