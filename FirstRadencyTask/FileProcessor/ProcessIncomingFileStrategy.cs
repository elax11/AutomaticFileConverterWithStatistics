using Microsoft.Extensions.Logging;

namespace FileProcessor
{
    public class ProcessIncomingFileStrategy : IProcessIncomingFileStrategy
    {
        ILogger<ProcessIncomingFileStrategy> logger;
        IFileTypeChecker fileTypeChecker;
        IFileReaderProvider fileReaderProvider;
        IValidator validator;
        IMetaLog metaLog;
        IParser parser;

        public ProcessIncomingFileStrategy(
            ILogger<ProcessIncomingFileStrategy> logger,
            IFileTypeChecker fileTypeChecker,
            IFileReaderProvider fileReaderProvider,
            IValidator validator,
            IMetaLog metaLog,
            IParser parser
            )
        {
            this.fileTypeChecker = fileTypeChecker;
            this.fileReaderProvider = fileReaderProvider;
            this.logger = logger;
            this.validator = validator;
            this.metaLog = metaLog;
            this.parser = parser;
        }

        public void ProcessFile(string fileName)
        {
            var fileType = fileTypeChecker.GetFileType(fileName);

            //(Use switch) ReadFile
            if (fileType == FileType.Unsupported) return;

            var fileLines = fileReaderProvider.Get(fileType)
                .ReadFile(fileName);

            var rawFilesAfterParse = parser.RawParseLines(fileLines);

            var filesAfterParse = validator.Validate(rawFilesAfterParse);

            foreach (var item in filesAfterParse)
            {
                /*Console.WriteLine(item.FirstName);
                Console.WriteLine(item.LastName);
                Console.WriteLine(item.City);
                Console.WriteLine(item.Payment);
                Console.WriteLine(item.Date);
                Console.WriteLine(item.AccountNumber);
                Console.WriteLine(item.Service);*/
                Console.WriteLine(metaLog.parcedFiles);
                Console.WriteLine(metaLog.parcedLines);
                Console.WriteLine(metaLog.foundErrors);
                Console.WriteLine(metaLog.invalidFiles);
            }

            //Validate
            /*if (!validator.Validate(fileLines))
            {
                logger.LogInformation("FileLines invalid");
                return;
            }*/




            //Transform
            /*var transformedLines = transformer.Transform(fileLines);*/


            //Save
            //fileWriter.Save(transformedLines);


        }
    }
}
