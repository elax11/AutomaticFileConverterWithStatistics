namespace FileProcessor
{
    public interface IFileReaderProvider
    {
        IFileReader Get(FileType fileType);
    }
}
