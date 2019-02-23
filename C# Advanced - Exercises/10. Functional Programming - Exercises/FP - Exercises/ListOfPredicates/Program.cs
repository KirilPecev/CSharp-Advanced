using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();
            for (int i = 1; i <= N; i++)
            {
                nums.Add(i);
            }

            int[] deviders = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            foreach (var devider in deviders)
            {
                Predicate<int> deviderPredicat = x => x % devider == 0;
                nums = nums.FindAll(deviderPredicat);
            }

            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
