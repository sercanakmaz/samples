using System;
using System.Collections.Generic;
using static System.String;
using System.Collections;
using static System.Linq.Enumerable;
using static System.Console;

namespace _60And70
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = "qwdwq";

            if (int.TryParse(input, out int numericResult))
                WriteLine(numericResult);
            else
                WriteLine("Could not parse input");

            var letters = ("a", "b");

            Console.WriteLine("{0}, {1}", letters.Item1, letters.Item2);

            (string Alpha, string Beta) namedLetters = ("a", "b");

            var range = Range(new List<int> { 5, 6, 1, 36, 213, 153, 4, -21, -341, -1421, 231 });

            Console.ReadKey();
        }

        public static (int Max, int Min) Range(IEnumerable<int> numbers)
        {
            int min = int.MinValue;
            int max = int.MaxValue;

            foreach (var n in numbers)
            {
                min = (n < min) ? n : min;
                max = (n > max) ? n : max;
            }

            return (max, min);
        }
    }
}