using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                List<string> currentList = input[1].Split(',',StringSplitOptions.RemoveEmptyEntries).ToList();
                if (!dict.ContainsKey(input[0]))
                {
                    dict.Add(input[0], currentList);
                }
                else
                {
                    dict[input[0]].AddRange(currentList);
                }
            }

            string[] colorAndItem = Console.ReadLine().Split();

            foreach (var color in dict)
            {
                Console.WriteLine($"{color.Key} clothes:");
                if (color.Key == colorAndItem[0])
                {
                    foreach (var wear in dict[color.Key].Distinct())
                    {
                        if (wear == colorAndItem[1])
                        {
                            Console.WriteLine($"* {wear} - {CountOfEquals(dict[color.Key], wear)} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {wear} - {CountOfEquals(dict[color.Key], wear)}");
                        }
                    }
                }
                else
                {
                    foreach (var wear in dict[color.Key].Distinct())
                    {
                        if (wear == colorAndItem[1])
                        {
                            Console.WriteLine($"* {wear} - {CountOfEquals(dict[color.Key], wear)}");
                        }
                        else
                        {
                            Console.WriteLine($"* {wear} - {CountOfEquals(dict[color.Key], wear)}");
                        }
                    }
                }
            }
        }

        private static int CountOfEquals(List<string> list, string wear)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (item == wear)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
