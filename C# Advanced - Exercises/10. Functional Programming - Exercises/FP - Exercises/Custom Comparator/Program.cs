using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Func<int, bool> evenNums = x => x % 2 == 0;
            Func<int, bool> oddNums = x => x % 2 != 0;
            List<int> result = nums.Where(evenNums).OrderBy(x => x).ToList();
            result.AddRange(nums.Where(oddNums).OrderBy(x => x).ToList());
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
