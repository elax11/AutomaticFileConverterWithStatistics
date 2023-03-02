namespace FileProcessor
{
    public class FileTypeChecker : IFileTypeChecker
    {
        IMetaLog metaLog;
        public FileTypeChecker(IMetaLog metaLog)
        {
            this.metaLog = metaLog;
        }
        public FileType GetFileType(string filePath)
        {
            if (filePath.Length < 4)
            {
                metaLog.foundErrors++;
                metaLog.invalidFiles.Add(filePath);
                return FileType.Unsupported;
            }
            if (filePath.Substring(filePath.Length - 4) == ".txt") return FileType.Txt;
            if (filePath.Substring(filePath.Length - 4) == ".csv") return FileType.Csv;
            metaLog.foundErrors++;
            metaLog.invalidFiles.Add(filePath);
            return FileType.Unsupported;
        }
    }
}
