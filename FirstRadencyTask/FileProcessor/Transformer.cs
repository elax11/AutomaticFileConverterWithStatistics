using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor
{
    public class Transformer : ITransformer
    {
        public IEnumerable<ITransformed> Transform(IEnumerable<TypeAfterParsing> parsedLines)
        {
            var result = parsedLines
            .Where(line => line.Valid == true)
            .GroupBy(x => x.City)
            .Select(y => new Transformed
            {
                Total = y.Sum(service => service.Payment),
                City = y.Key,
                Services = y
                    .GroupBy(q => q.Service)
                    .Select(u => new Service
                    {
                        Name = u.Key,
                        Total = u.Sum(service => service.Payment),
                        Payers = u
                            .Select(p => new Payer
                            {
                                AccountNumber = p.AccountNumber,
                                Name = $"{p.FirstName} {p.LastName}",
                                Payment = p.Payment,
                                Date = p.Date
                            })
                    })
            }).ToList();

            return result;
        }
    }
}
