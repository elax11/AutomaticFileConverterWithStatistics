namespace FileProcessor
{
    public interface IMetaLog
    {
        int parsedFiles { get; set; }
        int parsedLines { get; set; }
        int foundErrors { get; set; }
        List<string> invalidFiles { get; set; }

    }
}
