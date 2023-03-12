namespace FileProcessor
{
    public interface IValidator
    {
        IEnumerable<TypeAfterParsing> Validate(IEnumerable<RawTypeAfterParsing> fileLines);
    }
}
