using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MyApp
{
    public class ReadLinesFromFile
    {
        string filePath;
        FileSystemWatcher fileWatcher;
        string type;

        public ReadLinesFromFile(string filePath)
        {
            this.filePath = filePath;
        }

        public void checktype()
        {
            if (filePath.Substring(filePath.Length - 3) == "txt") type = "txt";
            if (filePath.Substring(filePath.Length - 3) == "scv") type = "csv";
            Console.WriteLine(type);
        }
    }
}
