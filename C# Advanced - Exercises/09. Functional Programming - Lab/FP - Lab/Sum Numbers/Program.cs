using System;
using System.Collections.Generic;
using System.Linq;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = x => int.Parse(x);
            List<int> nums = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(parser).ToList();
            Console.WriteLine(nums.Count);
            Console.WriteLine(nums.Sum());
        }
    }
}
