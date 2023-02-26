namespace FileProcessor
{
    public class FileTypeChecker : IFileTypeChecker
    {
        public FileType GetFileType(string filePath)
        {
            if (filePath.Length < 4) return FileType.Unsupported;
            if (filePath.Substring(filePath.Length - 4) == ".txt") return FileType.Txt;
            if (filePath.Substring(filePath.Length - 4) == ".csv") return FileType.Csv;
            return FileType.Unsupported;
        }
    }
}
