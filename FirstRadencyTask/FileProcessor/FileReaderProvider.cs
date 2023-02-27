namespace FileProcessor
{
    public class FileReaderProvider : IFileReaderProvider
    {
        ITxtFileReader txtFileReader;
        ICsvFileReader csvFileReader;

        public FileReaderProvider(
            ITxtFileReader txtFileReader, 
            ICsvFileReader csvFileReader)
        {
            this.txtFileReader = txtFileReader;
            this.csvFileReader = csvFileReader;
        }

        public IFileReader Get(FileType fileType)
        {
            switch (fileType)
            {
                case FileType.Txt: return txtFileReader;
                case FileType.Csv: return csvFileReader;
                default: throw new ArgumentException("Unsupported file type", nameof(fileType));
            }
        }
    }
}
