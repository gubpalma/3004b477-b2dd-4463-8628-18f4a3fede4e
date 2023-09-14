using System.Text.RegularExpressions;
using Sequence.Finder.Interfaces;

namespace Sequence.Finder.Infrastructure
{
    public class SequenceParser : ISequenceParser
    {
        private const string ValidationPattern = "^([0-9]*(\\ +)?)*$";
        
        public const string FormatErrorMessage = "Unexpected input format; expecting integers separated by whitespace";

        public IEnumerable<int> Perform(string values)
        {
            var results = new List<int>();

            if (string.IsNullOrEmpty(values)) 
                return results;

            if (!new Regex(ValidationPattern).IsMatch(values))
                throw new Exception("Unexpected input format; expecting integers separated by whitespace");

            var stringResults = 
                values
                    .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            foreach (var stringResult in stringResults)
            {
                try
                {
                    results
                        .Add(int.Parse(stringResult));
                }
                catch (Exception ex)
                {
                    throw new Exception($"Invalid input format (value '{stringResult}', expected integer");
                }
            }

            return 
                results
                    .ToArray();
        }
    }
}