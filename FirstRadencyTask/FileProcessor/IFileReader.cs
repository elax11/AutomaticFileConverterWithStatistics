namespace FileProcessor
{
    public interface IFileReader
    {
        IEnumerable<string> ReadFile(string fileName);
    }
}