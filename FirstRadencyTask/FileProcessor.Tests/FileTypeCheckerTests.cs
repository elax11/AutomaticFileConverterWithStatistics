
using NSubstitute;

namespace FileProcessor.Tests
{
    public class FileTypeCheckerTests
    {
        FileTypeChecker sut;
        IMetaLog mockMetalog;

        [SetUp]
        public void SetUp()
        {
            mockMetalog = Substitute.For<IMetaLog>();
            sut = new FileTypeChecker(mockMetalog);
        }

        [TestCase("", FileType.Unsupported)]
        [TestCase("txt", FileType.Unsupported)]
        [TestCase(".config", FileType.Unsupported)]
        [TestCase("NewFile.config", FileType.Unsupported)]
        [TestCase("1.config", FileType.Unsupported)]
        [TestCase(".tx", FileType.Unsupported)]
        [TestCase(".cs", FileType.Unsupported)]
        [TestCase(@"C:\Source\folder_a\NewFile.cs", FileType.Unsupported)]
        [TestCase(".txt", FileType.Txt)]
        [TestCase("NewFile.txt", FileType.Txt)]
        [TestCase("1.txt", FileType.Txt)]
        [TestCase(@"C:\Source\folder_a\NewFile.txt", FileType.Txt)]
        [TestCase(".csv", FileType.Csv)]
        [TestCase("NewFile.csv", FileType.Csv)]
        [TestCase("1.csv", FileType.Csv)]
        [TestCase(@"C:\Source\folder_a\NewFile.csv", FileType.Csv)]

        public void ShouldParseFileType(string filePath, FileType expected)
        {
            var actual = sut.GetFileType(filePath);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}