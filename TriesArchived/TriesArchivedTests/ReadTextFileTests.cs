using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using TriesArchived;
using Xunit;

namespace TriesArchivedTests
{
    public class ReadTextFileTests
    {
        private const string Path = @"c:\temp\int.txt";
        private const string DataLine1 = "TeamName NumberOfMembers Kills Archived";
        private const string DataLine2 = "\nTeamA  5 10 4";

        [Fact]
        public void Give_FileNameAndFilePath_ReadFile()
        {
            // Arrange

            var mockFileSystem = GetFileSystem();

            var sut = new ReadTextFile(mockFileSystem, Path); 

            // Act
            var lines = sut.GetLines().ToList();
            
            // Assert
            Assert.Equal(DataLine1, lines.First());
            Assert.Equal(DataLine2.Substring(1,DataLine2.Length-1), lines.ToList()[1]);
        }

        private IFileSystem GetFileSystem()
        {
            var mockFileSystem = new MockFileSystem();
            var mockInputFile = new MockFileData(DataLine1 + DataLine2);
            mockFileSystem.AddFile(Path, mockInputFile);

            return mockFileSystem;
        }
    }
}