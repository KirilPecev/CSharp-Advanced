using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Cubic_Assault
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, BigInteger>> info = new Dictionary<string, Dictionary<string, BigInteger>>();
            string input = Console.ReadLine();
            while (input != "Count em all")
            {
                string[] tokens = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string regionName = tokens[0];
                string meteorType = tokens[1];
                BigInteger count = BigInteger.Parse(tokens[2]);

                if (!info.ContainsKey(regionName))
                {
                    info.Add(regionName, new Dictionary<string, BigInteger>());
                    info[regionName].Add("Green", 0);
                    info[regionName].Add("Black", 0);
                    info[regionName].Add("Red", 0);
                }

                info[regionName][meteorType] += count;
                if (info[regionName][meteorType] >= 1000000)
                {
                    if (info[regionName]["Green"] >= 1000000)
                    {
                        info[regionName]["Red"] += info[regionName]["Green"] / 1000000;
                        info[regionName]["Green"] %= 1000000;
                    }

                    if (info[regionName]["Red"] >= 1000000)
                    {
                        info[regionName]["Black"] += info[regionName]["Red"] / 1000000;
                        info[regionName]["Red"] %= 1000000;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var region in info.OrderByDescending(x => x.Value["Black"]).ThenBy(x => x.Key.Length).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{region.Key}");
                foreach (var meteor in region.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
                }
            }
        }
    }
}
