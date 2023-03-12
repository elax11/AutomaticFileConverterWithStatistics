using System.Globalization;
using System.Text.RegularExpressions;

namespace FileProcessor
{
    public class Validator : IValidator
    {
        IMetaLog metaLog;
        public Validator(IMetaLog metaLog)
        {
            this.metaLog = metaLog;
        }
        public IEnumerable<TypeAfterParsing> Validate(IEnumerable<RawTypeAfterParsing> rawItemAfterParsing)
        {
            var validateLines = new List<TypeAfterParsing>();
            var errors = 0;
            foreach (var rawItem in rawItemAfterParsing)
            {
                DateTime dataValue;
                validateLines.Add(new TypeAfterParsing());
                if (!Regex.IsMatch(rawItem.FirstName, @"^[A-Za-z]{2,20}$")
                    || !Regex.IsMatch(rawItem.LastName, @"^[A-Za-z]{2,20}$")
                    || !Regex.IsMatch(rawItem.City, @"^[A-Za-z]{2,20}$")
                    || !Regex.IsMatch(rawItem.Payment, @"^[0-9]+\.?[0-9]*$")
                    || !DateTime.TryParseExact(rawItem.Date,
                       "yyyy-dd-MM",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out dataValue)
                    || !Regex.IsMatch(rawItem.AccountNumber, @"^[0-9]{7}$")
                    || !Regex.IsMatch(rawItem.Service, @"^[A-Za-z]{2,20}$"))
                {
                    validateLines.Last().Valid = false;
                    errors++;
                    metaLog.foundErrors++;
                }
                else
                {
                    validateLines.Last().FirstName=rawItem.FirstName;
                    validateLines.Last().LastName=rawItem.LastName;
                    validateLines.Last().City=rawItem.City;
                    validateLines.Last().Payment = decimal.Parse(rawItem.Payment);
                    validateLines.Last().Date = dataValue;
                    validateLines.Last().AccountNumber = long.Parse(rawItem.AccountNumber);
                    validateLines.Last().Service = rawItem.Service;
                    validateLines.Last().Valid = true;
                    metaLog.parsedLines++;
                }
            }
            metaLog.parsedFiles++;
            return validateLines;
        }

    }
}
