using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (var c in input)
            {
                if (!dict.ContainsKey(c))
                {
                    dict.Add(c, 1);
                }
                else
                {
                    dict[c]++;
                }
            }

            foreach (var c in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{c.Key}: {c.Value} time/s");
            }
        }
    }
}
