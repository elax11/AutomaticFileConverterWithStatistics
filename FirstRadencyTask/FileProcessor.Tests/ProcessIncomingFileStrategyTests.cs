
using NSubstitute;

namespace FileProcessor.Tests
{
    public class ProcessIncomingFileStrategyTests
    {
        IProcessIncomingFileStrategy sut;
        IFileTypeChecker mockFileTypeChecker;
        IFileReaderProvider mockFileReaderProvider;

        [SetUp]
        public void SetUp()
        {
            mockFileTypeChecker = Substitute.For<IFileTypeChecker>();
            mockFileReaderProvider = Substitute.For<IFileReaderProvider>();
            sut = new ProcessIncomingFileStrategy(mockFileTypeChecker, mockFileReaderProvider);
        }

        [Test]
        public void TestProcessUncupportedFileType()
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