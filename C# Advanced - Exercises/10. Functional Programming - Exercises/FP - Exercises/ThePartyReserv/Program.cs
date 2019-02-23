using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReserv
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invitees = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> currentList = new List<string>(invitees);
            List<string> filtered = invitees.ToList();
            while (true)
            {
                string[] commands = Console.ReadLine().Split(';').ToArray();
                if (commands[0] == "Print")
                {
                    break;
                }

                switch (commands[0])
                {
                    case "Add filter":
                        Add(invitees, commands[1], commands[2], currentList, filtered);
                        break;
                    case "Remove filter":
                        Remove(invitees, commands[1], commands[2], currentList, filtered);
                        break;
                }
            }

            invitees.RemoveAll(s => !currentList.Contains(s));
            Console.WriteLine(string.Join(" ", invitees));
        }



        private static void Remove(List<string> names, string command, string commandInfo, List<string> currentList, List<string> filtered)
        {
            Predicate<string> filterStartsWith = x => x.StartsWith(commandInfo);
            Predicate<string> filterEndsWith = x => x.EndsWith(commandInfo);
            Predicate<string> filterContains = x => x.Contains(commandInfo);
            Predicate<string> filterLength = x => x.Length == int.Parse(commandInfo);


            switch (command)
            {
                case "Starts with":
                    filtered = names.FindAll(filterStartsWith).ToList();
                    break;
                case "Ends with":
                    filtered = names.FindAll(filterEndsWith).ToList();
                    break;
                case "Contains":
                    filtered = names.FindAll(filterContains).ToList();
                    break;
                case "Length":
                    filtered = names.FindAll(filterLength).ToList();
                    break;

            }

            currentList.AddRange(filtered);
            currentList = currentList.Distinct().ToList();
        }

        private static void Add(List<string> names, string command, string commandInfo, List<string> currentList, List<string> filtered)
        {

            Predicate<string> filterStartsWith = x => x.StartsWith(commandInfo);
            Predicate<string> filterEndsWith = x => x.EndsWith(commandInfo);
            Predicate<string> filterContains = x => x.Contains(commandInfo);
            Predicate<string> filterLength = x => x.Length == int.Parse(commandInfo);

            switch (command)
            {
                case "Starts with":
                    filtered = names.FindAll(filterStartsWith).ToList();
                    break;
                case "Ends with":
                    filtered = names.FindAll(filterEndsWith).ToList();
                    break;
                case "Contains":
                    filtered = names.FindAll(filterContains).ToList();
                    break;
                case "Length":
                    filtered = names.FindAll(filterLength).ToList();
                    break;

            }

            currentList.RemoveAll(s => filtered.Contains(s));
        }
    }
}
