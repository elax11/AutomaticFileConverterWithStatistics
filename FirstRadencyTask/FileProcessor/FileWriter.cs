using Newtonsoft.Json;

namespace FileProcessor
{
    public class FileWriter : IFileWriter
    {
        IConfiguration configuration { get; set; }
        IMetaLog metaLog { get; set; }
        public FileWriter(IConfiguration configuration,
            IMetaLog metaLog)
        {
            this.configuration = configuration;
            this.metaLog = metaLog;
        }
        public void Save(IEnumerable<ITransformed> transformedLine)
        {
            var currentDirectoryPath = $@"{configuration.TargetPath}\{DateTime.Today.ToString("MM/dd/yyyy")}";

            if (!Directory.Exists(currentDirectoryPath))
            {
                System.IO.Directory.CreateDirectory(currentDirectoryPath);
            }

            string json = JsonConvert.SerializeObject(transformedLine, (Newtonsoft.Json.Formatting)System.Xml.Formatting.Indented);
            File.WriteAllText($@"{configuration.TargetPath}\{DateTime.Today.ToString("MM/dd/yyyy")}\output{metaLog.parcedFiles}.json", json);
        }
    }
}
