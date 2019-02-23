using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    return;
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", nums));
                    continue;
                }

                Func<int, int> changes = CreateCommand(command);
                nums = nums.Select(changes).ToList();
            }
        }

        private static Func<int, int> CreateCommand(string command)
        {
            switch (command)
            {
                case "add":
                    return x => x + 1;
                case "multiply":
                    return x => x * 2;
                case "subtract":
                    return x => x - 1;
                default:
                    return null;
            }
        }
    }
}
