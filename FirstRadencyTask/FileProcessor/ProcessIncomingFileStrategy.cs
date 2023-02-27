namespace FileProcessor
{
    public class ProcessIncomingFileStrategy: IProcessIncomingFileStrategy
    {
        IFileTypeChecker fileTypeChecker;
        IFileReaderProvider fileReaderProvider;
        
        public ProcessIncomingFileStrategy(
            IFileTypeChecker fileTypeChecker,
            IFileReaderProvider fileReaderProvider) 
        {
            this.fileTypeChecker = fileTypeChecker;
            this.fileReaderProvider = fileReaderProvider;
        }

        public void ProcessFile(string fileName)
        {
            var fileType = fileTypeChecker.GetFileType(fileName);

            //(Use switch) readFile
            if (fileType == FileType.Unsupported) return;

            var fileLines = fileReaderProvider.Get(fileType)
                .ReadFile(fileName);
            

            //Validate
            // if (!validator.Validate(fileLines))
            /* {
             *    logger.Warning("FileLines invalid");
             *    return
             * }
            */

            //Transform
            /* var transformedLines = transformer.Transform(fileLines); 
             */

            //Save
            /* fileWriter.Save(transformedLine);
             */

        }
    }
}
