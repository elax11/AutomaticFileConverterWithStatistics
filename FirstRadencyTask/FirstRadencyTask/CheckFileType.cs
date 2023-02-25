using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MyApp
{
    public class checkFileType : icheckFileType
    {
        string type;

        public void checktype(string filePath)
        {
            if (filePath.Substring(filePath.Length - 3) == "txt") type = "txt";
            if (filePath.Substring(filePath.Length - 3) == "scv") type = "scv";
            Console.WriteLine(type);
        }
    }
}
