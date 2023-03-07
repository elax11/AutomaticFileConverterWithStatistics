using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        ITransformer transformer;
        IFileWriter fileWriter;

        public ProcessIncomingFileStrategy(
            ILogger<ProcessIncomingFileStrategy> logger,
            IFileTypeChecker fileTypeChecker,
            IFileReaderProvider fileReaderProvider,
            IValidator validator,
            IMetaLog metaLog,
            IParser parser,
            ITransformer transformer,
            IFileWriter fileWriter
            )
        {
            this.fileTypeChecker = fileTypeChecker;
            this.fileReaderProvider = fileReaderProvider;
            this.logger = logger;
            this.validator = validator;
            this.metaLog = metaLog;
            this.parser = parser;
            this.transformer = transformer;
            this.fileWriter = fileWriter;
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

            var tranformed = transformer.Transform(filesAfterParse);

            fileWriter.Save(tranformed);


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


            //Save
            //fileWriter.Save(transformedLines);


        }
    }
}
