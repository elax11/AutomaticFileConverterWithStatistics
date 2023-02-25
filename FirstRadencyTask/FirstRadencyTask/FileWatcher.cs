using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    public class FileWatcher : ifilewatcher
    {
        FileSystemWatcher fileWatcher;
        /*Action<string> action;*/
        string directoryPath;
        IServiceProvider _serviceProvider;

        public FileWatcher(IServiceProvider serviceProvider)
        {
            directoryPath = System.Configuration.ConfigurationManager.AppSettings["pathToFolderA"];
            fileWatcher = new FileSystemWatcher(directoryPath);
            _serviceProvider = serviceProvider;
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
            using (var scope = _serviceProvider.CreateScope())
            {
                var consumerService = scope.ServiceProvider.GetRequiredService
                                                      <icheckFileType>();
                consumerService.checktype(e.FullPath);
            }
        }
    }
}
