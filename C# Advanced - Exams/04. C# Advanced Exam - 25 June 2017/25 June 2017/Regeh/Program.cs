using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\[\w+<(?<firstNums>\d+)(REGEH)(?<secondNums>\d+)>\w+\]";
            string input = Console.ReadLine();
            MatchCollection matched = Regex.Matches(input, pattern);
            List<int> nums = new List<int>();

            foreach (Match m in matched)
            {
                nums.Add(int.Parse(m.Groups["firstNums"].Value));
                nums.Add(int.Parse(m.Groups["secondNums"].Value));
            }

            int numSum = 0;
            string result = string.Empty;
            for (int i = 0; i < nums.Count; i++)
            {
                numSum += nums[i];
                numSum %= input.Length;
                result += input[numSum];
            }

            Console.WriteLine(result);
        }
    }
}
