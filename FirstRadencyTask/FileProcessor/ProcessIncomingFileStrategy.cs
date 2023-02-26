namespace FileProcessor
{
    public class ProcessIncomingFileStrategy: IProcessIncomingFileStrategy
    {
        IFileTypeChecker fileTypeChecker;
        ITxtFileReader txtFileReader;
        ICsvFileReader csvFileReader;
        
        public ProcessIncomingFileStrategy(
            IFileTypeChecker fileTypeChecker,
            ITxtFileReader txtFileReader,
            ICsvFileReader csvFileReader) 
        {
            this.fileTypeChecker = fileTypeChecker;
            this.txtFileReader = txtFileReader;
            this.csvFileReader = csvFileReader;
        }

        public void ProcessFile(string fileName)
        {
            var fileType = fileTypeChecker.GetFileType(fileName);

            //(Use switch) readFile
            IEnumerable<string> fileLines; 
            switch (fileType)
            {
                case FileType.Txt: fileLines = txtFileReader.ReadFile(fileName); 
                    break;
                case FileType.Csv: fileLines = csvFileReader.ReadFile(fileName); 
                    break;
                default: return;
            }

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
