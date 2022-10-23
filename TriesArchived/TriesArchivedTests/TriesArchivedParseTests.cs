using TriesArchived;
using Xunit;

namespace TriesArchivedTests
{
    public class TriesArchivedParseTests
    {
        private readonly ParseLineData _parseLineData;
        public TriesArchivedParseTests()
        {
            _parseLineData = new ParseLineData();
        }

        [Fact]
        public void Given_Line_Parse_TeamName()
        {
            var lineData = "TeamA 4 6 3";

            var teamName = _parseLineData.GetName(lineData);
            
            Assert.Equal("TeamA", teamName);
        }
        
        [Fact]
        public void Given_Line_Parse_Kills()
        {
            var lineData = "TeamA 4 6 3";

            var kills = _parseLineData.GetKills(lineData);
            
            Assert.Equal(6, kills);
        }

        [Fact]
        public void Given_Line_Parse_Archived()
        {
            var lineData = "TeamA 4 6 3";

            var archived = _parseLineData.GetArchived(lineData);
            
            Assert.Equal(3, archived);
        }
    }
}