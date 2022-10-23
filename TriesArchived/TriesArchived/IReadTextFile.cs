using System.Collections.Generic;

namespace TriesArchived
{
    public interface IReadTextFile
    {
        IEnumerable<string> GetLines();
    }
}