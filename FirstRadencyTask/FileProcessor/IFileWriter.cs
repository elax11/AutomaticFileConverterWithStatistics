namespace FileProcessor
{
    public interface IFileWriter
    {
        void Save(IEnumerable<ITransformed> transformedLine);
    }
}
