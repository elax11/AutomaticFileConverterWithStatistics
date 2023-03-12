namespace FileProcessor
{
    public interface ITransformer
    {
        IEnumerable<ITransformed> Transform(IEnumerable<TypeAfterParsing> parcedLines);
    }
}
