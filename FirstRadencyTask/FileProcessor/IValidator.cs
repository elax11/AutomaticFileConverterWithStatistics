using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor
{
    public interface IValidator
    {
        IEnumerable<TypeAfterParsing> Validate(IEnumerable<RawTypeAfterParsing> fileLines);
    }
}
