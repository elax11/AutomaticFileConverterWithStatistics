using System.Configuration;

namespace FileProcessor
{
    public class Configuration : IConfiguration
    {
        public string SourcePath => ConfigurationManager.AppSettings["SourcePath"];

        public string TargetPath => ConfigurationManager.AppSettings["TargetPath"];
    }
}
