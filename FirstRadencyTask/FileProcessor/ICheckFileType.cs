namespace FileProcessor
{
    public interface IFileTypeChecker
    {
        public FileType GetFileType(string filePath);
    }
}
