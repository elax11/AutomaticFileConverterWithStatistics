using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor
{
    public interface IValidator
    {
        bool Validate(IEnumerable<string> fileLines);
    }
}
