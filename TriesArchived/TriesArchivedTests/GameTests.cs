using System.IO.Abstractions.TestingHelpers;
using TriesArchived;
using Xunit;

namespace TriesArchivedTests
{
    public class GameTests
    {
        private const string Path = @"c:\temp\int.txt";

        public GameTests()
        {
            
        }
        
        [Fact]
        public void Given_FileWithGameResult_FindWinnerForTwoLine()
        {
            // Arrange
            var readTextFile = GetMockFileSystem();
            
            var sut = new Game(readTextFile, new ParseLineData());
            
            // Act
            var winner = sut.GetWinner();
            
            // Assert
            Assert.Equal("TeamB", winner);
        }

        private IReadTextFile GetMockFileSystem()
        {
            var fileSystem = new MockFileSystem();
            var dataLine1 = "TeamName NumberOfMembers Tries Archived";
            var dataLine2 = "\nTeamA  5 10 4";
            var dataLine3 = "\nTeamB  6 8 1";
            var mockInputFile = new MockFileData(dataLine1 + dataLine2 + dataLine3);
            fileSystem.AddFile(Path, mockInputFile);
            
            var readTextFile = new ReadTextFile(fileSystem, Path);
            
            return readTextFile;
        }
    }
}