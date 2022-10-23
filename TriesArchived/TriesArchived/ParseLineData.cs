using System;

namespace TriesArchived
{
    public class ParseLineData : ILineDataParse
    {
        public string GetName(string lineData)
        {
            var data = lineData.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return data[0];
        }

        public int GetKills(string lineData)
        {
            var data = lineData.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return int.Parse(data[2]);
        }

        public int GetArchived(string lineData)
        {
            var data = lineData.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return int.Parse(data[3]);
        }
    }
}