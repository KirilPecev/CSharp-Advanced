using System;
using System.Collections.Generic;

namespace CitiesConCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> dict = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (!dict.ContainsKey(input[0]))
                {
                    dict.Add(input[0], new Dictionary<string, List<string>>());
                    dict[input[0]].Add(input[1], new List<string>() { input[2] });
                }
                else
                {
                    if (!dict[input[0]].ContainsKey(input[1]))
                    {
                        dict[input[0]].Add(input[1], new List<string>());
                    }

                    dict[input[0]][input[1]].Add(input[2]);
                }
            }

            foreach (var continent in dict)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in dict[continent.Key])
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
