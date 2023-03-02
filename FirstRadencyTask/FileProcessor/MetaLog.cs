using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor
{
    public class MetaLog : IMetaLog
    {
        public int parcedFiles { get; set; }
        public int parcedLines { get; set; }
        public int foundErrors { get; set; }
        public List<string> invalidFiles { get; set; }
        public MetaLog(IEnumerable<string> listOfString)
        {
            invalidFiles = (List<string>)listOfString;
        }
    }
}
