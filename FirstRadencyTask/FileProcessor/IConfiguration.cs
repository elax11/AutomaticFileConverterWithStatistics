namespace FileProcessor
{
    public interface IConfiguration
    {
        string SourcePath { get; }
        string TargetPath { get; }
    }
}
