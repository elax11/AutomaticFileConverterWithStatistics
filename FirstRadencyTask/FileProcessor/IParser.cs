namespace FileProcessor
{
    public interface IParser
    {
        IEnumerable<RawTypeAfterParsing> RawParseLines(IEnumerable<string> fileLines);
    }
}
