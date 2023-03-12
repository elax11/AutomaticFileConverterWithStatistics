namespace FileProcessor
{
    public class Parser : IParser
    {
        public IEnumerable<RawTypeAfterParsing> RawParseLines(IEnumerable<string> fileLines)
        {
            var RawParsedLines = new List<RawTypeAfterParsing>();
            foreach (string line in fileLines)
            {
                var subLines = line.Split(',');
                if (subLines.Length == 9)
                {
                    RawParsedLines.Add(new RawTypeAfterParsing());
                    RawParsedLines.Last().FirstName = subLines[0].Trim();
                    RawParsedLines.Last().LastName = subLines[1].Trim();
                    RawParsedLines.Last().City = subLines[2].Trim().Substring(1);
                    RawParsedLines.Last().Payment = subLines[5].Trim();
                    RawParsedLines.Last().Date = subLines[6].Trim();
                    RawParsedLines.Last().AccountNumber = subLines[7].Trim();
                    RawParsedLines.Last().Service = subLines[8].Trim();
                }
            }
            return RawParsedLines;
        }
    }
}
