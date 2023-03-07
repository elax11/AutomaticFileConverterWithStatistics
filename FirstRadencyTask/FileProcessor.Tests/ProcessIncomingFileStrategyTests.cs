
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace FileProcessor.Tests
{
    public class ProcessIncomingFileStrategyTests
    {
        IProcessIncomingFileStrategy sut;
        IFileTypeChecker mockFileTypeChecker;
        IFileReaderProvider mockFileReaderProvider;
        ILogger<ProcessIncomingFileStrategy> mockLogger;
        IValidator mockValidator;
        IFileWriter mockFileWriter;
        IFileReader mockFileReader;
        IMetaLog mockMetalog;
        IParser mockParser;
        ITransformer mockTransformer;

        [SetUp]
        public void SetUp()
        {
            mockFileTypeChecker = Substitute.For<IFileTypeChecker>();
            mockFileReaderProvider = Substitute.For<IFileReaderProvider>();
            mockLogger = Substitute.For<ILogger<ProcessIncomingFileStrategy>>();
            mockValidator = Substitute.For<IValidator>();
            mockFileWriter = Substitute.For<IFileWriter>();
            mockFileReader = Substitute.For<IFileReader>();
            mockMetalog = Substitute.For<IMetaLog>();
            mockParser = Substitute.For<IParser>();
            mockTransformer = Substitute.For<ITransformer>();
            sut = new ProcessIncomingFileStrategy(mockLogger,
                mockFileTypeChecker,
                mockFileReaderProvider,
                mockValidator,
                mockMetalog,
                mockParser,
                mockTransformer);
        }

        [Test]
        public void TestProcessUnsupportedFileType()
        {
            mockFileTypeChecker.GetFileType(Arg.Any<string>())
                .Returns(FileType.Unsupported);

            sut.ProcessFile("");

            mockFileReaderProvider.DidNotReceive().Get(Arg.Any<FileType>());

            /*mockFileReaderProvider.DidNotReceiveWithAnyArgs().Get(default);*/

            /* mockFileTypeChecker.GetFileType(Arg.Is("csv"))
                 .Returns(FileType.Csv);

             mockFileTypeChecker.GetFileType(Arg.Is<string>(arg => arg == "txt"))
                 .Returns(FileType.Txt);

             mockFileTypeChecker.GetFileType(default)
                 .ReturnsForAnyArgs(FileType.Unsupported);

             mockFileTypeChecker.GetFileType("ads")
                 .ReturnsForAnyArgs(FileType.Unsupported);*/
        }

        [Test]
        public void ShouldReturnWithUncupportedFileType()
        {
            mockFileTypeChecker.GetFileType(Arg.Any<string>())
                .Returns(FileType.Unsupported);

            sut.ProcessFile("");

            mockFileReaderProvider.DidNotReceive().Get(Arg.Any<FileType>());
        }

        /*[Test]
        public void ShouldReturnWhenValidationIsFailed()
        {
            mockFileTypeChecker.GetFileType(Arg.Any<string>());

            mockFileReaderProvider.Get(Arg.Any<FileType>())
                .Returns(mockFileReader);

            mockValidator.Validate(Arg.Any<IEnumerable<string>>())
                .Returns(false);

            sut.ProcessFile("");

            mockTransformer.DidNotReceive().Transform(Arg.Any<IEnumerable<string>>());
        }*/

        /*
                [Test]
                public void ShouldProvideTxtFileReader()
                {
                    var actual = sut.Get(FileType.Txt);

                    Assert.That(actual, Is.InstanceOf<ITxtFileReader>());
                }

                [Test]
                public void ShouldProvideCsvFileReader()
                {
                    var actual = sut.Get(FileType.Csv);

                    Assert.That(actual, Is.InstanceOf<ICsvFileReader>());
                }

                [TestCase(FileType.Txt, typeof(ITxtFileReader))]
                [TestCase(FileType.Csv, typeof(ICsvFileReader))]
                public void ShouldProvideFileReader(FileType fileType, Type expected)
                {
                    var actual = sut.Get(fileType);

                    Assert.That(actual, Is.InstanceOf(expected));
                }

                [TestCase(FileType.Unsupported)]
                [TestCase((FileType)(-1))]
                [TestCase((FileType)int.MaxValue)]
                public void ShouldThrowUnsupported(FileType fileType)
                {            
                    Assert.Throws<ArgumentException>(() => sut.Get(fileType));
                }*/
    }
}