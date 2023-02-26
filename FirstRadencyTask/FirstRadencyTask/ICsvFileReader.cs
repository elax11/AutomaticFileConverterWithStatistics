namespace FirstRadencyTask
{
    public interface ICsvFileReader
    {
        IEnumerable<string> ReadFile(string fileName);
    }
}