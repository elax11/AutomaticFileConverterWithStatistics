namespace FileProcessor
{
    public class ReadLinesFromFile
    {
        string filePath;
        FileSystemWatcher fileWatcher;
        string type;

        public ReadLinesFromFile(string filePath)
        {
            this.filePath = filePath;
        }

        public void CheckType()
        {
            if (filePath.Substring(filePath.Length - 3) == "txt") type = "txt";
            if (filePath.Substring(filePath.Length - 3) == "scv") type = "csv";
            Console.WriteLine(type);
        }
    }
}
