namespace FileProcessor
{
    public class TxtFileReader: ITxtFileReader
    {
        public IEnumerable<string> ReadFile(string fileName)
        {
            var lines = File.ReadLines(fileName);
            return lines;
        }
    }
}
