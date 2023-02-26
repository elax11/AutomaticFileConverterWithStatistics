namespace FileProcessor
{
    public interface ITxtFileReader
    {
        IEnumerable<string> ReadFile(string fileName);
    }
}