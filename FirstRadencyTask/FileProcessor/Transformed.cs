using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor
{
    public class Transformed : ITransformed
    {
        public string City { get; set; }
        public IEnumerable<Service> Services { get ; set ; }
        public decimal Total { get ; set ; }
    }
}
