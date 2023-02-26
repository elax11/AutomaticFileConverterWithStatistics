namespace FirstRadencyTask
{
    public interface ITxtFileReader
    {
        IEnumerable<string> ReadFile(string fileName);
    }
}