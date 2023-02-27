
using NSubstitute;

namespace FileProcessor.Tests
{
    public class FileReaderProviderTests
    {
        IFileReaderProvider sut;

        [SetUp]
        public void SetUp()
        {
            var mockTxtFileReader = Substitute.For<ITxtFileReader>();
            var mockCsvFileReader = Substitute.For<ICsvFileReader>();
            sut = new FileReaderProvider(mockTxtFileReader, mockCsvFileReader);
        }

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
        }
    }
}