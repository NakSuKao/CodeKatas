using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.CodeKatas.StringCalculators
{
    public class StringCalculatorParosSrl
    {
        public int Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
                return 0;

            var delimiters = DelimetersGet(ref numbers);

            var integers = IntegersGet(numbers, delimiters);

            if (integers.Any(n => n < 0))
                throw new ArgumentException(
                    $"negatives not allowed: {String.Join(";", numbers.Where(n => n < 0).Select(number => number.ToString()))}");

            return integers.Sum(integer => integer);
        }

        private static IEnumerable<string> DelimetersGet(ref string numbers)
        {
            var delimeters = new List<string> { ",", "\n" };

            if (numbers.Length < 4) return delimeters;

            if (numbers[0] != '/' || numbers[1] != '/') return delimeters;

            delimeters.Remove(",");

            var newLineFirstIndex = numbers.IndexOf('\n');
            delimeters.Add(numbers.Substring(2, newLineFirstIndex - 2));

            numbers = numbers.Remove(0, newLineFirstIndex + 1);

            return delimeters;
        }

        private static IList<int> IntegersGet(string numbers, IEnumerable<string> delimiters)
        {
            return numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                          .Select(n => Convert.ToInt32(n))
                          .Where(n => n <= 1000)
                          .ToList();
        }
    }
}
