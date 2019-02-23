using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                if (commands[0] == "Party!")
                {
                    break;
                }

                switch (commands[0])
                {
                    case "Remove":
                        Remove(names, commands[1], commands[2]);
                        break;
                    case "Double":
                        Double(names, commands[1], commands[2]);
                        break;
                }
            }

            if (names.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void Double(List<string> names, string command, string givenString)
        {
            Predicate<string> filter = x => x.Contains(givenString);
            Predicate<string> filterLen = x => x.Length == int.Parse(givenString);
            List<string> newList = new List<string>();
            switch (command)
            {
                case "StartsWith":
                    newList = names.FindAll(filter);
                    foreach (var item in newList)
                    {
                        for (int i = 0; i < names.Count; i++)
                        {
                            if (names[i] == item)
                            {
                                names.Insert(i + 1, item);
                                break;
                            }
                        }
                    }
                    break;
                case "EndsWith":
                    newList = names.FindAll(filter);
                    foreach (var item in newList)
                    {
                        for (int i = 0; i < names.Count; i++)
                        {
                            if (names[i] == item)
                            {
                                names.Insert(i + 1, item);
                                break;
                            }
                        }
                    }
                    break;
                case "Length":
                    newList = names.FindAll(filterLen);
                    foreach (var item in newList)
                    {
                        for (int i = 0; i < names.Count; i++)
                        {
                            if (names[i] == item)
                            {
                                names.Insert(i + 1, item);
                                break;
                            }
                        }
                    }
                    break;
            }
        }

        private static void Remove(List<string> names, string command, string givenString)
        {
            Predicate<string> filter = x => x.Contains(givenString);
            Predicate<string> filterLen = x => x.Length == int.Parse(givenString);
            switch (command)
            {
                case "StartsWith":
                    names.RemoveAll(filter);
                    break;
                case "EndsWith":
                    names.RemoveAll(filter);
                    break;
                case "Length":
                    names.RemoveAll(filterLen);
                    break;
            }
        }
    }
}
