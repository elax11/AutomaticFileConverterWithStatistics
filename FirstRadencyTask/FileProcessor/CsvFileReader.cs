using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor
{
    public class CsvFileReader : ICsvFileReader
    {
        public IEnumerable<string> ReadFile(string fileName)
        {
            var lines = File.ReadLines(fileName).Skip(1);
            return lines;
        }
    }
}
