using System;
using System.Collections.Generic;
using System.Linq;

namespace Tagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();
            string line = Console.ReadLine();
            while (line != "end")
            {
                if (line.Contains("ban"))
                {
                    string banName = line.Split()[1];
                    dict.Remove(banName);
                    line = Console.ReadLine();
                    continue;
                }

                string[] lineArgs = line.Split(" -> ");
                string name = lineArgs[0];
                string tag = lineArgs[1];
                int likes = int.Parse(lineArgs[2]);

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new Dictionary<string, int>());
                    dict[name].Add(tag, likes);
                }
                else
                {
                    if (!dict[name].ContainsKey(tag))
                    {
                        dict[name].Add(tag, likes);
                    }
                    else
                    {
                        dict[name][tag] += likes;
                    }
                }


                line = Console.ReadLine();
            }

            foreach (var user in dict.OrderByDescending(x=>x.Value.Sum(n=>n.Value)).ThenBy(x=>x.Value.Count()))
            {
                Console.WriteLine($"{user.Key}");
                foreach (var tag in user.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }
        }
    }
}
