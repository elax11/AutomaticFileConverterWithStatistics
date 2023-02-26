namespace FileProcessor
{
    public interface ICsvFileReader
    {
        IEnumerable<string> ReadFile(string fileName);
    }
}