﻿using Microsoft.Extensions.DependencyInjection;

namespace FileProcessor
{
    public class FileWatcher : IFileWatcher
    {
        FileSystemWatcher fileWatcher;
        IServiceProvider serviceProvider;

        public FileWatcher(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            fileWatcher = new FileSystemWatcher(configuration.SourcePath);
            this.serviceProvider = serviceProvider;
        }

        public void StartWatching()
        {
            fileWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            fileWatcher.EnableRaisingEvents = true;
            fileWatcher.Created += new FileSystemEventHandler(FileCreated);
        }

        void FileCreated(object sender, FileSystemEventArgs e)
        {
            WaitForFile(e.FullPath);
            using (var scope = serviceProvider.CreateScope())
            {
                var consumerService = scope.ServiceProvider.GetRequiredService<IProcessIncomingFileStrategy>();
                consumerService.ProcessFile(e.FullPath);
            }
        }
        void WaitForFile(string fullPath)
        {
            while (true)
            {
                try
                {
                    using (StreamReader stream = new StreamReader(fullPath))
                    {
                        break;
                    }
                }
                catch
                {
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
