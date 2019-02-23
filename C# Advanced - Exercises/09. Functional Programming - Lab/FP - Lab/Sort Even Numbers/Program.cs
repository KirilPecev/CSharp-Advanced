using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Func<int, bool> evenNums = x => x % 2 == 0;

            List<int> filteredInput = input.Where(evenNums).OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(", ",filteredInput));

        }
    }
}
