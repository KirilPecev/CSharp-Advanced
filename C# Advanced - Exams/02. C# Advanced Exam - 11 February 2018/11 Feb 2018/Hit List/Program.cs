using System;
using System.Collections.Generic;
using System.Linq;

namespace Hit_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, string>> info = new Dictionary<string, Dictionary<string, string>>();
            while (true)
            {
                string[] input = Console.ReadLine().Split("=;".ToCharArray());
                if (input[0] == "end transmissions")
                {
                    break;
                }

                string name = input[0];

                if (!info.ContainsKey(name))
                {
                    info.Add(name, new Dictionary<string, string>());
                }

                for (int i = 1; i < input.Length; i++)
                {
                    string key = input[i].Split(':')[0];
                    string value = input[i].Split(':')[1];

                    if (!info[name].ContainsKey(key))
                    {
                        info[name].Add(key, value);
                    }
                    else
                    {
                        info[name][key] = value;
                    }
                }
            }

            string killThatPerson = Console.ReadLine().Split()[1];
            int infoIndex = 0;
            foreach (var name in info)
            {
                if (killThatPerson == name.Key)
                {
                    Console.WriteLine($"Info on {name.Key}:");
                    foreach (var item in info[name.Key].OrderBy(x=>x.Key))
                    {
                        infoIndex += item.Key.Length + item.Value.Length;
                        Console.WriteLine($"---{item.Key}: {item.Value}");
                    }
                }
            }

            Console.WriteLine($"Info index: {infoIndex}");
            if (infoIndex>=targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex-infoIndex} more info.");
            }
        }
    }
}
