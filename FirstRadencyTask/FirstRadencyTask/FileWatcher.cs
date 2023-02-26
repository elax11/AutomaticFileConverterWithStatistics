using Microsoft.Extensions.DependencyInjection;

namespace FirstRadencyTask
{
    public class FileWatcher : IFileWatcher
    {
        FileSystemWatcher fileWatcher;
        /*Action<string> action;*/
        string directoryPath;
        IServiceProvider serviceProvider;

        public FileWatcher(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            fileWatcher = new FileSystemWatcher(configuration.SourcePath);
            this.serviceProvider = serviceProvider;
        }
        /*
                public FileWatcher SetFileAddedHandler(Action<string> action)
                {
                    this.action = action;

                    return this;
                }*/

        public void StartWatching()
        {
            fileWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            fileWatcher.EnableRaisingEvents = true;
            fileWatcher.Created += new FileSystemEventHandler(FileCreated);
        }

        void FileCreated(object sender, FileSystemEventArgs e)
        {
            serviceProvider.GetRequiredService<ICheckFileType>().CheckType(e.FullPath);
            /*using (var scope = serviceProvider.CreateScope())
            {
                var consumerService = scope.ServiceProvider.GetRequiredService<ICheckFileType>();
                consumerService.CheckType(e.FullPath);
            }*/
        }
    }
}
