using FileProcessor;

namespace FirstRadencyTask
{
    public class CreateMidnightFileMeta : ICreateMidnightFileMeta
    {
        readonly IConfiguration configuration;
        readonly IMetaLog metaLog;
        public CreateMidnightFileMeta(IConfiguration configuration, IMetaLog metaLog) 
        {
            this.configuration = configuration;
            this.metaLog = metaLog;
        }
        public void CreateFile(object state)
        {
            var currentDirectoryPath = $@"{configuration.TargetPath}\{DateTime.Today.ToString("MM/dd/yyyy")}";

            if (!Directory.Exists(currentDirectoryPath))
            {
                System.IO.Directory.CreateDirectory(currentDirectoryPath);
            }
            string filePath = Path.Combine(currentDirectoryPath, "meta.log");
            File.Create(filePath).Close();
            var sw = new StreamWriter(filePath);
            sw.WriteLine($"parsed_files:{metaLog.parsedFiles}");
            sw.WriteLine($"parsed_lines:{metaLog.parsedLines}");
            sw.WriteLine($"found_errors:{metaLog.foundErrors}");
            sw.Write("invalid_files:");
            foreach (var item in metaLog.invalidFiles)
            {
                sw.Write($"[{item}]");
            }
            sw.Close();
        }
    }
}