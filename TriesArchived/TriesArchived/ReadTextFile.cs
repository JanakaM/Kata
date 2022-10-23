using System.Collections.Generic;
using System.IO.Abstractions;

namespace TriesArchived
{
    public class ReadTextFile : IReadTextFile
    {
        private readonly IFileSystem _mockFileSystem;
        private readonly string _path;

        public ReadTextFile(IFileSystem mockFileSystem, string path)
        {
            _mockFileSystem = mockFileSystem;
            _path = path;
        }

        public IEnumerable<string> GetLines()
        {
            return  _mockFileSystem.File.ReadLines(_path);
        }
    }
}