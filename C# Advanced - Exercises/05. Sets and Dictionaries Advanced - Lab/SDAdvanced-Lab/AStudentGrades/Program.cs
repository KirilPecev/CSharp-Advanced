using System;
using System.Collections.Generic;
using System.Linq;
namespace AStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (!dict.ContainsKey(input[0]))
                {
                    dict.Add(input[0], new List<double>() { double.Parse(input[1]) });
                }
                else
                {
                    dict[input[0]].Add(double.Parse(input[1]));
                }
            }

            foreach (var name in dict.Keys)
            {
                Console.Write($"{name} -> ");
                foreach (var grade in dict[name])
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {dict[name].Average():f2})");
            }
        }
    }
}
