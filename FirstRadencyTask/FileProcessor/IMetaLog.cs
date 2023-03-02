using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor
{
    public interface IMetaLog
    {
        int parcedFiles { get; set; }
        int parcedLines { get; set; }
        int foundErrors { get; set; }
        List<string> invalidFiles { get; set; }
    }
}
