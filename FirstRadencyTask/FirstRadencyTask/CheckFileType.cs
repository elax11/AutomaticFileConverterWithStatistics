namespace FirstRadencyTask
{
    public class CheckFileType : ICheckFileType
    {
        public FileType GetFileType(string filePath)
        {
            if (filePath.Substring(filePath.Length - 3) == "txt") return FileType.Txt;
            if (filePath.Substring(filePath.Length - 3) == "scv") return FileType.Csv;
            return FileType.Unsupported;
        }
    }
}
