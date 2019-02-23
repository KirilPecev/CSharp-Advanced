using System;
using System.Collections.Generic;
using System.Linq;

namespace SameValuesArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] values = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> dict = new Dictionary<double, int>();
            foreach (var num in values)
            {
                if (!dict.ContainsKey(num))
                {
                    dict.Add(num, 1);
                }
                else
                {
                    dict[num]++;
                }
            }

            foreach (var num in dict.Keys)
            {
                Console.WriteLine($"{num} - {dict[num]} times");
            }
        }
    }
}
