using System.Collections.Generic;
using System.Linq;

namespace TriesArchived
{
    public class Game
    {
        private readonly IReadTextFile _readTextFile;
        private readonly ILineDataParse _lineDataParse;

        public Game(IReadTextFile readTextFile, ILineDataParse lineDataParse)
        {
            _readTextFile = readTextFile;
            _lineDataParse = lineDataParse;
        }
        public string? GetWinner()
        {
            var results = new Dictionary<string, int>();
            var lines = _readTextFile.GetLines();
            
            // Skip header line
            var data = lines.Skip(1);

            foreach (var d in data)
            {
                var teamName = _lineDataParse.GetName(d);
                var result = _lineDataParse.GetKills(d) - _lineDataParse.GetArchived(d);
                results.Add(teamName, result); 
            }

            return results
                .OrderByDescending(x => x.Value)
                .Select(x => x.Key).ToList().First();
        }
    }
}