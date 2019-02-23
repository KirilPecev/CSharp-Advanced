using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            List<int> range = new List<int>();
            for (int i = input[0]; i <= input[1]; i++)
            {
                range.Add(i);
            }

            Predicate<int> oddNums = x => x % 2 != 0;
            Predicate<int> evenNums = x => x % 2 == 0;
            List<int> result = new List<int>();

            switch (command)
            {
                case "odd":
                    result = range.FindAll(oddNums);
                    break;
                case "even":
                    result = range.FindAll(evenNums);
                    break;
            }

            Console.WriteLine(string.Join(" ", result));

        }
    }
}
