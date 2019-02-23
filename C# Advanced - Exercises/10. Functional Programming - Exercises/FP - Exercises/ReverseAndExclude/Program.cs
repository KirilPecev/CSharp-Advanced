using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int divisibleNum = int.Parse(Console.ReadLine());
            Predicate<int> numsDivisibleBy = x => x % divisibleNum != 0;
            nums = nums.FindAll(numsDivisibleBy);
            nums.Reverse();
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
