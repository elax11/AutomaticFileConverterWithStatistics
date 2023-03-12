namespace FileProcessor
{
    public class CsvFileReader : ICsvFileReader
    {
        public IEnumerable<string> ReadFile(string fileName)
        {
            
            var lines = File.ReadLines(fileName).Skip(1);
            return lines;
        }
    }
}
