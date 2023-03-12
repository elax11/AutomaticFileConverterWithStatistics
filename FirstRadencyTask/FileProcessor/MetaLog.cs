namespace FileProcessor
{
    public class MetaLog : IMetaLog
    {
        public int parsedFiles { get; set; }
        public int parsedLines { get; set; }
        public int foundErrors { get; set; }
        public List<string> invalidFiles { get; set; }
        public MetaLog(IEnumerable<string> listOfString)
        {
            invalidFiles = (List<string>)listOfString;
        }
    }
}
